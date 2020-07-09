namespace testApp
{
    partial class Boleto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoleto = new System.Windows.Forms.TextBox();
            this.labelBoleto = new System.Windows.Forms.Label();
            this.buttonNegrita = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.sizeAlto = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.sizeAncho = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.variables = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.justificacion = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoleto
            // 
            this.textBoleto.Location = new System.Drawing.Point(9, 10);
            this.textBoleto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoleto.Multiline = true;
            this.textBoleto.Name = "textBoleto";
            this.textBoleto.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoleto.Size = new System.Drawing.Size(405, 402);
            this.textBoleto.TabIndex = 0;
            this.textBoleto.TextChanged += new System.EventHandler(this.textBoleto_TextChanged);
            // 
            // labelBoleto
            // 
            this.labelBoleto.AutoSize = true;
            this.labelBoleto.Location = new System.Drawing.Point(15, 423);
            this.labelBoleto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBoleto.Name = "labelBoleto";
            this.labelBoleto.Size = new System.Drawing.Size(45, 13);
            this.labelBoleto.TabIndex = 1;
            this.labelBoleto.Text = "Bytes: 0";
            // 
            // buttonNegrita
            // 
            this.buttonNegrita.Location = new System.Drawing.Point(11, 38);
            this.buttonNegrita.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonNegrita.Name = "buttonNegrita";
            this.buttonNegrita.Size = new System.Drawing.Size(84, 22);
            this.buttonNegrita.TabIndex = 2;
            this.buttonNegrita.Text = "Negrita";
            this.buttonNegrita.UseVisualStyleBackColor = true;
            this.buttonNegrita.Click += new System.EventHandler(this.buttonNegrita_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonClear);
            this.groupBox1.Controls.Add(this.buttonLoad);
            this.groupBox1.Controls.Add(this.buttonSave);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.variables);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.justificacion);
            this.groupBox1.Controls.Add(this.buttonNegrita);
            this.groupBox1.Location = new System.Drawing.Point(418, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(246, 243);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(11, 168);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(84, 22);
            this.buttonClear.TabIndex = 10;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(118, 195);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(84, 22);
            this.buttonLoad.TabIndex = 9;
            this.buttonLoad.Text = "Cargar";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(13, 195);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(84, 22);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.sizeAlto);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.sizeAncho);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(118, 17);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(106, 99);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dimension";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 65);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 22);
            this.button1.TabIndex = 3;
            this.button1.Text = "Tamaño";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sizeAlto
            // 
            this.sizeAlto.FormattingEnabled = true;
            this.sizeAlto.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.sizeAlto.Location = new System.Drawing.Point(12, 37);
            this.sizeAlto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sizeAlto.Name = "sizeAlto";
            this.sizeAlto.Size = new System.Drawing.Size(36, 21);
            this.sizeAlto.TabIndex = 9;
            this.sizeAlto.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Alto";
            // 
            // sizeAncho
            // 
            this.sizeAncho.FormattingEnabled = true;
            this.sizeAncho.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.sizeAncho.Location = new System.Drawing.Point(62, 37);
            this.sizeAncho.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sizeAncho.Name = "sizeAncho";
            this.sizeAncho.Size = new System.Drawing.Size(36, 21);
            this.sizeAncho.TabIndex = 11;
            this.sizeAncho.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Ancho";
            // 
            // variables
            // 
            this.variables.FormattingEnabled = true;
            this.variables.Items.AddRange(new object[] {
            "Folio",
            "Fecha",
            "CodigoBar1",
            "CodigoBar2"});
            this.variables.Location = new System.Drawing.Point(11, 133);
            this.variables.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.variables.Name = "variables";
            this.variables.Size = new System.Drawing.Size(86, 21);
            this.variables.TabIndex = 8;
            this.variables.Text = "Folio";
            this.variables.SelectedIndexChanged += new System.EventHandler(this.variables_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Variables";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Negrita";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Justificacion";
            // 
            // justificacion
            // 
            this.justificacion.FormattingEnabled = true;
            this.justificacion.Items.AddRange(new object[] {
            "Izquierda",
            "Centrada",
            "Derecha"});
            this.justificacion.Location = new System.Drawing.Point(11, 86);
            this.justificacion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.justificacion.Name = "justificacion";
            this.justificacion.Size = new System.Drawing.Size(92, 21);
            this.justificacion.TabIndex = 4;
            this.justificacion.Text = "Izquierda";
            this.justificacion.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Boleto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 442);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelBoleto);
            this.Controls.Add(this.textBoleto);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Boleto";
            this.Text = "Boleto";
            this.Load += new System.EventHandler(this.Boleto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoleto;
        private System.Windows.Forms.Label labelBoleto;
        private System.Windows.Forms.Button buttonNegrita;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox justificacion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox variables;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox sizeAlto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox sizeAncho;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonClear;
    }
}