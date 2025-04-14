using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class EvolucaoPaciente
{
    [Key]
    public int Id_Evolucao { get; set; }

    public int Id_Paciente { get; set; }
    [ForeignKey("Id_Paciente")]
    public required Paciente Paciente { get; set; }

    public DateTime Data { get; set; }
    public string? Descricao { get; set; }
}
