
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Net6CryptoSolver
{
    /// <summary>
    /// handles encrypting and decrypting a message 
    /// </summary>
    public class SubstitutionCipher

    {
     /// <summary>
    /// generates random numbers
    /// </summary>
        Random _generator = new Random();

        /// <summary>
        /// a trie without children
        /// </summary>
        ITrie _words = new TrieWithNoChildren();

        /// <summary>
        /// checks wether all words in the msg are in the dictionary- _words
        /// </summary>
        /// <param name="msg">the string we are checking </param>
        /// <returns>wether all words in the msg are in the dictionary- _words</returns>
        public bool AllWords(string msg)
        {


            
            
            {


            }
            String[] words = msg.Split();
            for (int i = 0; i < words.Length; i++) {
                if (!_words.Contains(words[i])){
                    return false;
                }
                    }
            return true;

           
        }
        /// <summary>
        /// applies random substitution cipher to encrypt msg, 
        /// </summary>
        /// <param name="msg">the string to encrypt </param>
        /// <returns>the ciphertext</returns>
        public string Encrypt(string msg)
        {
          
            //the random numbers we have already selected
            HashSet<int> track = new();
            Dictionary<int,char> dict = new();

            //use random to pich the cyper letter
            char cipher = (char)_generator.Next(26);
            //encode for msg
            StringBuilder sb = new StringBuilder();
           
             for(int d=0;d<msg.Length;d++)
            {
               
                int c = msg[d];
                char value;

                if (msg[d]==' ')
                {
                    sb.Append(' '.ToString());
                    continue;
                }
                if (!dict.TryGetValue(c, out value)){
                    //generate a random number
                    int rand = _generator.Next(26);
                    int ciph = c + rand;
                    if (ciph > 122)
                    {
                        ciph = ciph - 122 + 96;
                    }
                    while (track.Contains(ciph))
                    {
                        rand = _generator.Next(26);
                         ciph = c + rand;
                        if (ciph > 122)
                        {
                            ciph = ciph - 122 + 96;
                        }
                    }
                    
                    dict.Add(c,(char) (ciph));
                    track.Add(ciph);
                    sb.Append((char)(ciph));
                }
                else
                {
                    sb.Append((char)value);
                }
            }
            return sb.ToString();
         

        }
        /// <summary>
        /// reads the gven file and adds them to the trie
        /// </summary>
        /// <param name="fileName">the name of the dictionary file </param>
        /// <returns>if the file was successfully read or not </returns>
    public bool ReadDictionary(string fileName)
        {

            try
            {
                using (StreamReader input = new(fileName))
                {
                    while(!input.EndOfStream)
                    {
                        string read = input.ReadLine()!;
                        //we already checked that input is not null
                       ITrie next=     _words.Add(read);
                        _words = next;
                    }
                }
            }

            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;     
            }
            return true;

        }
        /// <summary>
        ///  Returns whether msg contains characters other than lower-case letters or spaces.
        /// </summary>
        /// <param name="msg">the string we are checking</param>
      ///<returns> whether msg contains characters other than lower-case letters or spaces.</returns>

        public bool ContainsInvalid(string msg)
        {
            for(int i=0;i<msg.Length;i++)
            {

                int loc = msg[i] - ITrie.AlphabetStart;
                if (!msg[i].Equals(' ') && (loc < 0 || msg[i] >= ITrie.AlphabetSize+ ITrie.AlphabetStart)  )
                {
                 //   if ( msg[i] -'a' > 25 || msg[i] - 26 < 0)
                
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// whether the words in plain have possible completions in the _words 
        /// </summary>
        /// <param name="plain">the array of stringbuilders we checking </param>
        /// <returns>whether the words in plain have possible completions in the _words </returns>
        public bool PossibleCompletion(StringBuilder[] plain)
        {
            foreach(StringBuilder sb in plain)
            {
             
               if(!_words.WildcardSearch(sb.ToString()))
                {
                    return false;
                }
            }
            return true;
            
        }
        /// <summary>
        /// whether the words in plain are a completed decryption
        /// </summary>
        /// <param name="plain">the array we are checking </param>
        /// <returns>whether the words in plain are a completed decryption</returns>
        public bool Solved(StringBuilder[] plain)
        {         

            //for each sb, do they have a ? 
            for(int i = 0; i < plain.Length; i++)
            {
                String x = plain[i].ToString();
                if (x.Contains('?'))
                {
                    return false;
                }
                if (!_words.Contains(x))
                {
                    return false;
                }
            }
            return true;
            //for every string builder, is it contained in _words and does it not have a ?



        }
        /// <summary>
        /// returns a size-2 array of the position of the next ? character
        /// </summary>
        /// <param name="plain">the array we are checking </param>
        /// <returns>an array giving the position of the next? character in plain</returns>
        private int[]? NextPos(StringBuilder[] plain)
        {
            //how to seperate the plain into words, how to know where a word ends
            int[] pos = new int[2];
            for (int i = 0; i < plain.Length; i++)
            {
                String x = plain[i].ToString();
                for (int k = 0; k < x.Length; k++)
                {
                    if (x[k] == '?')
                    {
                        pos[0]=i;
                        pos[1]=k;
                        return pos;
                    }
                }

            }
            return null;
        }

        /// <summary>
        /// substitutes the corresponding position with replace in plain
        /// </summary>
        /// <param name="orig">the original letter to be replaced </param>
        /// <param name="replace">the letter we want to replace with </param>
        /// <param name="cipher">the encrypted text </param>
        /// <param name="plain">th plain text </param>
        private void Substitute(char orig, char replace, string[] cipher, StringBuilder[] plain)
        {
            //go through all cipher words
            for(int i = 0; i < cipher.Length; i++)
                
            {//go through all cipher letters in words
                for (int k = 0; k < cipher[i].Length; k++)
                {

                    //for all occurences of orig in cipher
                    if (cipher[i][k] == orig)
                    {
                        //we need to go through all sbs in plain and go to position i 
                        //for (int j = 0; j < plain.Length; j++)
                        //{
                            plain[i][k] = replace;
                        //}
                    }
                }
            }
        }
        /// <summary>
        /// performs a recursive search to solve the cryptogram.
        /// </summary>
        /// <param name="cipher">the words of the encrypted message</param>
        /// <param name="partial">the current partial solution to the cipher </param>
        /// <param name="alphaUsed">which lowercase letters have been used in decryption</param>
        /// <returns>if the cryptogram has been solved </returns>
        private bool DecryptionSearch(string[] cipher, StringBuilder[] partial, bool[] alphaUsed)
        {
            char cval;
            if (Solved(partial))
            {
                return true;
            }
           
                
            if(!PossibleCompletion(partial))
            {
                return false;
            }
                //if any word in prtial does not have a possible math
            //find the next location of ? in the sbs 
            int[]? nextP = NextPos(partial);
            //get the cipher text value v at the same word and position, 
            //the position of the word is ind 0
            if (nextP != null)
            {
              cval=  cipher[nextP[0]][nextP[1]];


                for (int k = 0; k < alphaUsed.Length; k++)
                {
                    if (!alphaUsed[k])
                    {
                        //find the ciphertext value
                        Substitute(cval, (char)(k+97), cipher, partial);
                        alphaUsed[k] = true;
                         if(   DecryptionSearch(cipher, partial, alphaUsed))
                        {
                            return true;
                        }

                        alphaUsed[k] = false;
                        Substitute( cval ,'?', cipher, partial);

                    }


                }
                return false;
                
                       
                   }
            return false;
            }
        /// <summary>
        /// Decrypts msg and returns the first possible solution.
        /// </summary>
        /// <param name="msg">the string to be decrypted </param>
        /// <param name="solved">if the message was decrypted </param>
        /// <returns>the decrypted msg </returns>

        public string Decrypt(string msg, out bool solved)
        {
            //break mssg into array
            String[] words = msg.Split(" ");
            //sb array with same length
            StringBuilder[] build = new StringBuilder[words.Length];
            for (int k = 0; k < words.Length; k++)
            {
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < words[k].Length; i++)
                    {
                        sb.Append('?');
                    }
                    build[k]=sb;
                }
            }
                bool[] abool = new bool[26];
                for (int i = 0; i < abool.Length; i++)
                {
                    abool[i] = false;
                }
                solved = DecryptionSearch(words, build, abool);
                StringBuilder nsb = new StringBuilder();
                //append to the sb
                //itterate through our build, and 

            for(int i = 0; i < build.Length; i++)
            {
                nsb.Append(build[i]);
                nsb.Append(' ');
            }

                return nsb.ToString();

            
        }
    }
}
