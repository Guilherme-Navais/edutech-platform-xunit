using EduTechPlatform.App;
using Xunit;

namespace EduTechPlatform.Tests;

public class MatriculaFinanceiraServiceTests
{
    private readonly MatriculaFinanceiraService _service = new();

    [Theory]
    [InlineData(1000.00, 10, true, 500.00)]
    [InlineData(1000.00, 4, false, 900.00)]
    [InlineData(1000.00, 10, false, 1000.00)]
    public void CalcularValorMensalidade_DeveAplicarDescontosCorretamente(
        decimal valorBase, int diaPagamento, bool eBolsista, decimal valorEsperado)
    {
        // Act
        var resultado = _service.CalcularValorMensalidade(valorBase, diaPagamento, eBolsista);

        // Assert
        Assert.Equal(valorEsperado, resultado);
    }

    [Theory]
    [InlineData(false, "APROVADO", true)]
    [InlineData(true, "APROVADO", false)]
    [InlineData(false, "REPROVADO", false)]
    public void PodeRealizarRematricula_DeveValidarPendenciaESituacao(
        bool possuiPendenciaFinanceira, string situacaoAcademica, bool resultadoEsperado)
    {
        // Act
        var resultado = _service.PodeRealizarRematricula(possuiPendenciaFinanceira, situacaoAcademica);

        // Assert
        Assert.Equal(resultadoEsperado, resultado);
    }
}