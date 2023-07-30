using System;

namespace VirtuosoAssessment
{
    public class Program
    {
        static void Main()
        {
            var input = new string[,] {
                {"t-shirt", "dress shirt"},
                {"dress shirt", "pants"},
                {"dress shirt", "suit jacket"},
                {"tie", "suit jacket"},
                {"pants", "suit jacket"},
                {"belt", "suit jacket"},
                {"suit jacket", "overcoat"},
                {"dress shirt", "tie"},
                {"suit jacket", "sun glasses"},
                {"sun glasses", "overcoat"},
                {"left sock", "pants"},
                {"pants", "belt"},
                {"suit jacket", "left shoe"},
                {"suit jacket", "right shoe"},
                {"left shoe", "overcoat"},
                {"right sock", "pants"},
                {"right shoe", "overcoat"},
                {"t-shirt", "suit jacket"}
            };

            DependencySolver depSolver = new DependencySolver(input);
            depSolver.Print();

            // var cycleInput = new string[,] {
            //     {"dress shirt", "t-shirt"},
            //     {"t-shirt", "dress shirt"},
            //     {"dress shirt", "pants"},
            //     {"dress shirt", "suit jacket"},
            //     {"tie", "suit jacket"},
            //     {"pants", "suit jacket"},
            //     {"belt", "suit jacket"},
            //     {"suit jacket", "overcoat"},
            //     {"dress shirt", "tie"},
            //     {"suit jacket", "sun glasses"},
            //     {"sun glasses", "overcoat"},
            //     {"left sock", "pants"},
            //     {"pants", "belt"},
            //     {"suit jacket", "left shoe"},
            //     {"suit jacket", "right shoe"},
            //     {"left shoe", "overcoat"},
            //     {"right sock", "pants"},
            //     {"right shoe", "overcoat"},
            //     {"t-shirt", "suit jacket"}
            // };
            // depSolver.Dependencies = cycleInput;
            // depSolver.Print();
        }
    }
}
