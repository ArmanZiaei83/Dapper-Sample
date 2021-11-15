using System;
using System.Linq;
using Dapper;
using FluentMigrator.Runner;
using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace Migration
{
    class Program
    {
        private const string ConnectionString =
            @"Server = .; Initial Catalog = UserTestDb; Integrated Security = true";

        private static void Main(string[] args)
        {
            CheckDatabaseExistence("UserTestDb");
            var serviceProvider = CreateServices(ConnectionString);
            using var scope = serviceProvider.CreateScope();
            
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }

        private static IServiceProvider CreateServices(string connectionString)
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(_202111152203_InitializedDb).Assembly).For
                    .Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }

        private static void CheckDatabaseExistence(string name)
        {
            var query = @$"SELECT * FROM sys.databases WHERE name = '{name}'";
            var command = new SqlConnection($"Server = .; Integrated Security = true;");
            var result = command.Query(query);
            if (!result.Any())
                command.Execute($"CREATE DATABASE {name}");
        }
    }
}