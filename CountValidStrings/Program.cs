using System;
using System.IO;
using System.Text;

namespace CountValidStrings
{
    class Program
    {
        static void Main()
        {
            using (StreamReader file = new StreamReader("../../1.txt"))
            {
                byte matchCounter;
                byte validPasswordsCounter = 0;

                char checkedSymbol;
                StringBuilder buffer = new StringBuilder();
                byte cursor;

                short firstNumber;
                short secondNumber;

                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    cursor = 2;
                    checkedSymbol = ln[0];
                    while (ln[cursor] != '-')
                    {
                        buffer.Append(ln[cursor]);
                        cursor++;
                    }
                    firstNumber = Convert.ToInt16(buffer.ToString());
                    buffer.Clear();

                    cursor++;
                    while (ln[cursor] != ':')
                    {
                        buffer.Append(ln[cursor]);
                        cursor++;
                    }
                    secondNumber = Convert.ToInt16(buffer.ToString());

                    cursor = 2;
                    buffer.Clear();

                    matchCounter = 0;
                    while (cursor != ln.Length)
                    {
                        if (ln[cursor] == checkedSymbol)
                            matchCounter++;

                        cursor++;
                    }

                    if (firstNumber >= matchCounter && matchCounter <= secondNumber)
                        validPasswordsCounter++;
                }

                file.Close();
                Console.WriteLine($"File has {validPasswordsCounter} valid passwords.");
            }
        }
    }
}
