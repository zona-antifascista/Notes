namespace Notes.Api.Entities;

public class User : BaseEntity
{
    public string NickName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public List<Note> Notes { get; set; }

    public User(string nickName, string email, string passwordHash, List<Note> notes)
    {
        NickName = nickName;
        Email = email;
        PasswordHash = passwordHash;
        Notes = notes;
    }

    public User()
    {
        
    }

}
