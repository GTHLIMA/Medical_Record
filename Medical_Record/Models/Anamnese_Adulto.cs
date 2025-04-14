using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class AnamneseAdulto
{
    [Key]
    public int Id_Adulto { get; set; }

    public int Id_Paciente { get; set; }
    [ForeignKey("Id_Paciente")]
    public required Paciente Paciente { get; set; }

    public DateTime Data_Anamnese { get; set; }
    public DateTime Data_Nascimento { get; set; }
    public required string Naturalidade { get; set; }
    public string? Observacoes { get; set; }

    public required AtendimentoAdulto Atendimento { get; set; }
    public required ExamePsiquico Exame { get; set; }
}
