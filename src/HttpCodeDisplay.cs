using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientTest
{
    partial class Program
    {
        static void CheckCode(int code)
        {
            Console.Write($"Got an HTTP {code} response to request ");
            if (code.ToString()[0] == '2')
                Console.Write("(Successful, ");
            else if (code.ToString()[0] == '3')
                Console.Write("(Redirection, ");
            else if (code.ToString()[0] == '4')
                Console.Write("(Client Error, ");
            else if (code.ToString()[0] == '5')
                Console.Write("(Server Error, ");
            else if (code.ToString()[0] == '1')
                Console.Write("(Information, ");
            switch (code)
            {
                case 100:
                    Console.Write("Continue");
                    break;
                case 101:
                    Console.Write("Switching Protocols");
                    break;
                case 103:
                    Console.Write("Checkpoint");
                    break;
                case 200:
                    Console.Write("OK");
                    break;
                case 201:
                    Console.Write("Created Content");
                    break;
                case 205:
                    Console.Write("Retry Download");
                    break;
                case 301:
                    Console.Write("Moved");
                    break;
                case 302:
                    Console.Write("Moved Temporarily");
                    break;
                case 303:
                    Console.Write("See Different Website");
                    break;
                case 400:
                    Console.Write("Bad Syntax");
                    break;
                case 404:
                    Console.Write("Page Not Found");
                    break;
                case 500:
                    Console.Write("Generic");
                    break;
                case 503:
                    Console.Write("Server Down");
                    break;
                default:
                    Console.Write("HTTP Status Code Not Recognised");
                    break;
            }
            Console.WriteLine(")\n");
        }
    }
}
