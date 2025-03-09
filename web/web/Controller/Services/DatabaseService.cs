using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient;
using System.IO;
using System.Text;
namespace web.Controller.Services
{

    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task BackupDatabaseAsync(string backupFilePath)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                var tableNames = new List<string>();

                // Obtém os nomes das tabelas
                using (var cmd = new MySqlCommand("SHOW TABLES", conn))
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        tableNames.Add(reader.GetString(0));
                    }
                }

                // Gera o backup em um único arquivo
                await using (var writer = new StreamWriter(backupFilePath, false, Encoding.UTF8))
                {
                    await writer.WriteLineAsync("-- Backup do Banco de Dados");
                    await writer.WriteLineAsync($"-- Data: {DateTime.Now}\n");

                    foreach (var tableName in tableNames)
                    {
                        await BackupTableSchemaAsync(conn, tableName, writer);
                        await BackupTableDataAsync(conn, tableName, writer);
                    }
                }
            }
        }

        private async Task BackupTableSchemaAsync(MySqlConnection conn, string tableName, StreamWriter writer)
        {
            using (var cmd = new MySqlCommand($"SHOW CREATE TABLE `{tableName}`", conn))
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    string createTableSql = reader.GetString(1);
                    await writer.WriteLineAsync($"\n-- Estrutura da tabela `{tableName}`");
                    await writer.WriteLineAsync($"DROP TABLE IF EXISTS `{tableName}`;");
                    await writer.WriteLineAsync(createTableSql + ";\n");
                }
            }
        }

        private async Task BackupTableDataAsync(MySqlConnection conn, string tableName, StreamWriter writer)
        {
            using (var cmd = new MySqlCommand($"SELECT * FROM `{tableName}`", conn))
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var values = new List<string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        object value = reader.GetValue(i);
                        if (value == DBNull.Value)
                            values.Add("NULL");
                        else if (value is string || value is DateTime)
                            values.Add($"'{value.ToString().Replace("'", "''")}'");
                        else
                            values.Add(value.ToString());
                    }

                    string insertStatement = $"INSERT INTO `{tableName}` VALUES ({string.Join(", ", values)});";
                    await writer.WriteLineAsync(insertStatement);
                }
            }
        }
    }

}

