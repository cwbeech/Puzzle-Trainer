/* PuzzleTests.cs
 * Author: Rod Howell
 */

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.PuzzleTrainer.Tests
{
    /// <summary>
    /// Unit tests for the Puzzle class.
    /// </summary>
    [TestFixture]
    public class PuzzleTests
    {
        /// <summary>
        /// Tests that the values returned by AdjacentPuzzleNodes are correct.
        /// </summary>
        [Test, Timeout(1000), Category("A: AdjacentPuzzleNodes Tests")]
        public void TestCorrectResults()
        {
            Assert.Multiple(() =>
            {
                Assert.That(Puzzle.AdjacentPuzzleNodes(0), Is.EquivalentTo(new int[] { 1, 2, 3, 4, 5, 6 }));
                Assert.That(Puzzle.AdjacentPuzzleNodes(1), Is.EquivalentTo(new int[] { 0, 2, 6 }));
                Assert.That(Puzzle.AdjacentPuzzleNodes(2), Is.EquivalentTo(new int[] { 0, 1, 3 }));
                Assert.That(Puzzle.AdjacentPuzzleNodes(3), Is.EquivalentTo(new int[] { 0, 2, 4 }));
                Assert.That(Puzzle.AdjacentPuzzleNodes(4), Is.EquivalentTo(new int[] { 0, 3, 5 }));
                Assert.That(Puzzle.AdjacentPuzzleNodes(5), Is.EquivalentTo(new int[] { 0, 4, 6 }));
                Assert.That(Puzzle.AdjacentPuzzleNodes(6), Is.EquivalentTo(new int[] { 0, 1, 5 }));
            });
        }

        /// <summary>
        /// Tests that AdjacentPuzzleNodes parameters that are out of range throw
        /// the correct exception and message.
        /// </summary>
        [Test, Timeout(1000), Category("A: AdjacentPuzzleNodes Tests")]
        public void TestRangeCheck()
        {
            Assert.Multiple(() =>
            {
                Assert.Throws(Is.TypeOf<ArgumentException>().And.Message.EqualTo("The given value is not a node in the puzzle."),
                    () => Puzzle.AdjacentPuzzleNodes(-1), "-1 didn't throw the correct exception.");
                Assert.Throws(Is.TypeOf<ArgumentException>().And.Message.EqualTo("The given value is not a node in the puzzle."),
                    () => Puzzle.AdjacentPuzzleNodes(7), "7 didn't throw the correct exception.");
            });
        }

        /// <summary>
        /// Tests that AdjacentPuzzleNodes returns a copy of the array.
        /// </summary>
        [Test, Timeout(1000), Category("A: AdjacentPuzzleNodes Tests")]
        public void TestCopies()
        {
            Assert.That(ReferenceEquals(Puzzle.AdjacentPuzzleNodes(0), Puzzle.AdjacentPuzzleNodes(0)), Is.False);
        }

        /// <summary>
        /// Tests that distances are computed correctly.
        /// </summary>
        [Test, Timeout(1000), Category("B: Distances Test")]
        public void TestDistances()
        {
            Dictionary<Configuration, int> d = Puzzle.Distances();
            Assert.Multiple(() =>
            {
                Assert.That(d[new Configuration(new int[] { 0, 1, 2, 3, 4, 5, 6 })], Is.EqualTo(0));
                Assert.That(d[new Configuration(new int[] { 1, 0, 2, 3, 4, 5, 6 })], Is.EqualTo(1));
                Assert.That(d[new Configuration(new int[] { 1, 6, 2, 3, 4, 5, 0 })], Is.EqualTo(2));
                Assert.That(d[new Configuration(new int[] { 0, 6, 4, 5, 2, 3, 1 })], Is.EqualTo(11));
            });
        }
    }
}
