using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using MinimalAPI_RequestValidation.Services;

namespace MinimalAPI_RequestValidation;

public static class Endpoints
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        var endPoints = app.MapGroup("/posts");


        endPoints.MapPost("/", CreatePost)
            .WithSummary("Some Summary").
            WithDescription("Abc")
            .WithDisplayName("Some display name");

        // endPoints.MapPut("/", UpdatePost)
        //     .WithSummary("Update a existing post");
        //
        // endPoints.MapGet("/", GetPosts);
    }


    record CreatePostRequest(string Title, string Content);

    private static Created<Guid> CreatePost([FromBody]CreatePostRequest request,  Database database)
    {
        var post = new Post
        {
            Title = request.Title,
            Content = request.Content
        };
        
        database.Posts.Add(post);

        return TypedResults.Created<Guid>("/posts", post.Id);
    }

    private static Task UpdatePost(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static List<Post> GetPosts(CreatePostRequest request, Database database)
    {
        return database.Posts;
    }
}