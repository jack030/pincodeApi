using pincodeApi.Entities;
namespace pincodeApi.Entities.Controllers.Dto;

public class UserDto
{
    public int Id{get;set;}

    public string Name{get;set;}="";

    public string Password{get;set;}="";
    public string Confirm{get;set;}="";
    
    public int? RemainingDates{get;set;} = 30;
    public UserTypes UserType{get;set;}


}