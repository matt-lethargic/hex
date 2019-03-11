using System.Threading.Tasks;
using Acme.Core.Albums.Commands;
using Acme.Core.Artists;
using Acme.Core.Kernal.Commands;
using Acme.Core.Ports;

namespace Acme.Core.Albums.CommandHandlers
{
    public class SetAlbumArtistCommandHandler : ICommandHandler<SetAlbumArtistCommand>
    {
        private readonly IRepository _repository;

        public SetAlbumArtistCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(SetAlbumArtistCommand command)
        {
            Album album = await _repository.GetById<Album>(command.AlbumId);
            Artist artist = await _repository.GetById<Artist>(command.ArtistId);

            album.SetArtist(artist.Id);
            artist.AddAlbum(album.Id);

            await _repository.Save(album);
            await _repository.Save(artist);
        }
    }
}