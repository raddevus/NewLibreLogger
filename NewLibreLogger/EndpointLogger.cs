using System;
using System.Net.Http;

namespace NewLibre;

public class EndpointLogger: Loggable{
   private String Endpoint;
   private readonly HttpClient HttpClient;
   
   public EndpointLogger(String endpoint){
      if (!endpoint.IsNullOrEmpty()){
         Endpoint = endpoint;
      }
      Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff tt")} : EndpointLogger ctor...");
      Configure();
   }

   public override bool Configure(){
      return true;
   }

   public override string StorageTarget   {
      get{ return Endpoint;}
   }

   public override bool Write(String message){
      return true;
   }
   
   public async Task WriteAsync(String message){
      Task.Run(() => {
         try{
             File.AppendAllText(StorageTarget, $"{DateTime.Now.ToLongTimeString()}:   {message} {Environment.NewLine}");
             return true;
         }
         catch(Exception ex){
            return false;
         }
      });
   }
}

