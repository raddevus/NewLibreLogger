namespace NewLibreLogger.Tests;
using NewLibre;
using System.IO;

public class ConsoleLoggerTests{

   [Fact]
   void WriteMsgWithTimeTest(){
      ConsoleLogger cl = new();
      cl.Write("This is the console test.");
   }

   [Fact]
   void WriteMsgWithoutTime(){
      ConsoleLogger cl = new();
      cl.WriteMsg("This message is written without date/time info.");
   }
}
