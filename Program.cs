using static System.Console;
class FractionDemo
{

    // Created by Jake Magri

    // Main method to create objects and calculate fractions.

    static void Main()
    {
        Fraction f1 = new Fraction(1, 4);
        Fraction f2 = new Fraction(1, 8);
        Fraction f3 = new Fraction(2, 1, 2);
        Fraction f4 = new Fraction();
        Fraction answer = new Fraction();
        answer = f1 + f2;
        WriteLine("{0} + {1} = {2}",
           f1.FracString(), f2.FracString(), answer.FracString());
        answer = f1 + f3;
        WriteLine("{0} + {1} = {2}",
           f1.FracString(), f3.FracString(), answer.FracString());
        answer = f2 + f3;
        WriteLine("{0} + {1} = {2}",
           f2.FracString(), f3.FracString(), answer.FracString());
    }
}
class Fraction
{
    // declare variables

    private int wholeNum;
    private int numerator;
    private int denominator;

    // Add Properties and Constructors

    // Properties

    public int WholeNum
    {
        get { return wholeNum; }
        set { wholeNum = value; }
    }

    public int Numerator
    {
        get { return numerator; }
        set { numerator = value; }
    }

    public int Denominator
    {
        get { return denominator; }
        set { denominator = value != 0 ? value : 1; }
    }

    // Constructors

    public Fraction()
        : this(0, 0, 1)
    {
    }

    public Fraction(int numerator, int denominator)
        : this(0, numerator, denominator)
    {
    }

    public Fraction(int wholeNum, int numerator, int denominator)
    {
        WholeNum = wholeNum;
        Numerator = numerator;
        Denominator = denominator;
    }



    // Overloaded operator to calculate fractions with Fraction operator

    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        int num1 = (f1.WholeNum * f1.Denominator + f1.Numerator) * f2.Denominator;
        int num2 = (f2.WholeNum * f2.Denominator + f2.Numerator) * f1.Denominator;
        int num = num1 + num2;
        int denom = f1.Denominator * f2.Denominator;
        Fraction newFrac = new Fraction(num, denom);
        newFrac.Reduce();
        return newFrac;
    }

    // Provided Methods

    public void Reduce()
    {
        int gcd;
        int y;
        if (numerator >= denominator)
        {
            wholeNum += numerator / denominator;
            numerator = numerator % denominator;
        }
        gcd = 1;
        for (y = numerator; y > 0; --y)
        {
            if (numerator % y == 0 && denominator % y == 0)
            {
                gcd = y;
                y = 0;
            }
        }
        numerator /= gcd;
        denominator /= gcd;
    }



    // Implement this

    // Function that returns a string that contains a Fraction in mixed number format.

    public string FracString()
    {
        if (Numerator == 0 && WholeNum == 0)
        {
            return WholeNum.ToString();
        }
        else if (WholeNum == 0)
        {
            return Numerator.ToString() + "/" + Denominator.ToString();
        }
        else
        {
            return WholeNum.ToString() + " " + Numerator.ToString() + "/" + Denominator.ToString();
        }
    }
}