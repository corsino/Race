using Gyp.Corrida.Domain.Race;
using Gyp.Corrida.Domain.Race.Services;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Gyp.Corrida.Domain.Tests
{
    public class RaceServiceDomainUnitTest
    {
        [Fact]
        public void Should_Return_Zero_Completed_Laps()
        {
            List<Lap> lapList = new List<Lap>();
            var laps = Race.Race.GetCompletedLaps(lapList);
            
            Assert.Equal(0,laps);
        }

        [Fact]
        public void Should_Return_Two_Completed_Laps()
        {
            List<Lap> lapList = new List<Lap>();
            lapList.Add(new Lap() { LapNumber = 1 });
            lapList.Add(new Lap() { LapNumber = 2 });

            var laps = Race.Race.GetCompletedLaps(lapList);

            Assert.Equal(2, laps);
        }
       
    }
}
