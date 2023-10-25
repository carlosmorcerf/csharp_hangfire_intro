using EmailApi.Models;
using FluentEmail.Core;

namespace EmailApi.Services
{
    public class EmailService
    {
        private readonly IFluentEmail _fluentEmail;

        public EmailService(IFluentEmail fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }

        /// <summary>
        /// Envia um e-mail com base nos dados fornecidos na mensagem.
        /// </summary>
        /// <param name="mensagem">Os dados da mensagem a ser enviada.</param>
        public async Task EnviarEmail(MensagemDto mensagem)
        {
            var result = await _fluentEmail
                    .SetFrom(mensagem.Email, mensagem.Nome) // Define o nome e e-mail do remetente.
                    .To("teste@teste.com.br") // Define o e-mail do destinatário.
                    .Subject(mensagem.Assunto) // Define o assunto do e-mail.
                    .Body(mensagem.Mensagem) // Define o corpo em HTML do e-mail.
                    .SendAsync();

            return;
        }
    }
}