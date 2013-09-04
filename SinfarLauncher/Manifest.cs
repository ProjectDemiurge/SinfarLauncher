using System;
using System.Collections.Generic;
using System.IO;

namespace SinfarLauncher
{
    public class Manifest
    {
        public List<UpdateFile> UpdateFiles = new List<UpdateFile>();
        public List<UpdateFile> NeedsUpdate = new List<UpdateFile>();
 
        public Manifest(string rawManifest)
        {
            var delimiters = new char[] {'\r', '\n'};

            var rows = rawManifest.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            foreach (var row in rows)
            {
                UpdateFiles.Add(new UpdateFile(row));
            }
        }

        public void Compare(string nwndir)
        {

            foreach (var file in UpdateFiles)
            {
                var localfileinfo = new FileInfo(nwndir + file.Path);

                if (localfileinfo.Exists != true)
                {
                    NeedsUpdate.Add(file);
                }
                else if (file.Size != localfileinfo.Length)
                {
                    NeedsUpdate.Add(file);
                }

            }
        }
    }
}
