using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class ExamePsiquico
{
    [Key]
    public int Id_Exame { get; set; }

    public int Id_Adulto { get; set; }
    [ForeignKey("Id_Adulto")]
    public required AnamneseAdulto Anamnese { get; set; }

    public required string Aparencia { get; set; }
    public required string Comportamento { get; set; }

    public bool Cooperativo { get; set; }
    public bool Resistente { get; set; }
    public bool Indiferente { get; set; }

    public required string Memoria { get; set; }
    public required string Inteligencia { get; set; }
    public required string Sensopercepcao { get; set; }

    public required Pensamento Pensamento { get; set; }
    public required Linguagem Linguagem { get; set; }
    public required Humor Humor { get; set; }
}
