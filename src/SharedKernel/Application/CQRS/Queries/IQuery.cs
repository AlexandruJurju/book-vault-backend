using Ardalis.Result;
using MediatR;

namespace SharedKernel.Application.CQRS.Queries;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
