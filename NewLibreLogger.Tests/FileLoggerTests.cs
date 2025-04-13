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
   
   [Fact]
   void AddPathNoFile(){
      FileLogger fl = new FileLogger("./");
      Console.WriteLine($"Writing to {fl.StorageTarget}");
      fl.Write("This is my test");
   }

   [Fact]
   void AddFileNoPath(){
      FileLogger fl = new FileLogger(String.Empty,"newfile.txt");
      Console.WriteLine($"Writing to {fl.StorageTarget}");
      fl.Write("This is my test");
   }
}
