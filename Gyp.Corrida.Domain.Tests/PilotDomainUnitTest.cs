using Gyp.Corrida.Domain.Race;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Gyp.Corrida.Domain.Tests
{
    public class PilotDomainUnitTest
    {
        [Fact]
        public void Should_Return_Pilot_With_Three_Digits()
        {
            var lapList = new List<Lap>();
            lapList.Add(new Lap() { PilotNumber = 1 });
            lapList.Add(new Lap() { PilotNumber = 1 });

            var pilotCode = Pilot.GetPilotNumber(lapList);
            
            Assert.Equal(3,pilotCode.Length);
        }

        [Fact]
        public void Should_Fail_Multiples_PilotNumber_In_Model()
        {
            var lapList = new List<Lap>();
            lapList.Add(new Lap() { PilotNumber = 1 });
            lapList.Add(new Lap() { PilotNumber = 2 });

            Assert.Throws<ArgumentOutOfRangeException>(() => Pilot.GetPilotNumber(lapList));
        }

        [Fact]
        public void Should_Return_String_First_Pilot_Name_In_List()
        {
            var lapList = new List<Lap>();
            lapList.Add(new Lap() { PilotName = "F. MASSA" });
            lapList.Add(new Lap() { PilotName = "F. MASS" });

            var pilotName = Pilot.GetPilotName(lapList);

            Assert.NotEmpty(pilotName);
        }
        [Fact]
        public void Should_Fail_Empty_String_First_Pilot_Name_In_List()
        {
            var lapList = new List<Lap>();
            lapList.Add(new Lap() { PilotName = "" });
            lapList.Add(new Lap() { PilotName = "" });

            var pilotName = Pilot.GetPilotName(lapList);

            Assert.Empty(pilotName);
        }

        [Fact]
        public void Should_Return_Pilot_TotalTime_TimeSpan_Object()
        {
            var timeSpanList = new List<TimeSpan>();

            var totalTime = Pilot.GetPilotTotalTime(timeSpanList);

            Assert.IsType<TimeSpan>(totalTime);
        }

        [Fact]
        public void Should_Fail_Best_Pilot_Lap()
        {
            List<Lap> bestLap = new List<Lap>();

            bestLap.Add(new Lap() { LapTime = "1:02.769", LapNumber= 1 });
            bestLap.Add(new Lap() { LapTime = "1:02.770", LapNumber = 2 });
            bestLap.Add(new Lap() { LapTime = "1:02.771", LapNumber = 3 });
            bestLap.Add(new Lap() { LapTime = "1:02.772", LapNumber = 4 });
            bestLap.Add(new Lap() { LapTime = "1:02.773", LapNumber = 5 });
            BestLapDetail bestLapDetail = Lap.GetBestLap(bestLap);
            Assert.False(bestLapDetail.LapNumber == 2, "Not a best Lap");
        }

        [Fact]
        public void Should_Return_Best_Pilot_Lap()
        {
            List<Lap> bestLap = new List<Lap>();

            bestLap.Add(new Lap() { LapTime = "1:02.769", LapNumber = 1 });
            bestLap.Add(new Lap() { LapTime = "1:02.770", LapNumber = 2 });
            bestLap.Add(new Lap() { LapTime = "1:02.771", LapNumber = 3 });
            bestLap.Add(new Lap() { LapTime = "1:02.772", LapNumber = 4 });
            bestLap.Add(new Lap() { LapTime = "1:02.773", LapNumber = 5 });

            BestLapDetail bestLapDetail = Lap.GetBestLap(bestLap);
            Assert.True(bestLapDetail.LapNumber == 1, "Best Lap");
        }

        [Fact]
        public void Should_Not_Consider_Lap_Five_As_Best_Pilot_Lap()
        {
            List<Lap> bestLap = new List<Lap>();

            bestLap.Add(new Lap() { LapTime = "1:02.769", LapNumber = 1 });
            bestLap.Add(new Lap() { LapTime = "1:02.770", LapNumber = 2 });
            bestLap.Add(new Lap() { LapTime = "1:02.771", LapNumber = 3 });
            bestLap.Add(new Lap() { LapTime = "1:02.772", LapNumber = 4 });
            bestLap.Add(new Lap() { LapTime = "1:02.768", LapNumber = 5 });

            BestLapDetail bestLapDetail = Lap.GetBestLap(bestLap);
            Assert.False(bestLapDetail.LapNumber == 5, "Best Lap could not be >5");
        }
    }
}
