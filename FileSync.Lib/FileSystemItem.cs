using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSync
{
    public interface FileSystemItem
    {
        string FullName { get; }
        int GetHashCode { get; }

    }

}
