using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class AnamneseInfantil
{
    [Key]
    public int Id_Infantil { get; set; }

    public int Id_Paciente { get; set; }
    [ForeignKey("Id_Paciente")]
    public required Paciente Paciente { get; set; }

    public DateTime Data_Anamnese { get; set; }
    public required string Nome_Mae { get; set; }
    public int Idade_Mae { get; set; }
    public required string Profissao_Mae { get; set; }
    public required string Nome_Pai { get; set; }
    public int Idade_Pai { get; set; }
    public required string Profissao_Pai { get; set; }

    public DateTime Data_Nascimento { get; set; }
    public required string Naturalidade { get; set; }

    public int Irmaos { get; set; }
    public int Masculino { get; set; }
    public int Feminino { get; set; }

    public string? Observacoes { get; set; }

    public required AtendimentoInfantil Atendimento { get; set; }
    public required Concepcao Concepcao { get; set; }
    public required DesenvolvimentoMotor DesenvolvimentoMotor { get; set; }
    public required Social Social { get; set; }
    public required DadosEscolares DadosEscolares { get; set; }
    public required SaudeFisica SaudeFisica { get; set; }
}
