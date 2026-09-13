using System.ComponentModel.DataAnnotations;

namespace Trabalho_de_Gerenciamento.Models
{
    public class Pacientes
    {
        // Identificador único do paciente
        // Por convenção, o Entity Framework utiliza essa propriedade como chave primária
        public int Id { get; set; }

        // Nome do paciente
        // Campo obrigatório e limitado a 100 caracteres
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        // CPF do paciente
        // Campo obrigatório e limitado a 14 caracteres
        [Required]
        [StringLength(14)]
        public string CPF { get; set; }

        // Telefone do paciente
        // Campo obrigatório e limitado a 15 caracteres
        [Required]
        [StringLength(15)]
        public string Telefone { get; set; }

        // Endereço do paciente
        // Campo obrigatório e limitado a 200 caracteres
        [Required]
        [StringLength(200)]
        public string Endereco { get; set; }

        // Data de nascimento do paciente
        // Campo obrigatório
        [Required]
        public DateTime DataNascimento { get; set; }
    }
}

