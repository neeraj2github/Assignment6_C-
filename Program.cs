using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

public class Program
{
    static async Task Main()
    {
        Console.Write("Enter URL: ");
        string url = Console.ReadLine();

        string content = await DownloadContentAsync(url);
        await WriteContentToFileAsync("A.txt", content);

        Console.WriteLine("Content written to file.");
    }

    static async Task<string> DownloadContentAsync(string url)
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }

    static async Task WriteContentToFileAsync(string fileName, string content)
    {
        using (var writer = new StreamWriter(fileName))
        {
            await writer.WriteAsync(content);
        }
    }
}