using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace lezer
{
    internal class JatekosLovese
    {
        public string Nev { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

        public int Id { get; set; }

        public float T { get { return Tavolsag(); } }

        public JatekosLovese(string nev, float x, float y, int id)
        {
            Nev = nev;
            X = x;
            Y = y;
            Id = id;

        }


        public float Tavolsag()
        {
            float tavolsag = (float)Math.Sqrt(Math.Pow(X - JatekKezelo.Xkozep, 2) + Math.Pow(Y - JatekKezelo.Ykozep, 2));
            return tavolsag;

        }
    }
}
