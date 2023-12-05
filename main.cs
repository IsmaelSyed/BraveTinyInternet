using System;

class Program
{
    static void Main()
    {
        char[] allowedInitials = { 'D', 'E', 'F' };
        string[] salespersonNames = { "D", "E", "F" };
        double[] totalSales = new double[3];
        char highestSalesperson = ' ';

        do
        {
            Console.Write("Enter salesperson initial (D, E, F) or Z to exit: ");
            char salesperson = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (salesperson == 'Z')
                break;

            if (Array.IndexOf(allowedInitials, salesperson) == -1)
            {
                Console.WriteLine("Error, invalid salesperson selected, please try again");
                continue;
            }

            Console.Write("Enter sale amount: $");
            if (double.TryParse(Console.ReadLine(), out double sale) && sale >= 0)
            {
                int index = Array.IndexOf(allowedInitials, salesperson);
                totalSales[index] += sale;
            }
            else
            {
                Console.WriteLine("Error, invalid sale amount entered, please try again.");
            }

        } while (true);

        double grandTotal = 0;
        for (int i = 0; i < totalSales.Length; i++)
        {
            grandTotal += totalSales[i];
        }

        Console.WriteLine($"Grand Total: ${grandTotal:N0}");

        double highestSale = 0;
        for (int i = 0; i < totalSales.Length; i++)
        {
            if (totalSales[i] > highestSale)
            {
                highestSale = totalSales[i];
                highestSalesperson = allowedInitials[i];
            }
        }

        Console.WriteLine($"Highest Sale: {highestSalesperson}");
    }
}
