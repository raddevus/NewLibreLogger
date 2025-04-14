namespace NewLibreLogger.Tests;
using NewLibre;
using System.IO;

public class SqliteLoggerTests{

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
