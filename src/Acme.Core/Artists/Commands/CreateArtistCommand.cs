using System;
using Acme.Core.Kernal.Commands;

namespace Acme.Core.Artists.Commands
{
    public class CreateArtistCommand : ICommand
    {
        public Guid Id { get; }
        public string Name { get; }

        public CreateArtistCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
