using System;

class ShamirSecretSharing
{
    public static double LagrangeInterpolation(double[,] points, int x)
    {
        double result = 0;
        int rows = points.GetLength(0);

        for (int j = 0; j < rows; j++)
        {
            double term = points[j, 1];
            for (int i = 0; i < rows; i++)
            {
                if (i != j)
                {
                    term *= (x - points[i, 0]) / (points[j, 0] - points[i, 0]);
                }
            }
            result += term;
        }
        return result;
    }

    public static double ConvertToDecimal(string value, int baseValue)
    {
        return Convert.ToInt32(value, baseValue);
    }

    public static void Main()
    {
        Console.Write("Enter n (number of points): ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter k (degree of polynomial): ");
        int k = Convert.ToInt32(Console.ReadLine());

        double[,] points = new double[k, 2];

        for (int i = 0; i < k; i++)
        {
            Console.WriteLine("Enter point " + (i + 1) + " in format 'x': { 'base': 'b', 'value': 'v' }");

            Console.Write("x: ");
            points[i, 0] = Convert.ToInt32(Console.ReadLine());

            Console.Write("base: ");
            int baseValue = Convert.ToInt32(Console.ReadLine());

            Console.Write("value: ");
            string value = Console.ReadLine();

            points[i, 1] = ConvertToDecimal(value, baseValue);
        }

        double constantTerm = LagrangeInterpolation(points, 0);
        Console.WriteLine("Constant term c: " + constantTerm);
    }
}
