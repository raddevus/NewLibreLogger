namespace NewLibreLogger.Tests;
using NewLibre;
using System.IO;

public class EndpointLoggerTests{

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
   public async Task WriteMsgAsyncNoWaitTest(){
      EndpointLogger el = new("http://localhost:5247/RegisterUser3");
      Console.WriteLine("before call to endpointlogger...");
      string result = await el.WriteAsync("{\"uuid\":\"thisIsId\"}");
Console.WriteLine(result);

//      Task.Run (() => cl.WriteAsync("I'm writing async now. No stopping!"));
   }

   [Fact] 
   async void WriteMsgAsyncBlockTest(){
      ConsoleLogger cl = new();
      await cl.WriteAsync("I'm writing async with BLOCKing!");
   }
}
