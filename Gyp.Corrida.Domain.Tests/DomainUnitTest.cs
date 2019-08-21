using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.IO;
using Xunit;

namespace Gyp.Corrida.Domain.Tests
{
    public class DomainUnitTest
    {

        

        //[Fact]
        //public void Deve_Existir_4_voltas()
        //{
        //    RaceFileUseCase raceService = new RaceFileUseCase();

        //    Assert.Equal(4,raceService.UploadRaceFile());
        //}

        //[Fact]
        //public void Deve_gerar_lancamento_de_credito()
        //{
        //    var credito = new Valor(1000);
        //    var conta = new ContaCorrente(Guid.NewGuid(), 1, 100);

        //    conta.Creditar(credito);

        //    conta.Lancamentos.Count().Should().Be(1);

        //    var lancamento = conta.Lancamentos.First();
        //    lancamento.Conta.Should().Be(conta);
        //    lancamento.Valor.Should().Be(credito);
        //    lancamento.Should().BeOfType<Credito>();
        //}

        //[Fact]
        //public void Deve_gerar_lancamento_de_debito()
        //{
        //    var debito = new Valor(1000);
        //    var conta = new ContaCorrente(Guid.NewGuid(), 1, 100);

        //    conta.Debitar(debito);

        //    conta.Lancamentos.Count().Should().Be(1);

        //    var lancamento = conta.Lancamentos.First();

        //    lancamento.Conta.Should().Be(conta);
        //    lancamento.Valor.Should().Be(debito);
        //    lancamento.Should().BeOfType<Debito>();
        //}
    }
}
