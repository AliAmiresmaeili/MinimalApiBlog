using AutoMapper;
using MediatR;
using MinimalApiBlog.Api.Features.Categories.Models;
using MinimalApiBlog.Dal;
using MinimalApiBlog.Domain.Model;

namespace MinimalApiBlog.Api.Features.Categories.Commands
{
    public static class CreateCategory
    {
        public class Command : IRequest<CategoryDto>
        {
            public CategoryDto CategoryDto { get; set; } = default!;
        }

        public class Handler : IRequestHandler<Command, CategoryDto>
        {
            private readonly IMapper _mapper;
            private readonly ApplicationDbContext _context;
            public Handler(ApplicationDbContext context, IMapper mapper)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<CategoryDto> Handle(Command request, CancellationToken cancellationToken)
            {
                if (request == null)
                    throw new ArgumentNullException(nameof(request));

                var category = _mapper.Map<Category>(request.CategoryDto);
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return _mapper.Map<CategoryDto>(category);

            }
        }
    }
}
