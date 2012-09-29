using System;

namespace PictureProvider
{
    /// <summary>
    /// Allows retrieval of all supported providers.
    /// </summary>
    public static class ProviderFactory
    {
        public static IPictureProvider[] Providers
        {
            get
            {
                return new IPictureProvider[] {
                    new FileSystemPictureProvider(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)),
                    new FileSystemPictureProvider(Environment.CurrentDirectory)
                };
            }
        }
    }
}
