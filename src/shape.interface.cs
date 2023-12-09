namespace Tetris;

interface IShape
{
  void MoveDown();
  void MoveLeft();
  void MoveRight();
  void Rotate();
  bool CanMove(Direction direction);
  bool IsIntersecting(int x, int y);
}
