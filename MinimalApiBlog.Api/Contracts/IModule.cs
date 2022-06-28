namespace MinimalApiBlog.Api.Contracts
{
    public interface IModule
    {
        IEndpointRouteBuilder RegisterEndpoints(IEndpointRouteBuilder endpoints);
    }
}
