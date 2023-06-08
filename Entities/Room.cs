namespace pincodeApi.Entities;

public class Room
{
    public int Id{get;set;}

    public string Name{get;set;}="";

    public RoomTypes RoomType{get;set;}

    public virtual  ICollection<Video> Videos { get; set; }

    public Room()
    {
        Videos = new HashSet<Video>();
    }

    

   

}
