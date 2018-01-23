using System;
using System.IO;
using ch.wuerth.tobias.mux.Core.exceptions;
using ch.wuerth.tobias.mux.Core.logging;
using Newtonsoft.Json;

namespace ch.wuerth.tobias.mux.Core.io
{
    public static class FileInterface
    {
        public static Boolean Save<T>(T obj, String path) where T : class
        {
            if (null == obj)
            {
                LoggerBundle.Error(new ArgumentNullException(nameof(obj)));
                return false;
            }

            if (null == path)
            {
                LoggerBundle.Error(new ArgumentNullException(nameof(path)));
                return false;
            }

            if (File.Exists(path))
            {
                LoggerBundle.Error(new PathOccupiedException());
                return false;
            }

            try
            {
                LoggerBundle.Trace(Logger.DefaultLogFlags & ~LogFlags.SuffixNewLine
                    , $"Trying to serialize obj for file '{path}'...");
                String text = JsonConvert.SerializeObject(obj);
                LoggerBundle.Trace(Logger.DefaultLogFlags & ~LogFlags.PrefixLoggerType & ~LogFlags.PrefixTimeStamp, "Ok.");
                LoggerBundle.Trace($"Serialized object for file '{path}' is '{text}'");
                String pathRoot = Path.GetDirectoryName(path);
                if (!Directory.Exists(pathRoot))
                {
                    LoggerBundle.Trace(Logger.DefaultLogFlags & ~LogFlags.SuffixNewLine
                        , $"Directory '{pathRoot}' does not exist. Trying to create it...");
                    Directory.CreateDirectory(pathRoot);
                    LoggerBundle.Trace(Logger.DefaultLogFlags & ~LogFlags.PrefixLoggerType & ~LogFlags.PrefixTimeStamp, "Ok.");
                }
                LoggerBundle.Trace(Logger.DefaultLogFlags & ~LogFlags.SuffixNewLine, $"Writing object to file '{path}'...");
                File.WriteAllText(path, text);
                LoggerBundle.Trace(Logger.DefaultLogFlags & ~LogFlags.PrefixLoggerType & ~LogFlags.PrefixTimeStamp, "Ok.");
                return true;
            }
            catch (Exception ex)
            {
                LoggerBundle.Error(ex);
                return false;
            }
        }

        public static (T output, Boolean success) Read<T>(String path) where T : class
        {
            if (null == path)
            {
                LoggerBundle.Error(new ArgumentNullException(nameof(path)));
                return (null, false);
            }

            if (!File.Exists(path))
            {
                LoggerBundle.Error(new FileNotFoundException());
                return (null, false);
            }

            try
            {
                LoggerBundle.Trace(Logger.DefaultLogFlags & ~LogFlags.SuffixNewLine, $"Trying to read file '{path}'...");
                String jsonString = File.ReadAllText(path);
                LoggerBundle.Trace(Logger.DefaultLogFlags & ~LogFlags.PrefixLoggerType & ~LogFlags.PrefixTimeStamp, "Ok.");
                LoggerBundle.Trace($"Serialized object of file '{path}' is '{jsonString}'");

                LoggerBundle.Trace(Logger.DefaultLogFlags & ~LogFlags.SuffixNewLine, "Trying to deserialize object...");
                T obj = JsonConvert.DeserializeObject<T>(jsonString);
                LoggerBundle.Trace(Logger.DefaultLogFlags & ~LogFlags.PrefixLoggerType & ~LogFlags.PrefixTimeStamp, "Ok.");

                return (obj, true);
            }
            catch (Exception ex)
            {
                LoggerBundle.Error(ex);
                return (null, false);
            }
        }
    }
}