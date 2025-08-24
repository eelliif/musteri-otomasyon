using System.Data;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace MusteriOtomasyon
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ProjelerVT;Integrated Security=True;Encrypt=False");
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            verileriGoruntule();
            dataGridView1.ClearSelection();
            textBox1.Text = "0";
        }
        private void verileriGoruntule()
        {
            using (SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ProjelerVT;Integrated Security=True;Encrypt=False"))
            {
                try
                {
                    baglanti.Open();
                    string sorgu = "SELECT MusteriId,Ad,Soyad,AylikGelir,KrediyeUygunMu,Sehir FROM Müsteri";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sorgu, baglanti);
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanýndan veri çekerken hata oluþtu, Hata Kodu:H001\n" + ex.Message);
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int secilenSatir = e.RowIndex;
                textBox1.Text = dataGridView1.Rows[secilenSatir].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[secilenSatir].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[secilenSatir].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[secilenSatir].Cells[3].Value.ToString();
                if (dataGridView1.Rows[secilenSatir].Cells[4].Value?.ToString() == "True")
                {
                    textBox5.Text = "Evet";
                }
                else
                {
                    textBox5.Text = "Hayýr";
                }
                textBox6.Text = dataGridView1.Rows[secilenSatir].Cells[5].Value.ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ProjelerVT;Integrated Security=True;Encrypt=False"))
            {
                try
                {
                    baglanti.Open();
                    SqlCommand sqlcommand = new SqlCommand("INSERT INTO Müsteri (Ad,Soyad,AylikGelir,KrediyeUygunMu,Sehir) VALUES (@P1,@P2,@P3,@P4,@P5)", baglanti);
                    sqlcommand.Parameters.AddWithValue("@P1", textBox2.Text);
                    sqlcommand.Parameters.AddWithValue("@P2", textBox3.Text);
                    if (int.TryParse(textBox4.Text, out int aylikGelir))
                    {
                        sqlcommand.Parameters.AddWithValue("@P3", aylikGelir);
                        if (aylikGelir >= 10000)
                        {
                            sqlcommand.Parameters.AddWithValue("@P4", 1);
                        }
                        else
                        {
                            sqlcommand.Parameters.AddWithValue("@P4", 0);
                        }
                        sqlcommand.Parameters.AddWithValue("@P5", textBox6.Text);
                        sqlcommand.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Aylýk gelir deðeri geçerli bir sayý olmalýdýr.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kayýt eklenirken hata oluþtu! Hata Kodu:H002\n" + ex.Message);
                }
            }
            verileriGoruntule();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ProjelerVT;Integrated Security=True;Encrypt=False"))
            {
                if (textBox1.Text.Equals("0"))
                {
                    MessageBox.Show("Lütfen bir müþteri seçiniz!");
                }
                else
                {
                    try
                    {
                        baglanti.Open();
                        SqlCommand sqlcommand = new SqlCommand("DELETE FROM Müsteri WHERE MusteriId=@P1", baglanti);
                        sqlcommand.Parameters.AddWithValue("@P1", textBox1.Text);
                        sqlcommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kayýt silinirken hata oluþtu! Hata Kodu:H004\n" + ex.Message);
                    }
                }
            }
            verileriGoruntule();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ProjelerVT;Integrated Security=True;Encrypt=False"))
            {
                if (textBox1.Text.Equals("0"))
                {
                    MessageBox.Show("Lütfen bir müþteri seçiniz!");
                }
                else
                {
                    try
                    {
                        baglanti.Open();
                        SqlCommand sqlCommand = new SqlCommand("UPDATE Müsteri SET Ad=@P1,Soyad=@P2,AylikGelir=@P3,KrediyeUygunMu=@P4,Sehir=@P5 WHERE MusteriId=@P6", baglanti);
                        sqlCommand.Parameters.AddWithValue("@P1", textBox2.Text);
                        sqlCommand.Parameters.AddWithValue("@P2", textBox3.Text);
                        sqlCommand.Parameters.AddWithValue("@P5", textBox6.Text);
                        if (int.TryParse(textBox4.Text, out int aylikGelir))
                        {
                            sqlCommand.Parameters.AddWithValue("@P3", aylikGelir);
                            if (aylikGelir >= 10000)
                            {
                                sqlCommand.Parameters.AddWithValue("@P4", 1);
                            }
                            else
                            {
                                sqlCommand.Parameters.AddWithValue("@P4", 0);
                            }
                            sqlCommand.Parameters.AddWithValue("@P6", textBox1.Text);
                            sqlCommand.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("Aylýk gelir deðeri geçerli bir sayý olmalýdýr.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kayýt silinirken hata oluþtu! Hata Kodu:H005\n" + ex.Message);
                    }
                }
            }
            verileriGoruntule();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ProjelerVT;Integrated Security=True;Encrypt=False"))
            {
                try
                {
                    baglanti.Open();
                    string sorgu = "SELECT * FROM Müsteri WHERE Ad LIKE @P1 AND Soyad LIKE @P2 AND Sehir LIKE @P3";
                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                    da.SelectCommand.Parameters.AddWithValue("@P1", "%" + textBox2.Text + "%");
                    da.SelectCommand.Parameters.AddWithValue("@P2", "%" + textBox3.Text + "%");
                    da.SelectCommand.Parameters.AddWithValue("@P3", "%" + textBox6.Text + "%");
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Arama yapýlýrken hata oluþtu! Hata Kodu:H006\n" + ex.Message);
                }
            }
            dataGridView1.ClearSelection();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ProjelerVT;Integrated Security=True;Encrypt=False"))
            {
                try
                {
                    baglanti.Open();
                    if (int.TryParse(textBox4.Text, out int aylikGelir))
                    {
                        string sorgu = "SELECT * FROM Müsteri WHERE AylikGelir = @P1";
                        SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                        da.SelectCommand.Parameters.AddWithValue("@P1", aylikGelir);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dt;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Aylýk gelir deðeri geçerli bir sayý olmalýdýr.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Aylýk gelire göre arama yapýlýrken hata oluþtu! Hata Kodu:H007\n" + ex.Message);
                }
            }
            dataGridView1.ClearSelection();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            verileriGoruntule();
        }
    }
}
