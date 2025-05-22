using MediatR;

namespace RubiksCubeApi.Application.Common
{
    public abstract class BaseCommand<TResponse> : IRequest<TResponse>
    {
        //shared properties
    }
}
