using Salem;
using System;

class Program
{
	static void Main(string[] args)
	{
		var logger = new Logger();
		logger.Log("Info", "Hello World!");
        Console.ReadKey();
	}
}
