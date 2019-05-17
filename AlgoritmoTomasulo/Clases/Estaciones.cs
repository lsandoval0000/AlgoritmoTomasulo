using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoTomasulo.Clases
{
    class Estaciones : INotifyPropertyChanged
    {
        private string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        private string ocupada;

        public string Ocupada
        {
            get { return ocupada; }
            set { ocupada = value; }
        }
        private string operacion;

        public string Operacion
        {
            get { return operacion; }
            set { operacion = value; }
        }
        private string s1;

        public string S1
        {
            get { return s1; }
            set { s1 = value; }
        }
        private string s2;

        public string S2
        {
            get { return s2; }
            set { s2 = value; }
        }
        private string qj;

        public string Qj
        {
            get { return qj; }
            set { qj = value; }
        }
        private string qk;

        public string Qk
        {
            get { return qk; }
            set { qk = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }
    }
}
