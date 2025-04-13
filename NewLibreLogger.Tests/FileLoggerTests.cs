namespace NewLibreLogger.Tests;
using NewLibre;
using System.IO;

public class FileLoggerTests{
   //Redirect Console output to the terminal
   TextWriter terminalWriter; 
   public FileLoggerTests(){
      terminalWriter = Console.Out;
      Console.SetOut(terminalWriter);
   }

   [Fact]
   void NoPathNoFile(){
      FileLogger fl = new FileLogger();
      Console.WriteLine($"Writing to {fl.StorageTarget}");
      fl.Write("This is my test");
   }
}
