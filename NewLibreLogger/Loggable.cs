using System;
namespace NewLibre;

public abstract class Loggable{
	
	public Loggable(){
		Configure();
	}
	
   public abstract bool Configure();
   public abstract bool Write(String file);
   public abstract string StorageTarget{get;}
}
