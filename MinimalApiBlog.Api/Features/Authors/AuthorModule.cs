using MediatR;
using MinimalApiBlog.Api.Contracts;
using MinimalApiBlog.Api.Features.Authors.Commands;
using MinimalApiBlog.Api.Features.Authors.Models;
using MinimalApiBlog.Api.Features.Authors.Queries;

namespace MinimalApiBlog.Api.Features.Authors
{
    public class AuthorModule : IModule
    {
        public IEndpointRouteBuilder RegisterEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/api/authors", GetAllAuthorsAsync)
                .WithName("GetAllAuthors")
                .WithDisplayName("Authors")
                .WithTags("Authors")
                .Produces<List<AuthorGetDto>>()
                .Produces(500);

            endpoints.MapPost("/api/authors", CreateAuthorAsync)
                .WithName("CreateAuthor")
                .WithDisplayName("Authors")
                .WithTags("Authors")
                .Produces<AuthorGetDto>()
                .Produces(500);

            endpoints.MapGet("api/authors/{id}", GetAuthorById)
                .WithName("GetAuthorById")
                .WithDisplayName("Authors")
                .Produces<AuthorGetDto>()
                .Produces(404)
                .Produces(500);

            endpoints.MapPut("api/authors/{id}", UpdateAuthor)
                .WithName("UpdateAuthor")
                .WithDisplayName("Authors")
                .Produces(204)
                .Produces(500);

            endpoints.MapDelete("api/authors/{id}", DeleteAuthor)
                .WithName("DeleteAuthor")
                .WithDisplayName("Authors")
                .Produces(204)
                .Produces(500);

            return endpoints;
        }


        private static async Task<IResult> CreateAuthorAsync(AuthorDto authorDto, IMediator mediator, CancellationToken cancellationToken)
        {
            var command = new CreateAuthor.Command { AuthorDto = authorDto };
            var author = await mediator.Send(command, cancellationToken);
            return Results.Ok(author);
        }

        private static async Task<IResult> GetAllAuthorsAsync(IMediator mediator, CancellationToken cancellationToken)
        {
            var query = new GetAllAuthors.Query();
            var authors = await mediator.Send(query, cancellationToken);
            return Results.Ok(authors);
        }

        private async Task<IResult> GetAuthorById(int id, IMediator mediator, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetAuthorById.Query { AuthorId = id }, cancellationToken);
            if (result is null)
                return Results.NotFound();
            return Results.Ok(result);
        }

        private async Task<IResult> DeleteAuthor(int id, IMediator mediator, CancellationToken cancellationToken)
        {
            await mediator.Send(new DeleteAuthor.Command { AuthorId = id }, cancellationToken);
            return Results.NoContent();
        }

        private async Task<IResult> UpdateAuthor(int id, AuthorDto authorToUpdate, IMediator mediator, CancellationToken cancellationToken)
        {
            var command = new UpdateAuthor.Command
            {
                AuthorId = id,
                FirstName = authorToUpdate.FirstName,
                LastName = authorToUpdate.LastName,
                Bio = authorToUpdate.Bio ?? "",
                BirthDate = authorToUpdate.BirthDate
            };
            await mediator.Send(command, cancellationToken);
            return Results.NoContent();
        }
    }
}
