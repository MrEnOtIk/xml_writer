using System;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace xml_writer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Button1_Click(object sender, EventArgs e) //Добавление данных в форму
        {
            if (textBox1.Text == "" || textBox2.Text == "" || maskedTextBox3.Text == "" || maskedTextBox4.Text == "")
            {
                MessageBox.Show("Заполните все поля.", "Ошибка.");
            }
            else
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
                dataGridView1.Rows[n].Cells[2].Value = maskedTextBox4.Text;
                dataGridView1.Rows[n].Cells[3].Value = maskedTextBox5.Text;
                dataGridView1.Rows[n].Cells[4].Value = maskedTextBox3.Text;
                dataGridView1.Rows[n].Cells[5].Value = maskedTextBox1.Text;
                dataGridView1.Rows[n].Cells[6].Value = maskedTextBox2.Text;
                dataGridView1.Rows[n].Cells[7].Value = comboBox1.Text;
            }
        }

        private void Button4_Click(object sender, EventArgs e) //сохранение данных из формы в XML
        {
            try
            {
                DataSet ds = new DataSet(); // создаем пока что пустой кэш данных
                DataTable dt = new DataTable
                {
                    TableName = "Fix" // название таблицы
                }; // создаем пока что пустую таблицу данных
                dt.Columns.Add("Name"); // название колонок
                dt.Columns.Add("Mark");
                dt.Columns.Add("FIO");
                dt.Columns.Add("NumberPhone");
                dt.Columns.Add("Cost");
                dt.Columns.Add("DataPrim");
                dt.Columns.Add("DataVidachi");
                dt.Columns.Add("Status");
                ds.Tables.Add(dt); //в ds создается таблица, с названием и колонками, созданными выше

                foreach (DataGridViewRow r in dataGridView1.Rows) // пока в dataGridView1 есть строки
                {
                    DataRow row = ds.Tables["Fix"].NewRow(); // создаем новую строку в таблице, занесенной в ds
                    row["Name"] = r.Cells[0].Value;  //в столбец этой строки заносим данные из первого столбца dataGridView1
                    row["Mark"] = r.Cells[1].Value; // то же самое с остальными
                    row["FIO"] = r.Cells[2].Value;
                    row["NumberPhone"] = r.Cells[3].Value;
                    row["Cost"] = r.Cells[4].Value;
                    row["DataPrim"] = r.Cells[5].Value;
                    row["DataVidachi"] = r.Cells[6].Value;
                    row["Status"] = r.Cells[7].Value; 
                    ds.Tables["Fix"].Rows.Add(row); //добавление всей этой строки в таблицу ds.
                }
                ds.WriteXml(textBox6.Text);
                MessageBox.Show("XML файл успешно сохранен.", "Выполнено.");
            }
            catch
            {
                MessageBox.Show("Невозможно сохранить XML файл.", "Ошибка.");
            }
        }

        private void Button5_Click(object sender, EventArgs e) //загрузка файла XML в форму
        {
            if (dataGridView1.Rows.Count > 0) //если в таблице больше нуля строк
            {
                MessageBox.Show("Очистите поле перед загрузкой нового файла.", "Ошибка.");
            }
            else
            {
                if (File.Exists(textBox6.Text)) // если существует данный файл
                {
                DataSet ds = new DataSet(); // создаем новый пустой кэш данных
                ds.ReadXml(textBox6.Text); // записываем в него XML-данные из файла
                
                    foreach (DataRow item in ds.Tables["Fix"].Rows)
                    {
                        int n = dataGridView1.Rows.Add(); // добавляем новую сроку в dataGridView1
                        dataGridView1.Rows[n].Cells[0].Value = item["Name"]; // заносим в первый столбец созданной строки данные из первого столбца таблицы ds.
                        dataGridView1.Rows[n].Cells[1].Value = item["Mark"]; // то же самое с остальыми
                        dataGridView1.Rows[n].Cells[2].Value = item["FIO"];
                        dataGridView1.Rows[n].Cells[3].Value = item["NumberPhone"];
                        dataGridView1.Rows[n].Cells[4].Value = item["Cost"];
                        dataGridView1.Rows[n].Cells[5].Value = item["DataPrim"]; 
                        dataGridView1.Rows[n].Cells[6].Value = item["DataVidachi"];
                        dataGridView1.Rows[n].Cells[7].Value = item["Status"]; 
                    }
                }
                else
                {
                    MessageBox.Show("XML файл не найден.", "Ошибка.");
                }
            }
        }

        private void DataGridView1_MouseClick(object sender, MouseEventArgs e) // Выбор нужной строки для редактирования
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            maskedTextBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            maskedTextBox5.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            maskedTextBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            maskedTextBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            maskedTextBox2.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void Button2_Click(object sender, EventArgs e) // Редактирование
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int n = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
                dataGridView1.Rows[n].Cells[2].Value = maskedTextBox4.Text;
                dataGridView1.Rows[n].Cells[3].Value = maskedTextBox5.Text;
                dataGridView1.Rows[n].Cells[4].Value = maskedTextBox3.Text;
                dataGridView1.Rows[n].Cells[5].Value = maskedTextBox1.Text;
                dataGridView1.Rows[n].Cells[6].Value = maskedTextBox2.Text;
                dataGridView1.Rows[n].Cells[7].Value = comboBox1.Text;
            }
            else
            {
                MessageBox.Show("Выберите строку для редактирования.", "Ошибка.");
            }
        }

        private void Button3_Click(object sender, EventArgs e) // Удалить выбранную строку
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления.", "Ошибка.");
            }
        }

        private void Button6_Click(object sender, EventArgs e) // Очистить таблицу
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Таблица пустая.", "Ошибка.");
            }
        }

        private void Button7_Click(object sender, EventArgs e) // Авторизация
        {
            if (textBox3.Text == "Admin" && textBox4.Text == "Admin") 
            {
                panel2.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;  
                maskedTextBox1.Visible = true;
                maskedTextBox2.Visible = true;
                maskedTextBox3.Visible = true;
                maskedTextBox4.Visible = true;
                maskedTextBox5.Visible = true;
                comboBox1.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
            }
            else
            {
                MessageBox.Show("Логин или пароль введены неверно.", "Ошибка.");
            }
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void Button8_Click(object sender, EventArgs e) // Поиск
        {
            if (dataGridView1.RowCount != 0)
            {
                for (int i = dataGridView1.CurrentCell.RowIndex + 1; i < dataGridView1.RowCount; i++)
                {                    
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().ToUpper().Contains(textBox5.Text.ToUpper()))
                        {
                            dataGridView1.CurrentCell = dataGridView1[0, i];
                            return;
                        }
                }
                MessageBox.Show(this, "Достигнут конец базы данных или данные не существуют.", "Внимание");
                dataGridView1.CurrentCell = dataGridView1[0, 0];
            }
            else
            {
                MessageBox.Show(this, "База данных пуста.", "Внимание");
            }
        }

        private void Button9_Click(object sender, EventArgs e) // Выход
        {
            this.Close();
        }

        private void Button10_Click(object sender, EventArgs e) //Сортировка
        {
            string h = "Выполнено";
            if (dataGridView1.RowCount != 0)
            {
                foreach (DataGridViewRow s in dataGridView1.Rows)
                {
                    foreach (DataGridViewRow g in dataGridView1.Rows)
                    {
                        if (g.Cells["Column8"].Value.ToString().ToUpper().Contains(h.ToUpper()))
                        {
                            dataGridView1.Rows.RemoveAt(g.Index);
                        }
                    }
                }                  
              
                MessageBox.Show(this, "Сортировка завершена.", "Внимание");
                dataGridView1.CurrentCell = dataGridView1[0, 0];
            }
            else
            {
                MessageBox.Show(this, "База данных пуста.", "Внимание");
            }
        }

        private void Button11_Click(object sender, EventArgs e) //Заработок
        {
            dataGridView1.CurrentCell = dataGridView1[0, 0];
            string g;
            int k = 0;
            DateTime data1 = Convert.ToDateTime(maskedTextBox6.Text);
            DateTime data2 = Convert.ToDateTime(maskedTextBox7.Text);
            
            if (dataGridView1.RowCount != 0)
            {
                for (int j = 4; j < 5; j++)
                {
                    for (int i = dataGridView1.CurrentCell.RowIndex; i < dataGridView1.RowCount; i++)
                    {
                        DateTime data3 = Convert.ToDateTime(dataGridView1.Rows[i].Cells[6].Value);
                        DateTime data4 = Convert.ToDateTime(dataGridView1.Rows[i].Cells[6].Value);
                        if (data1 < data3 && data2 > data4)
                        {
                            g = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            k += Convert.ToInt32(g);
                        }                        
                    }
                }
            }
            MessageBox.Show(Convert.ToString(k)," Прибыль составила");
        }

    }
}
