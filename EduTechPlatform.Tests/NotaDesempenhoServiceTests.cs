using EduTechPlatform.App;
using Xunit;

namespace EduTechPlatform.Tests;

public class NotaDesempenhoServiceTests
{
    private readonly NotaDesempenhoService _service = new();

    [Theory]
    [InlineData(7.0, 7.0, 7.0, 7.0)]
    [InlineData(10.0, 10.0, 5.0, 8.0)]
    public void CalcularMediaPonderada_DeveRetornarMediaCorreta(
        decimal nota1, decimal nota2, decimal notaProjeto, decimal mediaEsperada)
    {
        // Act
        var resultado = _service.CalcularMediaPonderada(nota1, nota2, notaProjeto);

        // Assert
        Assert.Equal(mediaEsperada, resultado);
    }

    [Theory]
    [InlineData(8.5, "APROVADO")]
    [InlineData(6.0, "RECUPERACAO")]
    [InlineData(4.2, "REPROVADO")]
    public void ObterSituacaoAcademica_DeveRetornarSituacaoCorreta(
        decimal mediaFinal, string situacaoEsperada)
    {
        // Act
        var resultado = _service.ObterSituacaoAcademica(mediaFinal);

        // Assert
        Assert.Equal(situacaoEsperada, resultado);
    }
}