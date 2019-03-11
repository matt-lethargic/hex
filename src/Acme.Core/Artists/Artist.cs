using System;
using System.Collections.Generic;
using System.Text;
using Acme.Core.Kernal;

namespace Acme.Core.Artists
{
    public class Artist : Entity
    {
        public string Name { get; }

        public IList<Guid> AlbumIds { get; }

        public Artist(Guid id, string name)
            : base(id)
        {
            AlbumIds = new List<Guid>();
        }

        public void AddAlbum(Guid albumId)
        {
            AlbumIds.Add(albumId);
        }
    }
}
