using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medical_Record.Models
{
    public class AnamneseAdulto
    {
        [Key]
        public int Id_Adulto { get; set; }
        public int Id_Paciente { get; set; }

        [ForeignKey("Id_Paciente")]
        public required Paciente Paciente { get; set; } 

        public DateTime Data_Anamnese { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public required string Naturalidade { get; set; }
        public string? Observacoes { get; set; }

        public required AtendimentoAdulto Atendimento { get; set; }
        public required ExamePsiquico Exame { get; set; }
    }

    public class AtendimentoAdulto
    {
        [Key]
        public int Id_Atendimento_Adulto { get; set; }
        public int Id_Adulto { get; set; }

        [ForeignKey("Id_Adulto")]
        public required AnamneseAdulto Anamnese { get; set; }

        public bool Neuropsicologo { get; set; }
        public bool Neuropsquiatra { get; set; }
        public bool Psicologo { get; set; }
        public bool Ambulatorio { get; set; }
        public bool Internamento { get; set; }
        public bool Encaminhado { get; set; }
        public required string Queixa_Motivo { get; set; }
        public required string Avaliacao_Demanda { get; set; }
    }

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

    public class Humor
    {
        [Key]
        public int Id_Humor { get; set; }
        public int Id_Exame { get; set; }

        [ForeignKey("Id_Exame")]
        public required ExamePsiquico Exame { get; set; }

        public bool IsHumorous { get; set; } // Renamed to avoid conflict with the class name  
        public bool Exaltado { get; set; }
        public bool Baixo_Humor { get; set; }
        public bool Quebra_Subta { get; set; }
    }
}
