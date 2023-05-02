/* Puzzle.cs
 * Author: Calvin Beechner
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Ksu.Cis300.PuzzleTrainer
{
    /// <summary>
    /// Puzzle class.
    /// </summary>
    public static class Puzzle
    {
        /// <summary>
        /// Stores a representation of the puzzle graph.
        /// </summary>
        private static readonly int[][] _puzzleGraph = 
        {
            new int[] { 1, 2, 3, 4, 5, 6 }, //adjacent to 0.
            new int[] { 2, 0, 6 }, //adjacent to 1.
            new int[] { 3, 0, 1 }, //adjacent to 2.
            new int[] { 4, 0, 2 }, //adjacent to 3.
            new int[] { 5, 0, 3 }, //adjacent to 4.
            new int[] { 6, 0, 4 }, //adjacent to 5.
            new int[] { 1, 0, 5 }  //adjacent to 6.
        };

        /// <summary>
        /// A Configuration containing the solution configuration.
        /// </summary>
        private static readonly Configuration _solution = new Configuration(new int[] { 0, 1, 2, 3, 4, 5, 6 });

        /// <summary>
        /// Gets the outgoing Edges from a Configuration.
        /// </summary>
        /// <param name="configuration">The configuration who Edges are being looked up.</param>
        /// <returns>Returns an Edge[] containing all the outgoing edges from a configuration.</returns>
        private static Edge[] OutgoingEdges(Configuration configuration)
        {
            Edge[] result = new Edge[_puzzleGraph[configuration.EmptyNode].Length];
            for (int i = 0; i < _puzzleGraph[configuration.EmptyNode].Length; i++)
            {
                result[i] = new Edge(configuration, new Configuration(configuration, _puzzleGraph[configuration.EmptyNode][i]));
            }
            return result;
        }

        /// <summary>
        /// Gets the distances.
        /// </summary>
        /// <returns>Returns a Dictionary<Configuration, int> whose keys are the configurations reachable from the solution.</returns>
        public static Dictionary<Configuration, int> Distances()
        {
            Dictionary<Configuration, int> result = new Dictionary<Configuration, int>();
            result.Add(_solution, 0);
            Queue<Edge> q = new Queue<Edge>();
            foreach (Edge e in OutgoingEdges(_solution))
            {
                q.Enqueue(e);
            }
            while (q.Count > 0)
            {
                Edge e = q.Dequeue();
                Configuration x = e.Destination;
                if (!result.ContainsKey(x))
                {
                    result.Add(x, 1 + result[e.Source]);
                    foreach (Edge outgoing in OutgoingEdges(x))
                    {
                        q.Enqueue(outgoing);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the adjacent puzzle nodes.
        /// </summary>
        /// <param name="node">An int giving the puzzle node.</param>
        /// <returns>Returns an int[] containing all puzzle nodes adjacent to the given node.</returns>
        public static int[] AdjacentPuzzleNodes(int node)
        {
            if (node > 6 || node < 0)
            {
                throw new ArgumentException("The given value is not a node in the puzzle.");
            }
            int[] temp = (int[])_puzzleGraph[node].Clone();
            return temp;
        }

    }
}
