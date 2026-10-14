namespace TrainingCenter.ConsoleApp.UI
{
    public static class InputHelper
    {



        public static int ReadInt(string message)
        {
            int number;

            while (true)
            {
                Console.Write(message);

                bool isValid = int.TryParse(Console.ReadLine(), out number);

                if (isValid)
                {
                    return number;
                }

                Console.WriteLine("Invalid Number, Try Again.");
            }
        }




        public static string ReadString(string message)
        {
            string input;

            while (true)
            {
                Console.Write(message);

                input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }

                Console.WriteLine("Input Cannot Be Empty.");
            }
        }




        public static decimal ReadDecimal(string message)
        {
            decimal number;

            while (true)
            {
                Console.Write(message);

                bool isValid = decimal.TryParse(Console.ReadLine(), out number);

                if (isValid)
                {
                    return number;
                }

                Console.WriteLine("Invalid Decimal Number, Try Again.");
            }
        }
    }
}