/****************************************************************
 * This work is original work authored by Craig Baird, released *
 * under the Code Project Open Licence (CPOL) 1.02;             *
 * http://www.codeproject.com/info/cpol10.aspx                  *
 * This work is provided as is, no guarentees are made as to    *
 * suitability of this work for any specific purpose, use it at *
 * your own risk.                                               *
 * This product is not intended for use in any form except      *
 * learning. The author recommends only using small sections of *
 * code from this project when integrating the attacked         *
 * TcpServer project into your own project.                     *
 * This product is not intended for use for any comercial       *
 * purposes, however it may be used for such purposes.          *
 ****************************************************************/

using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
//Anexados
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
//using MySql.Data.MySqlClient; 
using System.Net;
using System.Threading;
using System.Net.NetworkInformation;


namespace testerApp
{
    public partial class frmMain : Form
    {
        //Par el servicio socket
        public delegate void invokeDelegate();
        List<testApp.PIC> PICS = new List<testApp.PIC>();
        //Para conexion del servidor de la appEstacionamientos
        string serverIp = "192.168.1.99";
        int serverPort = 123;
        TcpClient client; // Creates a TCP Client
        NetworkStream streamClient, streamRead; //Creats a NetworkStream (used for sending and receiving data)
        byte[] datalengthCliente = new byte[128]; // creates a new byte with length 4 ( used for receivng data's lenght)
        //Para conexion del servidor de accesa
        string serverIpAccesa = "accesawork.ddns.net";
        int serverPortAccesa = 170;
        TcpClient clientAccesa; // Creates a TCP Client
        NetworkStream streamClientAccesa, streamReadAccesa;
        byte[] datalengthClienteAccesa = new byte[128];

        //Variables de conexion
        bool picConectado = false;  //Pic conexion
        string picIp = "192.168.1.5";
        Ping Pings = new Ping();
        int timeoutPing = 150;  //Valor en milisegundos
        int pingError = 0;
        const int timeMaxPingError = 1;  //En minutos
        bool pingPic = false;
        bool resetearPic = false;

        //Crear objeto mysql
        testApp.tableMysql tabla = new testApp.tableMysql();
        string dbName = "estacionamientos"; //conaccantoniosolabis  estacionamientos
        string dbServer = "localhost";
        string dbUser = "root";
        string dbPassword = "canis789";  //ALAala123,.-   canis789
        bool eventoPC = false;
        string id;                       //Apunta al id actual de eventos pc

        //Otras variables
        byte tempGetReport = 0;
        bool showBoxes;
        bool showGUI;
        bool bloquearComandosDB;
        bool isTpvValidadora;

        //Nuevas variables
        string lastRegister = "";
        int tiempoTol = 1;

        /******************************************************************************/
        public frmMain()
        {
            InitializeComponent();
            this.CenterToScreen();

            //Bloquear cuadro de emulacion
            //groupBox12.Enabled = activarEmulacionSQL;

            //Cargar la base de datos a conectar
            StreamReader archivo = new StreamReader("config.txt");

            //Lectura a la base de datos establecer conexion
            dbName = archivo.ReadLine();
            dbPassword = archivo.ReadLine();
            picIp = archivo.ReadLine();
            showBoxes = archivo.ReadLine() == "alertDB" ? true : false;
            showGUI = archivo.ReadLine() == "hidden" ? true : false;
            bloquearComandosDB = archivo.ReadLine() == "blockDB" ? true : false;
            archivo.ReadLine().ToString();  //Barrera bidereccionañ
            tiempoTol = (int)Convert.ToInt16(archivo.ReadLine());
            isTpvValidadora = archivo.ReadLine() == "tpvValidadora";

            //Inicializar componentes
            groupBoxMysql.Enabled = !bloquearComandosDB;
        }
        /*********************************************************************************/
        private void frmMain_Load(object sender, EventArgs e)
        {
            //Para mantener el socket abierto
            btnChangePort_Click(null, null);
            timer1.Enabled = true;

            //Init combo box
            //comboBoxComandos.SelectedIndex = 0;

            //Conexion al servidor
            //conectarApp(serverIp, serverPort);

            //Conexion a la database
            tabla.conectar(dbServer, dbUser, dbPassword, dbName);
            txtLog.Text += tabla.estatusReport;
            if (!tabla.conectado)
                timerServerSQL.Enabled = true;

            if (showBoxes)
                MessageBox.Show(tabla.estatusReport);
        }
        /*********************************************************************************/
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            tcpServer1.Close();
        }
        /*********************************************************************************/
        private void btnChangePort_Click(object sender, EventArgs e)
        {
            try
            {
                openTcpPort();
            }
            catch (FormatException)
            {
                MessageBox.Show("Port must be an integer", "Invalid Port", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (OverflowException)
            {
                MessageBox.Show("Port is too large", "Invalid Port", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        /*********************************************************************************/
        private void openTcpPort()
        {
            tcpServer1.Close();
            tcpServer1.Port = Convert.ToInt32(txtPort.Text);
            txtPort.Text = tcpServer1.Port.ToString();
            tcpServer1.Open();

            displayTcpServerStatus();
        }
        /*********************************************************************************/
        private void displayTcpServerStatus()
        {
            if (tcpServer1.IsOpen)
            {
                lblStatus.Text = "PORT OPEN";
                lblStatus.BackColor = Color.Lime;
                //estado = 1;
            }
            else
            {
                lblStatus.Text = "PORT NOT OPEN";
                lblStatus.BackColor = Color.Red;
                //string mensaje = "Imposible Abrir el Puerto seleccionado, Es posible esté siendo ocupado por otro proceso...";
                //MessageBox.Show("Error", mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        /*********************************************************************************/
        string encrypt_basic(string texto)
        {
            char[] cadena = texto.ToArray();
            texto = "";

            for (int cont = 0; cont < cadena.Length; cont++)
            {
                if (cadena[cont] == '0')
                    cadena[cont] = '2';
                else if (cadena[cont] == '1')
                    cadena[cont] = '0';
                else if (cadena[cont] == '2')
                    cadena[cont] = '8';
                else if (cadena[cont] == '3')
                    cadena[cont] = '9';
                else if (cadena[cont] == '4')
                    cadena[cont] = '7';
                else if (cadena[cont] == '5')
                    cadena[cont] = '6';
                else if (cadena[cont] == '6')
                    cadena[cont] = '4';
                else if (cadena[cont] == '7')
                    cadena[cont] = '5';
                else if (cadena[cont] == '8')
                    cadena[cont] = '3';
                else if (cadena[cont] == '9')
                    cadena[cont] = '1';

                texto += "" + cadena[cont];
            }
            return texto;
        }
        /*********************************************************************************/
        string decrypt_basic(string texto)
        {
            char[] cadena = texto.ToArray();
            texto = "";

            for (int cont = 0; cont < cadena.Length; cont++)
            {
                if (cadena[cont] == '0')
                    cadena[cont] = '1';
                else if (cadena[cont] == '1')
                    cadena[cont] = '9';
                else if (cadena[cont] == '2')
                    cadena[cont] = '0';
                else if (cadena[cont] == '3')
                    cadena[cont] = '8';
                else if (cadena[cont] == '4')
                    cadena[cont] = '6';
                else if (cadena[cont] == '5')
                    cadena[cont] = '7';
                else if (cadena[cont] == '6')
                    cadena[cont] = '5';
                else if (cadena[cont] == '7')
                    cadena[cont] = '4';
                else if (cadena[cont] == '8')
                    cadena[cont] = '2';
                else if (cadena[cont] == '9')
                    cadena[cont] = '3';

                texto += "" + cadena[cont];
            }
            return texto;
        }
        /*********************************************************************************/
        bool parcheToServer(string texto, out string respuesta) {
            int tam = texto.Length;
            string tarjeta, fecha, estatus, entrada, folio;  //Para los eventos hacer enviados
            int nodo;

            //Inicializar proceso
            respuesta = null;


            if (texto.StartsWith("<PEN"))
            {
                if (texto.Contains("REG") && tam >= "<PEN6C2AE3REG>".Length)
                {   //<PEN6C2AE3REGREGISTRADO> FORMATO: SAVE123456789   
                    //respuesta = "SAVED" + "0000" + texto.Substring(4, 6) + ",";
                    //tarjeta = Convert.ToInt32(texto.Substring(4, 6), 16).ToString();
                    //txtLog.Text += "PENSIONADO: " + tarjeta + "\r\n";
                }
                else if (texto.Contains("VIG") && tam >= "<PENC8C81BVIG>".Length)
                {   //<PENC8C81BVIGMODIFICADO>    
                    //respuesta = "SAVED" + "0000" + texto.Substring(4, 6) + "X" + ",";
                }
                else if (tam >= "<PENC8C81B120006290818NNPNE01>".Length)
                {   //Evento por pensionado
                    //Retransmitir <PEN+C8C81B+12+00+06+29+08+18+NNPN+E01> == 1E-0000E43E0C0001, PENSIONADO0000E43E0C28-08-18-12-25-14/E10001
                    tarjeta = "0000" + texto.Substring(4, 6);
                    fecha = texto.Substring(16, 2) + "-" + texto.Substring(18, 2) + "-" + texto.Substring(20, 2) + "-" +
                        texto.Substring(10, 2) + "-" + texto.Substring(12, 2) + "-" + texto.Substring(14, 2);
                    estatus = texto.Substring(22, 4);
                    entrada = (texto.Substring(26, 1) == "E" ? "E" : "S");
                    nodo = Convert.ToInt32(texto.Substring(27, 2), 16);
                    entrada += (entrada == "E" ? ((nodo + 1) / 2) : nodo / 2);

                    //Modificar estatus
                    estatus = estatus.Replace("N", "0");
                    estatus = estatus.Replace("A", "1");
                    estatus = estatus.Replace("V", "1");
                    estatus = estatus.Replace("P", "1");
                    estatus = estatus.Replace("D", "1");
                    estatus = estatus.Replace("T", "1");
                    estatus = estatus.Replace("S", "1");
                    estatus = estatus.Replace("-", "0");

                    //Envio de evento
                    respuesta = "PENSIONADO" + tarjeta + fecha + "/" + entrada + estatus + ",";
                    //Respuesta
                    txtLog.Text += respuesta + "\r\n";
                    /*
                    //Añado acceso
                    capturar = texto.Substring("<PENC8C81B".Length, 6);
                    capturar += texto.Substring("<PENC8C81B120006290818NNPN".Length, 3);
                    accesosPermitidos.RemoveAt(0);
                    accesosPermitidos.Add(capturar); //Añade al final el primer item 
                     */
                }
            }
            else if (texto.StartsWith("<PRE"))
            {

            }
            else if (texto.StartsWith("<IDX"))
            {
                if (tam >= "<IDX4CD0B9102414290818NNNDE01>".Length)
                {
                    //<IDX+4CD0B9+102414290818NNNDE01>,  1E-0000E43E0C+0001
                    tarjeta = "0000" + texto.Substring(4, 6);
                    fecha = texto.Substring(16, 2) + "-" + texto.Substring(18, 2) + "-" + texto.Substring(20, 2) + "-" +
                        texto.Substring(10, 2) + "-" + texto.Substring(12, 2) + "-" + texto.Substring(14, 2);
                    estatus = texto.Substring(22, 4);
                    entrada = (texto.Substring(26, 1) == "E" ? "E" : "S");
                    nodo = Convert.ToInt32(texto.Substring(27, 2), 16);
                    entrada += entrada == "E" ? ((nodo + 1) / 2) : nodo / 2;

                    //Modificar estatus
                    estatus = estatus.Replace("N", "0");
                    estatus = estatus.Replace("A", "1");
                    estatus = estatus.Replace("V", "1");
                    estatus = estatus.Replace("P", "1");
                    estatus = estatus.Replace("D", "1");
                    estatus = estatus.Replace("T", "1");
                    estatus = estatus.Replace("S", "1");
                    estatus = estatus.Replace("-", "0");

                    //Envio de evento
                    respuesta = "PENSIONADO" + tarjeta + fecha + "/" + entrada + estatus + ",";
                    //Respuesta
                    txtLog.Text += respuesta + "\r\n";
                }
            }
            else if (texto.StartsWith("<FOL"))
            {
                //REENVIA EL FORMATO: FOL+00000013+08+33+48+29+08+18+E01 POR 1E-BOLETO08216483232030+0000004
                if (texto.Contains("GET"))
                {
                    //Sin accion
                    if (texto.Length >= "<FOLGET00000002E01>".Length)
                    {
                        folio = Convert.ToInt32(texto.Substring("<FOLGET".Length, 8), 16).ToString();
                        entrada = (texto.Substring("<FOLGET00000002".Length, 1) == "E" ? "E" : "S");
                        nodo = Convert.ToInt32(texto.Substring("<FOLGET00000002E".Length, 2), 16);
                        entrada += entrada == "E" ? ((nodo + 1) / 2) : nodo / 2;

                        txtLog.Text += "FOLIO: " + entrada + "-" + folio + "\r\n";
                    }
                }
                else if (tam >= "<FOL00000013083348290818E01>".Length)
                {
                    //Formato del boleto
                    string numFolio = Convert.ToInt32(texto.Substring(4, 8), 16).ToString("D7");
                    fecha = texto.Substring(12, 10) + "0" + texto.Substring(22, 2) + "1"; //HHMMSSDDMM + YY
                    entrada = (texto.Substring(24, 1) == "E" ? "E" : "S");
                    nodo = Convert.ToInt32(texto.Substring(25, 2), 16);
                    entrada = (entrada == "E" ? ((nodo + 1) / 2) : nodo / 2) + entrada + "-";

                    //Validacion de fechas del pic
                    try
                    {
                        //Validar hora del boleto
                        DateTime fechaActual = DateTime.Now;
                        DateTime fechaPic = fechaActual;

                        bool changeDate = !fechaFromPicDate(texto.Substring(12, 12), out fechaPic);
                        var dif = fechaActual - fechaPic;
                        //Valido rango de tiempo en fecha pasada y futura
                        int minutos = (int)dif.TotalMinutes;
                        if (minutos >= tiempoTol || minutos <= -tiempoTol || changeDate)
                        {
                            string nuevaFecha = fechaFromPcToPic(false);
                            fecha = nuevaFecha.Substring(0, 10) + "0" + nuevaFecha.Substring(10, 2) + "1"; //HHMMSSDDMM + YY
                            //MessageBox.Show("Variacion: " + (int)dif.TotalHours + "," + (int)dif.TotalMinutes + "," + (int)dif.TotalSeconds);
                            if (changeDate)
                            {
                                txtLog.Text += "Cambio de hora al boleto wrong format\r\n";
                                //Manda modificacion de cambio de hora
                                tabla.insertar("insert into eventosPC (fechaRegistro, fechaAtencion, evento, estatus) values(now(),'','CONFIGDATE','sin leer')");
                                txtLog.Text += "Registrando para pc: " + tabla.estatusReport;
                            }
                            else
                            {
                                txtLog.Text += "Cambio de hora al boleto \r\n";
                            }
                        }
                    }
                    catch
                    {
                        string nuevaFecha = fechaFromPcToPic(false);
                        fecha = nuevaFecha.Substring(0, 10) + "0" + nuevaFecha.Substring(10, 2) + "1"; //HHMMSSDDMM + YY                                                                              
                        txtLog.Text += "Cambio de hora al boleto por error de formato \r\n";
                    }
                    //Envio de evento
                    respuesta = entrada + "BOLETO" + encrypt_basic(fecha) + numFolio + ",";
                    txtLog.Text += respuesta + "\r\n";
                }
            }
            else if (texto.StartsWith("<CAR"))
            {
                if (tam >= "<CARO102105290818E01>".Length)
                {
                    //<CARO102105290818E01> por formato EN1-ENTRADA
                    entrada = (texto.Substring(17, 1) == "E" ? "E" : "S");
                    nodo = Convert.ToInt32(texto.Substring(18, 2), 16);
                    entrada = entrada + "N" + (entrada == "E" ? ((nodo + 1) / 2) : nodo / 2) + "-";

                    //FORMATO EN1-ENTRADA
                    if (texto.Substring(4, 1) == "I")
                    {
                        respuesta = entrada + "ENTRADA";
                    }
                    else if (texto.Substring(4, 1) == "O")
                    {
                        respuesta = entrada + "SINDETECCION";
                    }
                    //Envio de evento
                    //respuesta += (texto.Contains(",") ? "," : "");
                    txtLog.Text += respuesta + "\r\n";
                }
            }
            else if (texto.StartsWith("<BAR"))
            {
                if (tam >= "<BAROPEN130607290818E01>".Length)
                {
                    //<BAROPEN130607290818E01> formato: BARRERA+ABIERTA+E1+28+08+18+12+26+13,
                    fecha = texto.Substring(14, 2) + texto.Substring(16, 2) + texto.Substring(18, 2) +
                        texto.Substring(8, 2) + texto.Substring(10, 2) + texto.Substring(12, 2);
                    entrada = (texto.Substring(20, 1) == "E" ? "E" : "S");
                    nodo = Convert.ToInt32(texto.Substring(21, 2), 16);
                    entrada += (entrada == "E" ? ((nodo + 1) / 2) : nodo / 2);


                    //Envio de evento
                    respuesta = "BARRERAABIERTA" + entrada + fecha + ",";
                    //Respuesta
                    txtLog.Text += respuesta + "\r\n";
                    respuesta = null;
                }
            }
            else if (texto.StartsWith("<OUTKEY"))
            {
                //<OUTKEYFOL0001E241REGV02>
                int num;

                if (texto.Contains("NIP"))
                {
                    if (tam >= "<OUTKEYNIP00000DC4REGV02>".Length)
                    {
                        //Responder
                        num = Convert.ToInt32(texto.Substring("<OUTKEYNIP".Length, 8), 16);
                        respuesta = "NIP" + "REG" + num.ToString("D4") + texto.Substring("<OUTKEYNIP00000DC4REG".Length, 3) + ",";
                        txtLog.Text += respuesta + "\r\n";
                    }
                }
                else if (texto.Contains("FOL"))
                {
                    if (tam >= "<OUTKEYFOL00000DC4REGV02>".Length)
                    {
                        //Responder
                        num = Convert.ToInt32(texto.Substring("<OUTKEYFOL".Length, 8), 16);
                        respuesta = "FOL" + "REG" + num.ToString("D7") + texto.Substring("<OUTKEYNIP00000DC4REG".Length, 3) + ",";
                        txtLog.Text += respuesta + "\r\n";
                    }
                }
            }
            else if (texto.StartsWith("<NIP") || texto.StartsWith("<KEY"))
            {
                if (tam >= "<KEY1234094735200918NNPNV02>".Length)
                {
                    //FORMATO: NIP/KEY + NIP(4) + FECHA(12:HHMMSSDDMTYY) + [ACCESO,VIGENCIA,PASSBACK,DESCONOCIDO] + PLACA
                    string nip = texto.Substring(4, 4);
                    fecha = texto.Substring(8, 12);
                    estatus = texto.Substring(20, 4);
                    entrada = (texto.Substring(24, 1) == "E" ? "E" : "S");
                    nodo = Convert.ToInt32(texto.Substring(25, 2), 16);
                    entrada = (entrada == "E" ? ((nodo + 1) / 2) : nodo / 2) + entrada + "-";

                    //Modificar estatus
                    estatus = estatus.Replace("N", "0");
                    estatus = estatus.Replace("A", "1");
                    estatus = estatus.Replace("V", "1");
                    estatus = estatus.Replace("P", "1");
                    estatus = estatus.Replace("D", "1");
                    estatus = estatus.Replace("T", "1");
                    estatus = estatus.Replace("S", "1");
                    estatus = estatus.Replace("-", "0");
                    //Respuesta al sistema
                    respuesta = entrada + "NIP" + nip + fecha + estatus + ",";
                }
            }
            else if (texto.StartsWith("<CMDCUP")) {
                //<CMDCUP1E01>

                if (texto.Length >= "<CMDCUP1>".Length)
                {
                    estatus = texto.Substring("<CMDCUP".Length, 1);

                    if (estatus == "1")
                        respuesta = "CUPOLLENO";
                    else
                        respuesta = "CUPOLIBRE";
                }
            }
            else if (texto.StartsWith("<CMDPAS"))
            {
                if (texto.Length >= "<CMDPAS0E01>".Length)
                {
                    estatus = texto.Substring("<CMDPAS".Length, 1);

                    if (estatus == "1")
                        respuesta = "PASSBACKON";
                    else
                        respuesta = "PASSBACKOFF";
                }
            }
            else if (texto.StartsWith("<CMDOPN1"))
            {
                if (texto.Length >= "<CMDOPN1V02>".Length)
                {
                    entrada = (texto.Substring(8, 1) == "E" ? "E" : "S");
                    nodo = Convert.ToInt32(texto.Substring(9, 2), 16);
                    entrada = (entrada == "E" ? ((nodo + 1) / 2) : nodo / 2) + entrada + "-";

                    //respuesta = entrada + "ABIERTA";
                    txtLog.Text += entrada + "ABIERTA" + "\r\n";
                }
            }
            else if (texto.StartsWith("<SOP"))
            {
                if (texto.Length >= "<SOP4CAE53155923291018E01>".Length)
                {
                    tarjeta = "0000" + texto.Substring(4, 6);
                    fecha = texto.Substring(16, 2) + "-" + texto.Substring(18, 2) + "-" + texto.Substring(20, 2) + "-" +
                        texto.Substring(10, 2) + "-" + texto.Substring(12, 2) + "-" + texto.Substring(14, 2);
                    entrada = (texto.Substring(22, 1) == "E" ? "E" : "S");
                    nodo = Convert.ToInt32(texto.Substring(23, 2), 16);
                    entrada += (entrada == "E" ? ((nodo + 1) / 2) : nodo / 2);

                    respuesta = "SOPORTETAR" + tarjeta + fecha + "/" + entrada + "1000" + ",";
                    //respuesta = "SOPORTE:" + "0000" + texto.Substring("<SOP".Length, 6) + texto.Substring("<SOP4CAE53".Length, 12);
                    //respuesta += (texto.Substring("<SOP4CAE53155923291018".Length, 1) == "E" ? "E" : "S") + Convert.ToInt32(texto.Substring("<SOP4CAE53155923291018E".Length, 2), 16);
                    txtLog.Text += respuesta + "\r\n";
                }
            } else if (texto.StartsWith("<INIRST")) {
                //respuesta = "PIC RESET";
                txtLog.Text += "PIC RESETADO" + "\r\n";
                resetearPic = false;
            }
            else if (texto.StartsWith("<CONT"))
            {
                string contadorID, conteoEntran, conteoSalen, conteoBloqueos, conteoTotal;
                //if(texto.Length >= "<CONTXXE:XXXX/S:XXXX/B:XXXX/T:XXXX>".Length)
                //{
                contadorID = texto.Substring(5, 2);
                conteoEntran = texto.Substring(9, 4);
                conteoSalen = texto.Substring(16, 4);
                conteoBloqueos = texto.Substring(23, 4);
                conteoTotal = texto.Substring(30, 4);
                respuesta = "<CONT" + contadorID + "E:" + conteoEntran + "/" + "S:" + conteoSalen + "/" + "B:" + conteoBloqueos + "/" + "T:" + conteoTotal + ">";
                txtLog.Text += respuesta + "\r\n";
                //}
            }
            else if (texto.StartsWith("<RESET"))
            {
                string contadorID;
                contadorID = texto.Substring(6, 2);
                respuesta = "RESET" + contadorID;
                txtLog.Text += "Reset confirmado: " + respuesta + "\r\n";
            }
            //Devolver condicion logica
            if (respuesta != null)
                return true;
            else
                return false;
        }
        /*********************************************************************************/
        bool parcheToPic(string comandoServer, out string result)
        {
            string nodoDestino;
            int nodo;

            //Respuesta del server
            result = "";
            comandoServer = comandoServer.Replace("@", "");

            //Procesar palabras de control
            if (comandoServer.StartsWith("SI_ABRE_") && comandoServer.Length >= "SI_ABRE_S1".Length)
            {
                nodoDestino = comandoServer.Substring("SI_ABRE_".Length, 1) == "S" ? "V" : "E";
                nodo = Convert.ToInt32(comandoServer.Substring("SI_ABRE_S".Length, 1));

                //Nuevo nodo change
                if (nodoDestino == "V" && isTpvValidadora && nodo == 1)
                {
                    result = "<" + "OPN" + ">";
                    return true;
                }
                //Enviar algun nodo destino
                if (nodoDestino == "E")
                    nodo = (nodo * 2) - 1;
                else
                    nodo = nodo * 2;

                //Responder
                result = "<" + "CMD" + nodoDestino + nodo.ToString("X2") + "OPN" + ">";
            }
            else if (comandoServer.StartsWith("CUPO_"))
            {
                if (comandoServer.Contains("LLENO"))
                {
                    result = "<" + "CMD" + "ALL" + "CUP1" + ">";
                }
                else if (comandoServer.Contains("DISPO"))
                {
                    result = "<" + "CMD" + "ALL" + "CUP0" + ">";
                }

                result = "";
            }
            else if (comandoServer.StartsWith("CONFIGDATE"))
            {
                string dateText = fechaFromPcToPic(true);

                result = "<" + "RTC" + "SET" + dateText + ">";
            }
            else if (comandoServer.StartsWith("GETDATE"))
            {
                string dateText = fechaFromPcToPic(true);

                result = "<" + "RTC" + "GET" + ">";
            }
            else if (comandoServer.StartsWith("SAVE_RFID:"))
            {
                //Registrar pensionado: SAVE_RFID:00006C2AE3+1,
                if (comandoServer.Length >= "SAVE_RFID:00006C2AE31".Length)
                {
                    string tarjeta = comandoServer.Substring("SAVE_RFID:".Length, 10);
                    string vigencia = comandoServer.Substring("SAVE_RFID:00006C2AE3".Length, 1) == "1" ? "V" : "N";

                    result = "<" + "PEN" + tarjeta.Substring(4) + "REG" + vigencia + "O" + ">";
                }
            }
            else if (comandoServer.StartsWith("STATUSVIG:"))
            {
                if (comandoServer.Length >= "STATUSVIG:00006C2AE3X".Length)
                {
                    string tarjeta = comandoServer.Substring("STATUSVIG:".Length, 10);
                    string vigencia = comandoServer.Substring("STATUSVIG:00006C2AE3".Length, 1) == "1" ? "V" : "N";

                    //if (comandoServer.EndsWith("A"))
                    result = "<" + "PEN" + tarjeta.Substring(4) + "VIG" + vigencia + ">";
                }
            }
            else if (comandoServer.StartsWith("NIP"))
            {
                string dateText = fechaFromPcToPic(false);
                nodoDestino = comandoServer.Contains("EXP") ? "E01" : "V02"; //Validadora
                int numero;

                //Validacion
                if (comandoServer.Length >= "NIPEXP1234".Length)
                    numero = Convert.ToInt32(comandoServer.Substring("NIPEXP".Length, 4));
                else
                    return false;
                //Respuesta
                result = "<" + "CMD" + nodoDestino + "KEY" + "NIP" + numero.ToString("X8") + dateText + ">";
            }
            else if (comandoServer.StartsWith("FOL"))
            {
                string dateText = fechaFromPcToPic(false);
                nodoDestino = comandoServer.Contains("EXP") ? "E01" : "V02"; //Validadora
                int numero;

                if (comandoServer.Length >= "FOLEXP1234567".Length)
                    numero = Convert.ToInt32(comandoServer.Substring("FOLEXP".Length, 7));
                else
                    return false;  //NIPEXP
                //Respuesta
                result = "<" + "CMD" + nodoDestino + "KEY" + "FOL" + numero.ToString("X8") + dateText + ">";
            }
            else if (comandoServer.StartsWith("ANTIPASSBACK"))
            {
                if (comandoServer == "ANTIPASSBACKON")
                {
                    result = "<" + "CMD" + "ALL" + "PAS1" + ">";
                }
                else if (comandoServer == "ANTIPASSBACKOFF")
                {
                    result = "<" + "CMD" + "ALL" + "PAS0" + ">";
                }
            }
            else if (comandoServer.StartsWith("RESET"))
            {
                if (comandoServer.StartsWith("RESET_TPV"))
                {
                    result = "<RST>";
                }
                else
                {
                    if (comandoServer.Length >= "RESET_E1".Length)
                    {
                        nodoDestino = comandoServer.Substring("RESET_".Length, 1) == "S" ? "V" : "E";
                        nodo = Convert.ToInt32(comandoServer.Substring("RESET_S".Length, 1));

                        if (nodoDestino == "E")
                            nodo = (nodo * 2) - 1;
                        else
                            nodo = nodo * 2;

                        result = "<" + "CMD" + nodoDestino + nodo.ToString("X2") + "RST" + ">";
                    }

                }
            }
            else if (comandoServer.StartsWith("SET_FOLIO:"))
            {
                if (comandoServer.Length >= "SET_FOLIO:1234567".Length)
                {
                    int folio = Convert.ToInt32(comandoServer.Substring("SET_FOLIO:".Length, 7));
                    result = "<" + "CMD" + "E01" + "FOL" + "SET" + folio.ToString("X8") + ">";
                }
            }
            else if (comandoServer.StartsWith("GET_FOLIO"))
            {
                result = "<" + "CMD" + "E01" + "FOL" + "GET" + ">";
            }
            else if (comandoServer.StartsWith("PENSIONADOS_INFO"))
            {
                result = "<" + "TBL" + "ALL" + "INF" + "Pensionados" + ">";
            }
            else if (comandoServer.StartsWith("PENSIONADOS_ERASE"))
            {
                result = "<" + "TBL" + "ALL" + "ERS" + "Pensionados" + ">";
            }
            else if (comandoServer.StartsWith("PENSIONADOS_ACCESS"))
            {
                result = "<" + "TBL" + "ALL" + "PAS" + "Pensionados" + ">";
            }
            else if (comandoServer.StartsWith("BORRAR_ALL"))
            {
                result = "<BORRAR_ALL>";
            }


            //Condicion de datos
            if (result == "")
                return false;
            else
                return true;
        }
        /*********************************************************************************/
        string fechaFromPcToPic(bool dayOfWeek)
        {
            DateTime date = DateTime.Now;
            string dateText = "";
            //Convertir formato  W-HH/MM/SS DD/MM/YY
            if (dayOfWeek)
                dateText += Convert.ToString((int)date.DayOfWeek + 1); //Domingo = 0
            dateText += date.Hour.ToString("D2");
            //dateText += "21";
            dateText += date.Minute.ToString("D2");
            dateText += date.Second.ToString("D2");
            dateText += date.Day.ToString("D2");
            dateText += date.Month.ToString("D2");
            dateText += date.Year.ToString("D2").Substring(2, 2);

            return dateText;
        }
        /*********************************************************************************/
        string fechaFromPic(string fechaPic)
        {
            int hour, min, sec, day, month, year;
            string result = "";
            DateTime date;

            //Convertir la hora
            try
            {
                //HHMMSSDDMMYY
                if (fechaPic.Length >= "HHMMSSDDMMYY".Length)
                {
                    hour = Int32.Parse(fechaPic.Substring(0, 2));
                    min = Int32.Parse(fechaPic.Substring(2, 2));
                    sec = Int32.Parse(fechaPic.Substring(4, 2));
                    day = Int32.Parse(fechaPic.Substring(6, 2));
                    month = Int32.Parse(fechaPic.Substring(8, 2));
                    year = Int32.Parse(fechaPic.Substring(10, 2));
                    date = new DateTime(year, month, day, hour, min, sec);

                    result = date.ToString();
                }
                else
                {
                    result = DateTime.Now.ToString();
                }
            }
            catch
            {
                result = DateTime.Now.ToString();
            }

            return result;
        }
        /*********************************************************************************/
        bool fechaFromPicDate(string fechaPic, out DateTime fechaRef)
        {
            int hour, min, sec, day, month, year;
            DateTime date = DateTime.Now;

            //Convertir la hora
            try
            {
                //HHMMSSDDMMYY
                if (fechaPic.Length >= "HHMMSSDDMMYY".Length)
                {
                    hour = Int32.Parse(fechaPic.Substring(0, 2));
                    min = Int32.Parse(fechaPic.Substring(2, 2));
                    sec = Int32.Parse(fechaPic.Substring(4, 2));
                    day = Int32.Parse(fechaPic.Substring(6, 2));
                    month = Int32.Parse(fechaPic.Substring(8, 2));
                    year = 2000 + Int32.Parse(fechaPic.Substring(10, 2));
                    date = new DateTime(year, month, day, hour, min, sec);
                    fechaRef = date;
                    return true;
                }
                else
                {
                    date = DateTime.Now;
                }
            }
            catch
            {
                date = DateTime.Now;
            }
            fechaRef = date;
            return false;
        }
        /*********************************************************************************/
        private void tcpServer1_OnDataAvailable(tcpServer.TcpServerConnection connection)
        {
            byte[] datos = readStream(connection.Socket);
            string parcheText = "";

            //Si hay datos que procesar
            if (datos != null)
            {
                string dataStr = Encoding.ASCII.GetString(datos);
                //dataStr.EndsWith(",");
                invokeDelegate del = () =>
                {
                    //Convertir dataStr en array
                    string[] datosTcp = dataStr.Split(new char[] { '>' });

                    //Decodificar los datos de entrada
                    for (int i = 0; i < datosTcp.Length; i++)
                    {
                        //Añadir el caracter que anule por el split
                        datosTcp[i] += ">";

                        //Guardar evento a la tabla, registros completos 
                        if (datosTcp[i].StartsWith("<") && datosTcp[i].Length > 2)
                        {
                            if (picConectado)
                            {
                                //Crear evento de insertar
                                string query = "insert into eventosFromPic (fechaRegistro, evento, estatus) values('" +
                                                DateTime.Now.ToString() + "','" + datosTcp[i] + "','sin leer');";

                                //Escribo en la tabla si evento del pic
                                if (!tabla.insertar(query))
                                {
                                    //Guardar en un txt los eventos
                                }
                            }
                        }

                        //Modificar para la tabla tpv
                        if (datosTcp[i].StartsWith("<TPV"))
                        {
                            //Quitar evento TPV
                            datosTcp[i] = datosTcp[i].Replace("<TPV", "<");
                            //Pintar el dato recibido
                            txtLog.Text += datosTcp[i] + "\r\n";

                            //Verificamos el parche de datos
                            if (parcheToServer(datosTcp[i], out parcheText))
                            {
                                if (picConectado || true)
                                {
                                    //Crear evento de insertar
                                    string query = "insert into eventosPic (fechaRegistro, fechaAtencion, evento, estatus) values('" +
                                                    DateTime.Now.ToString() + "','','" + parcheText + "','sin leer');";

                                    //Escribo en la tabla si evento del pic
                                    if (lastRegister != parcheText)
                                    {
                                        if (tabla.insertar(query))
                                        {
                                            lastRegister = parcheText;
                                            tcpServer1.Send("<" + "SQL" + "WRT" + "1" + ">");
                                        }
                                        else
                                        {
                                            tcpServer1.Send("<" + "SQL" + "WRT" + "0" + ">");
                                        }
                                    }
                                    else
                                    {
                                        txtLog.Text += "DB: DUPLICIDAD DE REGISTRO \r\n";
                                        tcpServer1.Send("<" + "SQL" + "WRT" + "1" + ">");
                                    }
                                }

                                //Evento resultante
                                txtLog.Text += tabla.estatusReport;

                                //Renviar al servidor de la app
                                //ClientSend(parchetext);

                                //Retrasnmito al servidor accesa de mantenimiento
                                /*
                                if (clientAccesa != null)
                                {
                                    if (clientAccesa.Connected)
                                    {
                                        ClientAccesaSend(dataStr);
                                    }
                                }
                                */
                            }
                            else
                            {
                                //El dato no tiene formato correcto, apunta al siguiente dato del buffer
                                tcpServer1.Send("<" + "SQL" + "WRT" + "1" + ">");
                            }
                        }
                        else if (datosTcp[i].Length > 2)
                        {
                            txtLog.Text += "Evento no se guarda: " + datosTcp[i] + "\r\n";

                            //Evaluzar casos que no son generados por tpvs
                            if (datosTcp[i].StartsWith("<SQLACK>"))
                            {
                                //Actualizo tabla de leido
                                if (eventoPC)
                                {
                                    eventoPC = false;
                                    if (tabla.update("update eventosPC set  fechaAtencion = '" + DateTime.Now.ToString() + "', estatus = 'leido' where id = " + id))
                                        txtLog.Text += "DB: Evento actualizado por lectura pic \r\n";
                                }
                            }
                        }

                        //Pinta al final del dato
                        txtLog.SelectionStart = txtLog.TextLength;
                        txtLog.ScrollToCaret();
                    }
                    //Fin del invoke
                };
                Invoke(del);
                datos = null;
            }
        }
        /*************************************************************************************/
        protected byte[] readStream(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            if (stream.DataAvailable)
            {
                byte[] data = new byte[client.Available];

                int bytesRead = 0;
                try
                {
                    bytesRead = stream.Read(data, 0, data.Length);
                }
                catch (IOException)
                {
                }

                if (bytesRead < data.Length)
                {
                    byte[] lastData = data;
                    data = new byte[bytesRead];
                    Array.ConstrainedCopy(lastData, 0, data, 0, bytesRead);
                }
                return data;
            }
            return null;
        }
        /*********************************************************************************/
        private void tcpServer1_OnConnect(tcpServer.TcpServerConnection connection)
        {
            invokeDelegate setText = () =>
            {
                lblConnected.Text = tcpServer1.Connections.Count.ToString();
                txtLog.Text += "Cliente conectado" + connection.Socket.Client.RemoteEndPoint.ToString() + "\r\n";
            };
            Invoke(setText);
            string direccionIpPIC = connection.Socket.Client.RemoteEndPoint.ToString();
            string direccionIpPICsinPuerto = direccionIpPIC.Substring(0, 13);
            PICS.Add(new testApp.PIC() { DireccionIP = direccionIpPICsinPuerto, IsConnected = true });
        }
        /*********************************************************************************/
        private void timer1_Tick(object sender, EventArgs e)
        {
            int num;
            //int desconexiones;

            //Estatus del servidor
            displayTcpServerStatus();
            //Cuantos clientes estan conectados
            lblConnected.Text = tcpServer1.Connections.Count.ToString();

            bool result = Int32.TryParse(lblConnected.Text, out num);

            textClientTCP.Text = "";
            foreach (testApp.PIC PIC in PICS)
            {
                textClientTCP.Text += PIC.DireccionIP + "\r\n";
            }

            if (num > 0)
            {
                //cuentadesconexiones++;
                label10.Text = tcpServer.GlobalVar.GlobalValue.ToString();
            }
           
            //Reconecta si falla
            if (!tabla.conectado && !timerServerSQL.Enabled)
                timerServerSQL.Enabled = true;
        }
        /*********************************************************************************/
        private void txtIdleTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int time = Convert.ToInt32(txtIdleTime.Text);
                tcpServer1.IdleTime = time;
            }
            catch (FormatException) { }
            catch (OverflowException) { }
        }
        /*********************************************************************************/
        private void txtMaxThreads_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int threads = Convert.ToInt32(txtMaxThreads.Text);
                tcpServer1.MaxCallbackThreads = threads;
            }
            catch (FormatException) { }
            catch (OverflowException) { }
        }
        /*********************************************************************************/
        private void txtAttempts_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int attempts = Convert.ToInt32(txtAttempts.Text);
                tcpServer1.MaxSendAttempts = attempts;
            }
            catch (FormatException) { }
            catch (OverflowException) { }
        }
        /*********************************************************************************/
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
        }
        /*********************************************************************************/
        private void txtValidateInterval_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int interval = Convert.ToInt32(txtValidateInterval.Text);
                tcpServer1.VerifyConnectionInterval = interval;
            }
            catch (FormatException) { }
            catch (OverflowException) { }
        }
        /*********************************************************************************/

        //Rompe los puertos inactivos
        private void timer3_Tick(object sender, EventArgs e)
        {

        }
        /***********************************************************/
        private void btn_clear(object sender, EventArgs e)
        {
            this.txtLog.Text = "";
        }
        /***********************************************************/
        private void conectarApp(string ip, int puerto)
        {
            try
            {
                //client = new TcpClient("127.0.0.1", 123); //Trys to Connect
                client = new TcpClient(ip, puerto); //Trys to Connect
                txtLog.Text += "Conectado a la app" + "\r\n";
                serverParking.Enabled = false;
                //ClientReceive();
                openTcpPort();
      
            }
            catch (Exception ex)
            {
                //Si no pudo conectar activa timer para ser conectado
                //MessageBox.Show(ex.Message); // Error handler :D
            
                serverParking.Enabled = true;
                txtLog.Text += "Servidor no disponible: " + ex.Message + "\r\n";
                if (tcpServer1.IsOpen)
                {
                    tcpServer1.Close();
                }
            }
        }
        public void ClientReceive()
        {
            int bytes;
            streamClient = client.GetStream(); //Gets The Stream of The Connection
            
            new Thread(() => // Thread (like Timer)
            {

                while ((bytes = streamClient.Read(datalengthCliente, 0, datalengthCliente.Length)) != 0)//Keeps Trying to Receive the Size of the Message or Data
                {
                    
                    // how to make a byte E.X byte[] examlpe = new byte[the size of the byte here] , i used BitConverter.ToInt32(datalength,0) cuz i received the length of the data in byte called datalength :D
                  
                        //txtLog.Text = "Datos: " + i + "\r\n";
                        byte[] data = new byte[BitConverter.ToInt32(datalengthCliente, 0)]; // Creates a Byte for the data to be Received On
                        streamClient.Read(data, 0, bytes); //Receives The Real Data not the Size
                        this.Invoke((MethodInvoker)delegate // To Write the Received data
                        {
                            txtLog.Text += bytes + " ,Server : " + Encoding.Default.GetString(data) + "\r\n"; // Encoding.Default.GetString(data); Converts Bytes Received to String
                        });
                  

                }
                
            }).Start(); // Start the Thread
        }

        private void serverParking_Tick(object sender, EventArgs e)
        {
            conectarApp(serverIp, serverPort);
        }

        public void ClientSend(string msg)
        {
            try
            {
                
                if (client.Connected)
                {
                    streamClient = client.GetStream(); //Gets The Stream of The Connection
                    byte[] data; // creates a new byte without mentioning the size of it cuz its a byte used for sending
                    data = Encoding.Default.GetBytes(msg); // put the msg in the byte ( it automaticly uses the size of the msg )
                    streamClient.Write(data, 0, data.Length); //Sends the real data
                }
                else
                {
                    txtLog.Text += "No hay conexion al server" + "\r\n";
                    serverParking.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                txtLog.Text += "Se cayo el servidor: " + ex.Message + "\r\n";
                tcpServer1.Close();
            }
        }

        private void parche_Tick(object sender, EventArgs e)
        {
            int bytes = 0;
            string comandoServer;
            char[] delimitador = new char[]{','};

            try
            {
                //Si hay datos por tcp
                if (client == null)
                    return;

                if (client.Available != 0)
                {
                    streamRead = client.GetStream(); //Gets The Stream of The Connection
                    bytes = streamRead.Read(datalengthCliente, 0, client.Available);
                    datalengthCliente[bytes] = 0; //Final de cadena
                    //Mostrar lo que recibi
                    comandoServer = Encoding.ASCII.GetString(datalengthCliente, 0, bytes);
                    txtLog.Text += "R: " + comandoServer.Length + " ,Server : " + comandoServer + "\r\n";

                }
            }
            catch 
            { 
                //Sin funcion 
            }
        }
        /********************************************************************************************************************/
        private void AccesaClose_Click(object sender, EventArgs e)
        {

        }

        private void timerGetDataAccesa_Tick(object sender, EventArgs e)
        {
            int bytes = 0;
            string comandoServer;

            try
            {
                //Si hay datos por tcp
                if (clientAccesa == null)
                    return;

                if (clientAccesa.Available != 0)
                {
                    streamReadAccesa = clientAccesa.GetStream(); //Gets The Stream of The Connection
                    bytes = streamReadAccesa.Read(datalengthClienteAccesa, 0, clientAccesa.Available);
                    datalengthClienteAccesa[bytes] = 0; //Final de cadena
                    //Mostrar lo que recibi
                    comandoServer = Encoding.ASCII.GetString(datalengthClienteAccesa, 0, bytes);
                    txtLog.Text += "R: " + comandoServer.Length + " ,Accesa : " + comandoServer + "\r\n";

                    if (bytes > 1)
                    {
                        comandoServer.Replace("!", "");
                        tcpServer1.Send(comandoServer);
                        ClientAccesaSend("Recibido");

                    }
                }
            }
            catch 
            { 
                //Sin funcion 
            }
        }

        public void ClientAccesaSend(string msg)
        {
            try
            {
                if (clientAccesa.Connected)
                {
                    streamClientAccesa = clientAccesa.GetStream(); //Gets The Stream of The Connection
                    byte[] data; // creates a new byte without mentioning the size of it cuz its a byte used for sending
                    data = Encoding.Default.GetBytes(msg); // put the msg in the byte ( it automaticly uses the size of the msg )
                    streamClientAccesa.Write(data, 0, data.Length); //Sends the real data
                }
                else
                {
                    txtLog.Text += "No hay conexion al server Accesa" + "\r\n";
                }
            }
            catch (Exception ex)
            {
                txtLog.Text += "Se cayo el servidor Accesa: " + ex.Message + "\r\n";
            }
        }
        /*********************************************************************************/
        /************************************* MYSQL *************************************/
        /*********************************************************************************/
        private void timertServerSQL_Tick(object sender, EventArgs e)
        {
            tabla.conectar(dbServer, dbUser, dbPassword, dbName);
            //Apagar la reconexion
            if (tabla.conectado)
            {
                timerServerSQL.Enabled = false;
                txtLog.Text += "Reconexion establecida \r\n";
            }    
        }
        /*********************************************************************************/
        private void buttonEmularSQL_Click(object sender, EventArgs e)
        {
            tabla.insertar("insert into eventosPC (fechaRegistro, fechaAtencion, evento, estatus) values('now()','','" + mysqlEventoText.Text + "','sin leer')");
            txtLog.Text += "Registrando para pc: " + tabla.estatusReport;
        }
        /*********************************************************************************/
        private void comboBoxComandos_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabla.insertar("insert into eventosPC (fechaRegistro, fechaAtencion, evento, estatus) values('now()','','" + comboBoxComandos.Text + "','sin leer')");
            txtLog.Text += "Registrando para pc: " + tabla.estatusReport;
        }
        /*********************************************************************************/
        private void timerServerSQLRead_Tick(object sender, EventArgs e)
        {
            string evento, auxParche;
            foreach (testApp.PIC PIC in PICS)
            {
                if (PIC.IsConnected)
                {
                    if (tabla.consulta("select id from eventosPC where estatus = 'sin leer'", out id))
                    {
                        if (tabla.consulta("select evento from eventosPC where estatus = 'sin leer' and id = '" + id + "';", out evento))
                        {
                            if(parcheToPic(evento, out auxParche))
                            {
                                if (PIC.Ping)
                                {
                                    txtLog.Text += "Enviado evento al pic: " + evento + "\r\n";
                                   
                                    if (auxParche == "<BORRAR_ALL>")
                                    {
                                        tabla.update("update eventosPC set fechaAtencion = '" + DateTime.Now.ToString() + "', estatus = 'leido' where id = " + id);
                                        txtLog.Text += "DB: Evento actualizado \r\n";
                                        tcpServer1.Send("BORRAR_ALL");
                                        eventoPC = true;
                                        return;
                                    }
                                    /*
                                    //Evento para el pic
                                    auxParche = auxParche.Replace("<", "<TPV");
                                    tcpServer1.Send(auxParche);
                                    eventoPC = true;*/
                                }
                            }
                            else
                            {
                                //Actualiza el puntero por ser un formato incorrecto
                                if (tabla.update("update eventosPC set fechaAtencion = '" + DateTime.Now.ToString() + "', estatus = 'wrongFormat' where id = " + id))
                                    txtLog.Text += "DB: Evento actualizado por mal formato \r\n";
                            }
                        }
                    }
                }
            }
        }
        /*********************************************************************************/
        /********************************* TIMERS ****************************************/
        /*********************************************************************************/
        private void breakPorts_Tick(object sender, EventArgs e)
        {
            //Romper puertos mal conectados pic-servidor
            tcpServer1.Send("!");

            //Limpiar buffer automaticamente
            if (txtLog.Text.Length > 3000)
                txtLog.Text = "";

            //Solicitar al pic reporte de los modulos, cada 5 segundos
            if(++tempGetReport >= 60){
                tempGetReport = 0;
                //tcpServer1.Send("<" + "REP" + ">");
            } 
        }
        /*********************************************************************************/
        private void timerPing_Tick(object sender, EventArgs e)
        {
            try
            {
                
                foreach (testApp.PIC PIC in PICS)
                {
                    PingReply ping = Pings.Send(PIC.DireccionIP, timeoutPing);
                    if(ping.Status == IPStatus.Success)
                    {
                        Console.WriteLine("Ping respondido de: " + PIC.DireccionIP);
                        labelPing.Text = "Ping: " + ping.RoundtripTime + "ms";
                        PIC.Ping = true;
                        pingPic = true;
                    }
                    else
                    {
                        labelPing.Text = "Ping: -ms";
                        PIC.Ping = false;
                        pingPic = false;
                        pingError++;
                    }   
                }
                //Mostrar errores del ping
                labelPingError.Text = "PingError = " + pingError;

                //Si el ping sobrepasa la tasa predetermina resetea
                if (pingError >= timeMaxPingError * 60)  //Acumulo un minuto de error
                {
                    pingError = 0;
                    if (!resetearPic)
                    {
                        resetearPic = true;
                        tabla.insertar("insert into eventosPC (fechaRegistro, fechaAtencion, evento, estatus) values('" + DateTime.Now.ToString() + "','','" + "RESET_TPV" + "','sin leer')");
                        txtLog.Text += "ERROR CONECTION PIC: " + tabla.estatusReport;
                    }
                    //Si el pic esta conectado mando reset
                    if (picConectado)
                    {
                        //Mandar reset
                        txtLog.Text += "MANDAR RESET AL PIC \r\n";
                        tcpServer1.Send("<TPVRST>");
                    }
                }
            }
            catch (Exception)
            {
                throw;
                
                //txtLog.Text += "Problema con la IP del PC \r\n";
            }
            
        }
        /********************************************************************************************************************/
        private void frmMain_Shown(object sender, EventArgs e)
        {
            if(showGUI)
                this.Hide();
        }

        private void comboBoxComandos_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            tabla.insertar("insert into eventosPC (fechaRegistro, fechaAtencion, evento, estatus) values('now()','','" + comboBoxComandos.Text + "','sin leer')");
            txtLog.Text += "Registrando para pc: " + tabla.estatusReport;
        }

        private void comboBoxComandos_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void timerBarOpen_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("Tam: " + barrerasAbbiertas.Count + "  Texto:" + barrerasAbbiertas[0]);

            //for(int i = 0; i < maxRegisterAccesos; i++)
        }
    }
}
