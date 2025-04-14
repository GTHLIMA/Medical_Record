using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Pensamento
{
    [Key]
    public int Id_Pensamento { get; set; }

    public int Id_Exame { get; set; }
    [ForeignKey("Id_Exame")]
    public required ExamePsiquico Exame { get; set; }

    public bool Acelerado { get; set; }
    public bool Retardado { get; set; }
    public bool Fuga { get; set; }
    public bool Bloqueio { get; set; }
    public bool Prolixo { get; set; }
    public bool Repeticao { get; set; }
}
