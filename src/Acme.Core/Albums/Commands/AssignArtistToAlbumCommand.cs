using System;
using Acme.Core.Kernal.Commands;

namespace Acme.Core.Albums.Commands
{
    public class SetAlbumArtistCommand : ICommand
    {
        public Guid AlbumId { get; set; }
        public Guid ArtistId { get; set; }

        public SetAlbumArtistCommand(Guid albumId, Guid artistId)
        {
            AlbumId = albumId;
            ArtistId = artistId;
        }
    }
}