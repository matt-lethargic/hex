using Acme.Adapters.Command.Test;
using Acme.Adapters.Repository.Test;
using NUnit.Framework;

namespace Acme.Core.UnitTests
{
    public class ArtistUnitTests
    {
        private TestRepository _testRepository;
        private TestCommandDispatcher _testCommandDispatcher;

        [SetUp]
        public void Setup()
        {
            _testRepository = new TestRepository();
            _testCommandDispatcher = new TestCommandDispatcher();
        }
    }
}