using System;
using System.Threading.Tasks;
using Acme.Core.Artists.Commands;
using Acme.Core.Kernal.Commands;
using Acme.Core.Ports;

namespace Acme.Core.Artists.CommandHandlers
{
    public class CreateArtistCommandHandler : ICommandHandler<CreateArtistCommand>
    {
        private readonly IRepository _repository;

        public CreateArtistCommandHandler(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task Handle(CreateArtistCommand command)
        {
            Artist artist = new Artist(command.Id, command.Name);
            return _repository.Save(artist);
        }
    }
}
