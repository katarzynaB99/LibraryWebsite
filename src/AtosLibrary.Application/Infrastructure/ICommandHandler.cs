namespace AtosLibrary.Application.Infrastructure
{
    public interface ICommandHandler<in T>
    {
        void Handle(T command);
    }
}
