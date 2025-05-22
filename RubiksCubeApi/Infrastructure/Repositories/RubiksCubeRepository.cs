using Microsoft.EntityFrameworkCore;
using RubiksCubeApi.Application.Interfaces;
using RubiksCubeApi.Domain.Entities;
using RubiksCubeApi.Infrastructure.Data;

namespace RubiksCubeApi.Infrastructure.Repositories
{
    public class RubiksCubeRepository : RepositoryBase<RubiksCube>, IRubiksCubeRepository
    {
        public RubiksCubeRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<RubiksCube>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _context.RubiksCubes
                    .AsNoTracking()
                    .Include(c => c.RubiksBoxes)
                    .ToListAsync(cancellationToken);
            return result;
        }

        public async Task<RubiksCube?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.RubiksCubes
                .Include(c => c.RubiksBoxes)
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }
    }
}
