namespace Tetris;
public class L : IShape
{
  private string?[][] Table { get; set; }
  private int X { get; set; } = 0;
  private int Y { get; set; } = -1;
  private int Horientation { get; set; }

  public L(string?[][] table)
  {
    Horientation = new Random().Next(0, 4);
    int difference = Horientation == 0 || Horientation == 2 ? 1 : 2;
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

    if (Horientation == 0)
    {
      // X
      // X
      // XX
      if (Table[_y][X] != null || Table[_y][X + 1] != null)
        return false;

      return true;
    }

    if (Horientation == 1)
    {
      // XXX
      // X
      if (Table[_y][X] != null)
        return false;

      if (_y - 1 >= 0 && (Table[_y - 1][X + 1] != null || Table[_y - 1][X + 2] != null))
        return false;

      return true;
    }

    if (Horientation == 2)
    {
      // XX
      //  X
      //  X
      if (Table[_y][X + 1] != null)
        return false;

      if (_y - 1 >= 0 && Table[_y - 1][X + 1] != null)
        return false;

      if (_y - 2 >= 0 && Table[_y - 2][X] != null)
        return false;

      return true;
    }

    if (Horientation == 3)
    {
      //   X
      // XXX
      if (Table[_y][X] != null || Table[_y][X + 1] != null || Table[_y][X + 2] != null)
        return false;

      return true;
    }

    return true;
  }

  public bool IsIntersecting(int x, int y)
  {
    int _x = X;
    int _y = Y;

    if (Horientation == 0)
    {
      // X
      // X
      // XX

      if (_y == y && _x + 1 == x)
        return true;

      int x1 = X;
      int x2 = X;
      int y1 = Y - 2;
      int y2 = Y;

      return x >= x1 && x <= x2 && y >= y1 && y <= y2;
    }

    if (Horientation == 1)
    {
      // XXX
      // X

      if (_y == y && _x == x)
        return true;

      int x1 = X;
      int x2 = X + 2;
      int y1 = Y - 1;
      int y2 = Y - 1;

      return x >= x1 && x <= x2 && y >= y1 && y <= y2;
    }

    if (Horientation == 2)
    {
      // XX
      //  X
      //  X

      if (_y - 2 == y && _x == x)
        return true;

      int x1 = X + 1;
      int x2 = X + 1;
      int y1 = Y - 2;
      int y2 = Y;

      return x >= x1 && x <= x2 && y >= y1 && y <= y2;
    }

    if (Horientation == 3)
    {
      //   X
      // XXX

      if (_y - 1 == y && _x + 2 == x)
        return true;

      int x1 = X;
      int x2 = X + 2;
      int y1 = Y;
      int y2 = Y;

      return x >= x1 && x <= x2 && y >= y1 && y <= y2;
    }

    return false;
  }
}
