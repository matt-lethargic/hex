using System.Threading.Tasks;
using Acme.Core.Albums.Commands;
using Acme.Core.Kernal.Commands;
using Acme.Core.Ports;

namespace Acme.Core.Albums.CommandHandlers
{
    public class CreateAlbumCommandHandler : ICommandHandler<CreateAlbumCommand>
    {
        private readonly IRepository _repository;

        public CreateAlbumCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAlbumCommand command)
        {
            Album album = new Album(command.Id, command.Name);

            await _repository.Save(album);
        }
    }
}
