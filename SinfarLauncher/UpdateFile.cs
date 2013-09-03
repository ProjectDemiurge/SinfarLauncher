using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinfarLauncher
{
    public struct UpdateFile
    {
        public string Path;
        public string Hash;
        public int Size;
        public DateTime Lastmodified;

        public UpdateFile(string row)
        {
            var fields = row.Split(';');
            Path = fields[0];
            Hash = fields[1];
            Size = Convert.ToInt32(fields[2]);
            Lastmodified = Convert.ToDateTime(fields[3]);
        }
    }
}
