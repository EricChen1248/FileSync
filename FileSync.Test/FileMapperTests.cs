using System;
using System.IO;
using Xunit;

namespace FileSync.Test
{
    public class FileMapperTests
    {
        [Fact]
        public void TestUnequalTypes()
        {
            var mapper = new FileMapper();

            var file = new FileItem(new FileInfo("D:/a.txt"));
            var dir = new DirectoryItem(new DirectoryInfo("D:/"));

            _ = Assert.Throws<UnequalFileSystemTypeException>(() => mapper.Add(file, dir));
        }


        [Fact]
        public void TestSuccessFile()
        {
            var mapper = new FileMapper();

            var file = new FileItem(new FileInfo("D:/a.txt"));
            var file2 = new FileItem(new FileInfo("D:/b.txt"));

            mapper.Add(file, file2);

            Assert.True(mapper.GetMaster(file2) == (file, file2));
            Assert.True(mapper.GetMirror(file) == (file, file2));
        }
    }
}
