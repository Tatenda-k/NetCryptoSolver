﻿/* ITrie.cs
 * Julie Thornton
 */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6CryptoSolver
{
    /// <summary>
    /// An interface for a trie.
    /// </summary>
    public interface ITrie
    {

        /// <summary>
        /// The first character of the alphabet we use.
        /// </summary>
        const char AlphabetStart = 'a';

        /// <summary>
        /// The number of characters in the alphabet.
        /// </summary>
        const int AlphabetSize = 26;

        /// <summary>
        /// Determines whether this trie contains the given string.
        /// </summary>
        /// <param name="s">The string to look for.</param>
        /// <returns>Whether this trie contains s.</returns>
        bool Contains(string s);

        /// <summary>
        /// Adds the given string to this trie. This trie may or may not
        /// be changed by this method, but the resulting trie is always
        /// returned.
        /// </summary>
        /// <param name="s">The string to add.</param>
        /// <returns>The resulting trie.</returns>
        ITrie Add(string s);
        /// <summary>
        /// checks if the trie contains any word that matches s
        /// </summary>
        /// <param name="s">a string that includes wildcard</param>
        /// <returns> ithe trie contains any word that matches s f </returns>
        bool WildcardSearch(string s);




    }
}
