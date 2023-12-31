# VirtuosoAssessment
The DependencySolver is a C# class that provides a solution for resolving dependencies and printing items grouped by their depth in a topological order.

Usage
To use the DependencySolver, follow these steps:

1. Create a new instance of the DependencySolver class, passing the dependencies as a 2D string array to the constructor.

string[,] dependencies = new string[,]
{
    {"A", "B"},
    {"A", "C"},
    {"B", "D"},
    {"C", "D"},
    {"E", "F"}
};

DependencySolver solver = new DependencySolver(dependencies);

2. Alternatively, you can set the dependencies using the 'Dependencies' property.
DependencySolver solver = new DependencySolver();
solver.Dependencies = dependencies;

3. After the dependencies are set, you can call the 'Print()' method to print the items grouped by their depth.
solver.Print();
