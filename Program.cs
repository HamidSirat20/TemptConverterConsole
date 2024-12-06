class Program
{
    static void Main()
    {
        int value = 0;
        string? unit = null;
        bool isValid = false;

        while (!isValid)
        {
            Console.Write("Please enter a value and unit as {value C/F}: ");
            var userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput) || !userInput.Contains(' '))
            {
                Console.WriteLine("Invalid format. Try again.");
                continue;
            }

            var valueAndUnit = userInput.Split(' ');

            if (valueAndUnit.Length == 2 &&
                int.TryParse(valueAndUnit[0], out value) &&
                (valueAndUnit[1].Equals("C", StringComparison.OrdinalIgnoreCase) ||
                 valueAndUnit[1].Equals("F", StringComparison.OrdinalIgnoreCase)))
            {
                unit = valueAndUnit[1].ToLower();
                isValid = true;
            }
            else
            {
                Console.WriteLine("Invalid format. Try again.");
            }

            TempConvert(unit, value);
        }



        static void TempConvert(string unit, int value)
        {
            switch (unit)
            {
                case "c":
                    double fahrenheit = (9.0 / 5.0) * value + 32;
                    Console.WriteLine($"Your value in Fahrenheit is {fahrenheit:F2} F.");
                    break;

                case "f":
                    double celsius = (value - 32.0) * (5.0 / 9.0);
                    Console.WriteLine($"Your value in Celsius is {celsius:F3} C.");
                    break;

                default:
                    Console.WriteLine("No such unit defined.");
                    break;
            }
        }
    }
}
