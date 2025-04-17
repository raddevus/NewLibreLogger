using System;
using System.Text;
using System.Text.Json;
using System.Net.Http;

namespace NewLibre;

public class EndpointLogger: Loggable{
   private String Endpoint;
   private readonly HttpClient _httpClient;
   
   public EndpointLogger(String endpoint){
      if (!endpoint.IsNullOrEmpty()){
         Endpoint = endpoint;
      }
      _httpClient = new HttpClient();
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
   
   public async Task<string> WriteAsync(String message){
      Console.WriteLine("In WriteAsync...");
      try{
      var content = new StringContent(JsonSerializer.Serialize(message), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(Endpoint, content);
        return await response.Content.ReadAsStringAsync();
      }
      catch (Exception ex){
         Console.WriteLine($"Error: {ex.Message}");
         return "error";
      }
   }
}
