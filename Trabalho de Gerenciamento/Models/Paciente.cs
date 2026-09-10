using System.ComponentModel.DataAnnotations;
namespace Trabalho_de_Gerenciamento.Models;

public class Paciente
{
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string CPF { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }
}
