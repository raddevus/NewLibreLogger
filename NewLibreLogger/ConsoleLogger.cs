using System;

namespace NewLibre;

public class ConsoleLogger: Loggable{
   
   public ConsoleLogger(){
      Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff tt")} : ConsoleLogger ctor...");
   }

   public override string StorageTarget{
      get{ return null;}
   }

   public override bool Write(String message){
      try{
          Console.WriteLine($"{DateTime.Now.ToLongTimeString()} : {message} {Environment.NewLine}");
          return true;
      }
      catch(Exception ex){
         return false;
      }
   }

   // Only writes the user's message - no date/time info
   public bool WriteMsg(String message){
      try{
         Console.WriteLine($"{message}");
         return true;
      }
      catch (Exception ex){
         return false;
      }
   }

   public override bool Configure(){
      // no op function -- nothing needed for console
      return true;
   }
}

