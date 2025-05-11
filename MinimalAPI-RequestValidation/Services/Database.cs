namespace MinimalAPI_RequestValidation.Services;

public class Post
{
    public Guid Id { get; private init; } = Guid.NewGuid();
    public required string Title { get; set; }
    public required string Content { get; set; }
}

public class Database
{
    private static readonly List<Post> _posts = [];
    public List<Post> Posts => _posts;
}