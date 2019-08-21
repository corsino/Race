using Microsoft.AspNetCore.Http;
using Moq;
using System;
using Xunit;
using System.IO;
using Gyp.Corrida.Application.UseCases.File;

namespace Gyp.Corrida.Application.Tests
{
    public class RaceFileUseCaseUnitTest
    {

        [Fact]
        public void Should_Return_Invalid_File_Empty_Content()
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

            RaceFileUseCase raceService = new RaceFileUseCase();
            RaceFileRequest raceFileRequest = new RaceFileRequest(file);
            var raceValidateResult = raceService.ValidateInputFile(raceFileRequest);
            Assert.False(raceValidateResult.Success);
        }

        [Fact]
        public void Should_Return_Invalid_File_Format()
        {

            var fileMock = new Mock<IFormFile>();

            var content = "Invalid Extension";
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

            RaceFileUseCase raceService = new RaceFileUseCase();
            RaceFileRequest raceFileRequest = new RaceFileRequest(file);
            var raceValidateResult = raceService.ValidateInputFile(raceFileRequest);
            Assert.True(raceValidateResult.Success);

        }

        [Fact]
        public void Should_Return_Stream_Reader_File_Object()
        {

            var fileMock = new Mock<IFormFile>();

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

            RaceFileUseCase raceService = new RaceFileUseCase();
            var raceValidType = raceService.GetRaceContentFileStream(file);

            Assert.IsType<StreamReader>(raceValidType);

        }


        [Fact]
        public void Should_Return_Valid_File_Format()
        {

            var fileMock = new Mock<IFormFile>();

            var content = "Has content and extension";
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

            RaceFileUseCase raceService = new RaceFileUseCase();
            RaceFileRequest raceFileRequest = new RaceFileRequest(file);
            var raceValidateResult = raceService.ValidateInputFile(raceFileRequest);
            Assert.True(raceValidateResult.Success);
        }

    }
}
