namespace AlgoritmoTomasulo
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.txt_instrucciones = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_registrosR = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_colaInstrucciones = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_dependencias = new System.Windows.Forms.ListBox();
            this.btn_ejecutar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dgv_cauce = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgv_carga = new System.Windows.Forms.DataGridView();
            this.dgv_almacenamiento = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.dgv_reservaSumaResta = new System.Windows.Forms.DataGridView();
            this.dgv_reservaMulDiv = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dgv_memoria = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_ciclo = new System.Windows.Forms.TextBox();
            this.btn_reset = new System.Windows.Forms.Button();
            this.t_contador = new System.Windows.Forms.Timer(this.components);
            this.btn_siguiente = new System.Windows.Forms.Button();
            this.btn_auto = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_sumaL = new System.Windows.Forms.TextBox();
            this.txt_multL = new System.Windows.Forms.TextBox();
            this.txt_divL = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_info = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cauce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_carga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_almacenamiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_reservaSumaResta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_reservaMulDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_memoria)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_instrucciones
            // 
            this.txt_instrucciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_instrucciones.Location = new System.Drawing.Point(6, 37);
            this.txt_instrucciones.Multiline = true;
            this.txt_instrucciones.Name = "txt_instrucciones";
            this.txt_instrucciones.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_instrucciones.Size = new System.Drawing.Size(129, 194);
            this.txt_instrucciones.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Instrucciones a Ejecutar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Registros";
            // 
            // lb_registrosR
            // 
            this.lb_registrosR.FormattingEnabled = true;
            this.lb_registrosR.HorizontalScrollbar = true;
            this.lb_registrosR.Location = new System.Drawing.Point(54, 278);
            this.lb_registrosR.Name = "lb_registrosR";
            this.lb_registrosR.Size = new System.Drawing.Size(87, 199);
            this.lb_registrosR.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(843, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cola de Instrucciones";
            // 
            // lb_colaInstrucciones
            // 
            this.lb_colaInstrucciones.FormattingEnabled = true;
            this.lb_colaInstrucciones.HorizontalScrollbar = true;
            this.lb_colaInstrucciones.Location = new System.Drawing.Point(830, 33);
            this.lb_colaInstrucciones.Name = "lb_colaInstrucciones";
            this.lb_colaInstrucciones.Size = new System.Drawing.Size(143, 160);
            this.lb_colaInstrucciones.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 484);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Dependencias";
            // 
            // lb_dependencias
            // 
            this.lb_dependencias.FormattingEnabled = true;
            this.lb_dependencias.Location = new System.Drawing.Point(12, 501);
            this.lb_dependencias.Name = "lb_dependencias";
            this.lb_dependencias.Size = new System.Drawing.Size(199, 121);
            this.lb_dependencias.TabIndex = 10;
            // 
            // btn_ejecutar
            // 
            this.btn_ejecutar.Location = new System.Drawing.Point(166, 172);
            this.btn_ejecutar.Name = "btn_ejecutar";
            this.btn_ejecutar.Size = new System.Drawing.Size(75, 23);
            this.btn_ejecutar.TabIndex = 11;
            this.btn_ejecutar.Text = "Ejecutar";
            this.btn_ejecutar.UseVisualStyleBackColor = true;
            this.btn_ejecutar.Click += new System.EventHandler(this.btn_ejecutar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(240, 365);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Avance de Instrucciones";
            // 
            // dgv_cauce
            // 
            this.dgv_cauce.AllowUserToAddRows = false;
            this.dgv_cauce.AllowUserToDeleteRows = false;
            this.dgv_cauce.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_cauce.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_cauce.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_cauce.Location = new System.Drawing.Point(243, 381);
            this.dgv_cauce.MultiSelect = false;
            this.dgv_cauce.Name = "dgv_cauce";
            this.dgv_cauce.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_cauce.Size = new System.Drawing.Size(1065, 169);
            this.dgv_cauce.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(466, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Buffer de Carga";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(995, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Buffer de Almacenamiento";
            // 
            // dgv_carga
            // 
            this.dgv_carga.AllowUserToAddRows = false;
            this.dgv_carga.AllowUserToDeleteRows = false;
            this.dgv_carga.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_carga.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_carga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_carga.Location = new System.Drawing.Point(450, 42);
            this.dgv_carga.Name = "dgv_carga";
            this.dgv_carga.Size = new System.Drawing.Size(365, 165);
            this.dgv_carga.TabIndex = 16;
            // 
            // dgv_almacenamiento
            // 
            this.dgv_almacenamiento.AllowUserToAddRows = false;
            this.dgv_almacenamiento.AllowUserToDeleteRows = false;
            this.dgv_almacenamiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_almacenamiento.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_almacenamiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_almacenamiento.Location = new System.Drawing.Point(985, 55);
            this.dgv_almacenamiento.Name = "dgv_almacenamiento";
            this.dgv_almacenamiento.Size = new System.Drawing.Size(323, 103);
            this.dgv_almacenamiento.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(381, 215);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Estaciones de Reserva";
            // 
            // dgv_reservaSumaResta
            // 
            this.dgv_reservaSumaResta.AllowUserToAddRows = false;
            this.dgv_reservaSumaResta.AllowUserToDeleteRows = false;
            this.dgv_reservaSumaResta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_reservaSumaResta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_reservaSumaResta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_reservaSumaResta.Location = new System.Drawing.Point(374, 258);
            this.dgv_reservaSumaResta.Name = "dgv_reservaSumaResta";
            this.dgv_reservaSumaResta.Size = new System.Drawing.Size(466, 99);
            this.dgv_reservaSumaResta.TabIndex = 19;
            // 
            // dgv_reservaMulDiv
            // 
            this.dgv_reservaMulDiv.AllowUserToAddRows = false;
            this.dgv_reservaMulDiv.AllowUserToDeleteRows = false;
            this.dgv_reservaMulDiv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_reservaMulDiv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_reservaMulDiv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_reservaMulDiv.Location = new System.Drawing.Point(866, 258);
            this.dgv_reservaMulDiv.Name = "dgv_reservaMulDiv";
            this.dgv_reservaMulDiv.Size = new System.Drawing.Size(442, 79);
            this.dgv_reservaMulDiv.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(401, 239);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Suma / Resta";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(913, 239);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Multiplicación / División";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(240, 553);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Memoria";
            // 
            // dgv_memoria
            // 
            this.dgv_memoria.AllowUserToAddRows = false;
            this.dgv_memoria.AllowUserToDeleteRows = false;
            this.dgv_memoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_memoria.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_memoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_memoria.Location = new System.Drawing.Point(243, 569);
            this.dgv_memoria.Name = "dgv_memoria";
            this.dgv_memoria.Size = new System.Drawing.Size(1065, 52);
            this.dgv_memoria.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(688, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Ciclo";
            // 
            // txt_ciclo
            // 
            this.txt_ciclo.Location = new System.Drawing.Point(748, 6);
            this.txt_ciclo.Name = "txt_ciclo";
            this.txt_ciclo.Size = new System.Drawing.Size(67, 20);
            this.txt_ciclo.TabIndex = 28;
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(247, 172);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(75, 23);
            this.btn_reset.TabIndex = 29;
            this.btn_reset.Text = "Reiniciar";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // t_contador
            // 
            this.t_contador.Interval = 3000;
            this.t_contador.Tick += new System.EventHandler(this.t_contador_Tick);
            // 
            // btn_siguiente
            // 
            this.btn_siguiente.Location = new System.Drawing.Point(166, 201);
            this.btn_siguiente.Name = "btn_siguiente";
            this.btn_siguiente.Size = new System.Drawing.Size(75, 39);
            this.btn_siguiente.TabIndex = 30;
            this.btn_siguiente.Text = "Siguiente Ejecución";
            this.btn_siguiente.UseVisualStyleBackColor = true;
            this.btn_siguiente.Click += new System.EventHandler(this.btn_siguiente_Click);
            // 
            // btn_auto
            // 
            this.btn_auto.Location = new System.Drawing.Point(247, 201);
            this.btn_auto.Name = "btn_auto";
            this.btn_auto.Size = new System.Drawing.Size(84, 23);
            this.btn_auto.TabIndex = 31;
            this.btn_auto.Text = "Automático";
            this.btn_auto.UseVisualStyleBackColor = true;
            this.btn_auto.Click += new System.EventHandler(this.btn_auto_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(176, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Latencias de Ejecución";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(163, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "Carga: 2 ciclos";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(163, 67);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(145, 13);
            this.label15.TabIndex = 34;
            this.label15.Text = "Almacenamiento: 1 ciclo";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(163, 92);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 35;
            this.label16.Text = "Suma: ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(163, 117);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 13);
            this.label17.TabIndex = 36;
            this.label17.Text = "Multiplicación:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(163, 143);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 13);
            this.label18.TabIndex = 37;
            this.label18.Text = "División:";
            // 
            // txt_sumaL
            // 
            this.txt_sumaL.Location = new System.Drawing.Point(220, 89);
            this.txt_sumaL.Name = "txt_sumaL";
            this.txt_sumaL.Size = new System.Drawing.Size(44, 20);
            this.txt_sumaL.TabIndex = 38;
            // 
            // txt_multL
            // 
            this.txt_multL.Location = new System.Drawing.Point(258, 114);
            this.txt_multL.Name = "txt_multL";
            this.txt_multL.Size = new System.Drawing.Size(49, 20);
            this.txt_multL.TabIndex = 39;
            // 
            // txt_divL
            // 
            this.txt_divL.Location = new System.Drawing.Point(226, 143);
            this.txt_divL.Name = "txt_divL";
            this.txt_divL.Size = new System.Drawing.Size(47, 20);
            this.txt_divL.TabIndex = 40;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_ejecutar);
            this.groupBox1.Controls.Add(this.txt_divL);
            this.groupBox1.Controls.Add(this.txt_instrucciones);
            this.groupBox1.Controls.Add(this.txt_multL);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_sumaL);
            this.groupBox1.Controls.Add(this.btn_reset);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.btn_siguiente);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.btn_auto);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 248);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Iniciales";
            // 
            // btn_info
            // 
            this.btn_info.Image = ((System.Drawing.Image)(resources.GetObject("btn_info.Image")));
            this.btn_info.Location = new System.Drawing.Point(1257, 4);
            this.btn_info.Name = "btn_info";
            this.btn_info.Size = new System.Drawing.Size(51, 47);
            this.btn_info.TabIndex = 42;
            this.btn_info.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_info.UseVisualStyleBackColor = true;
            this.btn_info.Click += new System.EventHandler(this.btn_info_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1320, 633);
            this.Controls.Add(this.btn_info);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_ciclo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dgv_memoria);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgv_reservaMulDiv);
            this.Controls.Add(this.dgv_reservaSumaResta);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgv_almacenamiento);
            this.Controls.Add(this.dgv_carga);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgv_cauce);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lb_dependencias);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lb_colaInstrucciones);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb_registrosR);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algoritmo de Tomasulo";
            this.Load += new System.EventHandler(this.Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cauce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_carga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_almacenamiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_reservaSumaResta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_reservaMulDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_memoria)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_instrucciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lb_registrosR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lb_colaInstrucciones;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lb_dependencias;
        private System.Windows.Forms.Button btn_ejecutar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgv_cauce;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgv_carga;
        private System.Windows.Forms.DataGridView dgv_almacenamiento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgv_reservaSumaResta;
        private System.Windows.Forms.DataGridView dgv_reservaMulDiv;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgv_memoria;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_ciclo;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Timer t_contador;
        private System.Windows.Forms.Button btn_siguiente;
        private System.Windows.Forms.Button btn_auto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_sumaL;
        private System.Windows.Forms.TextBox txt_multL;
        private System.Windows.Forms.TextBox txt_divL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_info;
    }
}

