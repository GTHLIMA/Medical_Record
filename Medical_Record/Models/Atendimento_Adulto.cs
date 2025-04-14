using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class AtendimentoAdulto
{
    [Key]
    public int Id_Atendimento_Adulto { get; set; }

    public int Id_Adulto { get; set; }
    [ForeignKey("Id_Adulto")]
    public required AnamneseAdulto Anamnese { get; set; }

    public bool Neuropsicologo { get; set; }
    public bool Neuropsquiatra { get; set; }
    public bool Psicologo { get; set; }
    public bool Ambulatorio { get; set; }
    public bool Internamento { get; set; }
    public bool Encaminhado { get; set; }

    public required string Queixa_Motivo { get; set; }
    public required string Avaliacao_Demanda { get; set; }
}