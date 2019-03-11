using Acme.Core.Kernal.Commands;
using Acme.Core.Ports;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acme.Adapters.Command.Test
{
    public class TestCommandBus : ICommandBus
    {
        private readonly Dictionary<Type, List<Func<ICommand, Task>>> _routes = new Dictionary<Type, List<Func<ICommand, Task>>>();


        public void RegisterHandler<T>(Func<T, Task> handlerAction)
            where T : ICommand
        {
            if (!_routes.TryGetValue(typeof(T), out var handlers))
            {
                handlers = new List<Func<ICommand, Task>>();
                _routes.Add(typeof(T), handlers);
            }

            handlers.Add(x => handlerAction((T)x));
        }


        public async Task Dispatch<T>(T command)
            where T : ICommand
        {
            if (_routes.TryGetValue(typeof(T), out var handlers))
            {
                if (handlers.Count != 1) throw new InvalidOperationException("Cannot send to more than one handler.");
                await handlers[0](command);
            }
            else
            {
                throw new InvalidOperationException("No handler registered.");
            }
        }
    }
}
