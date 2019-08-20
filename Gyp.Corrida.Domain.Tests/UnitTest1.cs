using Gyp.Corrida.Domain.Corrida;
using System;
using Xunit;

namespace Gyp.Corrida.Domain.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Deve_Existir_4_voltas()
        {
            RaceService raceService = new RaceService();

            Assert.Equal(4,raceService.CalculaVolta());
        }
    }
}
