
namespace PictureProvider
{
    /// <summary>
    /// Describes a picture.
    /// </summary>
    public class Picture
    {
        /// <summary>
        /// The picture name (not necessarily its file name).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The picture's byte data.
        /// </summary>
        public byte[] Data { get; set; }
    }
}
