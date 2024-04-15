using System;

public class Logger
{
    private static Logger instance;
    private static readonly object lockObject = new object();

    /// <summary>
    /// private constructor prevent instantiation
    /// </summary>

    private Logger() 
    {
        
    }

    public static Logger Instance
    {
        get
        {
            lock (lockObject)
            {
                return instance ??= new Logger();
            }
        }
    }

    public void LogInfo(string message)
    {
        Console.WriteLine($"[INFO] {message}");
    }

    public void LogWarning(string message)
    {
        Console.WriteLine($"[WARNING] {message}");
    }

    public void LogError(string message)
    {
        Console.WriteLine($"[ERROR] {message}");
    }

    public void LogDebug(string message)
    {
        Console.WriteLine($"[DEBUG] {message}");
    }
}