namespace TestQueriesGenerator.Library.Services
{
    public static class GeneratorService
    {
        public static string GetIdNumber(uint number)
        {
            string targetNumber;

            uint valueLevel_1 = 1_000_000;
            uint valueLevel_2 = 100_000;
            uint valueLevel_3 = 10_000;
            uint valueLevel_4 = 1_000;
            uint valueLevel_5 = 100;
            uint valueLevel_6 = 10;

            if (number < valueLevel_6)
            {
                targetNumber = AddZeroes(6);
            }
            else if (number < valueLevel_5)
            {
                targetNumber = AddZeroes(5);
            }
            else if (number < valueLevel_4)
            {
                targetNumber = AddZeroes(4);
            }
            else if (number < valueLevel_3)
            {
                targetNumber = AddZeroes(3);
            }
            else if (number < valueLevel_2)
            {
                targetNumber = AddZeroes(2);
            }
            else if (number < valueLevel_1)
            {
                targetNumber = AddZeroes(1);
            }
            else
            {
                targetNumber = string.Empty;
            }

            return targetNumber + number.ToString();
        }

        private static string AddZeroes(int countZeroes)
        {
            string zeroString = string.Empty;

            for (int i = 0; i < countZeroes; i++)
            {
                zeroString += AddZero();
            }

            return zeroString;
        }
        private static string AddZero() => "0";
    }
}
