using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class AtendimentoInfantil
{
    [Key]
    public int Id_Atendimento_Infantil { get; set; }

    public int Id_Infantil { get; set; }
    [ForeignKey("Id_Infantil")]
    public required AnamneseInfantil Anamnese { get; set; }

    public bool Neuropsicologo { get; set; }
    public bool Neuropsquiatra { get; set; }
    public bool Psicologo { get; set; }
    public bool Ambulatorio { get; set; }
    public bool Internamento { get; set; }
    public bool Encaminhado { get; set; }

    public required string Queixa_Motivo { get; set; }
}
