using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PatrizierKartenEditor
{
    class CustomDataGridView : DataGridView
    {
        public CustomDataGridView()
        {
            DoubleBuffered = true;
        }
    }
    public partial class Form1 : Form
    {
        static byte[] fileBytes = null;
        static byte[] metadata = null;
        static string fileNamep = "";

        public Form1()
        {
            InitializeComponent();
            dataGridView1.VirtualMode = true;
            Demo(dataGridView1);
        }
        static void Demo(DataGridView dgv)
        {
            byte[] data = null;
            string fileName = "";

            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Patrizier Stadtplatz Datei (*.tow)|*.tow|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFileDialog.FileName;
                    fileNamep = fileName;
                    fileBytes = File.ReadAllBytes(openFileDialog.FileName);
                }
                BinaryReader reader = new BinaryReader(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None));
                metadata = reader.ReadBytes(0x64);
                data = reader.ReadBytes(0x7100);
                reader.Close();
            }
            catch (Exception ex1)
            {
                return;
            }

            DataTable dt = new DataTable();

            for (int i = 0; i < 128; i++)
            {
                dt.Columns.Add(new DataColumn { DataType = Type.GetType("System.String") });
            }

            for (int i = 0; i < 226; i++)
            {
                var dr = dt.NewRow();
                dt.Rows.Add(dr);
            }

            int stelle = 0;
            for (int columnName = 0; columnName < 128; columnName += 1)
            {
                for (int rowNum = 0; rowNum < 226; rowNum += 1)
                {
                    dt.Rows[rowNum][columnName] = data[stelle].ToString("X2");
                    stelle++;
                }
            }

            dgv.DataSource = dt;
            for (int ColumnIndex = 0; ColumnIndex < 128; ColumnIndex += 1)
            {
                dgv.Columns[ColumnIndex].Width = 24;
            }
            dgv.RowTemplate.Height = 12;
            float width2 = dgv.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Width;
            float width3 = width2 / 2.4f;
            dgv.RowsDefaultCellStyle.Font = new Font("Arial", width3, GraphicsUnit.Pixel);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            DataTable dt2 = (DataTable)dataGridView1.DataSource;
            var newfileBytes = new byte[28928];
            int stelle = 0;
            for (int columnName = 0; columnName < 128; columnName += 1)
            {
                for (int rowNum = 0; rowNum < 226; rowNum += 1)
                {
                    newfileBytes[stelle] = (byte)(Convert.ToInt32(dt2.Rows[rowNum][columnName].ToString(), 16));
                    stelle++;
                }
            }

            var merged = new byte[metadata.Length + newfileBytes.Length];
            metadata.CopyTo(merged, 0);
            newfileBytes.CopyTo(merged, metadata.Length);
            fileBytes = merged;
            File.WriteAllBytes(fileNamep, fileBytes);
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            int stelle2 = 0;
            for (int ColumnIndex = 0; ColumnIndex < 128; ColumnIndex += 1)
            {
                for (int RowIndex = 0; RowIndex < 226; RowIndex += 1)
                {
                    if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("1E"))
                    {
                        dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = Color.LightBlue;
                    }
                    if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("0C"))
                    {
                        dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = Color.LightSteelBlue;
                    }
                    if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("A0"))
                    {
                        dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = Color.DarkGreen;
                    }
                    if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("03"))
                    {
                        dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = Color.Brown;
                    }
                    if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("A1"))
                    {
                        dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = Color.Orange;
                    }
                    if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("3B"))
                    {
                        dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = Color.OrangeRed;
                    }
                    stelle2++;
                }
            }
        }

        private void buttonZoomOut_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
                row.Height = (int)(row.Height - 1);
            foreach (DataGridViewColumn col in dataGridView1.Columns)
                col.Width = (int)(col.Width - 2);
            float width2 = dataGridView1.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Width;
            float width3 = width2 / 2.4f;
            dataGridView1.RowsDefaultCellStyle.Font = new Font("Arial", width3, GraphicsUnit.Pixel);
        }

        private void buttonZoomIn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = (int)(row.Height + 1);
            }
            foreach (DataGridViewColumn col in dataGridView1.Columns)
                col.Width = (int)(col.Width + 2);
            float width2 = dataGridView1.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Width;
            float width3 = width2 / 2.4f;
            dataGridView1.RowsDefaultCellStyle.Font = new Font("Arial", width3, GraphicsUnit.Pixel);
        }

        private void buttonZoomOutMuch_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
                row.Height = (int)(row.Height - 5);
            foreach (DataGridViewColumn col in dataGridView1.Columns)
                col.Width = (int)(col.Width - 10);
            float width2 = dataGridView1.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Width;
            float width3 = width2 / 2.4f;
            dataGridView1.RowsDefaultCellStyle.Font = new Font("Arial", width3, GraphicsUnit.Pixel);
        }

        private void buttonZoomInMuch_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
                row.Height = (int)(row.Height + 5);
            foreach (DataGridViewColumn col in dataGridView1.Columns)
                col.Width = (int)(col.Width + 10);
            float width2 = dataGridView1.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Width;
            float width3 = width2 / 2.4f;
            dataGridView1.RowsDefaultCellStyle.Font = new Font("Arial", width3, GraphicsUnit.Pixel);
        }
    }
}
