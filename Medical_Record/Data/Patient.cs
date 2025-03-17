using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_Record.Data
{
    public class Patient
    {

        [Key]
        public int Id { get; set; }
        public required string Nome { get; set; }
        public string? Email { get; set; }
        public int? Idade { get; set; }
        public string? Telefone { get; set; }
        public string? Consultas { get; set; }
    }
}
