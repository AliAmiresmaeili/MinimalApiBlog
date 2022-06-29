using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalApiBlog.Api.Features.Authors.Models;
using MinimalApiBlog.Dal;

namespace MinimalApiBlog.Api.Features.Authors.Queries
{
    public static class GetAuthorById
    {
        public class Query : IRequest<AuthorGetDto>
        {
            public int AuthorId { get; set; }
        }

        public class Handler : IRequestHandler<Query, AuthorGetDto>
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;
            public Handler(ApplicationDbContext context, IMapper mapper)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }
            public async Task<AuthorGetDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == request.AuthorId, cancellationToken);
                return _mapper.Map<AuthorGetDto>(author);
            }
        }
    }
}
