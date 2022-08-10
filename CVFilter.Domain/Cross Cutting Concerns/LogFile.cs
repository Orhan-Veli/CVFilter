using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CVFilter.Domain.Cross_Cutting_Concerns
{
    public static class LogFile
    {
        public static void Write(Errors error,string message)
        {
            AbstractLogger loggerChain = GetChainOfLoggers();
            loggerChain.LogMessage((int)error, message);
        }

        private static AbstractLogger GetChainOfLoggers()
        {
            AbstractLogger errorLogger = new ErrorLogger((int)Errors.Error);
            AbstractLogger fileLogger = new FileLogger((int)Errors.Debug);
            AbstractLogger consoleLogger = new ConsoleLogger((int)Errors.Info);

            errorLogger.SetNextLogger(fileLogger);
            fileLogger.SetNextLogger(consoleLogger);

            return errorLogger;
        }
    }
    public abstract class AbstractLogger
    {
        protected int level;
        protected AbstractLogger nextLogger;

        public void SetNextLogger(AbstractLogger nextLogger)
        {
            this.nextLogger = nextLogger;
        }

        public void LogMessage(int level, string message)
        {
            if (this.level <= level)
            {
                Write(message);
            }
            if (nextLogger != null)
            {
                nextLogger.LogMessage(level, message);
            }
        }

        abstract protected void Write(string message);
    }

    public class ConsoleLogger : AbstractLogger
    {
        public ConsoleLogger(int level)
        {
            this.level = level;
        }

        protected override void Write(string message)
        {
            Console.WriteLine("StandartLogger " + message);
        }
    }

    public class ErrorLogger : AbstractLogger
    {
        public ErrorLogger(int level)
        {
            this.level = level;
        }

        protected override void Write(string message)
        {
            Console.WriteLine("Error Console " + message);
        }
    }

    public class FileLogger : AbstractLogger
    {
        public FileLogger(int level)
        {
            this.level = level;
        }

        protected override void Write(string message)
        {
            LogWriter.WriteLog(message);
        }
    }

    public static class LogWriter
    {
        public static void WriteLog(string strLog)
        {
            string logFilePath = @"C:\Logs\Log-" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
            FileInfo logFileInfo = new FileInfo(logFilePath);
            DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append))
            {
                using (StreamWriter log = new StreamWriter(fileStream))
                {
                    log.WriteLine(strLog);
                }
            }
        }
    }

    public enum Errors
    {
        Info = 1, Debug = 2, Error = 3
    }


}
