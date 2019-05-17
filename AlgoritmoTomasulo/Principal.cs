using AlgoritmoTomasulo.Clases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmoTomasulo
{
    public partial class Principal : Form
    {
        //form ayuda e info
        InfoAyuda infoAyuda=null;

        //lista de instrucciones
        List<Instruccion> instrucciones;

        //lista de dependencias
        List<Dependencias> dependencias;

        //lista carga almacenamiento
        BindingList<BufferT> bufferCarga;
        BindingList<BufferT> bufferAlmacenamiento;

        //lista estaciones sub mul
        BindingList<Estaciones> estacionAddSub;
        BindingList<Estaciones> estacionMulDiv;

        //registros R
        List<string> registrosR;

        Instruccion ins;

        //contador ciclos
        int ciclos;

        //gestor de memoria
        GestionMemoria gMen;

        //gestor de cauce
        GestionCauce gCau;

        //gestor de instrucciones
        GestionInstrucciones gInst;

        //gestor de los buffer de carga y almacenamiento
        GestionBuffers gBuffer;

        //gestor de estaciones de reserva
        GestionEstacionesReserva gEstReserva;

        //latencias
        int sumL, mulL, divL;

        public Principal()
        {
            InitializeComponent();
        }

        private void btn_ejecutar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_instrucciones.Lines.Length > 0)
                {
                    bool foco = true;
                    instrucciones = new List<Instruccion>();
                    dependencias = new List<Dependencias>();

                    gInst = new GestionInstrucciones();

                    //cargando instrucciones
                    for (int i = 0; i < txt_instrucciones.Lines.Length; i++)
                    {
                        string cad = txt_instrucciones.Lines[i];
                        ins = new Instruccion(cad);
                        ins.IdInstruccion = i;
                        ins.Ubicacion = "";
                        instrucciones.Add(ins);
                    }

                    //validar instrucciones
                    foco = gInst.validarInstrucciones(instrucciones);

                    //validar latencias
                    try
                    {
                        sumL = Convert.ToInt32(txt_sumaL.Text);
                        mulL = Convert.ToInt32(txt_multL.Text);
                        divL = Convert.ToInt32(txt_divL.Text);
                        if (sumL < 1 || mulL < 1 || divL < 1)
                        {
                            foco = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ingresó valores incorrectos en los campos de latencia de ejecución.");
                        foco = false;
                    }
                    if (foco)
                    {
                        //invirtiendo orden y agregando a cola
                        instrucciones.Reverse();

                        cargarInstrucciones();

                        gCau.volcarCauce(dgv_cauce, instrucciones);
                        btn_auto.Enabled = true;
                        btn_siguiente.Enabled = true;
                        btn_ejecutar.Enabled = false;

                        txt_divL.Enabled = false;
                        txt_multL.Enabled = false;
                        txt_sumaL.Enabled = false;

                        //calculando dependencias
                        gInst.calcularDependencias(instrucciones,dependencias);

                        cargarDependencias();
                    }
                    else
                    {
                        MessageBox.Show("Corrija los errores indicados.");
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar las instrucciones");
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Los datos proporcionados en las instrucciones presentan caracteres no válidos");
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            gMen = new GestionMemoria();
            gMen.inicializaMemoria();
            gMen.volcarMemoria(dgv_memoria);

            gCau = new GestionCauce();

            bufferAlmacenamiento = new BindingList<BufferT>();
            bufferCarga = new BindingList<BufferT>();

            gBuffer = new GestionBuffers();

            estacionAddSub = new BindingList<Estaciones>();
            estacionMulDiv = new BindingList<Estaciones>();

            gEstReserva = new GestionEstacionesReserva();
            
            registrosR = new List<string>();

            manejaCiclos(0);

            dgv_almacenamiento.DataSource = bufferAlmacenamiento;
            dgv_carga.DataSource = bufferCarga;
            dgv_cauce.DataSource = null;
            dgv_reservaMulDiv.DataSource = estacionMulDiv;
            dgv_reservaSumaResta.DataSource = estacionAddSub;

            gBuffer.inicializarBufferCarga(bufferCarga);
            gBuffer.inicializarBufferAlmacenamiento(bufferAlmacenamiento);

            gEstReserva.inicializarEstacionesReservaAddSub(estacionAddSub);
            gEstReserva.inicializarEstacionesReservaMulDiv(estacionMulDiv);

            gestionaRegistros(0);

            btn_auto.Enabled = false;
            btn_siguiente.Enabled = false;
            btn_ejecutar.Enabled = true;

            txt_divL.Text = "1";
            txt_multL.Text = "1";
            txt_sumaL.Text = "1";

            txt_divL.Enabled = true;
            txt_multL.Enabled = true;
            txt_sumaL.Enabled = true;
        }

        private void limpiarListas() {
            lb_colaInstrucciones.Items.Clear();
            lb_dependencias.Items.Clear();
            lb_registrosR.Items.Clear();

            gBuffer.inicializarBufferAlmacenamiento(bufferAlmacenamiento);
            gBuffer.inicializarBufferCarga(bufferCarga);

            gEstReserva.inicializarEstacionesReservaAddSub(estacionAddSub);
            gEstReserva.inicializarEstacionesReservaMulDiv(estacionMulDiv);

            refrescarDgv();
            registrosR.Clear();

            //txt_instrucciones.Clear();
        }

        //cargar instrucciones
        private void cargarInstrucciones() {
            foreach (Instruccion i in instrucciones)
            {
                gInst.asignaLatencia(i, sumL, mulL, divL);
                lb_colaInstrucciones.Items.Add((i.IdInstruccion+1)+" : "+i.Ins);
            }
        }

        //cargar dependencias
        private void cargarDependencias() {
            foreach (Dependencias dep in dependencias) {
                string cad = (dep.IdInsDependiente + 1) + " depende de " + (dep.IdInsOrigen + 1) + " por " + dep.PorQuienDepende;
                if (dep.Riesgo.Length != 0) {
                    cad = cad + " (" + dep.Riesgo + ")";
                }
                lb_dependencias.Items.Add(cad);
            }
        }

        //inicializa o carga registros R
        private void gestionaRegistros(int op) {
            lb_registrosR.Items.Clear();
            //solo se poseen 15
            for (int i = 0; i < 15; i++)
            {
                if (op == 0)
                {
                    registrosR.Add("0");
                    lb_registrosR.Items.Add("R" + i + " : 0");
                }
                else
                {
                    lb_registrosR.Items.Add("R" + i + " : " + registrosR[i]);
                }
            }
        }

        private void manejaCiclos(int op) {
            if (op == 0)
            {
                ciclos = 0;
                txt_ciclo.Text = ciclos.ToString();
            }
            else {
                ciclos = ciclos + 1;
                txt_ciclo.Text = ciclos.ToString();
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            manejaCiclos(0);
            limpiarListas();
            gestionaRegistros(0);
            
            dgv_cauce.Rows.Clear();
            dgv_cauce.Columns.Clear();
           
            t_contador.Stop();
            
            btn_auto.Enabled = false;
            btn_siguiente.Enabled = false;
            btn_ejecutar.Enabled = true;

            txt_divL.Enabled = true;
            txt_multL.Enabled = true;
            txt_sumaL.Enabled = true;

            btn_auto.Text = "Automático";
        }

        private void t_contador_Tick(object sender, EventArgs e)
        {
            //simulando modo automático
            if (gInst.instruccionesPendientes(instrucciones))
            {
                ejecutarCiclo();
            }
            else {
                t_contador.Stop();
                MessageBox.Show("Ejecución Finalizada");
                btn_auto.Enabled = false;
                btn_siguiente.Enabled = false;
            }
        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            if (gInst.instruccionesPendientes(instrucciones))
            {
                ejecutarCiclo();
            }
            else
            {
                MessageBox.Show("Ejecución Finalizada");
                btn_auto.Enabled = false;
                btn_siguiente.Enabled = false;
            }
        }

        private void btn_auto_Click(object sender, EventArgs e)
        {
            if (btn_auto.Text.CompareTo("Automático") == 0)
            {
                t_contador.Enabled = true;
                t_contador.Start();
                btn_auto.Text = "Detener";
                btn_siguiente.Enabled = false;
            }
            else {
                t_contador.Stop();
                btn_auto.Text = "Automático";
                btn_siguiente.Enabled = true;
            }
        }

        private void ejecutarCiclo() {
            manejaCiclos(1);
            int rs1, rs2;
            Estaciones temp;

            //Etapa ISS
            Instruccion instruccion = null;//será usada para tomar instrucciones de la cola de instrucciones

            //tomando instrucción de la cola de instrucciones
            if (lb_colaInstrucciones.Items.Count > 0) {
                instruccion = instrucciones[lb_colaInstrucciones.Items.Count - 1];
                //verificando tipo de instrucción y si hay estaciones de reserva o buffers disponibles para ella
                //Primero verificando a que estación o buffer va
                string destino = gInst.verificarDestinoInstruccion(instruccion);
                bool asignada = false;
                int indiceRegistro;
                switch (destino)
                {
                    case "LOAD":
                        //verificando disponibilidad de buffer de carga
                        int numBufferCargaDisponible = gBuffer.bufferCargaDisponible(bufferCarga);
                        if (numBufferCargaDisponible != -1) {
                            //indicando que el valor que se trae de memoria aún no está en el registro
                            indiceRegistro = Convert.ToInt32(instruccion.Rd.Substring(1));
                            registrosR[indiceRegistro] = "LOAD" + numBufferCargaDisponible;

                            //se asigna a esa posición del buffer la instrucción
                            gBuffer.asignarInstruccionABufferCargaDisponible(bufferCarga,instruccion, numBufferCargaDisponible);

                            //la instrucción guarda el lugar donde se almancena
                            instrucciones[lb_colaInstrucciones.Items.Count - 1].Ubicacion = "LOAD:" + numBufferCargaDisponible;

                            asignada = true;
                        }
                        break;
                    case "STORE":
                        //verificando disponibilidad de buffer de almacenamiento
                        int numBufferAlmacenamientoDisponible = gBuffer.bufferAlmacenamientoDisponible(bufferAlmacenamiento);
                        if (numBufferAlmacenamientoDisponible != -1)//No hay riesgo estructural
                        {
                            //indicando que el valor aún no está escrito en memoria
                            indiceRegistro = Convert.ToInt32(instruccion.Rd.Substring(1));
                            //registrosR[indiceRegistro] = "STORE" + numBufferAlmacenamientoDisponible;

                            //se asigna a esa posición del buffer la instrucción
                            gBuffer.asignarInstruccionABufferAlmacenamientoDisponible(bufferAlmacenamiento,instruccion, numBufferAlmacenamientoDisponible);

                            //la instrucción guarda el lugar donde se almancena
                            instrucciones[lb_colaInstrucciones.Items.Count - 1].Ubicacion = "STORE:" + numBufferAlmacenamientoDisponible;

                            asignada = true;
                        }
                        break;
                    case "ADD":
                        //verificando disponibilidad de Estaciones de reserva
                        int numEstacionReservaDisponibleAddSub = gEstReserva.estacionReservaDisponibleAddSub(estacionAddSub);
                        if (numEstacionReservaDisponibleAddSub != -1) //No hay riesgo estructural
                        { 
                            //se asigna la instrucción a la estación de reserva
                            //primero se deben obtener los datos de los registros a usar

                            rs1 = Convert.ToInt32(instruccion.Rs1.Substring(1));
                            rs2 = Convert.ToInt32(instruccion.Rs2.Substring(1));
                            temp = new Estaciones();
                            temp.Operacion = "";
                            temp.Qj = "";
                            temp.Qk = "";
                            temp.S1 = "";
                            temp.S2 = "";
                            if (registrosR[rs1].Contains("LOAD") || registrosR[rs1].Contains("STORE") || registrosR[rs1].Contains("ADD") || registrosR[rs1].Contains("MUL"))
                            {
                                //el valor no está en el registro, está en algún buffer o estación de reserva
                                temp.Qj = registrosR[rs1];
                            }
                            else { 
                                //el valor está en el registro
                                temp.S1 = registrosR[rs1];
                            }

                            if (registrosR[rs2].Contains("LOAD") || registrosR[rs2].Contains("STORE") || registrosR[rs2].Contains("ADD") || registrosR[rs2].Contains("MUL"))
                            {
                                //el valor no está en el registro, está en algún buffer o estación de reserva
                                temp.Qk = registrosR[rs2];
                            }
                            else
                            {
                                //el valor está en el registro
                                temp.S2 = registrosR[rs2];
                            }
                            //asignando operación a la estación
                            temp.Operacion = instruccion.Op;

                            //la instrucción guarda el lugar donde se almancena
                            instrucciones[lb_colaInstrucciones.Items.Count - 1].Ubicacion = "ADD:" + numEstacionReservaDisponibleAddSub;

                            //indicando que el valor aún no está escrito en el registro de destino
                            indiceRegistro = Convert.ToInt32(instruccion.Rd.Substring(1));
                            registrosR[indiceRegistro] = "ADD" + numEstacionReservaDisponibleAddSub;

                            //se asigna a esa posición del buffer la instrucción
                            gEstReserva.asignarInstruccionAEstacionReservaAddSub(estacionAddSub,instruccion, numEstacionReservaDisponibleAddSub, temp);

                            asignada = true;
                        }
                        break;
                    case "MUL":
                        //verificando disponibilidad de Estaciones de reserva
                        int numEstacionReservaDisponibleMulDiv = gEstReserva.estacionReservaDisponibleMulDiv(estacionMulDiv);
                        if (numEstacionReservaDisponibleMulDiv != -1) //No hay riesgo estructural
                        {
                            //se asigna la instrucción a la estación de reserva
                            //primero se deben obtener los datos de los registros a usar
                            
                            rs1 = Convert.ToInt32(instruccion.Rs1.Substring(1));
                            rs2 = Convert.ToInt32(instruccion.Rs2.Substring(1));
                            temp = new Estaciones();
                            temp.Operacion = "";
                            temp.Qj = "";
                            temp.Qk = "";
                            temp.S1 = "";
                            temp.S2 = "";
                            if (registrosR[rs1].Contains("LOAD") || registrosR[rs1].Contains("STORE") || registrosR[rs1].Contains("ADD") || registrosR[rs1].Contains("MUL"))
                            {
                                //el valor no está en el registro, está en algún buffer o estación de reserva
                                temp.Qj = registrosR[rs1];
                            }
                            else
                            {
                                //el valor está en el registro
                                temp.S1 = registrosR[rs1];
                            }

                            if (registrosR[rs2].Contains("LOAD") || registrosR[rs2].Contains("STORE") || registrosR[rs2].Contains("ADD") || registrosR[rs2].Contains("MUL"))
                            {
                                //el valor no está en el registro, está en algún buffer o estación de reserva
                                temp.Qk = registrosR[rs2];
                            }
                            else
                            {
                                //el valor está en el registro
                                temp.S2 = registrosR[rs2];
                            }
                            //asignando operación a la estación
                            temp.Operacion = instruccion.Op;

                            //la instrucción guarda el lugar donde se almancena
                            instrucciones[lb_colaInstrucciones.Items.Count - 1].Ubicacion = "MUL:" + numEstacionReservaDisponibleMulDiv;

                            //indicando que el valor aún no está escrito en el registro de destino
                            indiceRegistro = Convert.ToInt32(instruccion.Rd.Substring(1));
                            registrosR[indiceRegistro] = "MUL" + numEstacionReservaDisponibleMulDiv;

                            //se asigna a esa posición del buffer la instrucción
                            gEstReserva.asignarInstruccionAEstacionReservaMulDiv(estacionMulDiv,instruccion, numEstacionReservaDisponibleMulDiv, temp);

                            asignada = true;
                        }
                        break;
                }
                if (asignada) {
                    instrucciones[lb_colaInstrucciones.Items.Count - 1].Estado = 1;
                    lb_colaInstrucciones.Items.RemoveAt(lb_colaInstrucciones.Items.Count - 1);
                    refrescarDgv();
                    gestionaRegistros(1);
                }
            }

            //Etapa EX
            //se debe verificar que solo 1 instrucción de ADD/SUB se ejecute a la vez y una instrucción de MUL/DIV se ejecute a la vez
            int ufSuma, ufMul, ufMemoria;
            //0 indica que estan libres
            ufSuma = 0;
            ufMul = 0;
            ufMemoria = 0;
            //teniendo en cuenta que las instrucciones LD usan el sumador en su primer ciclo de ejecución para calcular la dirección desde
            //donde se cargará el dato y en el segundo ciclo de ejecución cargará el valor en el registro
            //las instrucciones de almacenamiento usan el sumador para calcular el lugar de memoria donde se guardarán los datos
            //solo necesita 1 ciclo de ejecución para calcular la posición a guardar a diferencia de las instrucciones LD
            //por lo tanto no se podrán ejecutar instrucciones LD, ST, ADD Y SUB en un mismo ciclo.
            //pero se pueden ejecutar instrucciones LD/ST/ADD/SUB y instrucciones DIV/MUL en un mismo ciclo, una instrucción de cada tipo
            //debido a que se tiene una unidad funcional para LD/ST/ADD/SUB y una unidad funcional para DIV/MUL
            string[] ubicacion;
            int pos;
            string[] direccion;
            int numRegistro;

            for (int i = instrucciones.Count - 1; i >= 0; i--)
            {
                if (instrucciones[i].Ubicacion == "" || (instruccion !=null && instruccion.IdInstruccion == instrucciones[i].IdInstruccion))
                {
                    continue;
                }

                ubicacion = instrucciones[i].Ubicacion.Split(':');
                //posición 0 -> lugar
                //posición 1 -> índice
                pos = Convert.ToInt32(ubicacion[1]);

                //solo se evaluan las instrucciones que se encuentran en el estado 1(ISS) y que tengan todos sus operandos disponibles
                //o las instrucciones en estado 5(burbuja) para ver si ya pueden ejecutarse
                if (instrucciones[i].Estado == 1 || instrucciones[i].Estado==5) {
                    switch (ubicacion[0]) {
                        case "LOAD":
                            direccion = bufferCarga[pos].Direccion.Split('+');
                            numRegistro = Convert.ToInt32(direccion[0].Substring(1));

                            if (ufSuma == 1)
                            {
                                instrucciones[i].Estado = 5;//unidad funcional ocupada
                            }
                            else
                            {
                                if (registrosR[numRegistro].Contains("LOAD") || registrosR[numRegistro].Contains("STORE") || registrosR[numRegistro].Contains("ADD") || registrosR[numRegistro].Contains("MUL"))
                                {
                                    //aún no estan listos los registros a usar
                                    instrucciones[i].Estado = 5;
                                }
                                else
                                {
                                    //valores cargados correctamente en los registros, empezando etapa EX
                                    ufSuma = 1;//usando el sumador
                                    //valor de memoria
                                    int valor = Convert.ToInt32(registrosR[numRegistro]) + Convert.ToInt32(direccion[1]);
                                    if (valor < 0 || valor > 76 || valor % 4 != 0)
                                    {
                                        finalizarProgramaError(instrucciones[i].IdInstruccion, " ha generado una lectura a memoria incorrecta. Programa Finalizado.");
                                    }
                                    bufferCarga[pos].Valor = valor;
                                    instrucciones[i].ContadorLatencia = instrucciones[i].ContadorLatencia + 1;
                                    instrucciones[i].Estado = 2;
                                }
                            }
                            break;
                        case "STORE":
                            direccion = bufferAlmacenamiento[pos].Direccion.Split('+');
                            numRegistro = Convert.ToInt32(direccion[0].Substring(1));

                            if (ufSuma == 1)
                            {
                                instrucciones[i].Estado = 5;//unidad funcional ocupada
                            }
                            else
                            {
                                if (registrosR[numRegistro].Contains("LOAD") || registrosR[numRegistro].Contains("STORE") || registrosR[numRegistro].Contains("ADD") || registrosR[numRegistro].Contains("MUL"))
                                {
                                    //aún no estan listos los registros a usar
                                    instrucciones[i].Estado = 5;
                                }
                                else
                                {
                                    int numRegistroAux = Convert.ToInt32(instrucciones[i].Rd.Substring(1));
                                    if (instrucciones[i].ContadorLatencia == instrucciones[i].Latencia && 
                                        (registrosR[numRegistroAux].Contains("LOAD") || registrosR[numRegistroAux].Contains("STORE") 
                                        || registrosR[numRegistroAux].Contains("ADD") || registrosR[numRegistroAux].Contains("MUL")))
                                    {
                                        //aún no estan listos los registros a usar
                                        instrucciones[i].Estado = 5;
                                        continue;
                                    }
                                    if (instrucciones[i].ContadorLatencia == instrucciones[i].Latencia &&
                                        !(registrosR[numRegistroAux].Contains("LOAD") || registrosR[numRegistroAux].Contains("STORE")
                                        || registrosR[numRegistroAux].Contains("ADD") || registrosR[numRegistroAux].Contains("MUL")))
                                    {
                                        instrucciones[i].Estado = 3;
                                        continue;
                                    }
                                    //valores cargados correctamente en los registros, empezando etapa EX
                                    ufSuma = 1;//usando el sumador
                                    //lugar de memoria donde se guardará el dato
                                    int valor = Convert.ToInt32(registrosR[numRegistro]) + Convert.ToInt32(direccion[1]);
                                    if (valor < 0 || valor > 76 || valor%4!=0 ) {
                                        finalizarProgramaError(instrucciones[i].IdInstruccion, " ha generado una lectura a memoria incorrecta. Programa Finalizado.");
                                    }

                                    bufferAlmacenamiento[pos].Valor = valor;
                                    instrucciones[i].ContadorLatencia = instrucciones[i].ContadorLatencia + 1;
                                    instrucciones[i].Estado = 2;
                                }
                            }
                            break;
                        case "ADD":
                            temp = estacionAddSub[pos];
                            if (ufSuma == 1)
                            {
                                instrucciones[i].Estado = 5;//unidad funcional ocupada
                            }
                            else
                            {
                                if (temp.Qj == "" && temp.Qk=="")
                                {
                                    //el valor de los registros ya se encuentra disponible, operando
                                    instrucciones[i].ContadorLatencia = instrucciones[i].ContadorLatencia + 1;
                                    instrucciones[i].Estado = 2;
                                    ufSuma = 1;
                                }
                                else
                                {
                                    //aún no se poseen los valores correctos de los registros, esperando
                                    instrucciones[i].Estado = 5;
                                }
                            }
                            break;
                        case "MUL":
                            temp = estacionMulDiv[pos];
                            if (ufMul == 1)
                            {
                                instrucciones[i].Estado = 5;//unidad funcional ocupada
                            }
                            else
                            {
                                if (temp.Qj == "" && temp.Qk=="")
                                {
                                    //el valor de los registros ya se encuentra disponible, operando
                                    instrucciones[i].ContadorLatencia = instrucciones[i].ContadorLatencia + 1;
                                    instrucciones[i].Estado = 2;
                                    ufSuma = 1;
                                }
                                else
                                {
                                    //aún no se poseen los valores correctos de los registros, esperando
                                    instrucciones[i].Estado = 5;
                                }
                            }
                            break;
                    }
                    refrescarDgv();
                    continue;
                }

                //las que estan en estado 2(EX) se verifica si cumplieron su latencia, si la cumplen pasan a estado 3(W)
                if (instrucciones[i].Estado == 2)
                {
                    if (ubicacion[0] == "STORE") {
                        numRegistro = Convert.ToInt32(instrucciones[i].Rd.Substring(1));
                        if (registrosR[numRegistro].Contains("LOAD") || registrosR[numRegistro].Contains("STORE") || registrosR[numRegistro].Contains("ADD") || registrosR[numRegistro].Contains("MUL"))
                        {
                            //aún no estan listos los registros a usar
                            instrucciones[i].Estado = 5;
                        }
                        else {
                            instrucciones[i].Estado = 3;
                        }
                        continue;
                    }

                    if (instrucciones[i].ContadorLatencia == instrucciones[i].Latencia)
                    {
                        instrucciones[i].Estado = 3;
                    }
                    else {
                        instrucciones[i].ContadorLatencia = instrucciones[i].ContadorLatencia + 1;
                    }
                    continue;
                }

                //Etapa W
                //las que estan en estado 3, escriben sus resultados directamente, salvo las instrucciones de almacenamiento
                //que deben esperar a que sus registros esten cargados correctamente
                //solo una instruccion puede escribir a memoria a la vez
                //cuando escribe en memoria o en registro, se debe actualizar en todas las estaciones de espera y buffers
                //los valores que se estan esperando
                int posMem;
                double dato;
                string t;
                if (instrucciones[i].Estado == 3)
                {
                    switch (ubicacion[0])
                    {
                        case "LOAD":
                            //ir a memoria traer el dato en la posición calculada y ponerlo en el registro indicado
                            posMem = bufferCarga[pos].Valor;
                            dato = gMen.cargarDato(posMem);
                            t = ubicacion[0] + ubicacion[1];
                            //primero buscando todos los que esperen el valor del RD de la instrucción de carga
                            for (int k = 0; k < registrosR.Count; k++) {
                                if (registrosR[k] == t)
                                {
                                    registrosR[k] = dato.ToString();
                                }
                            }
                            gEstReserva.actualizarEstacionReservaAddSub(estacionAddSub, dato, t);
                            gEstReserva.actualizarEstacionReservaMulDiv(estacionMulDiv, dato, t);
                            gBuffer.liberarBufferCarga(bufferCarga, pos);
                            instrucciones[i].Estado = 4;
                            break;
                        case "STORE":
                            if (ufMemoria == 0)
                            {
                                posMem = bufferAlmacenamiento[pos].Valor;
                                numRegistro = Convert.ToInt32(instrucciones[i].Rd.Substring(1));
                                gMen.guardarDato(posMem, Convert.ToDouble(registrosR[numRegistro]));
                                gBuffer.liberarBufferAlmacenamiento(bufferAlmacenamiento, pos);
                                instrucciones[i].Estado = 4;
                                ufMemoria = 1;
                            }
                            else {
                                instrucciones[i].Estado = 5;
                            }
                            gMen.volcarMemoria(dgv_memoria);
                            break;
                        case "ADD":
                            temp = estacionAddSub[pos];
                            if (temp.Operacion == "ADD")
                            {
                                dato = Convert.ToDouble(temp.S1) + Convert.ToDouble(temp.S2);
                            }
                            else {
                                dato = Convert.ToDouble(temp.S1) - Convert.ToDouble(temp.S2);
                            }
                            t = ubicacion[0] + ubicacion[1];
                            //primero buscando todos los que esperen el valor del RD de la instrucción de carga
                            for (int k = 0; k < registrosR.Count; k++) {
                                if (registrosR[k] == t)
                                {
                                    registrosR[k] = dato.ToString();
                                }
                            }
                            gEstReserva.actualizarEstacionReservaAddSub(estacionAddSub, dato, t);
                            gEstReserva.actualizarEstacionReservaMulDiv(estacionMulDiv, dato, t);
                            gEstReserva.liberarEstacionReservaAddSub(estacionAddSub, pos);
                            instrucciones[i].Estado = 4;
                            break;
                        case "MUL":
                            temp = estacionMulDiv[pos];
                            if (temp.Operacion == "MUL")
                            {
                                dato = Convert.ToDouble(temp.S1) * Convert.ToDouble(temp.S2);
                            }
                            else {
                                if (Convert.ToDouble(temp.S2) == 0) {
                                    finalizarProgramaError(instrucciones[i].IdInstruccion, " ha generado una división entre cero, programa terminado");
                                }
                                dato = Convert.ToDouble(temp.S1) / Convert.ToDouble(temp.S2);
                            }
                            t = ubicacion[0] + ubicacion[1];
                            //primero buscando todos los que esperen el valor del RD de la instrucción de carga
                            for (int k = 0; k < registrosR.Count; k++) {
                                if (registrosR[k] == t)
                                {
                                    registrosR[k] = dato.ToString();
                                }
                            }
                            gEstReserva.actualizarEstacionReservaAddSub(estacionAddSub, dato, t);
                            gEstReserva.actualizarEstacionReservaMulDiv(estacionMulDiv, dato, t);
                            gEstReserva.liberarEstacionReservaMulDiv(estacionMulDiv, pos);
                            instrucciones[i].Estado = 4;
                            break;
                    }
                    refrescarDgv();
                    continue;
                }
            }
            //actualizando el cauce
            gCau.siguienteCiclo(dgv_cauce, instrucciones);
        }

        //este método se ejecuta cuando existen un direccionamiento a memoria incorrecto, terminando el programa
        private void finalizarProgramaError(int idInstruccion,string msg) {
            t_contador.Stop();
            btn_auto.Enabled = false;
            btn_ejecutar.Enabled = false;
            btn_reset.Enabled = true;
            btn_siguiente.Enabled = false;

            MessageBox.Show("La instrucción n° " + (idInstruccion+1) + msg);
        }

        private void refrescarDgv() {
            dgv_carga.Refresh();
            dgv_almacenamiento.Refresh();
            dgv_reservaMulDiv.Refresh();
            dgv_reservaSumaResta.Refresh();
            gestionaRegistros(1);
        }

        private void btn_info_Click(object sender, EventArgs e)
        {
            if (infoAyuda != null)
            {
                infoAyuda.Show();
                infoAyuda.Focus();
            }
            else {
                infoAyuda = new InfoAyuda();
                infoAyuda.Show();
            }
        }
    }
}
