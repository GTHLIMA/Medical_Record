using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Concepcao
{
    [Key]
    public int Id_Concepcao { get; set; }

    public int Id_Infantil { get; set; }
    [ForeignKey("Id_Infantil")]
    public required AnamneseInfantil Anamnese { get; set; }

    public bool Gravidez_Planejada { get; set; }
    public int Idade_Concepcao_Mae { get; set; }
    public int Idade_Concepcao_Pai { get; set; }
    public bool Gestacoes_Anteriores { get; set; }
    public int Quantidade_Gestacoes { get; set; }
    public required string Ordem_Nascimento { get; set; }
}
