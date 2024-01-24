using System.ComponentModel.DataAnnotations;
using System.Data;
namespace BeeckerLearningGround.Classes;

internal class CalculatorLogic : ICalculatorLogic
{
    public double Compute(string expression)
    {
        expression = expression.Replace(" ", "");
        return ComputeAdditionSubtrahition(ref expression);
    }

    private double ComputeAdditionSubtrahition(ref string expression)
    {
        double leftValue = ComputeMultiplicationDivision(ref expression);
        while (expression.Length > 0)
        {
            char op = expression[0];
            if (op != '+' && op != '-')
                break;

            expression = expression.Substring(1); // Überspringe op

            double rightValue = ComputeMultiplicationDivision(ref expression);

            if (op == '+')
                leftValue += rightValue;
            else
                leftValue -= rightValue;
        }
        return leftValue;
    }
    private double ComputeMultiplicationDivision(ref string expression)
    {
        double leftValue = ComputeKlammern(ref expression);

        while (expression.Length > 0)
        {
            char op = expression[0];
            if (op != '*' && op != '/')
                break;

            expression = expression.Substring(1); // Überspringe op

            double rightValue = ComputeKlammern(ref expression);

            if (op == '*')
                leftValue *= rightValue;
            else
            {
                if (rightValue == 0)
                    throw new DivideByZeroException("Teilen durch Null ist nicht erlaubt.");
                leftValue /= rightValue;
            }
        }
        return leftValue;
    }
    private double ComputeKlammern(ref string expression)
    {
        if (expression.Length > 0 && expression[0] == '(')
        {
            expression = expression.Substring(1); // Überspringe "("
            double innerValue = ComputeAdditionSubtrahition(ref expression);
            if (expression.Length == 0 || expression[0] != ')')
                throw new ArgumentException("Es fehlt eine Klammer!");
            expression = expression.Substring(1); // Überspringe ")"
            return innerValue;
        }
        return DetermineDigitValue(ref expression);

    }
    private double DetermineDigitValue(ref string expression)
    {
        int i = 0;
        while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == ','))
        {
            i++;
        }

        if (i == 0)
            throw new ArgumentException("Ungültige Eingabe1");

        string number = expression.Substring(0, i);
        expression = expression.Substring(i);

        return double.Parse(number);
    }
    public double CheckResult(string input)
    {
        DataTable datatable = new();
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException();
        }
        return Convert.ToDouble(datatable.Compute(input, null));
    }
}
