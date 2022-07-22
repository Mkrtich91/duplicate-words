using System.Text;

namespace UniqueWords
{
    public static class TextProcessor
    {
        /// <summary>
        /// Returns the number of words that are duplicated in the <see cref="text"/>.
        /// </summary>
        /// <param name="text">Source text.</param>
        /// <returns>The number of words that are duplicated in the <see cref="text"/>.</returns>
        public static int CountDuplicateWords(string text)
        {
            // TODO #1. Analyze the method unit tests and add the method implementation.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the total number of all words that are duplicated in the <see cref="lines"/> list.
        /// </summary>
        /// <param name="lines">Source lines of text.</param>
        /// <returns>The total number of all words that are duplicated in the <see cref="lines"/> list.</returns>
        public static int GetTotalDuplicateWordsNumber(IList<string> lines)
        {
            StringBuilder builder = new ();
            Dictionary<string, int> counters = new ();

            // TODO #2. Analyze the method unit tests and add the method implementation.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the list of words that are duplicated in the <see cref="lines"/> collection.
        /// </summary>
        /// <param name="lines">Source lines of text.</param>
        /// <returns>The list of words that are duplicated in the <see cref="lines"/> collection.</returns>
        /// <exception cref="ArgumentNullException"><see cref="lines"/> is null.</exception>
        public static IList<string> GetDuplicateWords(ICollection<string>? lines)
        {
            HashSet<string> words = new ();
            HashSet<string> duplicates = new ();

            // TODO #3. Analyze the method unit tests and add the method implementation.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the collection of unique words from the <see cref="lines"/> enumerable object.
        /// </summary>
        /// <param name="lines">Source lines of text.</param>
        /// <param name="ignoreCase">If true, indicates that the case of strings should be ignored.</param>
        /// <returns>The collection of unique words from the <see cref="lines"/> enumerable object.</returns>
        /// <exception cref="ArgumentNullException"><see cref="lines"/> is null.</exception>
        public static ICollection<string> GetUniqueWords(IEnumerable<string>? lines, bool ignoreCase)
        {
            // TODO #4. Analyze the method unit tests and add the method implementation.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Searches a string for duplicates and removes all next occurrences of duplicate words. The first occurrence of a duplicate word should say on it's place.
        /// </summary>
        /// <param name="stringBuilder">The <see cref="StringBuilder"/> that contains a source text.</param>
        /// <exception cref="ArgumentNullException"><see cref="StringBuilder"/> is null.</exception>
        public static void RemoveDuplicateWordsInStringBuilder(StringBuilder? stringBuilder)
        {
            StringBuilder wordChars = new ();
            HashSet<string> words = new ();

            // TODO #5. Analyze the method unit tests and add the method implementation.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Searches a string for duplicates and removes all next occurrences of duplicate words. The first occurrence of a duplicate word should say on it's place.
        /// </summary>
        /// <param name="text">The source text.</param>
        /// <param name="ignoreCase">If true, indicates that the case of strings should be ignored.</param>
        /// <exception cref="ArgumentNullException"><see cref="text"/> is null.</exception>
        public static void RemoveDuplicateWordsInString(ref string? text, bool ignoreCase)
        {
            // TODO #6. Analyze the method unit tests and add the method implementation.
            throw new NotImplementedException();
        }
    }
}
