using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSync
{
    public class FileMapper
    {
        private readonly Dictionary<FileSystemItem, FileSystemItem> MasterDict;
        private readonly Dictionary<FileSystemItem, FileSystemItem> MirrorDict;

        public FileMapper()
        {
            MasterDict = new Dictionary<FileSystemItem, FileSystemItem>();
            MirrorDict = new Dictionary<FileSystemItem, FileSystemItem>();

        }

        public (FileSystemItem master, FileSystemItem mirror) GetMirror(FileSystemItem fsi) => (fsi, MasterDict[fsi]);
        public (FileSystemItem master, FileSystemItem mirror) GetMaster(FileSystemItem fsi) => (MirrorDict[fsi], fsi);

        public void Add(FileSystemItem masterFsi, FileSystemItem mirrorFsi)
        {
            if (masterFsi.GetType() != mirrorFsi.GetType())
            {
                throw new UnequalFileSystemTypeException($"Master item has type : {masterFsi.GetType()}, while Mirror item has type: {mirrorFsi.GetType()}");
            }

            if (MasterDict.ContainsKey(masterFsi))
            {
                throw new UnbalancedMapperException($"Master Dict contains {masterFsi.FullName}");
            }

            if (MirrorDict.ContainsKey(mirrorFsi))
            {
                throw new UnbalancedMapperException($"Mirror Dict contains {mirrorFsi.FullName}");
            }

            MasterDict[masterFsi] = mirrorFsi;
            MirrorDict[mirrorFsi] = masterFsi;
        }

        public void RemoveMaster(FileSystemItem fsi)
        {
            MirrorDict.Remove(MasterDict[fsi]);
            MasterDict.Remove(fsi);
        }

        public void RemoveMirror(FileSystemItem fsi)
        {
            MasterDict.Remove(MirrorDict[fsi]);
            MirrorDict.Remove(fsi);
        }
    }

    public class UnequalFileSystemTypeException : Exception
    {
        public UnequalFileSystemTypeException(string message) : base(message) { }
    }

    public class UnbalancedMapperException : Exception
    {
        public UnbalancedMapperException(string message) : base(message) { }
    }
}
