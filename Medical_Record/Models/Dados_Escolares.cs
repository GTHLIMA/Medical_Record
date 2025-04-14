using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class DadosEscolares
{
    [Key]
    public int Id_Escolar { get; set; }

    public int Id_Infantil { get; set; }
    [ForeignKey("Id_Infantil")]
    public required AnamneseInfantil Anamnese { get; set; }

    public bool Frequenta_Escola { get; set; }
    public int Idade_Inicio { get; set; }
    public required string Adaptacao { get; set; }

    public bool Atendimento_Especializado { get; set; }
    public required string Quais_Atendimentos { get; set; }
    public required string Atendimento_Motivo { get; set; }

    public bool Problemas_Escolares { get; set; }
    public string? Tipo_Problemas { get; set; }
    public string? Quando_Comecaram { get; set; }
}
