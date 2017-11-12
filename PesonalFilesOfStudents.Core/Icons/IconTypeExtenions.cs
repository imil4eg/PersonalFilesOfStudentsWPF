namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// Helper functions for <see cref="IconType"/>
    /// </summary>
    public static class IconTypeExtenions
    {
        /// <summary>
        /// Converts <see cref="IconType"/> to a FontAwesome string
        /// </summary>
        /// <param name="type">The type to convert</param>
        /// <returns></returns>
        public static string ToFontAwesome(this IconType type)
        {
            switch (type)
            {
                // Return a FontAwesome string based on icon type
                case IconType.Edit:
                    return "\uf044";

                case IconType.Delete:
                    return "\uf014";

                    // If none found, return null
                default:
                    return null;
            }
        }
    }
}
