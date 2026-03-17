// DESAFIO: Gerenciador de Configurações da Aplicação
// PROBLEMA: Uma aplicação precisa carregar configurações de banco de dados, APIs e cache
// uma única vez e compartilhar entre todos os componentes. O código atual permite múltiplas
// instâncias, causando inconsistências e desperdício de recursos

using System;
using System.Collections.Generic;
using DesignPatternChallenge.src.Managers;

namespace DesignPatternChallenge
{
    // Contexto: Sistema que precisa de configurações centralizadas e consistentes
    // As configurações são carregadas de arquivos, variáveis de ambiente e banco de dados
    
    // Serviços da aplicação que precisam das configurações
    public class DatabaseService
    {
        private readonly ConfigurationManager _config;

        public DatabaseService()
        {
            // Problema: Cada serviço cria sua própria instância
            _config = ConfigurationManager.Instance;
        }

        public void Connect()
        {
            var connectionString = _config.GetSetting("DatabaseConnection");
            Console.WriteLine($"[DatabaseService] Conectando ao banco: {connectionString}");
        }
    }

    public class ApiService
    {
        private readonly ConfigurationManager _config;

        public ApiService()
        {
            // Problema: Nova instância = novos carregamentos desnecessários
            _config = ConfigurationManager.Instance;
        }

        public void MakeRequest()
        {
            var apiKey = _config.GetSetting("ApiKey");
            Console.WriteLine($"[ApiService] Fazendo requisição com API Key: {apiKey}");
        }
    }

    public class CacheService
    {
        private readonly ConfigurationManager _config;

        public CacheService()
        {
            // Problema: Mais uma instância duplicada
            _config = ConfigurationManager.Instance;
        }

        public void Connect()
        {
            var cacheServer = _config.GetSetting("CacheServer");
            Console.WriteLine($"[CacheService] Conectando ao cache: {cacheServer}");
        }
    }

    public class LoggingService
    {
        private readonly ConfigurationManager _config;

        public LoggingService()
        {
            _config = ConfigurationManager.Instance;
        }

        public void Log(string message)
        {
            var logLevel = _config.GetSetting("LogLevel");
            Console.WriteLine($"[LoggingService] [{logLevel}] {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Configurações ===\n");

            // Problema 1: Múltiplas instâncias são criadas
            Console.WriteLine("Inicializando serviços...\n");
            
            var dbService = new DatabaseService();
            var apiService = new ApiService();
            var cacheService = new CacheService();
            var logService = new LoggingService();

            Console.WriteLine("\nUsando os serviços...\n");
            
            dbService.Connect();
            apiService.MakeRequest();
            cacheService.Connect();
            logService.Log("Sistema iniciado");

            // Problema 2: Configurações podem ficar inconsistentes
            Console.WriteLine("\n--- Tentativa de atualização ---\n");
            
            var config1 = ConfigurationManager.Instance;
            config1.UpdateSetting("LogLevel", "Debug");
        }
    }
}
