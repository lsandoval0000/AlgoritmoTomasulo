using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmoTomasulo.Clases
{
    class GestionMemoria
    {
        //20 posiciones de memoria
        private List<Double> memoria;

        public void inicializaMemoria() {
            memoria = new List<double>();
            for (int i = 0; i < 20; i++) {
                if (i % 2 == 0)
                {
                    memoria.Add(5);
                }
                else {
                    memoria.Add(0);
                }
            }
        }

        public void volcarMemoria(System.Windows.Forms.DataGridView dgv_memoria)
        {
            dgv_memoria.ColumnCount = 21;
            dgv_memoria.Columns[0].Name = "Posiciones";
            dgv_memoria.Rows.Clear();
            string[] fila = new string[21];
            fila[0] = "Valores";
            for (int i = 0; i < 20; i++)
            {
                fila[i + 1] = memoria[i].ToString();
                dgv_memoria.Columns[i+1].Name = (i*4).ToString();
            }
            dgv_memoria.Rows.Add(fila);
        }

        public bool guardarDato(int posicion, double valor) {
            try
            {
                int p = posicion / 4;
                memoria[p] = valor;
            }
            catch (Exception ex) {
                MessageBox.Show("La posición de memoria está fuera del rango.");
                return false;
            }
            return true;
        }

        public double cargarDato(int posicion) {
            double dato = 0;
            try
            {
                int p = posicion / 4;
                dato = memoria[p];
                
            }
            catch (Exception ex) {
                MessageBox.Show("La posición de memoria está fuera del rango.");
                return Double.MaxValue;
            }
            return dato;
        }
    }
}
