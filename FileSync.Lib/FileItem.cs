using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSync
{
    [DebuggerDisplay("File: {FullName}")]
    public class FileItem : FileSystemItem
    {
        private FileInfo Info;

        public string FullName => Info.FullName.Replace("\\", "/");

        int FileSystemItem.GetHashCode => throw new NotImplementedException();

        public FileItem(FileInfo info)
        {
            Info = info;
        }


    }
}
