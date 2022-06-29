using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalApiBlog.Api.Features.Categories.Models;
using MinimalApiBlog.Dal;

namespace MinimalApiBlog.Api.Features.Categories.Queries
{
    public static class GetCategoryById
    {
        public class Query : IRequest<CategoryDto>
        {
            public int CategoryId { get; set; }
        }

        public class Handler : IRequestHandler<Query, CategoryDto>
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;
            public Handler(ApplicationDbContext context, IMapper mapper)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }
            public async Task<CategoryDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var Category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.CategoryId, cancellationToken);
                return _mapper.Map<CategoryDto>(Category);
            }
        }
    }
}
