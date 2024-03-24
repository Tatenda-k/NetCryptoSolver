﻿/* TrieWithNoChildren.cs
 * Julie Thornton
 */

/*
 * Edited by: Tatenda Sekabanja
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6CryptoSolver
{
    /// <summary>
    /// Represents a trie with no children
    /// </summary>
    public class TrieWithNoChildren : ITrie
    {

        /// <summary>
        /// Indicates whether the trie rooted at this node contains the empty string.
        /// </summary>
        private bool _hasEmpty = false;

        /// <summary>
        /// Adds the given string to this trie.
        /// </summary>
        /// <param name="s">The string to add.</param>
        /// <returns>The resulting trie.</returns>
        public ITrie Add(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            if (s == "")
            {
                _hasEmpty = true;
                return this;
            }
            else
            {
                return new TrieWithOneChild(s, _hasEmpty);
            }
        }

        /// <summary>
        /// Determines whether this trie contains the given string.
        /// </summary>
        /// <param name="s">The string to look for.</param>
        /// <returns>Whether this trie contains s.</returns>
        public bool Contains(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            if (s == "")
            {
                return _hasEmpty;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// if the trie contains any word that matches s 
        /// </summary>
        /// <param name="s">the string we are searching for </param>
        /// <returns>if the trie contains any word that matches s </returns>
        /// <exception cref="ArgumentNullException">if a null strigin is passed</exception>
        public bool WildcardSearch(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            if (s == "")
            {
                return _hasEmpty;
            }
            else
            {
                return false;
            }




        }
    }
}
