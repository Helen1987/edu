using System.IO;
using System.Linq;
using System.Threading;

namespace PictureProvider
{
    /// <summary>
    /// A provider that provides pictures from a file system directory.
    /// Picture names are their physical location on disk, even though
    /// this is not guaranteed by the IPictureProvider interface.
    /// </summary>
    internal class FileSystemPictureProvider : IPictureProvider
    {
        private readonly string _path;
        private readonly int _pictureCount;
        private readonly string[] _fileNames;

        public FileSystemPictureProvider(string path)
        {
            _path = path;
            _fileNames = Directory.GetFiles(_path, "*.jpg");
            _pictureCount = _fileNames.Length;
        }

        #region IPictureProvider Members

        public int PictureCount
        {
            get { return _pictureCount; }
        }

        public string[] GetPictureNames(int startIndex, int count)
        {
            //Emulate delay:
            Thread.Sleep(5000);

            return _fileNames.Skip(startIndex).Take(count).ToArray();
        }

        public Picture GetPicture(string name)
        {
            //Emulate delay:
            Thread.Sleep(5000);

            return new Picture
            {
                Name = name,
                Data = File.ReadAllBytes(_fileNames.Where(f => f == name).Single())
            };
        }

        #endregion
    }
}
