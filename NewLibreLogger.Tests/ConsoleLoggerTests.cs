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

   [Fact]
   void WriteMsgAsyncNoWaitTest(){
      ConsoleLogger cl = new();
      Task.Run (() => cl.WriteAsync("I'm writing async now. No stopping!"));
   }

   [Fact] 
   async void WriteMsgAsyncBlockTest(){
      ConsoleLogger cl = new();
      await cl.WriteAsync("I'm writing async with BLOCKing!");
   }
}
