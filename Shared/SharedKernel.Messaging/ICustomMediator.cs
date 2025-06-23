namespace SharedKernel.Messaging
{
    public interface ICustomMediator
    {
        Task<TResult> Send<TCommand, TResult>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : ICommand<TResult>;
    }
}
