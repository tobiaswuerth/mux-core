using System;
using System.IO;
using ch.wuerth.tobias.mux.Core.events;
using ch.wuerth.tobias.mux.Core.exceptions;
using Newtonsoft.Json;

namespace ch.wuerth.tobias.mux.Core.io
{
    public static class FileInterface
    {
        public static Boolean Save<T>(T obj, String path, Boolean doOverride = false,
            ICallback<Exception> onException = null) where T : class
        {
            if (null == obj)
            {
                onException?.Push(new ArgumentNullException(nameof(obj)));
                return false;
            }

            if (null == path)
            {
                onException?.Push(new ArgumentNullException(nameof(path)));
                return false;
            }

            if (File.Exists(path) && !doOverride)
            {
                onException?.Push(new PathOccupiedException());
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
                onException?.Push(ex);
                return false;
            }
        }

        public static (T output, Boolean success) Read<T>(String path, ICallback<Exception> onException = null)
            where T : class
        {
            if (null == path)
            {
                onException?.Push(new ArgumentNullException(nameof(path)));
                return (null, false);
            }

            if (!File.Exists(path))
            {
                onException?.Push(new FileNotFoundException());
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
                onException?.Push(ex);
                return (null, false);
            }
        }
    }
}