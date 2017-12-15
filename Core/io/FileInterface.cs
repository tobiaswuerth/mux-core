using System;
using System.IO;
using ch.wuerth.tobias.mux.Core.exceptions;
using ch.wuerth.tobias.mux.Core.logging;
using Newtonsoft.Json;

namespace ch.wuerth.tobias.mux.Core.io
{
    public static class FileInterface
    {
        public static Boolean Save<T>(T obj, String path, Boolean doOverride = false, LoggerBundle logger = null)
            where T : class
        {
            if (null == obj)
            {
                logger?.Exception?.Log(new ArgumentNullException(nameof(obj)));
                return false;
            }

            if (null == path)
            {
                logger?.Exception?.Log(new ArgumentNullException(nameof(path)));
                return false;
            }

            if (File.Exists(path) && !doOverride)
            {
                logger?.Exception?.Log(new PathOccupiedException());
                return false;
            }

            try
            {
                String text = JsonConvert.SerializeObject(obj);
                File.WriteAllText(path, text);
                return true;
            }
            catch (Exception ex)
            {
                logger?.Exception?.Log(ex);
                return false;
            }
        }

        public static (T output, Boolean success) Read<T>(String path, LoggerBundle logger = null) where T : class
        {
            if (null == path)
            {
                logger?.Exception?.Log(new ArgumentNullException(nameof(path)));
                return (null, false);
            }

            if (!File.Exists(path))
            {
                logger?.Exception?.Log(new FileNotFoundException());
                return (null, false);
            }

            try
            {
                String jsonString = File.ReadAllText(path);
                T obj = JsonConvert.DeserializeObject<T>(jsonString);
                return (obj, true);
            }
            catch (Exception ex)
            {
                logger?.Exception?.Log(ex);
                return (null, false);
            }
        }
    }
}