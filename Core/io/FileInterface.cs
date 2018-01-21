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
                String text = JsonConvert.SerializeObject(obj);
                String pathRoot = Path.GetDirectoryName(path);
                if (!Directory.Exists(pathRoot))
                {
                    Directory.CreateDirectory(pathRoot);
                }
                File.WriteAllText(path, text);
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
                String jsonString = File.ReadAllText(path);
                T obj = JsonConvert.DeserializeObject<T>(jsonString);
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