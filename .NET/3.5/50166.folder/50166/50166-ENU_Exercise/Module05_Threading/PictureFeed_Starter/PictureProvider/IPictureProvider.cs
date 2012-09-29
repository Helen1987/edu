
namespace PictureProvider
{
    /// <summary>
    /// Retrieves pictures.
    /// </summary>
    public interface IPictureProvider
    {
        /// <summary>
        /// The total number of pictures this provider has.
        /// </summary>
        int PictureCount { get; }

        /// <summary>
        /// Retrieves a subset of the picture names.
        /// </summary>
        /// <param name="startIndex">The first picture.</param>
        /// <param name="count">The number of pictures.</param>
        /// <returns>An array of strings representing the picture
        /// names; these strings can be used to call the GetPicture method.</returns>
        string[] GetPictureNames(int startIndex, int count);

        /// <summary>
        /// Retrieves the picture with the specified name.
        /// </summary>
        /// <param name="name">The picture name.</param>
        /// <returns>The picture with the specified name.</returns>
        Picture GetPicture(string name);
    }
}
