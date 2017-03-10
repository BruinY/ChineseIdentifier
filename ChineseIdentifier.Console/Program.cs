using System;

namespace ChineseIdentifier.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var resxChecker = new ResxChecker();
            var chineseType = (ChineseType)Enum.Parse(typeof(ChineseType), args[0]);
            var resxFile = args[1];

            var result = resxChecker.IsOfType(chineseType, resxFile);

            if (result.WasMatch)
            {
                System.Console.WriteLine("File check complete - OK");
            }
            else
            {
                System.Console.WriteLine($"File check complete - {result.Message}");
            }
        }
    }
}
