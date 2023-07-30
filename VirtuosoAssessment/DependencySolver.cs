using System;

namespace VirtuosoAssessment{
    public class DependencySolver {
        private string[,] dependencies;
        private Dictionary<string, List<string>> dependencyDictionary;
        private HashSet<string> currentlyVisiting;
        private Dictionary<string, int> itemDepthDictionary;    
        public DependencySolver(string[,] dependencies) {
            if (dependencies == null) {
                throw new ArgumentNullException(nameof(dependencies), "Dependencies input cannot be null.");
            }
            this.dependencies = dependencies;
            this.dependencyDictionary = new Dictionary<string, List<string>>();
            this.currentlyVisiting = new HashSet<string>();
            this.itemDepthDictionary = new Dictionary<string, int>();
            this.Solve();
        }
        public string[,] Dependencies {
            get {
                return dependencies;
            }
            set {
                if (value == null) {
                    throw new ArgumentNullException(nameof(value), "Dependencies input cannot be null.");
                }
                this.dependencies = value;
                this.dependencyDictionary = new Dictionary<string, List<string>>();
                this.currentlyVisiting = new HashSet<string>();
                this.itemDepthDictionary = new Dictionary<string, int>();
                this.Solve();
            }
        }
        public void Print() {
            // Group items by their depth
            var itemsByDepth = itemDepthDictionary.GroupBy(kv => kv.Value)
                                                .ToDictionary(g => g.Key, g => g.Select(kv => kv.Key).OrderBy(item => item).ToList());

            foreach (var itemByDepth in itemsByDepth)
            {
                string itemsAtDepth = string.Join(", ", itemByDepth.Value);
                Console.WriteLine($"{itemsAtDepth}");
            }
        }
        private void Solve() {
            dependencyDictionary = createDependencyDictionary();
            foreach (var item in dependencyDictionary.Keys) {
                if (!itemDepthDictionary.ContainsKey(item)) {
                    TopologicalSort(item);
                }
            }
        }
        private Dictionary<string, List<string>> createDependencyDictionary() {
            Dictionary<string, List<string>> dependencyDictionary = new Dictionary<string, List<string>>();

            int rowCount = dependencies.GetLength(0);
            for (int i = 0; i < rowCount; i++) {
                string dependency = dependencies[i, 0];
                string item = dependencies[i, 1];

                if (!dependencyDictionary.ContainsKey(item)) {
                    dependencyDictionary[item] = new List<string>();
                }

                dependencyDictionary[item].Add(dependency);

                // Ensure dependencies make it into the list too, that way items with no dependencies are in the dictionary
                if (!dependencyDictionary.ContainsKey(dependency)) {
                    dependencyDictionary[dependency] = new List<string>();
                }
            }

            return dependencyDictionary;
        }    
        private void TopologicalSort(string item) {
            if (currentlyVisiting.Contains(item)) {
                throw new InvalidOperationException("Cycle detected in the dependencies.");
            }
            currentlyVisiting.Add(item);

            if (!dependencyDictionary.ContainsKey(item)) {
                // Item has no dependencies
                itemDepthDictionary[item] = 0;
                return;
            }

            foreach (var dependency in dependencyDictionary[item]) {
                TopologicalSort(dependency);
            }

            int depth = dependencyDictionary[item].Select(dependency => itemDepthDictionary[dependency]).DefaultIfEmpty(-1).Max() + 1;
            itemDepthDictionary[item] = depth;

            currentlyVisiting.Remove(item);
        }
    }
}