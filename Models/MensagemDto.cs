using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace EmailApi.Models
{
    public class MensagemDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MaxLength(150, ErrorMessage = "O campo Nome não pode exceder 150 caracteres.")]
        public string Nome { get; set; }  // Nome do remetente da mensagem.

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de e-mail válido.")]
        [MaxLength(150, ErrorMessage = "O campo Email não pode exceder 150 caracteres.")]
        public string Email { get; set; }  // Endereço de e-mail do remetente.

        [Required(ErrorMessage = "O campo Assunto é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo Assunto não pode exceder 100 caracteres.")]
        public string Assunto { get; set; }  // Assunto da mensagem.

        [Required(ErrorMessage = "O campo Mensagem é obrigatório.")]
        [MaxLength(500, ErrorMessage = "O campo Mensagem não pode exceder 500 caracteres.")]
        public string Mensagem { get; set; }  // Conteúdo da mensagem.
    }
}
