using System;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace InnovatorClientExample
{
    /// <summary>
    /// Summary description for StartForm.
    /// </summary>
    public class StartForm : Form
    {
        public static XmlDocument ConfigDoc = new XmlDocument();
        public static string ErrorMsg = "";

        /// <summary>
        ///  The Configuration definition from the XML config file.
        /// </summary>
        private ServerInfo connectionConfig = null;
        private static string Version = "1.0";

        /// <summary>
        /// Next 2 declarations create the IOM connection and the IOM Innovator and Item objects for us.
        /// </summary>
        private Aras.IOM.HttpServerConnection serverConnection;
        private Aras.IOM.Innovator innovator;

        private RichTextBox msgBox;
        private Button ExitButton;
        private Button LoadButton;
        private Button ConnectButton;
        private Button QueryButton;
        private Button LogoffButton;
        private Button SQLButton;
        private Button AMLButton;
        private Button MethodButton;
        private Button InfoButton;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private const string PATH_DELIMITER = "\\";
        private Button button_getToken;
        private Button button_getUserRest;
        private Button button1;
        private const string CONFIG_FILE_PATH = @"InnovatorClientExampleConfig.xml";

        /// <summary>
        /// Required for Windows Form Designer support.
        /// </summary>
        public StartForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.ExitButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.msgBox = new System.Windows.Forms.RichTextBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.QueryButton = new System.Windows.Forms.Button();
            this.LogoffButton = new System.Windows.Forms.Button();
            this.SQLButton = new System.Windows.Forms.Button();
            this.AMLButton = new System.Windows.Forms.Button();
            this.MethodButton = new System.Windows.Forms.Button();
            this.InfoButton = new System.Windows.Forms.Button();
            this.button_getToken = new System.Windows.Forms.Button();
            this.button_getUserRest = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(1102, 12);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(96, 23);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "Exit";
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(12, 12);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(96, 23);
            this.LoadButton.TabIndex = 1;
            this.LoadButton.Text = "1. Load Config";
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // msgBox
            // 
            this.msgBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msgBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msgBox.Location = new System.Drawing.Point(12, 52);
            this.msgBox.Name = "msgBox";
            this.msgBox.Size = new System.Drawing.Size(1183, 411);
            this.msgBox.TabIndex = 2;
            this.msgBox.Text = "";
            this.msgBox.TextChanged += new System.EventHandler(this.msgBox_TextChanged);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(114, 12);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(96, 23);
            this.ConnectButton.TabIndex = 3;
            this.ConnectButton.Text = "2. Connect";
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // QueryButton
            // 
            this.QueryButton.Location = new System.Drawing.Point(216, 12);
            this.QueryButton.Name = "QueryButton";
            this.QueryButton.Size = new System.Drawing.Size(88, 23);
            this.QueryButton.TabIndex = 4;
            this.QueryButton.Text = "3. Query";
            this.QueryButton.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // LogoffButton
            // 
            this.LogoffButton.Location = new System.Drawing.Point(1000, 12);
            this.LogoffButton.Name = "LogoffButton";
            this.LogoffButton.Size = new System.Drawing.Size(96, 23);
            this.LogoffButton.TabIndex = 5;
            this.LogoffButton.Text = "11. Logoff";
            this.LogoffButton.Click += new System.EventHandler(this.LogoffButton_Click);
            // 
            // SQLButton
            // 
            this.SQLButton.Location = new System.Drawing.Point(310, 12);
            this.SQLButton.Name = "SQLButton";
            this.SQLButton.Size = new System.Drawing.Size(88, 23);
            this.SQLButton.TabIndex = 6;
            this.SQLButton.Text = "4. SQL";
            this.SQLButton.UseVisualStyleBackColor = true;
            this.SQLButton.Click += new System.EventHandler(this.SQLButton_Click);
            // 
            // AMLButton
            // 
            this.AMLButton.Location = new System.Drawing.Point(404, 12);
            this.AMLButton.Name = "AMLButton";
            this.AMLButton.Size = new System.Drawing.Size(88, 23);
            this.AMLButton.TabIndex = 7;
            this.AMLButton.Text = "5. AML";
            this.AMLButton.UseVisualStyleBackColor = true;
            this.AMLButton.Click += new System.EventHandler(this.AMLButton_Click);
            // 
            // MethodButton
            // 
            this.MethodButton.Location = new System.Drawing.Point(498, 12);
            this.MethodButton.Name = "MethodButton";
            this.MethodButton.Size = new System.Drawing.Size(96, 23);
            this.MethodButton.TabIndex = 8;
            this.MethodButton.Text = "6. Method";
            this.MethodButton.UseVisualStyleBackColor = true;
            this.MethodButton.Click += new System.EventHandler(this.MethodButton_Click);
            // 
            // InfoButton
            // 
            this.InfoButton.Location = new System.Drawing.Point(600, 12);
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(96, 23);
            this.InfoButton.TabIndex = 9;
            this.InfoButton.Text = "7. Show info";
            this.InfoButton.UseVisualStyleBackColor = true;
            this.InfoButton.Click += new System.EventHandler(this.InfoButton_Click);
            // 
            // button_getToken
            // 
            this.button_getToken.Location = new System.Drawing.Point(702, 12);
            this.button_getToken.Name = "button_getToken";
            this.button_getToken.Size = new System.Drawing.Size(96, 23);
            this.button_getToken.TabIndex = 10;
            this.button_getToken.Text = "8. Get token";
            this.button_getToken.UseVisualStyleBackColor = true;
            this.button_getToken.Click += new System.EventHandler(this.button_getToken_Click);
            // 
            // button_getUserRest
            // 
            this.button_getUserRest.Location = new System.Drawing.Point(804, 12);
            this.button_getUserRest.Name = "button_getUserRest";
            this.button_getUserRest.Size = new System.Drawing.Size(96, 23);
            this.button_getUserRest.TabIndex = 11;
            this.button_getUserRest.Text = "9. Rest API";
            this.button_getUserRest.UseVisualStyleBackColor = true;
            this.button_getUserRest.Click += new System.EventHandler(this.button_getUserRest_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(906, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "10. SOAP API";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_getUserSoap_Click);
            // 
            // StartForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1209, 475);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_getUserRest);
            this.Controls.Add(this.button_getToken);
            this.Controls.Add(this.InfoButton);
            this.Controls.Add(this.MethodButton);
            this.Controls.Add(this.AMLButton);
            this.Controls.Add(this.SQLButton);
            this.Controls.Add(this.LogoffButton);
            this.Controls.Add(this.QueryButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.msgBox);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.ExitButton);
            this.Icon = global::InnovatorClientExample.Properties.Resources.Aras;
            this.MinimumSize = new System.Drawing.Size(930, 420);
            this.Name = "StartForm";
            this.Text = "Innovator Client Example Using IOM.DLL";
            this.Load += new System.EventHandler(this.StartForm_Load);
            this.ResumeLayout(false);

        }
        #endregion

        public string access_token;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new StartForm());
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            msgBox.AppendText(@"Welcome to the example IOM Client application demonstration

Very simple... click the buttons in sequence to exercise the client code

1. Load Config	-- loads connnection parameters from InnovatorClientExampleConfig.xml -- you may want to use a logon form in your application.
2. Connect	-- creates the innovator object and creates a connection for you
3. Query		-- runs an AML query for User items and displays the result
4. SQL		-- runs an SQL query for User items and displays the result
5. AML		-- runs an AML query written by user for User items and displays the result
6. Method	-- runs the server method VC_IsUserAdmin and displays the result
7. Show info	-- show info about server locale, timezone
8. Logoff		-- disconnects from Innovator, releasing all objects.
9. Exit		-- done with the example,  now open VS and start coding");
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            // Load the XML configuration.
            connectionConfig = ConfigurationReader.ParseXML(CONFIG_FILE_PATH);

            if (connectionConfig == null)
            {
                msgBox.AppendText("\n\nError with configuration file.\n" + ErrorMsg);
                return;
            }

            // Build the message for the Event Monitor.
            msgBox.AppendText("\n\nSuccessfuly loaded the Configuration file! \nYour Server is: " + connectionConfig.Server +
                "\n\nNow use the Connect button to Create and Test a Connection");
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (connectionConfig == null)
            {
                msgBox.AppendText("\n\nConfiguration not loaded -- use button 1 first!");
                return;
            }

            serverConnection = Aras.IOM.IomFactory.CreateHttpServerConnection(connectionConfig.Server + "/Server/InnovatorServer.aspx", connectionConfig.Database, connectionConfig.Username, connectionConfig.Password);

            Aras.IOM.Item result;
            try
            {
                result = serverConnection.Login();
            }
            catch (Exception exception)
            {
                msgBox.AppendText("\n\nLogin Error:  " + exception.Message);
                return;
            }

            if (result.isError())
            {
                msgBox.AppendText("\n\nLogin Error:  " + result.getErrorString());
                serverConnection = null;
                return;
            }

            innovator = new Aras.IOM.Innovator(serverConnection);

            msgBox.AppendText("\n\nDone!  -- the MyInnovator object is created and ready to run queries.\nNOTE: a roundtrip the server has already been tested!\nServer says your userID is " + innovator.getUserID());
        }

        private void QueryButton_Click(object sender, EventArgs e)
        {
            if (CheckError())
            {
                return;
            }

            Aras.IOM.Item selectUsersItem = innovator.newItem("User", "get");
            selectUsersItem.setAttribute("select", "first_name,last_name");

            selectUsersItem = selectUsersItem.apply();
            if (selectUsersItem.isError())
            {
                msgBox.AppendText("\n\nQuery Error: " + selectUsersItem.getErrorDetail());
                return;
            }
            selectUsersItem = selectUsersItem.getItemsByXPath("//Item[@type='User']");
            msgBox.AppendText("\n\nQuery Found " + selectUsersItem.getItemCount() + " User Items:\n");
            for (var i = 0; i < selectUsersItem.getItemCount(); i++)
            {
                msgBox.AppendText("\n   " + (i + 1) + "  " + selectUsersItem.getItemByIndex(i).getProperty("first_name", "na") + " " + selectUsersItem.getItemByIndex(i).getProperty("last_name", "na"));
            }
        }

        private void LogoffButton_Click(object sender, EventArgs e)
        {
            if (CheckError())
            {
                return;
            }

            serverConnection.Logout();
            serverConnection = null;
            msgBox.AppendText("\n\nConnection is now Logged-Off ");
        }

        private void SQLButton_Click(object sender, EventArgs e)
        {
            if (CheckError())
            {
                return;
            }

            Aras.IOM.Item result = innovator.applySQL("select login_name, first_name, last_name from [user]");
            if (result.isError())
            {
                msgBox.AppendText("\n\nSQL Error: " + result.getErrorDetail());
                return;
            }
            result = result.getItemsByXPath("//Item");
            msgBox.AppendText("\n\nSQL Found " + result.getItemCount() + " User Items:\n");
            for (var i = 0; i < result.getItemCount(); i++)
            {
                msgBox.AppendText("\n   " + (i + 1) + "  " + result.getItemByIndex(i).getProperty("first_name", "na") + " " + result.getItemByIndex(i).getProperty("last_name", "na"));
            }
        }

        private void AMLButton_Click(object sender, EventArgs e)
        {
            if (CheckError())
            {
                return;
            }

            Aras.IOM.Item result = innovator.applyAML("<AML><Item type='User' action='get' select='first_name,last_name'></Item></AML>");
            if (result.isError())
            {
                msgBox.AppendText("\n\nAML Error: " + result.getErrorDetail());
                return;
            }

            result = result.getItemsByXPath("//Item");
            msgBox.AppendText("\n\nAML Found " + result.getItemCount() + " User Items:\n");

            for (var i = 0; i < result.getItemCount(); i++)
            {
                msgBox.AppendText("\n   " + (i + 1) + "  " + result.getItemByIndex(i).getProperty("first_name", "na") + " " + result.getItemByIndex(i).getProperty("last_name", "na"));
            }
        }

        /// <summary>
        /// Scroll to the bottom when new data is written.
        /// </summary>
        private void msgBox_TextChanged(object sender, EventArgs e)
        {
            msgBox.SelectionStart = msgBox.Text.Length;
            msgBox.ScrollToCaret();
        }

        private bool CheckError()
        {
            if (connectionConfig == null)
            {
                msgBox.AppendText("\n\nConfiguration not loaded -- use button 1 first!");
                return true;
            }
            if (serverConnection == null)
            {
                msgBox.AppendText("\n\nMyInnovator connection object not valid -- use button 2 first!");
                return true;
            }

            return false;
        }

        private void MethodButton_Click(object sender, EventArgs e)
        {
            if (CheckError())
            {
                return;
            }

            Aras.IOM.Item result = innovator.applyMethod("VC_IsUserAdmin", "<id>" + innovator.getUserID() + "</id>");
            if (result.isError())
            {
                msgBox.AppendText("\n\nMethod Error: " + result.getErrorDetail());
                return;
            }
            msgBox.AppendText("\n\nResult of execution method VC_IsUserAdmin:\n");
            msgBox.AppendText("\n   " + result.getResult());
        }

        private void InfoButton_Click(object sender, EventArgs e)
        {
            if (CheckError())
            {
                return;
            }

            Aras.IOM.I18NSessionContext context = innovator.getI18NSessionContext();
            msgBox.AppendText("\n\n Information about server:\n");
            msgBox.AppendText("\n   Locale: " + context.GetLocale());
            msgBox.AppendText("\n   Timezone: " + context.GetTimeZone());
            msgBox.AppendText("\n   Database: " + serverConnection.GetDatabaseName());
        }

        private void button_getToken_Click(object sender, EventArgs e)
        {
            var client = new RestClient(connectionConfig.Server + "/OAuthServer/connect/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("grant_type", "password");
            request.AddParameter("scope", "Innovator");
            request.AddParameter("client_id", "IOMApp");
            request.AddParameter("username", connectionConfig.Username);
            request.AddParameter("password", connectionConfig.Password);
            request.AddParameter("database", connectionConfig.Database);
            IRestResponse response = client.Execute(request);

            JObject obj = JObject.Parse(response.Content);
            //string access_token = (string)obj.SelectToken("access_token");

            access_token = (string)obj.SelectToken("access_token");


            msgBox.AppendText("\n\nToken = " + access_token);
        }

        public class User
        {
            public string first_name { get; set; }
            public int last_name { get; set; }
        }

        private void button_getUserRest_Click(object sender, EventArgs e)
        {
            var client = new RestClient(connectionConfig.Server + "/server/odata/User?$select=first_name,last_name");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("accept-encoding", "gzip, deflate");
            request.AddHeader("cookie", "ASP.NET_SessionId=4bpjgxs4hyxdvvdyfqtdn3cq");
            request.AddHeader("Host", "localhost");
            request.AddHeader("Postman-Token", "e005ae19-9a3c-4ae1-aa64-ace567ae524d,4f175dfb-173c-4322-ab75-00d3081c6ad2");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "PostmanRuntime/7.15.0");
            request.AddHeader("Authorization", "Bearer " + access_token);
            IRestResponse response = client.Execute(request);

            JObject obj = JObject.Parse(response.Content);

            var values = (JArray)obj["value"];

            msgBox.AppendText("\n\nDone!  --Get REST OK, Users are :\n");
            int i = 0;

            foreach (JToken value in values)
            {
                //Console.WriteLine(value["first_name"].ToString());
                string first_name = value["first_name"].ToString();
                string last_name = value["last_name"].ToString();
                msgBox.AppendText("\n   " + (i+1) + ". " + first_name + " " + last_name);
                i++;
            }

        }

        private void button_getUserSoap_Click(object sender, EventArgs e)
        {
            var client = new RestClient(connectionConfig.Server + "/server/InnovatorServer.aspx");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("SOAPAction", "ApplyItem");
            request.AddHeader("Authorization", "Bearer " + access_token);
            request.AddHeader("Content-Type", "text/plain");
            request.AddParameter("text/plain", "<Item type=\"User\" action=\"get\" select=\"first_name,last_name\">\n</Item>", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response.Content);
            var values = doc["Item"];

            XmlNode enveloppe = doc.FirstChild;
            XmlNode body = enveloppe.FirstChild;
            XmlNode result = body.FirstChild;

            msgBox.AppendText("\n\nDone!  --Get SOAP OK, Users are :\n");

            if (result.HasChildNodes)
            {
                for (int i = 0; i < result.ChildNodes.Count; i++)
                {
                    //Console.WriteLine(result.ChildNodes[i].InnerText);
                    //Console.WriteLine(result.ChildNodes[i]["first_name"].InnerText);
                    //Console.WriteLine(result.ChildNodes[i]["last_name"].InnerText);

                    string first_name = result.ChildNodes[i]["first_name"].InnerText;
                    string last_name = result.ChildNodes[i]["last_name"].InnerText;
                    msgBox.AppendText("\n   " + (i+1) + ". " + first_name + " " + last_name);
                }
            }
           
        }
    }
}