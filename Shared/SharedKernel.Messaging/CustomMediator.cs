using Microsoft.Extensions.DependencyInjection;

namespace SharedKernel.Messaging
{
    public class CustomMediator : ICustomMediator
    {
        private readonly IServiceProvider _provider;

        public CustomMediator(IServiceProvider provider)
            => _provider = provider;

        public Task<TResult> Send<TCommand, TResult>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : ICommand<TResult>
        {
            var handler = _provider.GetRequiredService<ICommandHandler<TCommand, TResult>>();
            return handler.Handle(command, cancellationToken);
        }
    }
}
