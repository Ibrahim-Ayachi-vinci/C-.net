using System;
using System.IO;

class Logger
{
    // Déclaration du délégué
    public delegate void LogHandler(string message);

    // Instance du délégué
    public LogHandler Log;

    // Méthode pour enregistrer un message
    public void LogMessage(string message)
    {
        Log?.Invoke(message);  // Appelle toutes les méthodes attachées au délégué
    }
}

class ConsoleLogger
{
    // Méthode statique pour écrire dans la console
    public static void LogMessage(string message)
    {
        Console.WriteLine("ConsoleLogger : " + message);
    }
}

class FileLogger
{
    // Méthode statique pour écrire dans le fichier
    public static void LogMessage(string message)
    {
        string docPath = "C:\\Users\\ayach\\Desktop\\école\\3e année\\C-.net\\Delegate\\Delegate\\fileLog.txt";

        try
        {
            using (StreamWriter writer = new StreamWriter(docPath, true))
            {
                writer.WriteLine("FileLogger : " + message);
            }
            Console.WriteLine("Écriture terminée dans fileLog.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur lors de l'écriture dans le fichier : " + ex.Message);
        }
    }
}

class Test
{
    static void Main(string[] args)
    {
        // Création d'un logger
        Logger logger = new Logger();

        // Attacher la méthode ConsoleLogger et FileLogger au délégué
        logger.Log += ConsoleLogger.LogMessage;
        logger.Log += FileLogger.LogMessage;

        // Enregistrer un message
        logger.LogMessage("Je suis celui qui écrit");
    }
}
