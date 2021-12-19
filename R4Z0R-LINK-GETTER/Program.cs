// Type your username and press enter
using Figgle;
using HtmlAgilityPack;
using System.Diagnostics;
using System.Net;

Console.WriteLine(FiggleFonts.Doom.Render("R4Z0R"));
Console.WriteLine(FiggleFonts.Doom.Render("LINK-GETTER"));
Console.Write("Enter URL: ");
    
string userName = Console.ReadLine();

// Print the value of the variable (userName), which will display the input value
Console.WriteLine("URL is: " + userName);
Console.WriteLine("");
Console.WriteLine("------------------------------------------------------------");
Console.WriteLine("");
System.Threading.Thread.Sleep(1000);
Console.WriteLine("Checking for Website Status...");
System.Threading.Thread.Sleep(3000);
HttpClient Client = new HttpClient();
var result = await Client.GetAsync(userName);
int StatusCode = (int)result.StatusCode;
Console.WriteLine("[Website Status: "+StatusCode+"]");
HttpWebRequest request = (HttpWebRequest)WebRequest.Create(userName);

System.Diagnostics.Stopwatch timer = new Stopwatch();
timer.Start();

HttpWebResponse response = (HttpWebResponse)request.GetResponse();

timer.Stop();

TimeSpan timeTaken = timer.Elapsed;
Console.WriteLine("[Loading Time: " + timeTaken + "]");
System.Threading.Thread.Sleep(1000);
Console.WriteLine("Getting Links...");
System.Threading.Thread.Sleep(1000);
Console.WriteLine("");
Console.WriteLine("------------------------------------------------------------");
Console.WriteLine("");

var number = 0;
HtmlWeb hw = new HtmlWeb();
HtmlDocument doc = hw.Load(userName);
foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a"))
{
    var texts = link.Attributes["href"].Value;
    number++;
    Console.WriteLine("["+number+"]"+" "+texts);
    System.Threading.Thread.Sleep(150);
}
Console.WriteLine("");
Console.WriteLine("------------------------------------------------------------");
Console.WriteLine("");
Console.WriteLine("If you want to close the Program, press any Key...");
string anykey = Console.ReadLine();
Environment.Exit(0);