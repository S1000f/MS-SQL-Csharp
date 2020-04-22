using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MS_SQL {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        public SqlConnection conn = new SqlConnection();

        private void ConnectionDB() {
            conn.ConnectionString = String.Format("Data Source=({0});" + "Initial Catalog = {1};" + "Integrated Security = {2};"
                + "Timeout = 3", "local", "MYDB1", "SSPI");

            conn = new SqlConnection(conn.ConnectionString);
            conn.Open();
        }

        private void Query_Select() {
            ConnectionDB();

            //sql 명령어 선언
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conn;
            sqlCommand.CommandText = "select * from TB_CUST";

            // DB table 불러오기
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "TB_CUST");

            //datagridview에 출력
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "TB_CUST";
            conn.Close();
        }

        private void Query_Insert() {
            ConnectionDB();
            String sqlcommand = "Insert Into TB_CUST(CUST_ID, BIRTH_DT) values (@parameter1, @parameter2)";
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@parameter1", textBox1.Text);
            cmd.Parameters.AddWithValue("@parameter2", textBox2.Text);
            cmd.CommandText = sqlcommand;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void Query_Update() {
            ConnectionDB();
            String sqlCommand = "Update TB_CUST set CUST_ID = @p1, BIRTH_DT = @p2 where BIRTH_DT = @p3";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@p1", textBox1);
            cmd.Parameters.AddWithValue("@p2", textBox2);
            cmd.Parameters.AddWithValue("@p3", textBox2);
            cmd.CommandText = sqlCommand;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            Query_Select();
        }

        private void button1_Click_1(object sender, EventArgs e) {
            Query_Insert();
            Query_Select();
        }

        private void button2_Click(object sender, EventArgs e) {
            Query_Update();
            Query_Select();
        }

        private void Query_delete() {
            ConnectionDB();
            String sqlcommand = "Delete TB_CUST where BIRTH_DT = @p1";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@p1", textBox2.Text);
            cmd.CommandText = sqlcommand;
            conn.Close();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e) {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

    }
}
