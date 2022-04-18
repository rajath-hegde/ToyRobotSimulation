using System;
using ToyRobotSimulation.Model;

namespace ToyRobotSimulation.Controller
{
    public class Execution
    {
        private readonly Operations _operations;
        private bool _isPositionSet;
        private string _result = string.Empty;
        private readonly string[] _commands;

        public Execution(string[] commands)
        {
            _operations = new Operations();
            _commands = commands;
        }

        public string Execute()
        {
            foreach (string command in _commands)
            {
                if (_isPositionSet)
                {
                    ExecuteCommand(command);
                }
                else if (command.Contains("PLACE"))
                {
                    ExtractPlace(command);
                }
            }
            return _result;
        }

        public void ExecuteCommand(string command)
        {
            if (Enum.TryParse(command, out Movements movement))
            {
                _operations.Manoeuvre(movement);
            }
            else if (command.Contains("REPORT"))
            {
                _result += _operations.Report();
            }
            else
            {
                _result += $"[Error]: \"{command}\" command input is invalid, ignoring and going to next step\n";
            }
        }

        private void ExtractPlace(string command)
        {
            string[] position = command.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (position.Length != 4 || (!(Int32.TryParse(position[1], out int xAxis) && Int32.TryParse(position[2], out int yAxis))))
            {
                throw new ArgumentException("[Error]: Input coordinates are invalid");
            }

            _operations.Place(xAxis, yAxis, position[3]);
            _isPositionSet = true;
        }
    }
}
