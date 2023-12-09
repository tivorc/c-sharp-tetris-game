namespace Tetris;

public class I : IShape
{
  private string?[][] Table { get; set; }
  private int X { get; set; } = 0;
  private int Y { get; set; } = -1;
  private readonly int width = 4;
  private bool Horizontal { get; set; }

  public I(string?[][] table)
  {
    Horizontal = new Random().Next(0, 2) == 0;
    int difference = Horizontal ? 2 : 0;
    X = table[0].Length / 2 - difference;
    Table = table;
  }

  public void MoveDown()
  {
    Y++;
  }

  public void MoveLeft()
  {
    X--;
  }

  public void MoveRight()
  {
    X++;
  }

  public void Rotate()
  {
  }

  public bool CanMove(Direction direction)
  {
    if (Direction.Down == direction)
    {
      var _y = Y + 1;
      if (_y >= Table.Length)
        return false;

      if (Horizontal)
      {
        if (Table[_y][X] != null || Table[_y][X + 1] != null || Table[_y][X + 2] != null || Table[_y][X + 3] != null)
          return false;
      }
      else
      {
        if (Table[_y][X] != null)
          return false;
      }
    }

    if (Direction.Left == direction)
    {
      if (X - 1 < 0)
        return false;

      if (Horizontal)
      {

        if (Table[Y][X - 1] != null)
          return false;
      }
      else
      {
        if (Y == -1)
          return false;
        if (Table[Y][X - 1] != null)
          return false;
        if (Y - 1 >= 0 && Table[Y - 1][X - 1] != null)
          return false;
        if (Y - 2 >= 0 && Table[Y - 2][X - 1] != null)
          return false;
        if (Y - 3 >= 0 && Table[Y - 3][X - 1] != null)
          return false;
      }
    }

    if (Direction.Right == direction)
    {
      if (Y < 0)
        return false;

      if (Horizontal)
      {

        if (X + 4 >= Table[0].Length)
          return false;

        if (Table[Y][X + 4] != null)
          return false;
      }
      else
      {
        if (X + 1 >= Table[0].Length)
          return false;

        if (Table[Y][X + 1] != null)
          return false;
        if (Y - 1 >= 0 && Table[Y - 1][X + 1] != null)
          return false;
        if (Y - 2 >= 0 && Table[Y - 2][X + 1] != null)
          return false;
        if (Y - 3 >= 0 && Table[Y - 3][X + 1] != null)
          return false;
      }
    }

    return true;
  }

  public bool IsIntersecting(int x, int y)
  {
    int x1 = X;
    int x2 = X + width - 1;
    int y1 = Y;
    int y2 = Y;

    if (!Horizontal)
    {
      x2 = X;
      y1 = Y - width + 1;
      y2 = Y;
    }

    return x >= x1 && x <= x2 && y >= y1 && y <= y2;
  }
}
