using System;

namespace PolynomialMath
{
    public class Polynomial
    {
        private double[] coeff;

        /// <summary>
        /// Constructor with parameters, initializes polynomial object coefficients
        /// </summary>
        /// <param name="initialParams">Array of polynomial coefficients</param>
        /// <exception cref="ArgumentNullException">Throws when array of input coefficients is null or empty</exception>
        public Polynomial(double[] initialParams)
        {
            if (initialParams != null && initialParams.Length != 0)
            {
                coeff = new double[initialParams.Length];
                initialParams.CopyTo(coeff, 0);
            }
            else
            {
                throw new ArgumentNullException("Array of coefficients is null or empty");
            }            
        }

        /// <summary>
        /// Finds the sum of the input polynomial objects 
        /// </summary>
        /// <param name="arg1">First polynomial object</param>
        /// <param name="arg2">Second polynomial object</param>
        /// <returns>New polynomial object with summarized coefficients</returns>
        public static Polynomial operator +(Polynomial arg1, Polynomial arg2)
        {
            int size = arg1.coeff.Length > arg2.coeff.Length ? arg1.coeff.Length : arg2.coeff.Length;

            double[] newCoeffArray = new double[size];

            arg1.coeff.CopyTo(newCoeffArray, 0);

            for (int i = 0; i < arg2.coeff.Length; i++)
            {
                newCoeffArray[i] += arg2.coeff[i];
            }

            return new Polynomial(newCoeffArray);
        }

        /// <summary>
        /// Finds the difference of the input polynomial objects 
        /// </summary>
        /// <param name="arg1">First polynomial object</param>
        /// <param name="arg2">Second polynomial object</param>
        /// <returns>New polynomial object with differenced coefficients</returns>
        public static Polynomial operator -(Polynomial arg1, Polynomial arg2)
        {
            return -arg2 + arg1;
        }

        /// <summary>
        /// Change sign of polynomial object coefficients 
        /// </summary>
        /// <param name="arg">Polynomial object</param>
        /// <returns>New polynomial object with invert coefficients</returns>
        public static Polynomial operator -(Polynomial arg)
        {
            double[] newCoeffArray = new double[arg.coeff.Length];

            for (int i = 0; i < newCoeffArray.Length; i++)
            {
                newCoeffArray[i] = -arg.coeff[i];
            }

            return new Polynomial(newCoeffArray);
        }

        /// <summary>
        /// Multiply two polynomial objects 
        /// </summary>
        /// <param name="arg1">First polynomial object</param>
        /// <param name="arg2">Second polynomial object</param>
        /// <returns>New polynomial object with multiplied coefficients</returns>
        public static Polynomial operator *(Polynomial arg1, Polynomial arg2)
        {
            int firstPolLength = arg1.coeff.Length;
     
            int secondPolLength = arg2.coeff.Length;

            int size = firstPolLength + secondPolLength - 1;

            double[] newCoeffArray = new double[size];

            for (int i = 0; i < firstPolLength; i++)
            {
                for (int j = 0; j < secondPolLength; j++)
                {
                    newCoeffArray[i + j] += arg1.coeff[i] * arg2.coeff[j];
                }
            }

            return new Polynomial(newCoeffArray);
        }

        /// <summary>
        /// Check the equality of two polynomial objects
        /// </summary>
        /// <param name="arg1">First polynomial object</param>
        /// <param name="arg2">Second polynomial object</para
        /// <returns>True(equality) or false(inequality)</returns>
        public static bool operator ==(Polynomial arg1, Polynomial arg2)
        {
            int firstPolLength = arg1.coeff.Length;

            int secondPolLength = arg2.coeff.Length;

            if (firstPolLength != secondPolLength)
            {
                return false;
            }

            for (int i = 0; i < firstPolLength; i++)
            {
                if (arg1.coeff[i] != arg2.coeff[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Check the inequality of two polynomial objects
        /// </summary>
        /// <param name="arg1">First polynomial object</param>
        /// <param name="arg2">Second polynomial object</para
        /// <returns>True(inequality) or false(equality)</returns>
        public static bool operator !=(Polynomial arg1, Polynomial arg2)
        {
            return !(arg1 == arg2);
        }

        /// <summary>
        /// Gives string representation of object
        /// </summary>
        /// <returns>String representation of object</returns>
        public override string ToString()
        {        
            string polView = coeff[0].ToString();

            for (int i = 1; i < coeff.Length; i++)
            {
                polView += " + " + coeff[i] + "x^" + i;
            }

            return polView;
        }

        /// <summary>
        /// Check the equality of two objects
        /// </summary>
        /// <param name="obj">Object for comparison on equality</param>
        /// <returns>True(equality) or false(inequality)</returns>
        public override bool Equals(object obj)
        {
            if (obj is Polynomial)
            {
                return this == (Polynomial)obj;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Calculates psevdounique number
        /// </summary>
        /// <returns>psevdounique number</returns>
        public override int GetHashCode()
        {
            int hashcode = coeff[0].GetHashCode();

            for (int i = 1; i < coeff.Length; i++)
            {
                hashcode ^= coeff[i].GetHashCode();
            }

            return hashcode;
        }
    }
}
