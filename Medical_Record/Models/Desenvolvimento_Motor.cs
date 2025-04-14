using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class DesenvolvimentoMotor
{
    [Key]
    public int Id_Desenvolvimento { get; set; }

    public int Id_Infantil { get; set; }
    [ForeignKey("Id_Infantil")]
    public required AnamneseInfantil Anamnese { get; set; }

    public int Idade_Engatinhou { get; set; }
    public int Idade_Andou { get; set; }
    public int Idade_Falou { get; set; }

    public bool Problema_Fala { get; set; }
    public required string Detalhes_Problema_Fala { get; set; }
}
