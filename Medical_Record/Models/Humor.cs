using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Humor
{
    [Key]
    public int Id_Humor { get; set; }

    public int Id_Exame { get; set; }
    [ForeignKey("Id_Exame")]
    public required ExamePsiquico Exame { get; set; }

    public bool HumorValue { get; set; }
    public bool Exaltado { get; set; }
    public bool Baixo_Humor { get; set; }
    public bool Quebra_Subta { get; set; }
}
