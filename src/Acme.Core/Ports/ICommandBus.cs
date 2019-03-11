using System.Threading.Tasks;
using Acme.Core.Kernal.Commands;

namespace Acme.Core.Ports
{
    public interface ICommandBus
    {
        Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
