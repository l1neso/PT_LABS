namespace OOP_RATIONAL
{
    public class Rational
    {
        private int numerator;
        public int Numerator
        {
            get {return this.numerator;}
            set {this.numerator = value; Simplify();}
        }

        private int denominator;
        public int Denominator
        {
            get {return this.denominator;}

            set
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("Denominator should not be 0");

                }
                this.denominator = value;
                Simplify();
            }
        }



        public Rational (int numerator, int denominator)
        {
            this.numerator = numerator;

            if (denominator == 0)
            {
                throw new DivideByZeroException("Ne deli na 0");
            } 

            this.denominator = denominator;
            Simplify();

        }

        public Rational (int numerator)
        {
            this.numerator = numerator;
            this.denominator = 1;
            Simplify();

        }

        public override string ToString() {
            return $"Rational: {Numerator} / {Denominator}";
            
        }

        public static Rational operator+(Rational r1, Rational r2)
        {
            int newDenominator = r1.Denominator * r2.Denominator;
            int newNumerator = r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator;

            return new Rational(newNumerator, newDenominator);
        }

        public static Rational operator-(Rational r1, Rational r2)
        {
            int newDenominator = r1.Denominator * r2.Denominator;
            int newNumerator = r1.Numerator * r2.Denominator - r2.Numerator * r1.Denominator;

            return new Rational(newNumerator, newDenominator);
        }

        public static Rational operator*(Rational r1, Rational r2)
        {
            int newDenominator = r1.Denominator * r2.Denominator;
            int newNumerator = r1.Numerator * r2.Numerator;

            return new Rational(newNumerator, newDenominator);
        }

        public static Rational operator/(Rational r1, Rational r2)
        {
            int newDenominator = r1.Denominator * r2.Numerator;
            int newNumerator = r1.Numerator * r2.Denominator;

            return new Rational(newNumerator, newDenominator);
        }

        public static bool operator ==(Rational r1, Rational r2)
        {
            return r1.Numerator * r2.Denominator == r2.Numerator * r1.Denominator;
        }

        public static bool operator !=(Rational r1, Rational r2)
        {
            return !(r1 == r2);
        }

        public static bool operator >(Rational r1, Rational r2)
        {
            return r1.Numerator * r2.Denominator > r2.Numerator * r1.Denominator;
        }

        public static bool operator <(Rational r1, Rational r2)
        {
            return r2 > r1;
        }

        public static bool operator >=(Rational r1, Rational r2)
        {
            return (r1 > r2) || (r1 == r2);
        }

        public static bool operator <=(Rational r1, Rational r2)
        {
            return (r1 < r2) || (r1 == r2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Rational other)
            {
                return this == other;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }


        public static int GCD(int a, int b)
        {
            while(b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        private void Simplify()
        {
            if (denominator < 0)
            {
                numerator *= -1;
                denominator *= -1;
            }

            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            numerator /= gcd;
            denominator /= gcd;
        }
    }
}