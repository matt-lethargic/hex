using Acme.Adapters.Command.Test;
using Acme.Adapters.Repository.Test;
using Acme.Core.Albums;
using Acme.Core.Albums.CommandHandlers;
using Acme.Core.Albums.Commands;
using Acme.Core.Artists;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.Core.UnitTests
{
    public class AlbumUnitTests
    {
        private TestRepository _testRepository;
        private TestCommandDispatcher _testCommandDispatcher;

        [SetUp]
        public void Setup()
        {
            _testRepository = new TestRepository();
            _testCommandDispatcher = new TestCommandDispatcher();

            CreateAlbumCommandHandler createHandler = new CreateAlbumCommandHandler(_testRepository);
            SetAlbumArtistCommandHandler setHandler = new SetAlbumArtistCommandHandler(_testRepository);

            _testCommandDispatcher.RegisterHandler<CreateAlbumCommand>(x => createHandler.Handle(x));
            _testCommandDispatcher.RegisterHandler<SetAlbumArtistCommand>(x => setHandler.Handle(x));
        }

        [Test]
        public async Task CreateAblum_writes_to_repository()
        {
            CreateAlbumCommand command = new CreateAlbumCommand(Guid.NewGuid(), "Testsville Centrl");
            await _testCommandDispatcher.Dispatch(command);

            var savedEntity = _testRepository.TestEntities.FirstOrDefault(x => x.Id == command.Id) as Album;
            Assert.IsNotNull(savedEntity);
            Assert.AreEqual(command.Id, savedEntity.Id);
            Assert.AreEqual(command.Name, savedEntity.Name);
        }

        [Test]
        public async Task SetAlbumArtist_saves_album_and_artist()
        {
            var album = new Album(Guid.NewGuid(), "Test Album");
            var artist = new Artist(Guid.NewGuid(), "Bob Tester");
            _testRepository.TestEntities.Add(album);
            _testRepository.TestEntities.Add(artist);


            SetAlbumArtistCommand command = new SetAlbumArtistCommand(album.Id, artist.Id);
            await _testCommandDispatcher.Dispatch(command);

            var savedAlbum = _testRepository.TestEntities.OfType<Album>().FirstOrDefault(x => x.Id == album.Id);
            var savedArtist = _testRepository.TestEntities.OfType<Artist>().FirstOrDefault(x => x.Id == artist.Id);

            Assert.NotNull(savedArtist);
            Assert.NotNull(savedAlbum);
            Assert.AreEqual(artist.Id, savedAlbum.ArtistId);
            Assert.Contains(album.Id, savedArtist.AlbumIds.ToArray());
        }
    }
}