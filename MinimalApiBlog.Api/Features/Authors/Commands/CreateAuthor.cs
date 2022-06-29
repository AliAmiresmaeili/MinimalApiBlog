using AutoMapper;
using MediatR;
using MinimalApiBlog.Api.Features.Authors.Models;
using MinimalApiBlog.Dal;
using MinimalApiBlog.Domain.Model;

namespace MinimalApiBlog.Api.Features.Authors.Commands
{
    public static class CreateAuthor
    {
        public class Command : IRequest<AuthorGetDto>
        {
            public AuthorDto AuthorDto { get; set; } = default!;
        }

        public class Handler : IRequestHandler<Command, AuthorGetDto>
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;
            public Handler(ApplicationDbContext context, IMapper mapper)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<AuthorGetDto> Handle(Command request, CancellationToken cancellationToken)
            {
                if (request == null)
                    throw new ArgumentNullException(nameof(request));

                var author = _mapper.Map<Author>(request.AuthorDto);
                _context.Authors.Add(author);
                await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<AuthorGetDto>(author);
            }
        }
    }
}
