/* Edge.cs
 * Author: Calvin Beechner
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.PuzzleTrainer
{
    /// <summary>
    /// Edge structure. 
    /// </summary>
    public readonly struct Edge
    {
        /// <summary>
        /// Gets a Configuration giving the source node of the edge.
        /// </summary>
        public Configuration Source { get; }

        /// <summary>
        /// Gets a Configuration giving the destination node of the edge.
        /// </summary>
        public Configuration Destination { get; }

        /// <summary>
        /// Edge constructor. Used for creating a new Edge.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public Edge(Configuration source, Configuration destination)
        {
            Source = source;
            Destination = destination;
        }


    }
}
