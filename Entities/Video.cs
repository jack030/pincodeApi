namespace pincodeApi.Entities;

public class Video
{
    public int Id{get;set;}

    public string Name{get;set;}="";

    public int Episode{get;set;}=1;
    

    public string? Link{get;set;} ="";

    public int RoomId{get;set;}
    public virtual Room? Room{get;set;} = null;
    //TODO: description
    //thubmnail
    

}


    

   

