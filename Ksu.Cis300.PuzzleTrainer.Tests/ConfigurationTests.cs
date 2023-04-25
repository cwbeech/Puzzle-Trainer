/* ConfigurationTests.cs
 * Author: Rod Howell
 */
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.PuzzleTrainer.Tests
{
    /// <summary>
    /// Unit tests for the Configuration class.
    /// </summary>
    [TestFixture]
    public class ConfigurationTests
    {
        /// <summary>
        /// Tests that constructing a Configuration with two empty puzzle nodes
        /// throws the correct exception with the correct message.
        /// </summary>
        [Test, Timeout(1000), Category("A: Constructor Exceptions")]
        public void Test2EmptyNodes()
        {
            Assert.Throws(Is.TypeOf<ArgumentException>().And.Message.EqualTo("The given configuration has more than one empty puzzle node."),
                () => new Configuration(new int[] { 1, 0, 2, 0 }));
        }

        /// <summary>
        /// Tests that constructing a Configuration with no empty puzzle nodes
        /// throws the correct exception with the correct message.
        /// </summary>
        [Test, Timeout(1000), Category("A: Constructor Exceptions")]
        public void Test0EmptyNodes()
        {
            Assert.Throws(Is.TypeOf<ArgumentException>().And.Message.EqualTo("The given configuration has no empty puzzle node."),
                () => new Configuration(new int[] { 1, 3, 2 }));
        }

        /// <summary>
        /// Tests that constructing a Configuration from another Configuration and
        /// the index of its empty puzzle node throws the correct exception with the
        /// correct message.
        /// </summary>
        [Test, Timeout(1000), Category("A: Constructor Exceptions")]
        public void TestSwapEmpty()
        {
            Configuration c = new Configuration(new int[] { 1, 0, 3, 2, 4 });
            Assert.Throws(Is.TypeOf<ArgumentException>().And.Message.EqualTo("The given puzzle node is empty."),
                () => new Configuration(c, 1));
        }

        /// <summary>
        /// Tests that comparing null with a non-null Configuration yields
        /// false for == and true for !=.
        /// </summary>
        [Test, Timeout(1000), Category("B: Simple Equality Tests")]
        public void TestEqualsOperatorNullWithNonNull()
        {
            Configuration c = new Configuration(new int[] { 0, 2, 1 });
            Assert.Multiple(() =>
            {
                Assert.That(null == c, Is.False);
                Assert.That(null != c, Is.True);
            });
        }

        /// <summary>
        /// Tests that comparing a non-null Configuration with null yields
        /// false for == and true for !=.
        /// </summary>
        [Test, Timeout(1000), Category("B: Simple Equality Tests")]
        public void TestEqualsOperatorNonNullWithNull()
        {
            Configuration c = new Configuration(new int[] { 0, 2, 1 });
            Assert.Multiple(() =>
            {
                Assert.That(c == null, Is.False);
                Assert.That(c != null, Is.True);
            });
        }

        /// <summary>
        /// Tests that comparing two null Configurations yields true for == and
        /// false for !=.
        /// </summary>
        [Test, Timeout(1000), Category("B: Simple Equality Tests")]
        public void TestEqualsOperatorNullWithNull()
        {
            Assert.Multiple(() =>
            {
                Assert.That((Configuration)null == (Configuration)null, Is.True);
                Assert.That((Configuration)null != (Configuration)null, Is.False);
            });
        }

        /// <summary>
        /// Tests that comparing a Configuration with an int yields false.
        /// </summary>
        [Test, Timeout(1000), Category("B: Simple Equality Tests")]
        public void TestEqualsMethodWrongType()
        {
            Assert.That(new Configuration(new int[] { 2, 1, 0 }).Equals(8), Is.False);
        }

        /// <summary>
        /// Tests that ==, !=, and Equals work correctly for equal configurations.
        /// </summary>
        [Test, Timeout(1000), Category("C: Advanced Equality Tests")]
        public void TestEqualConfigurations()
        {
            Configuration c1 = new Configuration(new int[] { 2, 0, 1 });
            Configuration c2 = new Configuration(new int[] { 2, 0, 1 });
            Assert.Multiple(() =>
            {
                Assert.That(c1 == c2, Is.True);
                Assert.That(c1 != c2, Is.False);
                Assert.That(c1, Is.EqualTo(c2));
            });
        }

        /// <summary>
        /// Tests that Configurations of different lengths are not equal.
        /// </summary>
        [Test, Timeout(1000), Category("C: Advanced Equality Tests")]
        public void TestDifferentLengths()
        {
            Configuration c1 = new Configuration(new int[] { 0, 1 });
            Configuration c2 = new Configuration(new int[] { 0, 1, 2 });
            Assert.That(c1 == c2, Is.False);
            Assert.That(c1 != c2, Is.True);
            Assert.That(c1, Is.Not.EqualTo(c2));
        }

        [Test, Timeout(1000), Category("C: Advanced Equality Tests")]
        public void TestDifferentValues()
        {
            Configuration c1 = new Configuration(new int[] { 1, 0, 2, 3, 4 });
            Configuration c2 = new Configuration(new int[] { 1, 0, 3, 2, 4 });
            Assert.That(c1 == c2, Is.False);
            Assert.That(c1 != c2, Is.True);
            Assert.That(c1, Is.Not.EqualTo(c2));
        }

        /// <summary>
        /// Tests the Length property for a Configuration of length 4.
        /// </summary>
        [Test, Timeout(1000), Category("D: Property Tests")]
        public void TestLength4()
        {
            Configuration c = new Configuration(new int[] { 3, 2, 1, 0 });
            Assert.That(c.Length, Is.EqualTo(4));
        }

        /// <summary>
        /// Tests the Length property for a Configuration of length 5.
        /// </summary>
        [Test, Timeout(1000), Category("D: Property Tests")]
        public void TestLength5()
        {
            Configuration c = new Configuration(new int[] { 3, 2, 1, 0, 4 });
            Assert.That(c.Length, Is.EqualTo(5));
        }

        /// <summary>
        /// Tests the EmptyNode property when the empty node is at index 2.
        /// </summary>
        [Test, Timeout(1000), Category("D: Property Tests")]
        public void TestEmptyNode2()
        {
            Configuration c = new Configuration(new int[] {3, 2, 0, 1 });
            Assert.That(c.EmptyNode, Is.EqualTo(2));
        }

        /// <summary>
        /// Tests the EmptyNode property when the empty node is at index 3.
        /// </summary>
        [Test, Timeout(1000), Category("D: Property Tests")]
        public void TestEmptyNode3()
        {
            Configuration c = new Configuration(new int[] { 2, 3, 1, 0 });
            Assert.That(c.EmptyNode, Is.EqualTo(3));
        }

        /// <summary>
        /// Tests that the 1-parameter constructor copies the array.
        /// </summary>
        [Test, Timeout(1000), Category("E: Constructor Tests")]
        public void Test1ParameterCopies()
        {
            int[] vals = new int[] { 0, 1, 2, 3 };
            Configuration c1 = new Configuration(vals);
            vals[1] = 2;
            vals[2] = 1;
            Configuration c2 = new Configuration(vals);
            Assert.That(c1, Is.Not.EqualTo(c2));
        }

        /// <summary>
        /// Tests that the 2-parameter constructor copies the array.
        /// </summary>
        [Test, Timeout(1000), Category("E: Constructor Tests")]
        public void Test2ParameterCopies()
        {
            Configuration c1 = new Configuration(new int[] { 0, 1, 2 });
            Configuration c2 = new Configuration(c1, 1);
            Assert.That(c1, Is.Not.EqualTo(c2));
        }

        /// <summary>
        /// Tests that the 2-parameter constructor correctly swaps elements.
        /// </summary>
        [Test, Timeout(1000), Category("E: Constructor Tests")]
        public void TestSwapConstructor()
        {
            Configuration c1 = new Configuration(new int[] { 1, 0, 2, 3 });
            Configuration c2 = new Configuration(c1, 2);
            Configuration c3 = new Configuration(new int[] { 1, 2, 0, 3 });
            Assert.That(c2, Is.EqualTo(c3));
        }

        /// <summary>
        /// Tests that the GetHashCode method returns a correct value for a Configuration
        /// consisting only of 0. Depending on the order the parts of the Configuration
        /// are used, two different results can be correct.
        /// </summary>
        [Test, Timeout(1000), Category("F: GetHashCode Tests")]
        public void TestHashLength1()
        {
            Assert.That(new Configuration(new int[] { 0 }).GetHashCode(), 
                Is.EqualTo(37).Or.EqualTo(1));
        }

        /// <summary>
        /// Tests that the GetHashCode method returns a correct value for a Configuration
        /// consisting only of 0. Depending on the order the parts of the Configuration
        /// are used, two different results can be correct.
        /// </summary>
        [Test, Timeout(1000), Category("F: GetHashCode Tests")]
        public void TestHashLength3()
        {
            Assert.That(new Configuration(new int[] { 3, 0, 3 }).GetHashCode(),
                Is.EqualTo(3 * (37 * (37 * 37 + 1) + 1)).Or.EqualTo(3 * (37 * 37 * 38 + 1)));
        }

        /// <summary>
        /// Tests that the hash code is saved. If it is recomputed each time, this test
        /// will time out.
        /// </summary>
        [Test, Timeout(1000), Category("F: GetHashCode Tests")]
        public void TestSaveHashCode()
        {
            int[] a = new int[1000000];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = i;
            }
            Configuration c = new Configuration(a);
            for (int i = 0; i < c.Length; i++)
            {
                c.GetHashCode();
            }
            Assert.Pass();
        }
    }
}
