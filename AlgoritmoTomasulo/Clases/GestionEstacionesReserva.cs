using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoTomasulo.Clases
{
    class GestionEstacionesReserva
    {
        int TOTAL_ESTACIONES_ADDSUB = 3;
        int TOTAL_ESTACIONES_MUL = 2;

        //Suma Resta, 3
        public void inicializarEstacionesReservaAddSub(BindingList<Estaciones> estacionAddSub)
        {
            estacionAddSub.Clear();
            for (int i = 0; i < TOTAL_ESTACIONES_ADDSUB; i++)
            {
                Estaciones b = new Estaciones();
                b.Tipo = "ADD" + i;
                b.Ocupada = "NO";
                b.Qj = "";
                b.Qk = "";
                b.S1 = "";
                b.S2 = "";
                estacionAddSub.Add(b);
            }
        }

        public int estacionReservaDisponibleAddSub(BindingList<Estaciones> estacionAddSub)
        {
            int indice = -1;
            for (int i = 0; i < TOTAL_ESTACIONES_ADDSUB; i++)
            {
                if (estacionAddSub[i].Ocupada == "NO")
                {
                    indice = i;
                    break;
                }
            }
            return indice;
        }

        public void asignarInstruccionAEstacionReservaAddSub(BindingList<Estaciones> estacionAddSub,Instruccion instruccion, int indice, Estaciones temp)
        {
            temp.Ocupada = "SI";
            temp.Tipo = estacionAddSub[indice].Tipo;
            estacionAddSub[indice] = temp;
        }

        public void liberarEstacionReservaAddSub(BindingList<Estaciones> estacionAddSub, int indice)
        {
            estacionAddSub[indice].Ocupada = "NO";
            estacionAddSub[indice].Operacion = "";
            estacionAddSub[indice].Qj = "";
            estacionAddSub[indice].Qk = "";
            estacionAddSub[indice].S1 = "";
            estacionAddSub[indice].S2 = "";
        }

        public void actualizarEstacionReservaAddSub(BindingList<Estaciones> estacionAddSub,double dato,string ub)
        {
            for (int i = 0; i < TOTAL_ESTACIONES_ADDSUB; i++)
            {
                if (estacionAddSub[i].Qj==ub)
                {
                    estacionAddSub[i].Qj = "";
                    estacionAddSub[i].S1 = dato.ToString();
                }
                if (estacionAddSub[i].Qk == ub)
                {
                    estacionAddSub[i].Qk = "";
                    estacionAddSub[i].S2 = dato.ToString();
                }
            }
        }

        //------------------------------------------------------------------------
        //Multiplicación División, 2
        public void inicializarEstacionesReservaMulDiv(BindingList<Estaciones> estacionMulDiv)
        {
            estacionMulDiv.Clear();
            for (int i = 0; i < TOTAL_ESTACIONES_MUL; i++)
            {
                Estaciones b = new Estaciones();
                b.Tipo = "MUL" + i;
                b.Ocupada = "NO";
                b.Qj = "";
                b.Qk = "";
                b.S1 = "";
                b.S2 = "";
                estacionMulDiv.Add(b);
            }
        }

        public int estacionReservaDisponibleMulDiv(BindingList<Estaciones> estacionMulDiv)
        {
            int indice = -1;
            for (int i = 0; i < TOTAL_ESTACIONES_MUL; i++)
            {
                if (estacionMulDiv[i].Ocupada == "NO")
                {
                    indice = i;
                    break;
                }
            }
            return indice;
        }

        public void asignarInstruccionAEstacionReservaMulDiv(BindingList<Estaciones> estacionMulDiv,Instruccion instruccion, int indice, Estaciones temp)
        {
            temp.Ocupada = "SI";
            temp.Tipo = estacionMulDiv[indice].Tipo;
            estacionMulDiv[indice] = temp;
        }

        public void liberarEstacionReservaMulDiv(BindingList<Estaciones> estacionMulDiv,int indice) {
            estacionMulDiv[indice].Ocupada = "NO";
            estacionMulDiv[indice].Operacion = "";
            estacionMulDiv[indice].Qj = "";
            estacionMulDiv[indice].Qk = "";
            estacionMulDiv[indice].S1 = "";
            estacionMulDiv[indice].S2 = "";
        }

        public void actualizarEstacionReservaMulDiv(BindingList<Estaciones> estacionMulDiv, double dato, string ub)
        {
            for (int i = 0; i < TOTAL_ESTACIONES_MUL; i++)
            {
                if (estacionMulDiv[i].Qj == ub)
                {
                    estacionMulDiv[i].Qj = "";
                    estacionMulDiv[i].S1 = dato.ToString();
                }
                if (estacionMulDiv[i].Qk == ub)
                {
                    estacionMulDiv[i].Qk = "";
                    estacionMulDiv[i].S2 = dato.ToString();
                }
            }
        }
    }
}
