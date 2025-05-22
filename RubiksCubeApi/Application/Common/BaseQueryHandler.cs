using MediatR;
using RubiksCubeApi.Application.Interfaces;

namespace RubiksCubeApi.Application.Common
{
    public abstract class BaseQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IBaseQuery<TResult>
    {
        public async Task<TResult> Handle(TQuery request, CancellationToken cancellationToken)
        {
            return await HandleQueryAsync(request, cancellationToken);
        }

        protected abstract Task<TResult> HandleQueryAsync(TQuery query, CancellationToken cancellationToken);
    }
}
