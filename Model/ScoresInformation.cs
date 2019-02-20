using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoPalavras.Model
{
    public class ScoresInformation
    {
        private int _idScore;
        public int IdScore
        {
            get { return _idScore; }
            set { _idScore = value; }
        }
        private int _idLetter;
        public int IdLetter
        {
            get { return _idLetter; }
            set { _idLetter = value; }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        private int _score;
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        private int _idUser;
        public int IdUser
        {
            get { return _idUser; }
            set { _idUser = value; }
        }
    }
}
