using Medical_Record.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medical_Record.Models
{
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
        public required DesenvolvimentoMotor Desenvolvimento { get; set; }
        public required Social Social { get; set; }
        public required DadosEscolares DadosEscolares { get; set; }
        public required SaudeFisica SaudeFisica { get; set; }
    }

    public class AtendimentoInfantil
    {
        [Key]
        public int Id_Atendimento_Infantil { get; set; }

        public int Id_Infantil { get; set; }

        [ForeignKey("Id_Infantil")]
        public required AnamneseInfantil Anamnese { get; set; }

        public bool Neuropsicologo { get; set; }
        public bool Neuropsquiatra { get; set; }
        public bool Psicologo { get; set; }
        public bool Ambulatorio { get; set; }
        public bool Internamento { get; set; }
        public bool Encaminhado { get; set; }
        public required string Queixa_Motivo { get; set; }
    }

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
        public string? Detalhes_Problema_Fala { get; set; }
    }

    public class Social
    {
        [Key]
        public int Id_Social { get; set; }

        public int Id_Infantil { get; set; }

        [ForeignKey("Id_Infantil")]
        public required AnamneseInfantil Anamnese { get; set; }

        public required string Interacao_Pais { get; set; }
        public required string Interacao_Irmaos { get; set; }
        public required string Interacao_Outros { get; set; }
        public required string Atitude_Estranhos { get; set; }
    }

    public class DadosEscolares
    {
        [Key]
        public int Id_Escolar { get; set; }

        public int Id_Infantil { get; set; }

        [ForeignKey("Id_Infantil")]
        public required AnamneseInfantil Anamnese { get; set; }

        public bool Frequenta_Escola { get; set; }
        public int Idade_Inicio { get; set; }
        public required string Adptacao { get; set; }
        public bool Atendimento_Especializado { get; set; }
        public required string Quais_Atendimentos { get; set; }
        public required string Atendimento_Motivo { get; set; }
        public bool Problemas_Escolares { get; set; }
        public required string Tipo_Problemas { get; set; }
        public required string Quando_Comecaram { get; set; }
    }

    public class SaudeFisica
    {
        [Key]
        public int Id_Saude { get; set; }

        public int Id_Infantil { get; set; }

        [ForeignKey("Id_Infantil")]
        public required AnamneseInfantil Anamnese { get; set; }

        public required string Doencas_Infantis { get; set; }
        public required string Cirugias_Internacoes { get; set; }
        public required string Tratamentos { get; set; }
        public bool Uso_Medicamento { get; set; }
        public required string Quais_Medicamentos { get; set; }
        public required string Antecedentes_Familiares { get; set; }
        public required string Motivo_Queixa { get; set; }
        public required string Quando_Como_Iniciou { get; set; }
        public required string Enxergam_Problema { get; set; }
        public required string Espectativas { get; set; }
    }
}
