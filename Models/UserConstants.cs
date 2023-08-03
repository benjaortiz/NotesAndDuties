namespace NotesAndDutiesAPI.Models{

    // list of user constants used to store some usernames (its just to have some data to use
    // without having to use EFcore to store the user info)
    public class UserConstants{
        public static List<UserModel> Users = new List<UserModel>(){
            new UserModel { Username = "theBestAdmin", Password = "weakpassword123", EmailAddress = "admin.thebest@email.com", Role = "Admin"},
            new UserModel { Username = "regularDude", Password = "123NotSoWeakPassword123", EmailAddress = "justadude@email.com", Role = "User"}
        };
    }
}