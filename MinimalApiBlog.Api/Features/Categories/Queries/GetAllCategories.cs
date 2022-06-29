using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalApiBlog.Api.Features.Categories.Models;
using MinimalApiBlog.Dal;

namespace MinimalApiBlog.Api.Features.Categories.Queries
{
    public static class GetAllCategories
    {
        public class Query : IRequest<List<CategoryDto>>
        {
        }

        public class Handler : IRequestHandler<Query, List<CategoryDto>>
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;

            public Handler(ApplicationDbContext context, IMapper mapper)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<List<CategoryDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var Categorys = await _context.Categories.ToListAsync(cancellationToken);
                return _mapper.Map<List<CategoryDto>>(Categorys);
            }
        }
    }
}
