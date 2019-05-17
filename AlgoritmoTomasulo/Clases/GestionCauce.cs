using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmoTomasulo.Clases
{
    class GestionCauce
    {
        public void volcarCauce(System.Windows.Forms.DataGridView dgv_cauce, List<Instruccion> instrucciones)
        {
            dgv_cauce.ColumnCount = 1;
            dgv_cauce.Columns[0].Name = "Instrucciones";
            if (instrucciones.Count > 0)
            {
                for (int i = instrucciones.Count - 1; i >= 0; i--)
                {
                    dgv_cauce.Rows.Add(instrucciones[i].Ins);
                }
            }
        }

        public void siguienteCiclo(System.Windows.Forms.DataGridView dgv_cauce, List<Instruccion> instrucciones) {
            /*estados
             *0 - inicial
             *1 - ISS
             *2 - EX
             *3 - W
             *4 - final
             *5 - burbuja
             */
            dgv_cauce.ColumnCount = dgv_cauce.ColumnCount + 1;
            dgv_cauce.Columns[dgv_cauce.ColumnCount - 1].Name = (dgv_cauce.ColumnCount - 1).ToString();
            
            string fase = "";
            for (int i = instrucciones.Count - 1; i >= 0; i--)
            {
                switch (instrucciones[i].Estado) { 
                    case 1:
                        fase = "ISS";
                        break;
                    case 2:
                        fase = "EX";
                        break;
                    case 3:
                        fase = "W";
                        break;
                    case 5:
                        fase = "-";
                        break;
                    default:
                        fase = "";
                        break;
                }
                dgv_cauce.Rows[(instrucciones.Count - 1 - i)].Cells[dgv_cauce.ColumnCount - 1].Value = fase;
            }
        }
    }
}
