using System;
using System.IO;
using ToyRobotSimulation.Controller;

namespace ToyRobotSimulation
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                if (args == null || args.Length == 0)
                {
                    Console.WriteLine("[ERROR]: No input data provided, add an input file");
                    return;
                }

                if (File.Exists(args[0]))
                {
                    string[] commands = File.ReadAllLines(args[0]);
                    Execution execution = new(commands);
                    Console.WriteLine(execution.Execute());
                }
                else
                {
                    Console.WriteLine("[ERROR]: File does not exist");
                    return;
                }
            }
            catch (Exception e)
            {
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(e.Message);
            }
        }
    }
}
