using System;
using Task1;
using NUnit.Framework;
using System.Collections.Generic;
namespace Task1Test
{
    [TestFixture]
    public class PolynomialTest
    {
        [Test]
        public void PolynomialEqualTest()
        {
            var a = new Polynomial(1, 2, 3, 4);
            var b = new Polynomial(1, 2, 3, 4);
            Polynomial c = null;

            Assert.AreEqual(a.Equals(b), true);
            Assert.AreEqual(a == b, true);
            Assert.AreEqual(a != b, false);
            Assert.AreEqual(a == null, false);
        }
        //tyuio
        public IEnumerable<TestCaseData> AddData
        {
            get
            {
                yield return new TestCaseData(new Polynomial(1, 4, 3, 8), new Polynomial(1, 2, 7)).Returns(new Polynomial(2, 6, 10, 8));
                yield return new TestCaseData(new Polynomial(1, -2, 3), new Polynomial(1, 2, 7, -8)).Returns(new Polynomial(2, 0, 10, -8));
            }
        }

        [Test, TestCaseSource("AddData")]
        public Polynomial AddTest(Polynomial a, Polynomial b)
        {
            return Polynomial.Addition(a, b);
        }




        public IEnumerable<TestCaseData> SubData
        {
            get
            {
                yield return new TestCaseData(new Polynomial(15, 50, 25, 35), new Polynomial(5, 40, 15)).Returns(new Polynomial(10, 10, 10, 35));
                yield return new TestCaseData(new Polynomial(5, 10, 5), new Polynomial(15, 5, 15, -8)).Returns(new Polynomial(-10, 5, -10, 8));
            }
        }

        [Test, TestCaseSource("SubData")]
        public Polynomial SubTest(Polynomial a, Polynomial b)
        {
            return Polynomial.Subtraction(a, b);
        }


        public IEnumerable<TestCaseData> MulData
        {
            get
            {
                yield return new TestCaseData(new Polynomial(3, 4, 1), new Polynomial(5, 2)).Returns(new Polynomial(15, 26, 13, 35, 2));
            }
        }

        [Test, TestCaseSource("MulData")]
        public Polynomial MulTest(Polynomial a, Polynomial b)
        {
            return Polynomial.Multiplication(a, b);
        }



    }
}
