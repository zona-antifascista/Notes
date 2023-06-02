namespace Notes.Api.Entities;

public class Note : BaseEntity
{
    public string Title { get; set; }

    /// <summary>
    /// Encrypt content by AES 
    /// </summary>
    public string Content { get; set; }

    public Note(string title, string content)
    {
        Title = title;
        Content = content;
    }

    public Note()
    {
        
    }
}
