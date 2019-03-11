using System;
using Acme.Core.Kernal.Commands;

namespace Acme.Core.Albums.Commands
{
    public class CreateAlbumCommand : ICommand
    {
        public Guid Id { get; }
        public string Name { get; }

        public CreateAlbumCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
