namespace NewLibreLogger.Tests;
using NewLibre;
using System.IO;

public class ConsoleLoggerTests{

   [Fact]
   void WriteMsgTest(){
      ConsoleLogger cl = new();
      cl.Write("This is the console test.");
   }
}
