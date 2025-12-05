namespace Folha.Domain.Services;

public class CalculadoraFolha
{
    public decimal ValorHora(decimal salarioBase) => Math.Round(salarioBase / 220m, 2);
    public decimal ValorHoraNoturna(decimal valorHora) => Math.Round(valorHora * 1.20m, 2);
    public decimal ValorHoraExtraDiurna(decimal valorHora) => Math.Round(valorHora * 1.50m, 2);
    public decimal ValorHoraExtraNoturna(decimal valorHora) => Math.Round(valorHora * 1.80m, 2);

    public (decimal inss, decimal baseIR) CalcularINSS(decimal salarioBruto)
    {
        // Faixas 2025 (exemplo)
        decimal restante = salarioBruto;
        decimal inss = 0;
        (decimal teto, decimal aliquota)[] faixas = {
            (1518.00m, 0.075m),
            (2793.88m, 0.09m),
            (4190.83m, 0.12m),
            (8157.41m, 0.14m)
        };
        decimal anterior = 0;
        foreach (var f in faixas)
        {
            var baseFaixa = Math.Max(Math.Min(restante, f.teto - anterior), 0);
            inss += baseFaixa * f.aliquota;
            anterior = f.teto;
        }
        inss = Math.Round(inss, 2);
        return (inss, salarioBruto - inss);
    }

    public decimal CalcularIRRF(decimal baseIR)
    {
        if (baseIR <= 1903.99m) return 0m;
        if (baseIR <= 2826.65m) return Math.Round(baseIR * 0.075m, 2);
        if (baseIR <= 3751.05m) return Math.Round(baseIR * 0.15m, 2);
        if (baseIR <= 4664.68m) return Math.Round(baseIR * 0.225m, 2);
        return Math.Round(baseIR * 0.275m, 2);
    }
}
