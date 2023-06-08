namespace pincodeApi.Entities;

public class User
{
    public int Id{get;set;}

    public string Name{get;set;}="";

    public string Password{get;set;}="";
    
    public int? RemainingDates{get;set;} = 30;
    public UserTypes UserType{get;set;}


}
