using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoTomasulo.Clases
{
    class GestionBuffers
    {
        int TOTAL_BUFFER_CARGA = 6;
        int TOTAL_BUFFER_ALMACENAMIENTO=3;

        //carga
        //6 buffers para carga
        public void inicializarBufferCarga(BindingList<BufferT> bufferCarga)
        {
            bufferCarga.Clear();
            for (int i = 0; i < TOTAL_BUFFER_CARGA; i++)
            {
                BufferT b = new BufferT();
                b.Tipo = "LOAD"+i;
                b.Ocupada = "NO";
                bufferCarga.Add(b);
            }
        }

        public int bufferCargaDisponible(BindingList<BufferT> bufferCarga)
        {
            int indice = -1;
            for (int i = 0; i < TOTAL_BUFFER_CARGA; i++)
            {
                if (bufferCarga[i].Ocupada == "NO") {
                    indice = i;
                    break;
                }
            }
            return indice;
        }

        public void asignarInstruccionABufferCargaDisponible(BindingList<BufferT> bufferCarga,Instruccion ins, int indice) {
            bufferCarga[indice].Ocupada = "SI";
            bufferCarga[indice].Direccion = ins.Rs1 + "+" + ins.Inmediato;
        }

        public void liberarBufferCarga(BindingList<BufferT> bufferCarga,int indice)
        {
            bufferCarga[indice].Ocupada = "NO";
            bufferCarga[indice].Direccion = "";
            bufferCarga[indice].Valor = 0;
        }

        //-------------------------------------------------------------------
        //almacenamiento
        //3 buffers para almacenamiento
        public void inicializarBufferAlmacenamiento(BindingList<BufferT> bufferAlmacenamiento)
        {
            bufferAlmacenamiento.Clear();
            for (int i = 0; i < TOTAL_BUFFER_ALMACENAMIENTO; i++)
            {
                BufferT b = new BufferT();
                b.Tipo = "STORE" + i;
                b.Ocupada = "NO";
                bufferAlmacenamiento.Add(b);
            }
        }

        public int bufferAlmacenamientoDisponible(BindingList<BufferT> bufferAlmacenamiento)
        {
            int indice = -1;
            for (int i = 0; i < TOTAL_BUFFER_ALMACENAMIENTO; i++)
            {
                if (bufferAlmacenamiento[i].Ocupada == "NO")
                {
                    indice = i;
                    break;
                }
            }
            return indice;
        }

        public void asignarInstruccionABufferAlmacenamientoDisponible(BindingList<BufferT> bufferAlmacenamiento,Instruccion ins, int indice)
        {
            bufferAlmacenamiento[indice].Ocupada = "SI";
            bufferAlmacenamiento[indice].Direccion = ins.Rs1 + "+" + ins.Inmediato;
        }

        public void liberarBufferAlmacenamiento(BindingList<BufferT> bufferAlmacenamiento, int indice)
        {
            bufferAlmacenamiento[indice].Ocupada = "NO";
            bufferAlmacenamiento[indice].Direccion = "";
            bufferAlmacenamiento[indice].Valor = 0;
        }
    }
}
