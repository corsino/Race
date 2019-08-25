using Microsoft.AspNetCore.Http;
using Moq;
using System;
using Xunit;
using System.IO;
using Gyp.Corrida.Application.UseCases.Race;
using Gyp.Corrida.Domain.Race.Services;
using NSubstitute;

namespace Gyp.Corrida.Application.Tests
{
    public class RaceFileUseCaseUnitTest
    {

        [Fact]
        public void Should_Return_Invalid_Extension()
        {

            var fileMock = new Mock<IFormFile>();

            var content = "Invalid Extension";
            var fileName = "mock-file-race.pdf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

            var file = fileMock.Object;
            var isValidFileRace = FileRace.IsValid(file);

            Assert.False(isValidFileRace);
        }

        [Fact]
        public void Should_Return_Valid_Extension()
        {

            var fileMock = new Mock<IFormFile>();

            var content = "Valid Extension";
            var fileName = "mock-file-race.txt";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

            var file = fileMock.Object;
            var isValidFileRace = FileRace.IsValid(file);

            Assert.True(isValidFileRace);
        }

        [Fact]
        public void Should_Return_Has_No_Content()
        {

            var fileMock = new Mock<IFormFile>();

            var content = "";
            var fileName = "mock-file-race.txt";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

            var file = fileMock.Object;
            var isValidFileRace = FileRace.IsValid(file);

            Assert.False(isValidFileRace);
        }

        [Fact]
        public void Should_Return_Has_Content()
        {

            var fileMock = new Mock<IFormFile>();

            var content = "Has File Content";
            var fileName = "mock-file-race.txt";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

            var file = fileMock.Object;

            var isValidFileRace = FileRace.IsValid(file);

            Assert.True(isValidFileRace);
        }


        [Fact]
        public void Should_Return_Stream_Reader_Object()
        {

            var fileMock = new Mock<IFormFile>();
            var raceServiceMock = Substitute.For<IRaceService>();

            var content = "File Content";
            var fileName = "mock-file-race.txt";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

            var file = fileMock.Object;

            RaceUseCase raceService = new RaceUseCase(raceServiceMock);
            var raceValidType = raceService.GetRaceContentFileStream(file);

            Assert.IsType<StreamReader>(raceValidType);

        }
    }
}
