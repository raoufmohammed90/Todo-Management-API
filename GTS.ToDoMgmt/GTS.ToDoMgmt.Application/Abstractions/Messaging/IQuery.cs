using MediatR;

namespace GTS.ToDoMgmt.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {
    }
}
