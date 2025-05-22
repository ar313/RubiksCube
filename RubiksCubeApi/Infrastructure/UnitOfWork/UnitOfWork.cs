using RubiksCubeApi.Application.Interfaces;
using RubiksCubeApi.Infrastructure.Data;
using RubiksCubeApi.Infrastructure.Repositories;
using System;

namespace RubiksCubeApi.Infrastructure.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        private IRubiksCubeRepository? _rubiksCubeRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(AppDbContext));
        }

        public IRubiksCubeRepository RubiksCubeRepository =>
            _rubiksCubeRepository ??= new RubiksCubeRepository(_context);

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
