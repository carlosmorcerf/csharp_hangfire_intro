using EmailApi.Models;
using EmailApi.Services;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Configuração do Hangfire usando o SQL Server
var hangfireConnectionString = builder.Configuration.GetConnectionString("HangfireConnection");
builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)  // Define o nível de compatibilidade dos dados.
    .UseSimpleAssemblyNameTypeSerializer()  // Utiliza um serializador simples de nomes de assemblies.
    .UseRecommendedSerializerSettings()  // Configurações recomendadas para o serializador.
    .UseSqlServerStorage(hangfireConnectionString));  // Armazenamento no SQL Server.
builder.Services.AddHangfireServer();  // Configuração do servidor Hangfire.

// Configuração do FluentEmail para envio de e-mails
builder.Services
    .AddFluentEmail("seu_endereco_de_email@exemplo.com")  // Substitua pelo seu endereço de e-mail.
    .AddSmtpSender(new SmtpClient("seu_servidor_smtp.com", 587)  // Substitua pelo seu servidor SMTP e porta.
    {
        EnableSsl = true,  // Habilita SSL para conexão segura (se necessário).
        Credentials = new NetworkCredential("seu_usuario_smtp", "sua_senha_smtp")  // Substitua pelo seu usuário e senha SMTP.
    });


var app = builder.Build();

// Configuração do painel de controle do Hangfire
app.UseHangfireDashboard();

// Configuração de endpoints do Hangfire Dashboard
app.UseRouting();

app.MapHangfireDashboard(); // Endpoint do painel de controle: http://localhost:5053/hangfire

app.MapGet("/", () => "Hello World!");  // Rota padrão de "Hello World!"

// Endpoint para enviar e-mails em segundo plano
app.MapPost("/mensagens", ([FromBody] MensagemDto mensagem) =>
{
    BackgroundJob.Enqueue<EmailService>((s) => s.EnviarEmail(mensagem));
    // Agendamento de um trabalho em segundo plano para enviar o e-mail.
});

app.Run();
