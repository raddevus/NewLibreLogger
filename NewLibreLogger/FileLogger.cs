using System;

namespace NewLibre;

public class FileLogger: Loggable{
   private String Path = @$"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}";
   private String FileName = "file.log";
   private String TargetFile;
   
   public FileLogger(string path = null, string filename = null){
      if (!path.IsNullOrEmpty()){
         Path = path;
      }
      if (!filename.IsNullOrEmpty()){
         FileName = filename;
      }
      Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff tt")} : FileActivityTracker ctor...");
   }

   public override bool Configure(){
      TargetFile = @$"{System.IO.Path.Combine(Path,FileName)}";
      return true;
   }

   public override string StorageTarget{
      get{ return TargetFile;}
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

