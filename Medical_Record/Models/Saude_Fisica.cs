using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class SaudeFisica
{
    [Key]
    public int Id_Saude { get; set; }

    public int Id_Infantil { get; set; }
    [ForeignKey("Id_Infantil")]
    public required AnamneseInfantil Anamnese { get; set; }

    public string? Doencas_Infantis { get; set; }
    public string? Cirugias_Internacoes { get; set; }
    public string? Tratamentos { get; set; }

    public bool Uso_Medicamento { get; set; }
    public string? Quais_Medicamentos { get; set; }

    public string? Antecedentes_Familiares { get; set; }
    public string? Motivo_Queixa { get; set; }
    public string? Quando_Como_Iniciou { get; set; }
    public string? Enxergam_Problema { get; set; }
    public string? Espectativas { get; set; }
}
