using System;
using System.Data;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese expresion:");
            string regexp = Console.ReadLine();
            Parser parser = new Parser();
            parser.Parse(regexp);
            Console.WriteLine("Expresion okay");
            DataTable dt = new DataTable();
            var answer = dt.Compute(regexp, "");
            Console.WriteLine(answer);

            /*Scanner scanner = new Scanner(regexp);
            Token nextToken;

            DataTable dt = new DataTable();
            var answer = (double)dt.Compute("-00002+8*-4/(5--3)","");
            Console.WriteLine(answer);
            do
            {
                nextToken = scanner.GetToken();
                Console.WriteLine("Token: {0}, Valor {1}", nextToken.Tag, nextToken.Value);
            } while (nextToken.Tag != TokenType.EOF);
            */

            Console.ReadLine();
        }
    }
}
