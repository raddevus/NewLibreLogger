public abstract class Trackable{
	
	public Trackable(){
		Configure();
	}
	
	public abstract bool Configure();
    public abstract bool WriteActivity(String file);
    public abstract string StorageTarget{get;}
}
