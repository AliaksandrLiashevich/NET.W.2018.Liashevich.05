using System;
using NUnit.Framework;

namespace PolynomialMath.Tests
{
    [TestFixture]

    public class PolynomialTests
    {
        [TestCase(new double[] { 1, 3 }, new double[] { 3 }, new double[] { 4, 3 })]
        [TestCase(new double[] { 0.562, 3.254 }, new double[] { -0.562, -9.51 }, new double[] { 0, -6.256 })]
        [TestCase(new double[] { 0.6536, -1.5421, 9 }, new double[] { -5.445, -9.42155 }, new double[] { -4.7914, -10.96365, 9 })]

        public void PlusOperator_SumCalculation_NewObjectWithSummedCoefficients(double[] args1, double[] args2, double[] expected)
        {
            Polynomial polynomialOne = new Polynomial(args1);

            Polynomial polynomialTwo = new Polynomial(args2);

            Polynomial polynomialSum = polynomialOne + polynomialTwo;             

            Assert.AreEqual(expected, polynomialSum.Coeff);
        }

        [TestCase(new double[] { 1, 3 }, new double[] { 3 }, new double[] { -2, 3 })]
        [TestCase(new double[] { 0.562, 3.254 }, new double[] { -0.562, -9.51 }, new double[] { 1.124, 12.764 })]
        [TestCase(new double[] { 0.6536, -1.5421, 9 }, new double[] { -5.445, -9.42155 }, new double[] { 6.0986, 7.87945, 9 })]

        public void MinusOperator_DifferenceCalculation_NewObjectWithDifferencedCoefficients(double[] args1, double[] args2, double[] expected)
        {
            Polynomial polynomialOne = new Polynomial(args1);

            Polynomial polynomialTwo = new Polynomial(args2);

            Polynomial polynomialDif = polynomialOne - polynomialTwo;

            Assert.AreEqual(expected, polynomialDif.Coeff);
        }

        [TestCase(new double[] { 1, 3 }, new double[] { -1, -3 })]
        [TestCase(new double[] { 0.562, 3.254 }, new double[] { -0.562, -3.254 })]
        [TestCase(new double[] { 0.6536, -1.5421, 9 }, new double[] { -0.6536, 1.5421, -9 })]

        public void MinusOperator_InvertsCoefficients_NewObjectWithInvertCoefficients(double[] args,double[] expected)
        {
            Polynomial polynomial = new Polynomial(args);

            Polynomial polynomialInvert = -polynomial;

            Assert.AreEqual(expected, polynomialInvert.Coeff);
        }

        [TestCase(new double[] { 1, 3 }, new double[] { 3 }, new double[] { 3, 9 })]
        [TestCase(new double[] { 5, 2 }, new double[] { -9, 15 }, new double[] { -45, 57, 30 })]

        public void MultOperator_MultiplyCoefficeints_NewObjectWithMyltipliedCoefficients(double[] args1, double[] args2, double[] expected)
        {
            Polynomial polynomialOne = new Polynomial(args1);

            Polynomial polynomialTwo = new Polynomial(args2);

            Polynomial polynomialMult = polynomialOne * polynomialTwo;

            Assert.AreEqual(expected, polynomialMult.Coeff);
        }

        [TestCase(new double[] { 1, 3 }, new double[] { -1, -3 }, false)]
        [TestCase(new double[] { 0.562, 3.254 }, new double[] { 0.562, 3.254 }, true)]
        [TestCase(new double[] { 0.6536, -1.5421, 9 }, new double[] { -0.6536, 1.5421, -9 }, false)]

        public void EqualityOperator_CompareObjects_BoolResult(double[] args1, double[] args2, bool expected)
        {
            Polynomial polynomialOne = new Polynomial(args1);

            Polynomial polynomialTwo = new Polynomial(args2);

            Assert.AreEqual(expected, polynomialOne == polynomialTwo);
        }

        [TestCase(new double[] { 1, 3 }, new double[] { -1, -3 }, true)]
        [TestCase(new double[] { 0.562, 3.254 }, new double[] { 0.562, 3.254 }, false)]
        [TestCase(new double[] { 0.6536, -1.5421, 9 }, new double[] { -0.6536, 1.5421, -9 }, true)]

        public void InequalityOperator_CompareObjects_BoolResult(double[] args1, double[] args2, bool expected)
        {
            Polynomial polynomialOne = new Polynomial(args1);

            Polynomial polynomialTwo = new Polynomial(args2);

            Assert.AreEqual(expected, polynomialOne != polynomialTwo);
        }

    }
}
