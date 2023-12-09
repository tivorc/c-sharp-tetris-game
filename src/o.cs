namespace Tetris;
public class O : IShape
{
  private string?[][] Table { get; set; }
  private int X { get; set; } = 0;
  private int Y { get; set; } = -1;
  private readonly int width = 2;

  public O(string?[][] table)
  {
    X = table[0].Length / 2 - 1;
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

    if (Table[_y][X] != null || Table[_y][X + 1] != null)
      return false;

    return true;
  }

  public bool IsIntersecting(int x, int y)
  {
    int x1 = X;
    int x2 = X + width - 1;
    int y1 = Y - width + 1;
    int y2 = Y;

    return x >= x1 && x <= x2 && y >= y1 && y <= y2;
  }
}
