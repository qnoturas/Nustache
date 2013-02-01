namespace Nustache.Core
{
    /// <summary>
    /// Responsible for storing the various options that can be applied to the rendering of a template.
    /// </summary>
    public class Options
    {
        /// <summary>
        /// Gets or sets a value indicating whether to preserve tags that have no matching data in the given
        /// object.  This is useful for unit and integration tests; ensuring all the tags are catered for.
        /// </summary>
        public bool PreserveUndefinedVariables { get; set; }

        /// <summary>
        /// Get the default values for the options object.
        /// </summary>
        /// <returns></returns>
        public static Options Defaults()
        {
            return new Options
                {
                    PreserveUndefinedVariables = false
                };
        }
    }
}
