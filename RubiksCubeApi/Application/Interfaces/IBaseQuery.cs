using MediatR;

namespace RubiksCubeApi.Application.Interfaces
{
    public interface IBaseQuery<TResult> : IRequest<TResult>
    {
    }
}
