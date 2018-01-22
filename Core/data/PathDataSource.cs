using System;
using System.Collections.Generic;
using System.IO;
using ch.wuerth.tobias.mux.Core.logging;

namespace ch.wuerth.tobias.mux.Core.data
{
    public class PathDataSource : DataSource<String>
    {
        private readonly List<String> _extensionFilter;
        private readonly String _rootPath;

        public PathDataSource(String rootPath, List<String> extensionFilter)
        {
            _rootPath = rootPath;
            _extensionFilter = extensionFilter;
        }

        public override IEnumerable<String> Get()
        {
            return Crawl(_rootPath);
        }

        private IEnumerable<String> Crawl(String path)
        {
            LoggerBundle.Trace($"Starting to crawl path '{path}'");
            LoggerBundle.Trace($"Working on files in path '{path}'");
            foreach (String file in Directory.EnumerateFiles(path))
            {
                if (_extensionFilter.Contains(Path.GetExtension(file)))
                {
                    yield return file;
                }
            }

            LoggerBundle.Trace($"Working on directories in path '{path}'");
            foreach (String dir in Directory.EnumerateDirectories(path))
            {
                foreach (String file in Crawl(dir))
                {
                    yield return file;
                }
            }
        }
    }
}