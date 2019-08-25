using Gyp.Corrida.Domain.Race;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Gyp.Corrida.Domain.Tests
{
    public class LapDomainUnitTest
    {
        [Fact]
        public void Should_Return_Valid_Object_Line_Format_One()
        {
            string mockLine = "23:49:08.277      038 – F.MASSA                           1		1:02.852                        44,275";
            var lap = Lap.BuildLapObject(mockLine);
            
            Assert.NotNull(lap);
        }

        [Fact]
        public void Should_Return_Valid_Object_Line_Format_Two()
        {
            string mockLine = "23:49:11.075      002 – K.RAIKKONEN                       1             1:04.108                        43,408";
            var lap = Lap.BuildLapObject(mockLine);

            Assert.NotNull(lap);
        }

        [Fact]
        public void Should_Fail_No_Datetime_Present_In_Model()
        {
            string mockLine = "002 – K.RAIKKONEN                       1             1:04.108                        43,408";
            Assert.Throws<FormatException>(() => Lap.BuildLapObject(mockLine));
        }

        [Fact]
        public void Should_Fail_No_Data_Present_In_Model()
        {
            string mockLine = "";
            Assert.Throws<ArgumentOutOfRangeException>(() => Lap.BuildLapObject(mockLine));
        }

        [Fact]
        public void Should_Fail_Invalid_DateTime()
        {
            string mockLine = "invalid format";
            Assert.Throws<FormatException>(() => Lap.GetTimeSpanFromLapString(mockLine));
        }

        [Fact]
        public void Should_Return_Converted_TimeSpan_From_Lap_String()
        {
            string mockLine = "2:10.434";
            Assert.IsType<TimeSpan>(Lap.GetTimeSpanFromLapString(mockLine));
        }


        [Fact]
        public void Should_Return_Four_Valid_Laps()
        {
            List<Lap> totalValidLaps = new List<Lap>();

            totalValidLaps.Add(new Lap() { LapNumber = 1 });

            totalValidLaps.Add(new Lap() { LapNumber = 2 });

            totalValidLaps.Add(new Lap() { LapNumber = 3 });

            totalValidLaps.Add(new Lap() { LapNumber = 4 });

            totalValidLaps.Add(new Lap() { LapNumber = 5 });

            Assert.Equal(4, Lap.GetTotalValidLaps(totalValidLaps).ToList().Count);
        }

    }
}
