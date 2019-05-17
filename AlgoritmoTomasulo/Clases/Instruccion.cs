using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlgoritmoTomasulo.Clases
{
    class Instruccion
    {
        private int idInstruccion;

        public int IdInstruccion
        {
            get { return idInstruccion; }
            set { idInstruccion = value; }
        }
        private string rs1;

        public string Rs1
        {
            get { return rs1; }
            set { rs1 = value; }
        }
        private string rs2;

        public string Rs2
        {
            get { return rs2; }
            set { rs2 = value; }
        }
        private string rd;

        public string Rd
        {
            get { return rd; }
            set { rd = value; }
        }
        private string op;

        public string Op
        {
            get { return op; }
            set { op = value; }
        }

        private int inmediato;

        public int Inmediato
        {
            get { return inmediato; }
            set { inmediato = value; }
        }

        private string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        private string ins;

        public string Ins
        {
            get { return ins; }
            set { ins = value; }
        }

        private int estado;
        /*
         *0 - inicial
         *1 - ISS
         *2 - EX
         *3 - W
         *4 - final
         *5 - burbuja
         */

        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private int latencia;

        public int Latencia
        {
            get { return latencia; }
            set { latencia = value; }
        }

        private int contadorLatencia;

        public int ContadorLatencia
        {
            get { return contadorLatencia; }
            set { contadorLatencia = value; }
        }

        private string ubicacion;

        public string Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        public Instruccion(String cad) {
            this.contadorLatencia = 0;
            decodificar(cad);
        }

        public void decodificar(String cad)
        {
            String[] partes = cad.ToUpper().Split(new char[] { ' ' }, 2,StringSplitOptions.RemoveEmptyEntries);
            this.op = partes[0];
            //reemplazando espacios entre operandos
            partes[1] = Regex.Replace(partes[1], @"\s+", "");
            this.ins = partes[0] + " " + partes[1];

            if ("ADD,SUB,DIV,MUL".Contains(partes[0]))
            {
                //ALU
                string[] operandos = partes[1].Split(',');
                this.rd = operandos[0];
                this.rs1 = operandos[1];
                this.rs2 = operandos[2];
                this.tipo = "R";
            }
            else
            {
                //carga almacenamiento
                this.tipo = "I";
                string[] operandos = partes[1].Split(',');
                if (this.op == "ST")
                {
                    this.rd = operandos[1];
                    this.inmediato = Convert.ToInt32(operandos[0].Split('(')[0]);
                    //obteniendo rs1 de la instrucción
                    this.rs1 = operandos[0].Split('(')[1].Substring(0, operandos[0].Split('(')[1].Length - 1);
                }
                else
                {
                    this.rd = operandos[0];
                    this.inmediato = Convert.ToInt32(operandos[1].Split('(')[0]);
                    //obteniendo rs1 de la instrucción
                    this.rs1 = operandos[1].Split('(')[1].Substring(0, operandos[1].Split('(')[1].Length - 1);
                }
            }
            this.estado = 0;
        }
    }
}
