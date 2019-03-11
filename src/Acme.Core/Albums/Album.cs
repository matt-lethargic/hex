using Acme.Core.Kernal;
using System;

namespace Acme.Core.Albums
{
    public class Album : Entity
    {
        public string Name { get; }
        public Guid ArtistId { get; private set; }

        public Album(Guid id, string name)
            : base(id)
        {
            Name = name;
        }

        public void SetArtist(Guid artistId)
        {
            ArtistId = artistId;
        }
    }
}
