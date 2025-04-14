namespace NewLibreLogger.Tests;
using NewLibre;
using System.IO;

public class SqliteLoggerTests{

   [Fact]
   void NoPathNoFile(){
      SqliteLogger sl = new ();
      Console.WriteLine($"Writing to {sl.StorageTarget}");
      sl.Write("This is my test");
   }

   [Fact]
   void SetTableName(){
      SqliteLogger sl = new(String.Empty, String.Empty, "logtask");
      Console.WriteLine($"Writing to {sl.StorageTarget}");
      sl.Write("This is test to logtask table.");
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
