using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZW_Demonstration
{
    /// <summary>
    /// This is a program I wrote to demonstrate the LZW compression algorithm.
    /// This code and idea is based of wikipedia page.
    /// </summary>
    class Program
    {
        //private static List<LookupEntry> alphabet;
        private static Dictionary<string, int> alphabet;

        static void Main(string[] args)
        {
             alphabet = GenerateBaseAlphabet();


            string inputString = null;
            while (inputString == null)
                inputString = GetInputString();

            Compress(inputString);

            Console.ReadKey();
        }

        static void PrintAlphabet(List<LookupEntry> lookupEntries)
        {
            foreach (LookupEntry item in lookupEntries)
            {
                Console.WriteLine(item.GenerateObjString());
            }
        }

        static string GetInputString()
        {
            Console.WriteLine("Please enter a string consiting of charcters A - Z: ");
            string inputToSanitise = Console.ReadLine().ToUpper();

            bool isSanitised = true;
            
            foreach (char c in inputToSanitise)
            {
                if (char.IsDigit(c))
                {
                    isSanitised = false;
                    break;
                }     
            }
            //Use recursive method to get valid input
            if (!isSanitised)
            {
                Console.WriteLine("Input string cannot contain digits. Please try again...\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            else
                return inputToSanitise;

            return null;
        }

        static void Compress(string input)
        {
            Console.WriteLine("Size before compression: " + (input.Length * 6));

            int bitTotal;

            char current;
            char next;
            int code;
            

            int pointer = 0;
            while (input[pointer] != '#')
            {
                current = input[pointer];
                next = input[pointer + 1];

                string newSymbol = current.ToString() + next.ToString();


            }
            
        }




        #region HELPER METHODS
        static Dictionary<string, int> GenerateBaseAlphabet()
        {
            Dictionary<string, int> dictToRtn = new Dictionary<string, int>;

            int count = 0;

            for (int i = 65; i < 91; i++)
            {
                string sym = Convert.ToChar(i).ToString();

                dictToRtn.Add(sym, GetBinaryAsString(count));

                count++;
            }

            dictToRtn.Add("#", GetBinaryAsString(count));

            return dictToRtn;
        }

        static int GetBinaryAsString(int n)
        {
            char[] binary = new char[6]; // Define our binary string to return. 6 bit binary number

            int pos = 5; //Array pointer is from 0 - 5. Thus, the last item is at index 5.
            int i = 0;

            while (i < 6)
            {
                if ((n & (1 << i)) != 0) // i is 1, shift bits left
                    binary[pos] = '1';
                else
                    binary[pos] = '0';
                pos--;
                i++;
            }
            return int.Parse(binary.ToString());
        }
        #endregion
    }
    class LookupEntry
    {
        public string symbol;
        public string code;

        public LookupEntry(string sym, string code)
        {
            symbol = sym;
            this.code = code;
        }

        public string GenerateObjString()
        {
            return symbol + " --- " + code;
        }
    }

}
