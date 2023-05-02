/* Configuration.cs
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
    /// Configuration class. Used to hold configurations having an arbitrary number of puzzle nodes.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// A const int giving the multiplier to use in polynomial hashing.
        /// </summary>
        private const int _multiplier = 37;

        /// <summary>
        /// A readonly int to contain the hash code.
        /// </summary>
        private readonly int _hashCode;

        /// <summary>
        /// A readonly int[] to contain the contents of each puzzle node.
        /// </summary>
        private readonly int[] _contents;

        /// <summary>
        /// Gets an int giving the index of the empty puzzle node within this configuration.
        /// </summary>
        public int EmptyNode { get; }

        /// <summary>
        /// Gets an int giving the number of puzzle nodes in the configuration.
        /// </summary>
        public int Length
        {
            get => _contents.Length;
        }

        /// <summary>
        /// Computes the hash code.
        /// </summary>
        /// <returns>Returns an int giving the hash code.</returns>
        private int ComputeHashCode()
        {
            int hashCode = Length; // should it be zero or Length?
            foreach (int i in _contents)
            {
                hashCode *= _multiplier;
                hashCode += i;
            }
            return hashCode;
        }

        /// <summary>
        /// Finds the empty puzzle node.
        /// </summary>
        /// <returns>Returns an int giving the index of the puzzle node.</returns>
        private int FindEmptyNode()
        {
            int result = -1;
            for (int i = 0; i < _contents.Length; i++)
            {
                if (_contents[i] == 0)
                {
                    if (result != -1) //if more than one is found the result wont be -1.
                    {
                        throw new ArgumentException("The given configuration has more than one empty puzzle node.");
                    }
                    result = i;
                }
            }
            if (result == -1) //if none are found the result will be -1.
            {
                throw new ArgumentException("The given configuration has no empty puzzle node.");
            }
            return result;
        }

        /// <summary>
        /// Configuration constructor.
        /// </summary>
        /// <param name="contents">The contents of all the puzzle nodes.</param>
        public Configuration(int[] contents)
        {
            int[] temp = (int[])contents.Clone();
            _contents = temp;
            EmptyNode = FindEmptyNode();
            _hashCode = ComputeHashCode();
        }

        /// <summary>
        /// Configuration constructor. Used to copy a Configurations contents to a new Configuration while swapping the empty node for the specified node.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="num"></param>
        /// <exception cref="ArgumentException"></exception>
        public Configuration(Configuration configuration, int num)
        {
            int[] temp = (int[])configuration._contents.Clone(); //copies configurations _contents.

            if (num == configuration.EmptyNode)
            {
                throw new ArgumentException("The given puzzle node is empty.");
            }

            int tempInt = temp[configuration.EmptyNode];
            temp[configuration.EmptyNode] = temp[num]; //swaps the empty node for the specified num.
            temp[num] = tempInt;

            //Configuration conf = new Configuration(temp); //constructs new Configuraion.
            
            _contents = temp;
            EmptyNode = FindEmptyNode(); //Constructs Configuration using the values assigned to conf.
            _hashCode = ComputeHashCode();

        }

        /// <summary>
        /// Implements == operator for comparing Configurations.
        /// </summary>
        /// <param name="x">The first Configuration.</param>
        /// <param name="y">The second Configuration.</param>
        /// <returns>Returns a bool representing whether the two Configurations were the same.</returns>
        public static bool operator ==(Configuration x, Configuration y)
        {
            if (Equals(x, null))
            {
                return Equals(y, null);
            }
            else if (Equals(y, null))
            {
                return false;
            }
            if (x.Length == y.Length)
            {
                for (int i = 0; i < x.Length; i++)
                {
                    if (x._contents[i] != y._contents[i])
                    {
                        return false; //the configurations differ in values.
                    }
                }
                return true; //if the program can make it through the loop without returning false then the two Configurations do not differ.
            }
            else
            {
                return false; //the Configurations differ in length.
            }
        }

        /// <summary>
        /// Implements != operator for comparing Configurations.
        /// </summary>
        /// <param name="x">The first Configuration.</param>
        /// <param name="y">The second Configuration.</param>
        /// <returns>Returns a bool representing whether the two Configurations were the same.</returns>
        public static bool operator !=(Configuration x, Configuration y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Overrides the Equals method.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Returns a bool representing whether the Configuration being compared is equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Configuration)
            {
                return this == (Configuration)obj;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Overrides the GetHashCode method.
        /// </summary>
        /// <returns>Returns the value in the field storing the hash code.</returns>
        public override int GetHashCode()
        {
            return _hashCode;
        }
    }
}
