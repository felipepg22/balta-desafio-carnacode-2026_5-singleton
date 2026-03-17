using System;

namespace DesignPatternChallenge.src.Managers;

public class ConfigurationManager
{   
    private static ConfigurationManager _instance;
    private static readonly object _lock = new();

    private Dictionary<string, string> _settings = new ();

    private ConfigurationManager()
    {
        LoadSettings();
    }

    private void LoadSettings()
    {
        Console.WriteLine("🔄 Carregando configurações...");
            
        // Simulando operação custosa de carregamento
        System.Threading.Thread.Sleep(200);

        // Carregando configurações de diferentes fontes
        _settings["DatabaseConnection"] = "Server=localhost;Database=MyApp;";
        _settings["ApiKey"] = "abc123xyz789";
        _settings["CacheServer"] = "redis://localhost:6379";
        _settings["MaxRetries"] = "3";
        _settings["TimeoutSeconds"] = "30";
        _settings["EnableLogging"] = "true";
        _settings["LogLevel"] = "Information";

        Console.WriteLine("✅ Configurações carregadas com sucesso!\n");
    }

    public string GetSetting(string key)
    {
        if (_settings.ContainsKey(key))
            return _settings[key];

        return null;
    } 

    public void UpdateSetting(string key, string value)
    {
        _settings[key] = value;
        Console.WriteLine($"Configuração atualizada: {key} = {value}");
    }

    public static ConfigurationManager Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ConfigurationManager();
                    }
                }
            }
            return _instance;
        }
    }
}
