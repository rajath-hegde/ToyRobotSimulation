using System;
using ToyRobotSimulation.Model;

namespace ToyRobotSimulation.Controller
{
    public class Operations
    {
        private readonly Table _table = new(5, 5);
        private int _xAxis = 0;
        private int _yAxis = 0;
        private Directions _direction;

        public Operations()
        {
        }

        public void Place(int x, int y, string direction)
        {
            if (_table.IsPositionValid(x, y))
            {
                _xAxis = x;
                _yAxis = y;
                if (!Enum.TryParse(direction, out _direction))
                    throw new ArgumentException("[Error]: Direction input is invalid");
            }
            else
            {
                throw new ArgumentException("[Error]: Position input is invalid");
            }
        }

        public void Manoeuvre(Movements movement)
        {
            switch (movement)
            {
                case Movements.MOVE:
                    Move();
                    break;
                case Movements.RIGHT:
                    Right();
                    break;
                case Movements.LEFT:
                    Left();
                    break;
            }
        }

        public string Report() => $"{_xAxis},{_yAxis},{_direction}";

        public void Move()
        {
            switch (_direction)
            {
                case Directions.EAST:
                    {
                        if (_table.IsPositionValid(_xAxis + 1, _yAxis))
                        {
                            ++_xAxis;
                        }
                        break;
                    }
                case Directions.WEST:
                    {
                        if (_table.IsPositionValid(_xAxis - 1, _yAxis))
                        {
                            --_xAxis;
                        }
                        break;
                    }
                case Directions.NORTH:
                    {
                        if (_table.IsPositionValid(_xAxis, _yAxis + 1))
                        {
                            ++_yAxis;
                        }
                        break;
                    }
                case Directions.SOUTH:
                    {
                        if (_table.IsPositionValid(_xAxis, _yAxis - 1))
                        {
                            --_yAxis;
                        }
                        break;
                    }
            }
        }

        public void Left()
        {
            if (_direction == Directions.NORTH)
                _direction = Directions.WEST;
            else
                --_direction;
        }

        public void Right()
        {
            if (_direction == Directions.WEST)
                _direction = Directions.NORTH;
            else
                ++_direction;
        }
    }
}
