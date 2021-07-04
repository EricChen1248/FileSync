using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSync
{
    [DebuggerDisplay("Dir: {FullName}")]
    public class DirectoryItem : FileSystemItem
    {
        private DirectoryInfo Info;
        private IEnumerable<FileSystemItem> Children;

        public string FullName => Info.FullName.Replace("\\","/");

        int FileSystemItem.GetHashCode => throw new NotImplementedException();

        public DirectoryItem(DirectoryInfo info)
        {
            Info = info;
        }

        public void GetChildren(bool recurse = false)
        {
            var children = new List<FileSystemItem>();
            var dirs = Info.GetDirectories("*", new EnumerationOptions
            {
                IgnoreInaccessible = true,
                RecurseSubdirectories = false,
            });

            foreach (var dir in dirs)
            {
                var child = new DirectoryItem(dir);
                children.Add(child);
                if (recurse)
                {
                    child.GetChildren(recurse);
                }
            }

            var files = Info.GetFiles("*", new EnumerationOptions
            {
                IgnoreInaccessible = true,
                RecurseSubdirectories = false,
            });

            foreach (var file in files)
            {
                var child = new FileItem(file);
                children.Add(child);
            }

            Children = children;
        }

    }
}
