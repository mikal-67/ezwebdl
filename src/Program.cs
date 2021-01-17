using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientTest
{
    partial class Program
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static readonly HttpClient client = new HttpClient();
        static HttpResponseMessage response;
        static async Task Main(string[] args)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions
            try
            {
                if(args[0] == "/h:code")
                {
                    Console.WriteLine("Most Common HTTP Codes:");
                    Console.WriteLine("404 - Page Not Found");
                    Console.WriteLine("This means that the page does not exist at the URL.");
                    Console.WriteLine("200 - OK");
                    Console.WriteLine("This means that everything is OK and downloading was a success.");
                    Console.WriteLine("500 - Generic Server Error");
                    Console.WriteLine("This means that something it wrong at the server's end, and the server gave no further info.");
                    Console.WriteLine("HTTP Status Code Not Recognized");
                    Console.WriteLine("This means that a code came that this program could not recognize.");
                    return;
                }
                else if(args[0] == "/h")
                {
                    Console.WriteLine("Usage: ezwebdl URL");
                    Console.WriteLine("  where URL is the URL of the website you want to connect to.");
                    Console.WriteLine("or: ezwebdl /h");
                    Console.WriteLine("  Shows this.");
                    Console.WriteLine("or: ezwebdl /h:code");
                    Console.WriteLine("  Shows a list of common HTTP codes.");
                    return;
                }
                response = await client.GetAsync(args[0]);
                CheckCode((int)response.StatusCode);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                string[] s = args[0].Split('/');
                string currentDir = s[2];
                Directory.CreateDirectory(currentDir);
                if(!(s[s.Length - 1].EndsWith(".html") || s[s.Length - 1].EndsWith(".htm") || s[s.Length - 1].EndsWith(".php") || s[s.Length - 1].EndsWith(".asp") || s[s.Length - 1].EndsWith(".aspx")))
                {
                    File.WriteAllText(currentDir + "\\" + s[s.Length - 1] + ".html", responseBody);
                }
                else
                {
                    File.WriteAllText(currentDir + "\\" + s[s.Length - 1], responseBody);
                }
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("Page downloading failed");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Usage: ezwebdl URL");
                Console.WriteLine("  where URL is the URL of the website you want to connect to.");
                Console.WriteLine("or: ezwebdl /h");
                Console.WriteLine("  Shows this.");
                Console.WriteLine("or: ezwebdl /h:code");
                Console.WriteLine("  Shows a list of common HTTP codes.");
            }
            
        }
        
    }
}
