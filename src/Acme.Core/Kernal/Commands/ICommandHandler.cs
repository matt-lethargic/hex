using System.Threading.Tasks;

namespace Acme.Core.Kernal.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }
}