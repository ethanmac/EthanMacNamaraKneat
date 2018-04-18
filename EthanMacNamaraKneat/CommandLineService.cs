using System;

namespace EthanMacNamaraKneat
{
    public class CommandLineService
    {
        public CommandLineService()
        {
        }

        public void WriteToConsole(string message)
        {
            Console.Write(message);
        }

        public void WriteLineToConsole(string message)
        {
            Console.WriteLine(message);
        }

        //returns input string
        public string ReadConsolesLine()
        {
            return Console.ReadLine();
        }

        public void ClearConsole()
        {
            Console.Clear();
        }

        public string ReadConsolesLineWithPrompt(string prompt)
        {
            WriteToConsole(prompt);
            return Console.ReadLine();
        }

        public bool IsInputValidInt(string input)
        {
            var j = 0;
            if (Int32.TryParse(input, out j))
            {
                return true;
            }
            return false;
        }
    }
}