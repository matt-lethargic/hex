using Acme.Core.Kernal;
using System;
using System.Collections.Generic;

namespace Acme.Core.Artists
{
    public class Artist : Entity
    {
        public string Name { get; }

        public IList<Guid> AlbumIds { get; }

        public Artist(Guid id, string name)
            : base(id)
        {
            Name = name;
            AlbumIds = new List<Guid>();
        }

        public void AddAlbum(Guid albumId)
        {
            AlbumIds.Add(albumId);
        }
    }
}
