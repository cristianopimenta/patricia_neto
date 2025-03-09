using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace web.Controller.Services
{
    public class DatabaseBackupScheduler : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<DatabaseBackupScheduler> _logger;

        public DatabaseBackupScheduler(IServiceProvider serviceProvider, ILogger<DatabaseBackupScheduler> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Serviço de Backup iniciado.");

            while (!stoppingToken.IsCancellationRequested)
            {
                // Calcula o tempo restante até 23:59
                var now = DateTime.Now;
                var nextRun = now.Date.AddDays(1).AddMinutes(-1); // Próximo 23:59
                var delay = nextRun - now;

                _logger.LogInformation($"Próximo backup agendado para {nextRun}");

                // Aguarda até 23:59
                if (delay > TimeSpan.Zero)
                    await Task.Delay(delay, stoppingToken);

                // Executa o backup
                await RunBackup();
            }
        }

        private async Task RunBackup()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var databaseService = scope.ServiceProvider.GetRequiredService<DatabaseService>();
                try
                {
                    // Diretório do backup
                    var backupDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Backups");
                    Directory.CreateDirectory(backupDirectory);

                    // Nome do arquivo de backup baseado apenas na data do dia
                    string backupFileName = $"backup_{DateTime.Now:yyyyMMdd}.sql";
                    string backupFilePath = Path.Combine(backupDirectory, backupFileName);

                    // Verificar se já existe um backup para o dia
                    if (Directory.GetFiles(backupDirectory, $"backup_{DateTime.Now:yyyyMMdd}*.sql").Length > 0)
                    {
                        Console.WriteLine("Backup já foi realizado hoje. Nenhuma ação necessária.");
                        return; // Sai do método sem realizar o backup
                    }

                    // Executar o backup
                    await databaseService.BackupDatabaseAsync(backupFilePath);
                    Console.WriteLine($"Backup concluído com sucesso: {backupFilePath}");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Erro ao realizar o backup: {ex.Message}");
                }
            }
        }

    }
}

