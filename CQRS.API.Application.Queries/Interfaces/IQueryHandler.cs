namespace CQRS.API.Application.Queries.Interfaces
{
    public interface IQueryHandler<in TQuery, IResult> where TQuery : class, IQuery<IResult>
    {
        Task<IResult> HandleAsync(TQuery query);
    }
}
