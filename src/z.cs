namespace Tetris;
public class Z : IShape
{
  private string?[][] Table { get; set; }
  private int X { get; set; } = 0;
  private int Y { get; set; } = -1;
  private bool Horizontal { get; set; }

  public Z(string?[][] table)
  {
    Horizontal = new Random().Next(0, 2) == 0;
    int difference = Horizontal ? 2 : 1;
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
    var _y = Y + 1;
    if (_y >= Table.Length)
      return false;

    if (Horizontal)
    {
      // XX
      //  XX

      if (Table[_y][X + 1] != null || Table[_y][X + 2] != null)
        return false;

      if (_y - 1 >= 0 && Table[_y - 1][X] != null)
        return false;

      return true;
    }
    else
    {
      //  X
      // XX
      // X

      if (Table[_y][X] != null)
        return false;

      if (_y - 1 >= 0 && Table[_y - 1][X + 1] != null)
        return false;

      return true;
    }
  }

  public bool IsIntersecting(int x, int y)
  {
    int x1 = X;
    int x2 = X;
    int y1 = Y;
    int y2 = Y;

    if (Horizontal)
    {
      // XX
      //  XX

      x1 = X + 1;
      x2 = X + 2;

      if (x >= x1 && x <= x2 && y >= y1 && y <= y2)
        return true;

      x1 = X;
      x2 = X + 1;
      y1 = Y - 1;
      y2 = Y - 1;

      return x >= x1 && x <= x2 && y >= y1 && y <= y2;
    }
    else
    {
      //  X
      // XX
      // X

      y1 = Y - 1;
      y2 = Y;

      if (x >= x1 && x <= x2 && y >= y1 && y <= y2)
        return true;

      x1 = X + 1;
      x2 = X + 1;
      y1 = Y - 2;
      y2 = Y - 1;

      return x >= x1 && x <= x2 && y >= y1 && y <= y2;
    }
  }
}
