using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Social
{
    [Key]
    public int Id_Social { get; set; }

    public int Id_Infantil { get; set; }
    [ForeignKey("Id_Infantil")]
    public required AnamneseInfantil Anamnese { get; set; }

    public string? Interacao_Pais { get; set; }
    public string? Interacao_Irmaos { get; set; }
    public string? Interacao_Outros { get; set; }
    public string? Atitude_Estranhos { get; set; }
}
