using Microsoft.EntityFrameworkCore;
using RubiksCubeApi.Domain.Entities;

namespace RubiksCubeApi.Application.Interfaces
{
    public interface IRubiksCubeRepository : IRepository<RubiksCube>
    {
        public Task<RubiksCube?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        public Task<List<RubiksCube>> GetAllAsync(CancellationToken cancellationToken);
    }
}
