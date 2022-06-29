using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalApiBlog.Dal;

namespace MinimalApiBlog.Api.Features.Categories.Commands
{
    public static class UpdateCategory
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
            public string Name { get; set; } = default!;
            public string Description { get; set; } = default!;
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ApplicationDbContext _context;

            public Handler(ApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if (request == null)
                {
                    throw new ArgumentNullException(nameof(request));
                }

                var category = await _context.Categories.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);
                if (category is not null)
                {
                    category.Name = request.Name;
                    category.Description = request.Description;
                }

                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
