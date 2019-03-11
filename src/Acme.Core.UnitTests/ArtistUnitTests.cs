using System;
using System.Linq;
using System.Threading.Tasks;
using Acme.Adapters.Command.Test;
using Acme.Adapters.Repository.Test;
using Acme.Core.Artists;
using Acme.Core.Artists.CommandHandlers;
using Acme.Core.Artists.Commands;
using NUnit.Framework;

namespace Acme.Core.UnitTests
{
    public class ArtistUnitTests
    {
        private TestRepository _testRepository;
        private TestCommandBus _testCommandBus;

        [SetUp]
        public void Setup()
        {
            _testRepository = new TestRepository();
            _testCommandBus = new TestCommandBus();

            CreateArtistCommandHandler createArtistCommandHandler = new CreateArtistCommandHandler(_testRepository);
            _testCommandBus.RegisterHandler<CreateArtistCommand>(x=> createArtistCommandHandler.Handle(x));
        }

        [Test]
        public async Task CreateAblum_writes_to_repository()
        {
            CreateArtistCommand command = new CreateArtistCommand(Guid.NewGuid(), "Bobby Tester");
            await _testCommandBus.Dispatch(command);

            var savedEntity = _testRepository.TestEntities.FirstOrDefault(x => x.Id == command.Id) as Artist;
            Assert.IsNotNull(savedEntity);
            Assert.AreEqual(command.Id, savedEntity.Id);
            Assert.AreEqual(command.Name, savedEntity.Name);
        }
    }
}