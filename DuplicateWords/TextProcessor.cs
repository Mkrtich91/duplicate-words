using System.Text;
using System.Text.RegularExpressions;

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
            string[] words = text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word]++;
                }
                else
                {
                    wordCounts[word] = 1;
                }
            }

            int duplicateCount = 0;
            foreach (int count in wordCounts.Values)
            {
                if (count > 1)
                {
                    duplicateCount++;
                }
            }

            return duplicateCount;
        }

        /// <summary>
        /// Returns the total number of all words that are duplicated in the <see cref="lines"/> list.
        /// </summary>
        /// <param name="lines">Source lines of text.</param>
        /// <returns>The total number of all words that are duplicated in the <see cref="lines"/> list.</returns>
        public static int GetTotalDuplicateWordsNumber(IList<string> lines)
        {
            StringBuilder builder = new StringBuilder();

            foreach (string line in lines)
            {
                builder.AppendLine(line);
            }

            string text = builder.ToString();

            string[] words = text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word]++;
                }
                else
                {
                    wordCounts[word] = 1;
                }
            }

            int duplicateCount = 0;
            foreach (int count in wordCounts.Values)
            {
                if (count > 1)
                {
                    duplicateCount += count;
                }
            }

            return duplicateCount;
        }

        /// <summary>
        /// Returns the list of words that are duplicated in the <see cref="lines"/> collection.
        /// </summary>
        /// <param name="lines">Source lines of text.</param>
        /// <returns>The list of words that are duplicated in the <see cref="lines"/> collection.</returns>
        /// <exception cref="ArgumentNullException"><see cref="lines"/> is null.</exception>
        public static IList<string> GetDuplicateWords(ICollection<string>? lines)
        {
            HashSet<string> words = new HashSet<string>();

            HashSet<string> duplicates = new HashSet<string>();
            if (lines == null)
            {
                throw new ArgumentNullException(nameof(lines));
            }

            foreach (string line in lines)
            {
                string[] lineWords = line.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in lineWords)
                {
                    if (words.Contains(word))
                    {
                        duplicates.Add(word);
                    }
                    else
                    {
                        words.Add(word);
                    }
                }
            }

            return duplicates.ToList();
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
            if (lines == null)
            {
                throw new ArgumentNullException(nameof(lines));
            }

            var comparer = ignoreCase ? StringComparer.InvariantCultureIgnoreCase : StringComparer.InvariantCulture;
            var uniqueWords = new Dictionary<string, bool?>(comparer);

            foreach (var line in lines)
            {
                var words = line.Split(new[] { ' ', '\t', '\n', '\r', ',', '.', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    if (!uniqueWords.ContainsKey(word))
                    {
                        uniqueWords[word] = true;
                    }
                    else
                    {
                    uniqueWords[word] = false;
                    }
                }
            }

            return uniqueWords.Where(pair => pair.Value == true).Select(pair => pair.Key).OrderBy(w => w, comparer).ToList();
        }

        /// <summary>
        /// Searches a string for duplicates and removes all next occurrences of duplicate words. The first occurrence of a duplicate word should say on it's place.
        /// </summary>
        /// <param name="stringBuilder">The <see cref="StringBuilder"/> that contains a source text.</param>
        /// <exception cref="ArgumentNullException"><see cref="StringBuilder"/> is null.</exception>
        public static void RemoveDuplicateWordsInStringBuilder(StringBuilder? stringBuilder)
        {
            if (stringBuilder == null)
            {
                throw new ArgumentNullException(nameof(stringBuilder));
            }

            string[] parts = Regex.Split(stringBuilder.ToString(), @"(\b[\p{L}]+\b|\W+)");

            HashSet<string> uniqueWords = new HashSet<string>();

            for (int i = 0; i < parts.Length; i++)
            {
                // Check if the part is a word
                if (Regex.IsMatch(parts[i], @"\b[\p{L}]+\b"))
                {
                    string word = parts[i];
                    if (!uniqueWords.Contains(word))
                    {
                        uniqueWords.Add(word);
                    }
                    else
                    {
                        parts[i] = string.Empty;
                    }
                }
            }

            stringBuilder.Clear();

            foreach (string part in parts)
            {
                stringBuilder.Append(part);
            }
        }

        /// <summary>
        /// Searches a string for duplicates and removes all next occurrences of duplicate words. The first occurrence of a duplicate word should say on it's place.
        /// </summary>
        /// <param name="text">The source text.</param>
        /// <param name="ignoreCase">If true, indicates that the case of strings should be ignored.</param>
        /// <exception cref="ArgumentNullException"><see cref="text"/> is null.</exception>
        public static void RemoveDuplicateWordsInString(ref string? text, bool ignoreCase)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            string[] parts = Regex.Split(text, @"(\b[\p{L}]+\b|\W+)");

            HashSet<string> uniqueWords = new HashSet<string>(ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);

            for (int i = 0; i < parts.Length; i++)
            {
                if (Regex.IsMatch(parts[i], @"\b[\p{L}]+\b"))
                {
                    string word = parts[i];
                    if (!uniqueWords.Contains(word))
                    {
                        uniqueWords.Add(word);
                    }
                    else
                    {
                        parts[i] = string.Empty;
                    }
                }
            }

            text = string.Concat(parts);
        }
    }
}
