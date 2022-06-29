using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalApiBlog.Dal;

namespace MinimalApiBlog.Api.Features.Authors.Commands
{
    public static class DeleteAuthor
    {
        public class Command : IRequest
        {
            public int AuthorId { get; init; }
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
                var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == request.AuthorId, cancellationToken);
                if (author != null)
                    _context.Authors.Remove(author);

                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
