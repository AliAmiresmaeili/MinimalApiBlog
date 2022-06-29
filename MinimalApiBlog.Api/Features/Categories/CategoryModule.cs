using MediatR;
using MinimalApiBlog.Api.Contracts;
using MinimalApiBlog.Api.Features.Categories.Commands;
using MinimalApiBlog.Api.Features.Categories.Models;
using MinimalApiBlog.Api.Features.Categories.Queries;

namespace MinimalApiBlog.Api.Features.Categories
{
    public class CategoryModule : IModule
    {
        public IEndpointRouteBuilder RegisterEndpoints(IEndpointRouteBuilder endpoints)
        {

            endpoints.MapGet("/api/categories", GetAllCategoriesAsync)
                .WithName("GetAllCategories")
                .WithDisplayName("Categories")
                .WithTags("Categories")
                .Produces<List<CategoryDto>>()
                .Produces(500);

            endpoints.MapPost("/api/categories", CreateCategoryAsync)
                .WithName("CreateCategory")
                .WithDisplayName("Categories")
                .WithTags("Categories")
                .Produces<CategoryDto>()
                .Produces(500);

            endpoints.MapGet("api/categories/{id}", GetCategoryById)
                .WithName("GetCategoryById")
                .WithDisplayName("Categories")
                .Produces<CategoryDto>()
                .Produces(404)
                .Produces(500);

            endpoints.MapPut("api/categories/{id}", UpdateCategory)
                .WithName("UpdateCategory")
                .WithDisplayName("Categories")
                .Produces(204)
                .Produces(500);

            endpoints.MapDelete("api/categories/{id}", DeleteCategory)
                .WithName("DeleteCategory")
                .WithDisplayName("Categories")
                .Produces(204)
                .Produces(500);

            return endpoints;
        }

        private static async Task<IResult> CreateCategoryAsync(CategoryDto CategoryDto, IMediator mediator, CancellationToken cancellationToken)
        {
            var command = new CreateCategory.Command { CategoryDto = CategoryDto };
            var category = await mediator.Send(command, cancellationToken);
            return Results.Ok(category);
        }

        private static async Task<IResult> GetAllCategoriesAsync(IMediator mediator, CancellationToken cancellationToken)
        {
            var query = new GetAllCategories.Query();
            var categories = await mediator.Send(query, cancellationToken);
            return Results.Ok(categories);
        }

        private async Task<IResult> GetCategoryById(int id, IMediator mediator, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetCategoryById.Query { CategoryId = id }, cancellationToken);
            if (result is null)
                return Results.NotFound();
            return Results.Ok(result);
        }

        private async Task<IResult> DeleteCategory(int id, IMediator mediator, CancellationToken cancellationToken)
        {
            await mediator.Send(new DeleteCategory.Command { CategoryId = id }, cancellationToken);
            return Results.NoContent();
        }

        private async Task<IResult> UpdateCategory(int id, CategoryDto CategoryToUpdate, IMediator mediator, CancellationToken cancellationToken)
        {
            var command = new UpdateCategory.Command
            {
                Id = id,
                Name = CategoryToUpdate.Name ?? "",
                Description = CategoryToUpdate.Description ?? "",
            };
            await mediator.Send(command, cancellationToken);
            return Results.NoContent();
        }
    }
}
