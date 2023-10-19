
using System.Text;

internal class Program
{
    private static void Main()
    {
        using (StreamReader file = new StreamReader("../../1.txt"))
        {
            byte matchCounter;
            byte validPasswordsCounter = 0;
            byte errorLines = 0;

            char checkedSymbol;
            StringBuilder buffer = new StringBuilder();
            byte cursor;

            short firstNumber;
            short secondNumber;

            string ln;
            while ((ln = file.ReadLine()) != null)
            {
                checkedSymbol = ln[0];
                cursor = 0;

                TakeBeforeDelimiter(buffer, ref cursor, ln, '-');
                if (GetNumber(buffer, out firstNumber, ref errorLines))
                    continue;

                buffer.Clear();

                TakeBeforeDelimiter(buffer, ref cursor, ln, ':');
                if (GetNumber(buffer, out secondNumber, ref errorLines))
                    continue;

                buffer.Clear();

                matchCounter = 0;
                while (cursor != ln.Length)
                {
                    if (ln[cursor] == checkedSymbol)
                        matchCounter++;

                    cursor++;
                }

                if (firstNumber <= matchCounter && matchCounter <= secondNumber)
                    validPasswordsCounter++;
            }

            file.Close();
            Console.WriteLine($"File has {validPasswordsCounter} valid passwords.");
            if (errorLines > 0)
                Console.WriteLine($"With {errorLines} lines with defects");
        }

        static void TakeBeforeDelimiter(StringBuilder buffer, ref byte cursor, string ln, char delimiter)
        {
            cursor++;
            for (; ln[cursor] != delimiter; cursor++)
                buffer.Append(ln[cursor]);
        }

        static bool GetNumber(StringBuilder buffer, out short firstNumber, ref byte errorLines)
        {
            var conversionSuccess = Int16.TryParse(buffer.ToString(), out firstNumber);
            buffer.Clear();

            if (conversionSuccess)
                return false;

            errorLines++;
            return true;
        }
    }

}