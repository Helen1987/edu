using System;
using System.Collections.Generic;
using System.Text;
using FileDataComponent;

namespace ConsoleClient
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Downloading to c:\\");
			FileData.ClientFolder = @"c:\";
			Console.WriteLine("Enter the name of the file to download.");
			Console.WriteLine("This is a file in the server's download directory.");
			Console.WriteLine("The download directory is c:\\temp by default.");
			Console.Write("> ");
			string file = Console.ReadLine();
			FileService proxy = new FileService();
			Console.WriteLine();
			Console.WriteLine("Starting download.");
			proxy.DownloadFile(file);
			Console.WriteLine("Download complete.");
			Console.ReadLine();
		}
	}
}
