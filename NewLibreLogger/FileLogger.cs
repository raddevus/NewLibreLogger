using System;

namespace NewLibre;

public class FileLogger: Loggable{
   private String Path = @$"Path.Combine({Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}";
   private String FileName;
   public FileLogger(string path = null){
       
      Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff tt")} : FileActivityTracker ctor...");
   }

   public override bool Configure(){
      FileName = @$"Path.Combine({Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)},temp,InterfaceStudy.log";
      return true;
   }

   public override string StorageTarget{
      get{ return FileName;}
   }

   public override bool Write(String message){
      try{
          File.AppendAllText(StorageTarget, $"{DateTime.Now.ToLongTimeString()}:   {message} {Environment.NewLine}");
          return true;
      }
      catch(Exception ex){
         return false;
      }
   }
}

