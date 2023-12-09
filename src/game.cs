namespace Tetris;

public class Game
{
  public string?[][] Table { get; set; }
  private IShape _shape;

  public Game(int width, int height)
  {
    Console.CursorVisible = false;
    Table = new string?[height][];
    CreateTable(width, height);
    _shape = GetRandomShape();
  }

  public void Run()
  {
    PrintTable();
    while (TopIsEmpty())
    {
      var key = Console.ReadKey(true);
      Console.Clear();
      if (key.Key == ConsoleKey.LeftArrow)
        MoveLeft();
      else if (key.Key == ConsoleKey.RightArrow)
        MoveRight();
      else if (key.Key == ConsoleKey.DownArrow)
        MoveDown();
      else if (key.Key == ConsoleKey.UpArrow)
        Rotate();

      PrintTable();
    }
  }

  private void CreateTable(int width, int height)
  {
    for (int i = 0; i < height; i++)
    {
      for (int j = 0; j < width; j++)
      {
        if (Table[i] == null)
          Table[i] = new string?[width];
      }
    }
  }

  private void PrintTable()
  {
    for (int i = 0; i < Table.Length; i++)
    {
      for (int j = 0; j < Table[i].Length; j++)
      {
        if (_shape.IsIntersecting(j, i))
        {
          Console.BackgroundColor = GetShapeColor();
          Console.Write("  ");
        }
        else
        {
          string? value = Table[i][j];
          if (value == null)
            Console.BackgroundColor = ConsoleColor.Gray;
          else
            Console.BackgroundColor = GetColorByName(value);
          Console.Write("  ");
        }
      }
      Console.ResetColor();
      Console.WriteLine();
    }
  }

  private void AddCurrentShapeToTable()
  {
    for (int i = 0; i < Table.Length; i++)
    {
      for (int j = 0; j < Table[i].Length; j++)
      {
        if (_shape.IsIntersecting(j, i))
        {
          Table[i][j] = _shape.GetType().Name;
        }
      }
    }
  }

  private void MoveDown()
  {
    bool canMove = _shape.CanMove(Direction.Down);
    if (canMove)
    {
      _shape.MoveDown();
      return;
    }

    AddCurrentShapeToTable();
    RemoveCompleteLines();
    _shape = GetRandomShape();
  }

  private void MoveLeft()
  {
    bool canMove = _shape.CanMove(Direction.Left);
    if (canMove)
    {
      _shape.MoveLeft();
      return;
    }
  }

  private void MoveRight()
  {
    bool canMove = _shape.CanMove(Direction.Right);
    if (canMove)
    {
      _shape.MoveRight();
      return;
    }
  }

  private void Rotate()
  {
    _shape.Rotate();
  }

  private bool TopIsEmpty()
  {
    bool isEmpty = true;
    for (int i = 0; i < Table[0].Length; i++)
    {
      if (Table[0][i] != null)
        isEmpty = false;
    }
    return isEmpty;
  }

  private IShape GetRandomShape()
  {
    var randomNumber = new Random().Next(0, 7);
    if (randomNumber == 0)
      return new I(Table);
    else if (randomNumber == 1)
      return new O(Table);
    else if (randomNumber == 2)
      return new L(Table);
    else if (randomNumber == 3)
      return new J(Table);
    else if (randomNumber == 4)
      return new T(Table);
    else if (randomNumber == 5)
      return new S(Table);
    else
      return new Z(Table);
  }

  private ConsoleColor GetShapeColor()
  {
    var name = _shape.GetType().Name;
    return GetColorByName(name);
  }

  private ConsoleColor GetColorByName(string name)
  {
    if (name == "I")
      return ConsoleColor.DarkBlue;
    else if (name == "O")
      return ConsoleColor.Red;
    else if (name == "L")
      return ConsoleColor.Green;
    else if (name == "J")
      return ConsoleColor.Cyan;
    else if (name == "T")
      return ConsoleColor.Magenta;
    else if (name == "S")
      return ConsoleColor.DarkYellow;
    else
      return ConsoleColor.DarkRed;
  }

  private void RemoveCompleteLines()
  {
    var lines = new List<int>();
    for (int i = Table.Length - 1; i >= 0; i--)
    {
      bool isComplete = true;
      for (int j = 0; j < Table[i].Length; j++)
      {
        if (Table[i][j] == null)
          isComplete = false;
      }

      if (isComplete)
      {
        lines.Add(i);
      }
    }

    int removedLines = 0;
    lines.ForEach(line =>
    {
      for (int i = line + removedLines; i >= 0; i--)
      {
        for (int j = 0; j < Table[i].Length; j++)
        {
          if (i == 0)
            Table[i][j] = null;
          else
            Table[i][j] = Table[i - 1][j];
        }
      }
      removedLines++;
    });
  }
}
