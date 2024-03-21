namespace RemoteLearning.TheUniverse.Infrastructure
{
    public interface IRequestHandler<TRequest, out TResponse>
    {
        TResponse Execute(TRequest request);
    }
}