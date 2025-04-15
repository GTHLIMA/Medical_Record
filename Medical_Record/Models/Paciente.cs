using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_Record.Models
{
    public class Paciente
    {

        [Key]
        public int Id_Paciente { get; set; }
        public required string Nome { get; set; }
        public string? Email { get; set; }
        public int? Idade { get; set; }
        public string? Telefone { get; set; }
        public string? Sexo { get; set; }
    }

    public class EvolucaoPaciente
    {
        [Key]
        public int Id_Evolucao { get; set; }

        public int Id_Paciente { get; set; }

        [ForeignKey("Id_Paciente")]
        public required Paciente Paciente { get; set; }

        public DateTime Data { get; set; }

        public required string Descricao { get; set; }
    }
}
