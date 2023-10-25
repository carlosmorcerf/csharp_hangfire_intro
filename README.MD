# Projeto Hangfire e C#: Rodando Processos em Background

Este projeto é uma demonstração de como usar o Hangfire para executar processos em background em um aplicativo C#. Neste exemplo, criamos uma API simples e usamos o Hangfire para agendar e executar tarefas em segundo plano, como o envio de e-mails.

## Artigo

Para obter um guia completo sobre como configurar e usar este projeto, consulte o [artigo associado](https://tinyurl.com/3evfr6r3) no meu blog.

## Pré-requisitos

- .NET Core SDK
- Um servidor SQL Server ou Docker (se você não tiver o MSSQL instalado localmente, você pode utilizar o docker-compose.yml)
- Configuração de servidor SMTP (para envio de e-mails). Ex: Mailtrap.

## Como Usar

1. Clone este repositório.

```bash
git clone https://github.com/carlosmorcerf/csharp_hangfire_intro.git
```

2. Configure a connection string do SQL Server no arquivo `appsettings.Development.json`.

3. Configure o servidor SMTP no arquivo `Program.cs`.

4. Execute o projeto.

```bash
dotnet run
```

5. Acesse o painel de controle do Hangfire em `http://localhost:5053/hangfire` (ou a URL que você configurou).

## Contribuição

Se você deseja contribuir para este projeto, fique à vontade para criar um fork e enviar uma solicitação de pull.

## Licença

Este projeto está licenciado sob a Licença MIT - consulte o arquivo [LICENSE](LICENSE) para obter detalhes.
