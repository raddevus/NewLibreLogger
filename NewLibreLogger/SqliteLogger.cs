using System;
using Microsoft.Data.Sqlite;

namespace NewLibre;

public class SqliteLogger: Loggable{
   private SqliteCommand Command{get;set;}
   private String connectionString;
   
   protected SqliteConnection connection;
   private String Path = @$"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}";
   private String FileName = "nllogger.db";
   private String TableName = "task";
   private String TargetFile;
   
   public SqliteLogger(string path = null, string filename = null, 
         string tableName = null){
      if (!path.IsNullOrEmpty()){
         Path = path;
      }
      if (!filename.IsNullOrEmpty()){
         FileName = filename;
      }
      if (!tableName.IsNullOrEmpty()){
         TableName = tableName;
      }
      Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff tt")} : FileActivityTracker ctor...");
      Configure();
      InitializeTableCreate();
      
      try{
         connection.Open();
         FileInfo fi = new(TargetFile);
         if (fi.Length == 0){
            foreach (String tableCreate in allTableCreation){
               Command.CommandText = tableCreate;
               Command.ExecuteNonQuery();
            }
         }
         Console.WriteLine(connection.DataSource);
      }
      finally{
         if (connection != null){
            connection.Close();
         }
      }
   }
  
   // Make sure you set the size of this array so it is
   // large enough to match the number of tables you create.
   protected String [] allTableCreation = new string[1];
   void InitializeTableCreate(){
      allTableCreation[0] =  
         @$"CREATE Table {TableName}
            ( [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
              [Description] NVARCHAR(1000) check(length(Description) <= 1000),
              [Created] NVARCHAR(30) default (datetime('now','localtime')) check(length(Created) <= 30)
            )";
   }

   public override bool Configure(){
      TargetFile = @$"{System.IO.Path.Combine(Path,FileName)}";
      connectionString = $"Data Source={TargetFile}";
      connection = new SqliteConnection(connectionString);
      Command = connection.CreateCommand();
      return true;
   }

   public override string StorageTarget{
      get{ return connectionString;}
   }

   public override bool Write(String message){
      Command.CommandText = @$"INSERT into {TableName} (Description)values($message);select * from task where id =(SELECT last_insert_rowid())";
      Command.Parameters.AddWithValue("$message",message);
      try{
          Console.WriteLine("Saving...");
            connection.Open();
            Console.WriteLine("Opened.");
            // id should be last id inserted into table
            var id = Convert.ToInt64(Command.ExecuteScalar());
            Console.WriteLine("inserted.");
          return true;
      }
      catch(Exception ex){
         return false;
      }
   }
}

