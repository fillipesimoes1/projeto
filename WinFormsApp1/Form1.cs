namespace WinFormsApp1;
 using MySql.Data.MySqlClient;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)

        {
            try
            {
              var strConexao = "server=localhost;uid=aulas;pwd=2525;database=teste ";
              var conexao = new MySqlConnection(strConexao);
               conexao.Open();
            MessageBox.Show("Conexão ok");
        
            } catch(Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
            
        }


    }

