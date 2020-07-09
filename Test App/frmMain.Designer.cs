namespace testerApp
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnChangePort = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdleTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaxThreads = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAttempts = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.txtValidateInterval = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.breakPorts = new System.Windows.Forms.Timer(this.components);
            this.button15 = new System.Windows.Forms.Button();
            this.tcpServer1 = new tcpServer.TcpServer(this.components);
            this.textClientTCP = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblConnected = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timerServerSQL = new System.Windows.Forms.Timer(this.components);
            this.groupBoxMysql = new System.Windows.Forms.GroupBox();
            this.comboBoxComandos = new System.Windows.Forms.ComboBox();
            this.mysqlEventoText = new System.Windows.Forms.TextBox();
            this.mysqlRespuesta = new System.Windows.Forms.Label();
            this.buttonEmularSQL = new System.Windows.Forms.Button();
            this.timerServerSQLRead = new System.Windows.Forms.Timer(this.components);
            this.labelPing = new System.Windows.Forms.Label();
            this.timerPing = new System.Windows.Forms.Timer(this.components);
            this.labelPingError = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBoxMysql.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(12, 18);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(355, 447);
            this.txtLog.TabIndex = 1;
            // 
            // btnChangePort
            // 
            this.btnChangePort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChangePort.Location = new System.Drawing.Point(151, 39);
            this.btnChangePort.Name = "btnChangePort";
            this.btnChangePort.Size = new System.Drawing.Size(74, 23);
            this.btnChangePort.TabIndex = 13;
            this.btnChangePort.Text = "Change";
            this.btnChangePort.UseVisualStyleBackColor = true;
            this.btnChangePort.Click += new System.EventHandler(this.btnChangePort_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(129, 23);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(96, 13);
            this.lblStatus.TabIndex = 24;
            this.lblStatus.Text = "PORT NOT OPEN";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Idle Time";
            // 
            // txtIdleTime
            // 
            this.txtIdleTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtIdleTime.Location = new System.Drawing.Point(109, 184);
            this.txtIdleTime.Name = "txtIdleTime";
            this.txtIdleTime.Size = new System.Drawing.Size(40, 20);
            this.txtIdleTime.TabIndex = 26;
            this.txtIdleTime.Text = "50";
            this.txtIdleTime.TextChanged += new System.EventHandler(this.txtIdleTime_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Max Threads";
            // 
            // txtMaxThreads
            // 
            this.txtMaxThreads.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMaxThreads.Location = new System.Drawing.Point(109, 207);
            this.txtMaxThreads.Name = "txtMaxThreads";
            this.txtMaxThreads.Size = new System.Drawing.Size(40, 20);
            this.txtMaxThreads.TabIndex = 28;
            this.txtMaxThreads.Text = "100";
            this.txtMaxThreads.TextChanged += new System.EventHandler(this.txtMaxThreads_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Max Send Attempts";
            // 
            // txtAttempts
            // 
            this.txtAttempts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAttempts.Location = new System.Drawing.Point(109, 229);
            this.txtAttempts.Name = "txtAttempts";
            this.txtAttempts.Size = new System.Drawing.Size(40, 20);
            this.txtAttempts.TabIndex = 30;
            this.txtAttempts.Text = "3";
            this.txtAttempts.TextChanged += new System.EventHandler(this.txtAttempts_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Validate Interval";
            // 
            // txtValidateInterval
            // 
            this.txtValidateInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtValidateInterval.Location = new System.Drawing.Point(109, 253);
            this.txtValidateInterval.Name = "txtValidateInterval";
            this.txtValidateInterval.Size = new System.Drawing.Size(40, 20);
            this.txtValidateInterval.TabIndex = 34;
            this.txtValidateInterval.Text = "100";
            this.txtValidateInterval.TextChanged += new System.EventHandler(this.txtValidateInterval_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(100, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 16);
            this.label10.TabIndex = 37;
            this.label10.Text = "0";
            // 
            // breakPorts
            // 
            this.breakPorts.Enabled = true;
            this.breakPorts.Interval = 1000;
            this.breakPorts.Tick += new System.EventHandler(this.breakPorts_Tick);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(499, 500);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(75, 23);
            this.button15.TabIndex = 60;
            this.button15.Text = "Clear";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.btn_clear);
            // 
            // tcpServer1
            // 
            this.tcpServer1.Encoding = ((System.Text.Encoding)(resources.GetObject("tcpServer1.Encoding")));
            this.tcpServer1.IdleTime = 50;
            this.tcpServer1.IsOpen = false;
            this.tcpServer1.MaxCallbackThreads = 100;
            this.tcpServer1.MaxSendAttempts = 3;
            this.tcpServer1.Port = -1;
            this.tcpServer1.VerifyConnectionInterval = 0;
            this.tcpServer1.OnConnect += new tcpServer.tcpServerConnectionChanged(this.tcpServer1_OnConnect);
            this.tcpServer1.OnDataAvailable += new tcpServer.tcpServerConnectionChanged(this.tcpServer1_OnDataAvailable);
            // 
            // textClientTCP
            // 
            this.textClientTCP.Location = new System.Drawing.Point(0, 68);
            this.textClientTCP.Multiline = true;
            this.textClientTCP.Name = "textClientTCP";
            this.textClientTCP.ReadOnly = true;
            this.textClientTCP.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textClientTCP.Size = new System.Drawing.Size(225, 110);
            this.textClientTCP.TabIndex = 63;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLog);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(384, 481);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recepcion";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblConnected);
            this.groupBox2.Controls.Add(this.txtPort);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textClientTCP);
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtIdleTime);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtMaxThreads);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtAttempts);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtValidateInterval);
            this.groupBox2.Controls.Add(this.btnChangePort);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(410, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(230, 281);
            this.groupBox2.TabIndex = 65;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conexion";
            // 
            // lblConnected
            // 
            this.lblConnected.AutoSize = true;
            this.lblConnected.Location = new System.Drawing.Point(72, 49);
            this.lblConnected.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(13, 13);
            this.lblConnected.TabIndex = 69;
            this.lblConnected.Text = "0";
            // 
            // txtPort
            // 
            this.txtPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPort.Location = new System.Drawing.Point(57, 20);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(24, 20);
            this.txtPort.TabIndex = 68;
            this.txtPort.Text = "131";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 67;
            this.label2.Text = "PORT:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 66;
            this.label1.Text = "Clientes: ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(410, 296);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(174, 73);
            this.groupBox3.TabIndex = 66;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Estatus conexion";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(100, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 16);
            this.label13.TabIndex = 72;
            this.label13.Text = "0";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 71;
            this.label9.Text = "Correcto:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 70;
            this.label3.Text = "Desconexiones: ";
            // 
            // timerServerSQL
            // 
            this.timerServerSQL.Interval = 5000;
            this.timerServerSQL.Tick += new System.EventHandler(this.timertServerSQL_Tick);
            // 
            // groupBoxMysql
            // 
            this.groupBoxMysql.Controls.Add(this.comboBoxComandos);
            this.groupBoxMysql.Controls.Add(this.mysqlEventoText);
            this.groupBoxMysql.Controls.Add(this.mysqlRespuesta);
            this.groupBoxMysql.Controls.Add(this.buttonEmularSQL);
            this.groupBoxMysql.Location = new System.Drawing.Point(410, 374);
            this.groupBoxMysql.Name = "groupBoxMysql";
            this.groupBoxMysql.Size = new System.Drawing.Size(245, 117);
            this.groupBoxMysql.TabIndex = 83;
            this.groupBoxMysql.TabStop = false;
            this.groupBoxMysql.Text = "Mysql";
            // 
            // comboBoxComandos
            // 
            this.comboBoxComandos.FormattingEnabled = true;
            this.comboBoxComandos.Items.AddRange(new object[] {
            "SI_ABRE_E1",
            "SI_ABRE_S1",
            "CONFIGDATE",
            "GETDATE",
            "ANTIPASSBACKON",
            "ANTIPASSBACKOFF",
            "NIPEXP1234",
            "NIPVAL1234",
            "FOLVAL0000025",
            "SET_FOLIO:0000000",
            "GET_FOLIO",
            "STATUSVIG:0000C8C81B0",
            "STATUSVIG:0000C8C81B1",
            "SAVE_RFID:0000C8C81B0",
            "SAVE_RFID:0000C8C81B1",
            "PENSIONADOS_INFO",
            "PENSIONADOS_ACCESS",
            "RESET_TPV",
            "RESET_E1",
            "RESET_S1"});
            this.comboBoxComandos.Location = new System.Drawing.Point(11, 19);
            this.comboBoxComandos.Name = "comboBoxComandos";
            this.comboBoxComandos.Size = new System.Drawing.Size(219, 21);
            this.comboBoxComandos.TabIndex = 86;
            this.comboBoxComandos.SelectedIndexChanged += new System.EventHandler(this.comboBoxComandos_SelectedIndexChanged_1);
            this.comboBoxComandos.SelectedValueChanged += new System.EventHandler(this.comboBoxComandos_SelectedValueChanged);
            // 
            // mysqlEventoText
            // 
            this.mysqlEventoText.Location = new System.Drawing.Point(11, 62);
            this.mysqlEventoText.Name = "mysqlEventoText";
            this.mysqlEventoText.Size = new System.Drawing.Size(219, 20);
            this.mysqlEventoText.TabIndex = 85;
            // 
            // mysqlRespuesta
            // 
            this.mysqlRespuesta.AutoSize = true;
            this.mysqlRespuesta.Location = new System.Drawing.Point(8, 148);
            this.mysqlRespuesta.Name = "mysqlRespuesta";
            this.mysqlRespuesta.Size = new System.Drawing.Size(41, 13);
            this.mysqlRespuesta.TabIndex = 82;
            this.mysqlRespuesta.Text = "Evento";
            // 
            // buttonEmularSQL
            // 
            this.buttonEmularSQL.Location = new System.Drawing.Point(155, 88);
            this.buttonEmularSQL.Name = "buttonEmularSQL";
            this.buttonEmularSQL.Size = new System.Drawing.Size(75, 23);
            this.buttonEmularSQL.TabIndex = 81;
            this.buttonEmularSQL.Text = "Emular evento";
            this.buttonEmularSQL.UseVisualStyleBackColor = true;
            this.buttonEmularSQL.Click += new System.EventHandler(this.buttonEmularSQL_Click);
            // 
            // timerServerSQLRead
            // 
            this.timerServerSQLRead.Enabled = true;
            this.timerServerSQLRead.Interval = 2000;
            this.timerServerSQLRead.Tick += new System.EventHandler(this.timerServerSQLRead_Tick);
            // 
            // labelPing
            // 
            this.labelPing.AutoSize = true;
            this.labelPing.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPing.Location = new System.Drawing.Point(17, 500);
            this.labelPing.Name = "labelPing";
            this.labelPing.Size = new System.Drawing.Size(52, 24);
            this.labelPing.TabIndex = 85;
            this.labelPing.Text = "Ping";
            // 
            // timerPing
            // 
            this.timerPing.Enabled = true;
            this.timerPing.Interval = 1000;
            this.timerPing.Tick += new System.EventHandler(this.timerPing_Tick);
            // 
            // labelPingError
            // 
            this.labelPingError.AutoSize = true;
            this.labelPingError.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPingError.Location = new System.Drawing.Point(145, 500);
            this.labelPingError.Name = "labelPingError";
            this.labelPingError.Size = new System.Drawing.Size(134, 24);
            this.labelPingError.TabIndex = 86;
            this.labelPingError.Text = "PingError = 0";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 533);
            this.Controls.Add(this.labelPingError);
            this.Controls.Add(this.labelPing);
            this.Controls.Add(this.groupBoxMysql);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button15);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(680, 480);
            this.Name = "frmMain";
            this.Text = "Parche tablas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBoxMysql.ResumeLayout(false);
            this.groupBoxMysql.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLog;
        private tcpServer.TcpServer tcpServer1;
        private System.Windows.Forms.Button btnChangePort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdleTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaxThreads;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAttempts;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtValidateInterval;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer breakPorts;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.TextBox textClientTCP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblConnected;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Timer timerServerSQL;
        private System.Windows.Forms.GroupBox groupBoxMysql;
        private System.Windows.Forms.TextBox mysqlEventoText;
        private System.Windows.Forms.Label mysqlRespuesta;
        private System.Windows.Forms.Button buttonEmularSQL;
        private System.Windows.Forms.Timer timerServerSQLRead;
        private System.Windows.Forms.ComboBox comboBoxComandos;
        private System.Windows.Forms.Label labelPing;
        private System.Windows.Forms.Timer timerPing;
        private System.Windows.Forms.Label labelPingError;
    }
}

