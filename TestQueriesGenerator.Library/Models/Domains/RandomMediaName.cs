namespace TestQueriesGenerator.Library.Models.Domains
{
    public class RandomMediaName
    {
        public byte Length { get; }
        public byte Lowers { get; }
        public byte Uppers { get; }

        public RandomMediaName(byte lowers, byte uppers)
        {
            Length = (byte)(lowers + uppers);
            Lowers = lowers;
            Uppers = uppers;
        }

        public string Generate()
        {
            string targetRandomIdName = string.Empty;

            char[] lowersArray = GenerateLetters(Lowers, false);
            char[] uppersArray = GenerateLetters(Uppers, true);

            List<char> lowersList = FillListOfLetters(lowersArray);
            List<char> uppersList = FillListOfLetters(uppersArray);

            for (byte i = 0; i < Length; i++)
            {
                char letter;

                if (IsUpperCase())
                {
                    letter = RetrieveLetterFromList(ref uppersList);
                }
                else
                {
                    letter = RetrieveLetterFromList(ref lowersList);
                }

                targetRandomIdName += Convert.ToString(letter);
            }

            return targetRandomIdName;
        }

        private bool IsUpperCase()
        {
            // This is logic to choose letter's case by random way.

            int random = (new Random()).Next(0, 2);

            if (random == 1)
            {
                return true;
            }

            return false;
        }

        private char RetrieveLetterFromList(ref List<char> lettersList)
        {
            char letter;
            byte random;

            try
            {
                random = Convert.ToByte((new Random()).Next(0, lettersList.Count));

                // Retrieve a random letter from the list.
                letter = lettersList[(int)random];

                // Remove this retrieved letter from the list.
                lettersList.RemoveAt((int)random);
            }
            catch (ArgumentOutOfRangeException)
            {
                // TODO: When development, I've been detected the exception but I've not had time to research it.
                //Console.WriteLine($"EXCEPTION: random = {random}");

                // The following code was added to process the exception throwing.
                random = Convert.ToByte(new Random().Next(0, 2));
                letter = (random == 1) ? '#' : '$';
            }

            return letter;
        }

        private List<char> FillListOfLetters(char[] lettersArray)
        {
            var lettersList = new List<char>(lettersArray.Length);

            foreach (var letter in lettersArray)
            {
                lettersList.Add(letter);
            }

            return lettersList;
        }

        private char[] GenerateLetters(int count, bool isUpper)
        {
            var letters = new char[count];

            if (isUpper)
            {
                PopulateUppersArray(ref letters);
            }
            else
            {
                PopulateLowersArray(ref letters);
            }

            return letters;
        }

        private void PopulateLowersArray(ref char[] letters)
        {
            for (byte i = 0; i < letters.Length; i++)
            {
                letters[i] = GetRandomLowerLetter();
            }
        }

        private void PopulateUppersArray(ref char[] letters)
        {
            for (byte i = 0; i < letters.Length; i++)
            {
                letters[i] = GetRandomUpperLetter();
            }
        }

        private char GetRandomLowerLetter()
        {
            // I use ASCII notation for generating random character:
            // 97 integer literal is 'a' letter from ASCII
            // 122 integer literal is 'z' (ASCII)

            int random = (new Random()).Next(97, (122 + 1));
            return Convert.ToChar(random);
        }

        private char GetRandomUpperLetter()
        {
            // I use ASCII notation for generating random character:
            // 65 integer literal is 'A' letter from ASCII
            // 90 integer literal is 'Z' (ASCII)

            int random = (new Random()).Next(65, (90 + 1));
            return Convert.ToChar(random);
        }
    }
}
