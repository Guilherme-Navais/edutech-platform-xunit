namespace EduTechPlatform.App;

public class FrequenciaService
{
    public double CalcularPorcentagemPresenca(int aulasTotais, int faltas)
    {
        return ((aulasTotais - faltas) / (double)aulasTotais) * 100.0;
    }

    public bool AprovadoPorFrequencia(int aulasTotais, int faltas)
    {
        double porcentagem = CalcularPorcentagemPresenca(aulasTotais, faltas);
        return porcentagem >= 75.0;
    }
}