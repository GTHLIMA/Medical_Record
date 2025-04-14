using System.ComponentModel.DataAnnotations;

public class Paciente
{
    [Key]
    public int Id_Paciente { get; set; }

    public required string Nome { get; set; }
    public int Idade { get; set; }
    public required string Telefone { get; set; }
    public string? Email { get; set; }
    public required string Sexo { get; set; }
}
