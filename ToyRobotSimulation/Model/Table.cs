namespace ToyRobotSimulation.Model
{
    public class Table
    {
        private readonly int _width;
        private readonly int _length;

        public Table(int width, int length)
        {
            _width = width;
            _length = length;
        }
        public bool IsPositionValid(int x, int y) => x >= 0 && x < _width && y >= 0 && y < _length;
    }
}
