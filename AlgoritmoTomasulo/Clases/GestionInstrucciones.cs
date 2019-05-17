using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmoTomasulo.Clases
{
    class GestionInstrucciones
    {
        public bool instruccionesPendientes(List<Instruccion> instrucciones)
        {
            bool foco = false;
            foreach (Instruccion ins in instrucciones) {
                if (ins.Estado != 4) {
                    foco= true;
                }
            }
            return foco;
        }

        public string verificarDestinoInstruccion(Instruccion ins) {
            string opt = "";
            switch (ins.Op)
            {
                case "LD":
                    opt = "LOAD";
                    break;
                case "ST":
                    opt = "STORE";
                    break;
                case "ADD":
                case "SUB":
                    opt = "ADD";
                    break;
                case "DIV":
                case "MUL":
                    opt = "MUL";
                    break;
            }
            return opt;
        }

        public void asignaLatencia(Instruccion ins,int sumL, int mulL, int divL) {
            switch (ins.Op) { 
                case "LD":
                    ins.Latencia = 2;
                    break;
                case "ST":
                    ins.Latencia = 1;
                    break;
                case "ADD":
                case "SUB":
                    ins.Latencia = sumL;
                    break;
                case "DIV":
                    ins.Latencia = divL;
                    break;
                case "MUL":
                    ins.Latencia = mulL;
                    break;
            }
        }

        public bool validarInstrucciones(List<Instruccion> instrucciones)
        {
            bool foco = true;
            string mensaje = "";
            foreach (Instruccion ins in instrucciones) {
                if (!"ADD,SUB,DIV,MUL,LD,ST".Contains(ins.Op)) {
                    mensaje = "Existen instrucciones no soportadas por el simulador";
                    foco = false;
                    break;
                }
                if (ins.Tipo == "R")
                {
                    if (ins.Rs1.Contains("R") && ins.Rs2.Contains("R") && ins.Rd.Contains("R"))
                    {
                        //obteniendo número de registro
                        int ns1, ns2, ns3;
                        try
                        {
                            ns1 = Convert.ToInt32(ins.Rs1.Substring(1));
                            ns2 = Convert.ToInt32(ins.Rs2.Substring(1));
                            ns3 = Convert.ToInt32(ins.Rd.Substring(1));
                            if (!((ns1 >= 0 && ns1 <= 14) && (ns2 >= 0 && ns2 <= 14) && (ns3 >= 0 && ns3 <= 14))) {
                                mensaje = "Solo se cuenta con 15 registros, desde R0 hasta R14";
                                foco = false;
                                break;
                            }
                        }
                        catch (Exception ex) {
                            mensaje = "Los nombres de los registros contienen caracteres no válidos";
                            foco = false;
                            break;
                        }
                    }
                    else {
                        mensaje = "Error en los nombres de los registros";
                        foco = false;
                        break;
                    }
                }
                else { 
                    //Instrucción tipo I
                    if (ins.Rs1.Contains("R") && ins.Rd.Contains("R"))
                    {
                        //obteniendo número de registro
                        int ns1, ns2, ns3;
                        try
                        {
                            ns1 = Convert.ToInt32(ins.Rs1.Substring(1));
                            ns3 = Convert.ToInt32(ins.Rd.Substring(1));
                            if (!((ns1 >= 0 && ns1 <= 14)  && (ns3 >= 0 && ns3 <= 14)))
                            {
                                mensaje = "Solo se cuenta con 15 registros, desde R0 hasta R14";
                                foco = false;
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            mensaje = "Los nombres de los registros contienen caracteres no válidos";
                            foco = false;
                            break;
                        }
                    }
                    else
                    {
                        mensaje = "Error en los nombres de los registros";
                        foco = false;
                        break;
                    }
                }
            }
            if(!foco)
                MessageBox.Show(mensaje);
            return foco;
        }

        public void calcularDependencias(List<Instruccion> instrucciones,List<Dependencias> dependencias)
        {
            //como la lista de instrucciones esta a la inversa, se empieza desde el final
            for (int i = instrucciones.Count - 1; i >= 0; i--) {
                Instruccion ins = instrucciones[i];
                for (int j = i + 1; j < instrucciones.Count; j++){
                    if ((ins.Rs1 == instrucciones[j].Rd || ins.Rs2 == instrucciones[j].Rd) && instrucciones[j].Op != "ST")
                    {
                        Dependencias dep = new Dependencias();
                        dep.IdInsDependiente = ins.IdInstruccion;
                        dep.IdInsOrigen = instrucciones[j].IdInstruccion;
                        dep.PorQuienDepende = instrucciones[j].Rd;
                        if (j - i <= 2)
                        {
                            dep.Riesgo = "RAW";
                        }
                        else {
                            dep.Riesgo = "";
                        }
                        dependencias.Add(dep);
                    }
                    if (ins.Op == "ST" && (ins.Rd == instrucciones[j].Rd)) {
                        Dependencias dep = new Dependencias();
                        dep.IdInsDependiente = ins.IdInstruccion;
                        dep.IdInsOrigen = instrucciones[j].IdInstruccion;
                        dep.PorQuienDepende = instrucciones[j].Rd;
                        dep.Riesgo = "";
                        dependencias.Add(dep);
                    }
                }
            }
        }
    }
}
