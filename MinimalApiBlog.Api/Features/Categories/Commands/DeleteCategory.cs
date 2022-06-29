using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalApiBlog.Dal;

namespace MinimalApiBlog.Api.Features.Categories.Commands
{
    public static class DeleteCategory
    {
        public class Command : IRequest
        {
            public int CategoryId { get; init; }
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
                var category = await _context.Categories.FirstOrDefaultAsync(a => a.Id == request.CategoryId, cancellationToken);
                if (category != null)
                    _context.Categories.Remove(category);

                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
