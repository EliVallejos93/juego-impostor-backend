using FluentValidation;
using juego_impostor_backend.Shared.Persistence;
using MediatR;

namespace juego_impostor_backend.Shared.Behaviors
{
    //public class TransactionBehavior<TRequest, TResponse>(AppDbContext dbContext) : IPipelineBehavior<TRequest, TResponse>
    //where TRequest : notnull
    //{
    //    private readonly AppDbContext _dbContext = dbContext;

    //    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    //    {
    //        if (_dbContext.Database.CurrentTransaction != null)
    //            return await next();

    //        TResponse response;
    //        await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

    //        try
    //        {
    //            response = await next();
    //            await transaction.CommitAsync(cancellationToken);
    //        }
    //        catch
    //        {
    //            await transaction.RollbackAsync(cancellationToken);
    //            throw;
    //        }

    //        return response;
    //    }
    //}
}
