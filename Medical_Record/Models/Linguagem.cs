using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Linguagem
{
    [Key]
    public int Id_Linguagem { get; set; }

    public int Id_Exame { get; set; }
    [ForeignKey("Id_Exame")]
    public required ExamePsiquico Exame { get; set; }

    public bool Suicida { get; set; }
    public bool Disartria { get; set; }
    public bool Afasias { get; set; }
    public bool Parafasia { get; set; }
    public bool Neologismo { get; set; }
    public bool Mussitacao { get; set; }
    public bool Logorreia { get; set; }
    public bool Para_Respostas { get; set; }
}
