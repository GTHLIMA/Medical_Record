using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_Record.Data
{
    public class User
    {
        //Essa classe representa a estrutura da tabela de usuários no banco de dados. Em vez de fazer em SQL, é feito em C#

        [Key]
        public int Id { get; set; }

        public required string Password { get; set; }
    }
}
