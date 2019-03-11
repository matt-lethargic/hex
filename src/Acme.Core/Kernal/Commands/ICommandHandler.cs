using System.Threading.Tasks;

namespace Acme.Core.Kernal.Commands
{
    public interface ICommandHandler<in TCommand> 
    {
        Task Handle(TCommand command);
    }
}