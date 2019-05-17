using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoTomasulo.Clases
{
    class Dependencias
    {
        private int idInsDependiente;

        public int IdInsDependiente
        {
            get { return idInsDependiente; }
            set { idInsDependiente = value; }
        }
        private int idInsOrigen;

        public int IdInsOrigen
        {
            get { return idInsOrigen; }
            set { idInsOrigen = value; }
        }
        private string porQuienDepende;

        public string PorQuienDepende
        {
            get { return porQuienDepende; }
            set { porQuienDepende = value; }
        }
        private string riesgo;

        public string Riesgo
        {
            get { return riesgo; }
            set { riesgo = value; }
        }
    }
}
