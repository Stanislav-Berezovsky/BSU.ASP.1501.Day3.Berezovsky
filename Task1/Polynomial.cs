using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Polynomial
    {
        public int Exponent { get; private set; }
        private readonly double[] _coefficientArray;
        public double this[int i]
        {
            get
            {
                return _coefficientArray[i];
            }
        }

        public Polynomial(params double[] coefficientArray)
        {
            if (coefficientArray == null)
                throw new ArgumentNullException();
            this._coefficientArray = new double[coefficientArray.Length];
            Exponent = coefficientArray.Length;
        }


        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            if (a == null)
                throw new ArgumentNullException("Empty argument");
            if (b == null)
                throw new ArgumentNullException("Empty argument");
            int max = 0;
            int min = 0;
            bool choice = true;
            if (a.Exponent >= b.Exponent)
            {
                max = a.Exponent;
                min = b.Exponent;
            }
            else
            {
                max = b.Exponent;
                min = a.Exponent;
                choice = false;
            }
            double[] coeficientArray = new double[max];
            if (choice)
                a._coefficientArray.CopyTo(coeficientArray, 0);
            else
                b._coefficientArray.CopyTo(coeficientArray, 0);
            for (int i = 0; i < min; i++)
            {
                if (choice)
                    coeficientArray[i] = coeficientArray[i] + b._coefficientArray[i];
                else
                    coeficientArray[i] = coeficientArray[i] + a._coefficientArray[i];
            }
            return new Polynomial(coeficientArray);
        }



        public static Polynomial Addition(Polynomial a, Polynomial b)
        {
            return a + b;
        }


        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            if (a == null)
                throw new ArgumentNullException("Empty argument");
            if (b == null)
                throw new ArgumentNullException("Empty argument");
            if (a.Exponent > b.Exponent)
            {
                double[] coeficientArray = new double[a._coefficientArray.Length];
                a._coefficientArray.CopyTo(coeficientArray, 0);
                for (int i = 0; i < b.Exponent; i++)
                {
                    coeficientArray[i] = coeficientArray[i] + b._coefficientArray[i];
                }
                return new Polynomial(coeficientArray);
            }
            else
            {
                double[] coeficientArray = new double[b._coefficientArray.Length];
                for (int i = 0; i < coeficientArray.Length; i++)
                {
                    coeficientArray[i] = b._coefficientArray[i] * (-1);
                }
                for (int i = 0; i < a.Exponent; i++)
                {
                    coeficientArray[i] = coeficientArray[i] - a._coefficientArray[i];
                }
                return new Polynomial(coeficientArray);
            }
        }

        public static Polynomial Subtraction(Polynomial a, Polynomial b)
        {
            return a - b;
        }

        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            if (a == null)
                throw new ArgumentNullException("Empty argument");
            if (b == null)
                throw new ArgumentNullException("Empty argument");
            double[] coeficientArray = new double[a.Exponent + b.Exponent];
            for (int i = 0; i < a.Exponent; i++)
            {
                for (int j = 0; j < b.Exponent; j++)
                {
                    coeficientArray[i + j] = coeficientArray[i + j] + a._coefficientArray[i] * b._coefficientArray[j];
                }
            }
            return new Polynomial(coeficientArray);
        }


        public static Polynomial Multiplication(Polynomial a, Polynomial b)
        {
            return a * b;
        }


        public static bool operator !=(Polynomial a, Polynomial b)
        {
            return !(a.Equals(b));
        }

        public static bool operator ==(Polynomial a, Polynomial b)
        {
            if ((object)a == (object)b)
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a.Equals(b);
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Polynomial))
                return false;
            return Equals((Polynomial)obj);
        }

        public bool Equals(Polynomial a)
        {
            if ((object)a == null)
            {
                return false;
            }
            if (this.Exponent != a.Exponent)
                return false;
            return this._coefficientArray.SequenceEqual(a._coefficientArray);
        }

        public override int GetHashCode()
        {
            return (int)_coefficientArray.Max();
        }

    }
}
