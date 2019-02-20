using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoPalavras.Model
{
    class WordsInformation
    {
        private int _idWord;
        public int IdWord
        {
            get { return _idWord; }
            set { _idWord = value; }
        }

        private string _word;
        public string Word
        {
            get { return _word; }
            set { _word = value; }
        }

        private int _idLetter;
        public int IdLetter
        {
            get { return _idLetter; }
            set { _idLetter = value; }
        }
    }
}
