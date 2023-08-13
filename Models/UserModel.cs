using System.ComponentModel.DataAnnotations;

namespace NotesAndDutiesAPI.Models{
    //Model that represents a user
    public class UserModel {
        [Key]
        public int UserId {get; set;}
        
        public string Username {get; set;}

        public string Password {get; set;}

        public string EmailAddress { get; set;}

        public string Role {get; set;}
    }

    public class UserModelDto {
        public string Username {get; set;}

        public string Password {get; set;}

        public string EmailAddress { get; set;}

        public string Role {get; set;}
    }
}