using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialMath
{
    public class Polynomial
    {
        private double[] coefficients;
        public Polynomial(double[] initialParams)
        {
            if (initialParams != null && initialParams.Length != 0)
            {
                coefficients = new double[initialParams.Length];
                initialParams.CopyTo(coefficients, 0);
            }
            else
            {
                coefficients = new double[] { 0 };
            }            
        }
        public static Polynomial operator +(Polynomial firstObj, Polynomial secondObj)
        {
            int firstPolLength = firstObj.coefficients.Length;
            int secondPolLength = secondObj.coefficients.Length;
            int size = firstPolLength > secondPolLength ? firstPolLength : secondPolLength;
            double[] newCoeffArray = new double[size];
            for (int i = 0; i < size; i++)
            {
                if (firstPolLength != 0 && secondPolLength != 0)
                {
                    newCoeffArray[i] = firstObj.coefficients[i] + secondObj.coefficients[i];
                    firstPolLength--;
                    secondPolLength--;
                }
                else if (firstPolLength == 0)
                {
                    newCoeffArray[i] = secondObj.coefficients[i];
                }
                else
                {
                    newCoeffArray[i] = firstObj.coefficients[i];
                }
            }
            return new Polynomial(newCoeffArray);
        }
        public static Polynomial operator -(Polynomial firstObj, Polynomial secondObj)
        {
            int firstPolLength = firstObj.coefficients.Length;
            int secondPolLength = secondObj.coefficients.Length;
            int size = firstPolLength > secondPolLength ? firstPolLength : secondPolLength;
            double[] newCoeffArray = new double[size];
            for (int i = 0; i < size; i++)
            {
                if (firstPolLength != 0 && secondPolLength != 0)
                {
                    newCoeffArray[i] = firstObj.coefficients[i] - secondObj.coefficients[i];
                    firstPolLength--;
                    secondPolLength--;
                }
                else if (firstPolLength == 0)
                {
                    newCoeffArray[i] = -secondObj.coefficients[i];
                }
                else
                {
                    newCoeffArray[i] = firstObj.coefficients[i];
                }
            }
            return new Polynomial(newCoeffArray);
        }
        public static Polynomial operator *(Polynomial firstObj, Polynomial secondObj)
        {
            int firstPolLength = firstObj.coefficients.Length;
            int secondPolLength = secondObj.coefficients.Length;
            int size = firstPolLength + secondPolLength - 1;
            double[] newCoeffArray = new double[size];
            for (int i = 0; i < firstPolLength; i++)
                for (int j = 0; j < secondPolLength; j++)
                    newCoeffArray[i + j] += firstObj.coefficients[i] * secondObj.coefficients[j];
            return new Polynomial(newCoeffArray);
        }
        public static bool operator ==(Polynomial firstObj, Polynomial secondObj)
        {
            int firstPolLength = firstObj.coefficients.Length;
            int secondPolLength = secondObj.coefficients.Length;
            if (firstPolLength != secondPolLength)
                return false;
            for (int i = 0; i < firstPolLength; i++)
                if (firstObj.coefficients[i] != secondObj.coefficients[i])
                    return false;
            return true;
        }
        public static bool operator !=(Polynomial firstObj, Polynomial secondObj)
        {
            int firstPolLength = firstObj.coefficients.Length;
            int secondPolLength = secondObj.coefficients.Length;
            if (firstPolLength != secondPolLength)
                return true;
            for (int i = 0; i < firstPolLength; i++)
                if (firstObj.coefficients[i] != secondObj.coefficients[i])
                    return true;
            return false;
        }
        public override string ToString()
        {
            
            string polView = coefficients[0].ToString();
            for(int i = 1; i <coefficients.Length; i++)
                polView += " + " + coefficients[i] + "x^" + i;
            return polView;
        }
        public override bool Equals(Object obj)
        {
            return (this == obj);
        }
        public override int GetHashCode()
        {
            int hashcode = 0;
            for(int i = 0; i < coefficients.Length; i++)
                hashcode = 31 * hashcode + coefficients[i].GetHashCode();
            return hashcode;
        }
    }
}
