/* TrieWithManyChildren.cs
 * Julie Thornton
 */
/*
 * Edited:Tatenda Sekabanja
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6CryptoSolver
{
    /// <summary>
    /// Represents a trie with more than one child
    /// </summary>
    public class TrieWithManyChildren : ITrie
    {
        /// <summary>
        /// Indicates whether the trie rooted at this node contains the empty string.
        /// </summary>
        private bool _hasEmpty = false;

        /// <summary>
        /// This node's children.
        /// </summary>
        private ITrie?[] _children = new ITrie?[ITrie.AlphabetSize];

        /// <summary>
        /// Constructs a trie containing the given string and having the given child at the given label.
        /// If s contains any characters other than lower-case English letters,
        /// throws an ArgumentException.
        /// If childLabel is not a lower-case English letter, throws an ArgumentException.
        /// </summary>
        /// <param name="s">The string to include.</param>
        /// <param name="hasEmpty">Indicates whether this trie should contain the empty string.</param>
        /// <param name="childLabel">The label of the child.</param>
        /// <param name="child">The child labeled childLabel.</param>
        public TrieWithManyChildren(string s, bool hasEmpty, char childLabel, ITrie child)
        {
            if (s == null || child == null)
            {
                throw new ArgumentNullException();
            }
            if (childLabel < ITrie.AlphabetStart || childLabel >= ITrie.AlphabetStart + ITrie.AlphabetSize)
            {
                throw new ArgumentException();
            }
            _hasEmpty = hasEmpty;
            _children[childLabel - ITrie.AlphabetStart] = child;
            Add(s);
        }

        /// <summary>
        /// Determines whether the trie rooted at this node contains the given string.
        /// </summary>
        /// <param name="s">The string to look up.</param>
        /// <returns>Whether the trie at this node contains s.</returns>
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
                int loc = s[0] - ITrie.AlphabetStart;
                if (loc < 0 || loc >= ITrie.AlphabetSize)
                {
                    return false;
                }
                else
                {
                    ITrie? child = _children[loc];
                    if (child == null)
                    {
                        return false;
                    }
                    return child.Contains(s.Substring(1));
                }
            }
        }

        /// <summary>
        /// Adds the given string to the trie rooted at this node.
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
            }
            else
            {
                int loc = s[0] - ITrie.AlphabetStart;
                if (loc < 0 || loc >= ITrie.AlphabetSize)
                {
                    throw new ArgumentException();
                }
                ITrie? child = _children[loc];
                if (child == null)
                {
                    child = new TrieWithNoChildren();
                }
                _children[loc] = child.Add(s.Substring(1));
            }
            return this;
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
                int loc = s[0] - ITrie.AlphabetStart;
                if (loc!=-34 &&(loc < 0 || loc >= ITrie.AlphabetSize))
                {
                    return false;
                }
                else
                {
                    

                    if (loc != -34)
                    {
                        ITrie? child = _children[loc];
                      
                        if (child == null)
                        {
                            return false;
                        }
                        return child.WildcardSearch(s.Substring(1));
                    }

                    else
                    {
                        
                        for(int i = 0; i < _children.Length; i++)
                        {
                            if (_children[i]!=null) {
                             ITrie child = _children[i];
                                if (child.WildcardSearch(s.Substring(1)))
                                {
                                    return true;
                                }

                            }
                        }
                        return false;
                    }
                }
            }
        }


    }
}
