namespace RubiksCubeApi.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IRubiksCubeRepository RubiksCubeRepository { get; }
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
