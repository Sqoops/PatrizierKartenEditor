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
      catch (Exception)
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
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("9E"))
            dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#fff1ff");
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("10"))
            dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#f2f2f2");
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("20"))
            dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#e6e6e6");
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("1E"))
            dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#e6ccff");
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("0E"))
            dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#b366ff");
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("0C"))
            dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#b3d9ff");
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("A0"))
            dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#99e699");
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("03"))
            dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#996633");
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("04"))
            dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#ac7339");
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("83"))
            dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#a3a375");
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("84"))
            dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#b8b894");
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("80"))
            dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#8a8a5c");
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("0D"))
            dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#404040");
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("09"))
            dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#808080");
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("11"))
            dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#bfbfbf");
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("0A"))
            dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#a6a6a6");
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("A1"))
            dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#ff6666");
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("A2"))
            dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#ff4d4d");
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("3B"))
            dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#ffcc00");
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

    //  max ColumnIndex: 128
    //  max RowIndex: 226
    private void buttonScript_Click(object sender, EventArgs e)
    {
      // clear stuff
      for (int ColumnIndex = 1; ColumnIndex < 127; ColumnIndex += 1)
        for (int RowIndex = 3; RowIndex < 223; RowIndex += 1)
        {
          // clear fischereien
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("0E"))
          {
            dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value = "0C";
            if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex - 1].Value.Equals("1E"))
              dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex - 1].Value = "0C";
            if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("1E"))
              dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value = "0C";
            if (dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex].Value.Equals("1E"))
              dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex].Value = "0C";
            if (dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex].Value.Equals("1E"))
              dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex].Value = "0C";
            if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex + 1].Value.Equals("1E"))
              dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex + 1].Value = "0C";
            if (dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 1].Value.Equals("1E"))
              dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 1].Value = "0C";
            if (dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 1].Value.Equals("1E"))
              dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 1].Value = "0C";
          }
          // clear haus a1
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("A1"))
          {
            dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value = "A0";
            if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex - 1].Value.Equals("9E"))
              dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex - 1].Value = "A0";
            if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("9E"))
              dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value = "A0";
            if (dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex].Value.Equals("9E"))
              dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex].Value = "A0";
            if (dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex].Value.Equals("9E"))
              dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex].Value = "A0";
            if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex + 1].Value.Equals("9E"))
              dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex + 1].Value = "A0";
            if (dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 1].Value.Equals("9E"))
              dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 1].Value = "A0";
            if (dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 1].Value.Equals("9E"))
              dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 1].Value = "A0";
          }
          // clear haus a2
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("A2"))
          {
            dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value = "A0";
            if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex + 1].Value.Equals("9E"))
              dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex + 1].Value = "A0";
            if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("9E"))
              dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value = "A0";
            if (dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex].Value.Equals("9E"))
              dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex].Value = "A0";
            if (dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex].Value.Equals("9E"))
              dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex].Value = "A0";
            if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex - 1].Value.Equals("9E"))
              dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex - 1].Value = "A0";
            if (dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex - 1].Value.Equals("9E"))
              dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex - 1].Value = "A0";
            if (dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex - 1].Value.Equals("9E"))
              dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex - 1].Value = "A0";
          }
        }
      // clear stuff2
      for (int ColumnIndex = 2; ColumnIndex < 126; ColumnIndex++)
        for (int RowIndex = 1; RowIndex < 222; RowIndex++)
        {
          // clear steinfelsen 1
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("0D"))
            if (dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex].Value.Equals("0D"))
              if (dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex].Value.Equals("0D"))
                if (dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex + 1].Value.Equals("0D"))
                  if (dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex + 1].Value.Equals("0D"))
                    if (dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex + 1].Value.Equals("0D"))

                      if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("09") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("11"))
                        if (dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex].Value.Equals("09") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex].Value.Equals("11"))

                          if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex - 1].Value.Equals("20") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex - 1].Value.Equals("09") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex - 1].Value.Equals("10") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex - 1].Value.Equals("11"))
                            if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex - 1].Value.Equals("20") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex - 1].Value.Equals("09") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex - 1].Value.Equals("10") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex - 1].Value.Equals("11"))
                              if (dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex - 1].Value.Equals("20") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex - 1].Value.Equals("09") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex - 1].Value.Equals("10") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex - 1].Value.Equals("11"))
                                if (dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex - 1].Value.Equals("20") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex - 1].Value.Equals("09") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex - 1].Value.Equals("10") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex - 1].Value.Equals("11"))
                                  if (dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex - 1].Value.Equals("20") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex - 1].Value.Equals("09") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex - 1].Value.Equals("10") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex - 1].Value.Equals("11"))

                                    if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 1].Value.Equals("20") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 1].Value.Equals("09") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 1].Value.Equals("10") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 1].Value.Equals("11"))
                                      if (dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex + 1].Value.Equals("20") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex + 1].Value.Equals("09") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex + 1].Value.Equals("10") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex + 1].Value.Equals("11"))

                                        if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 2].Value.Equals("20") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 2].Value.Equals("09") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 2].Value.Equals("10") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 2].Value.Equals("11"))
                                          if (dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex + 2].Value.Equals("20") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex + 2].Value.Equals("09") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex + 2].Value.Equals("10") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex + 2].Value.Equals("11"))
                                            if (dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex + 2].Value.Equals("20") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex + 2].Value.Equals("09") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex + 2].Value.Equals("10") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex + 2].Value.Equals("11"))
                                              if (dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex + 2].Value.Equals("20") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex + 2].Value.Equals("09") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex + 2].Value.Equals("10") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex + 2].Value.Equals("11"))
                                                if (dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex + 2].Value.Equals("20") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex + 2].Value.Equals("09") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex + 2].Value.Equals("10") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex + 2].Value.Equals("11"))
                                                {
                                                  if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex].Value.Equals("20"))
                                                  {
                                                    dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value = "20";
                                                    dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex].Value = "20";
                                                    dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex].Value = "20";
                                                    dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex + 1].Value = "20";
                                                    dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex + 1].Value = "20";
                                                    dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex + 1].Value = "20";
                                                  }
                                                  if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex].Value.Equals("10"))
                                                  {
                                                    dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value = "10";
                                                    dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex].Value = "10";
                                                    dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex].Value = "10";
                                                    dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex + 1].Value = "10";
                                                    dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex + 1].Value = "10";
                                                    dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex + 1].Value = "10";
                                                  }
                                                }
          // clear steinfelsen 2
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("0D"))
            if (dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex].Value.Equals("0D"))
              if (dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex].Value.Equals("0D"))
                if (dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex].Value.Equals("0D"))
                  if (dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex - 1].Value.Equals("0D"))
                    if (dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex + 1].Value.Equals("0D"))

                      if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("09") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("11"))
                        if (dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex].Value.Equals("09") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex].Value.Equals("11"))

                          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex - 1].Value.Equals("20") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex - 1].Value.Equals("09") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex - 1].Value.Equals("10") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex - 1].Value.Equals("11"))
                            if (dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex - 2].Value.Equals("20") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex - 2].Value.Equals("09") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex - 2].Value.Equals("10") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex - 2].Value.Equals("11"))
                              if (dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex - 1].Value.Equals("20") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex - 1].Value.Equals("09") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex - 1].Value.Equals("10") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex - 1].Value.Equals("11"))
                                if (dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex - 1].Value.Equals("20") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex - 1].Value.Equals("09") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex - 1].Value.Equals("10") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex - 1].Value.Equals("11"))
                                  if (dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex - 1].Value.Equals("20") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex - 1].Value.Equals("09") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex - 1].Value.Equals("10") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex - 1].Value.Equals("11"))

                                    if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 1].Value.Equals("20") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 1].Value.Equals("09") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 1].Value.Equals("10") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 1].Value.Equals("11"))
                                      if (dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex + 1].Value.Equals("20") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex + 1].Value.Equals("09") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex + 1].Value.Equals("10") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex + 1].Value.Equals("11"))
                                        if (dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex + 1].Value.Equals("20") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex + 1].Value.Equals("09") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex + 1].Value.Equals("10") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex + 1].Value.Equals("11"))

                                          if (dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex + 2].Value.Equals("20") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex + 2].Value.Equals("09") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex + 2].Value.Equals("10") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex + 2].Value.Equals("11"))
                                            if (dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex + 2].Value.Equals("20") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex + 2].Value.Equals("09") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex + 2].Value.Equals("10") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex + 2].Value.Equals("11"))
                                              if (dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex + 2].Value.Equals("20") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex + 2].Value.Equals("09") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex + 2].Value.Equals("10") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex + 2].Value.Equals("11"))
                                              {
                                                if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex].Value.Equals("20"))
                                                {
                                                  dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value = "20";
                                                  dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex].Value = "20";
                                                  dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex].Value = "20";
                                                  dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex].Value = "20";
                                                  dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex - 1].Value = "20";
                                                  dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex + 1].Value = "20";
                                                }
                                                if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex].Value.Equals("10"))
                                                {
                                                  dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value = "10";
                                                  dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex].Value = "10";
                                                  dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex].Value = "10";
                                                  dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex].Value = "10";
                                                  dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex - 1].Value = "10";
                                                  dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex + 1].Value = "10";
                                                }
                                              }
        }
      // haus oben rechts von der inneren straße 
      for (int ColumnIndex = 1; ColumnIndex < 127; ColumnIndex += 1)
        for (int RowIndex = 2; RowIndex < 224; RowIndex += 1)
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("83") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("80"))
            if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("83") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("80"))
              if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 1].Value.Equals("83") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 1].Value.Equals("80"))
                if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex + 1].Value.Equals("84") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex + 1].Value.Equals("A0"))
                  if (dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 1].Value.Equals("84") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 1].Value.Equals("A0"))
                    if (dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 1].Value.Equals("84") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 1].Value.Equals("A0"))
                      if (dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 2].Value.Equals("84") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 2].Value.Equals("A0"))
                        if (dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 2].Value.Equals("84") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 2].Value.Equals("A0"))
                          if (dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 2].Value.Equals("84") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 2].Value.Equals("A0"))
                            if (!dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 3].Value.Equals("84"))
                            {
                              dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex + 1].Value = "A1";
                              dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 1].Value = "9E";
                              dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 1].Value = "9E";
                              dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 2].Value = "9E";
                              dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 2].Value = "9E";
                              dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 2].Value = "9E";
                            }
      // haus oben links von der inneren straße 
      for (int ColumnIndex = 1; ColumnIndex < 127; ColumnIndex += 1)
        for (int RowIndex = 2; RowIndex < 224; RowIndex += 1)
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("83") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("80"))
            if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("A0") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("84") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("91"))
              if (dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex].Value.Equals("A0") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex].Value.Equals("84") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex].Value.Equals("91"))
                if (dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex].Value.Equals("A0") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex].Value.Equals("84") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex].Value.Equals("91"))
                  if (dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex - 1].Value.Equals("A0") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex - 1].Value.Equals("84") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex - 1].Value.Equals("91"))
                    if (dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex - 1].Value.Equals("A0") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex - 1].Value.Equals("84") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex - 1].Value.Equals("91"))
                      if (dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex - 1].Value.Equals("A0") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex - 1].Value.Equals("84") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex - 1].Value.Equals("91"))
                      {
                        dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value = "A2";
                        dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex].Value = "9E";
                        dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex].Value = "9E";
                        dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex - 1].Value = "9E";
                        dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex - 1].Value = "9E";
                        dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex - 1].Value = "9E";
                      }
      // haus unten rechts von der inneren straße 
      for (int ColumnIndex = 1; ColumnIndex < 127; ColumnIndex += 1)
        for (int RowIndex = 2; RowIndex < 224; RowIndex += 1)
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("83") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("80"))
            if (dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex + 1].Value.Equals("A0") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex + 1].Value.Equals("84") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex + 1].Value.Equals("91"))
              if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 1].Value.Equals("A0") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 1].Value.Equals("84") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 1].Value.Equals("91"))
                if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex + 1].Value.Equals("A0") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex + 1].Value.Equals("84") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex + 1].Value.Equals("91"))
                  if (dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex + 2].Value.Equals("A0") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex + 2].Value.Equals("84") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex + 2].Value.Equals("91"))
                    if (dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex + 2].Value.Equals("A0") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex + 2].Value.Equals("84") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex + 2].Value.Equals("91"))
                      if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 2].Value.Equals("A0") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 2].Value.Equals("84") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 2].Value.Equals("91"))
                      {
                        dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex + 1].Value = "9E";
                        dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 1].Value = "9E";
                        dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex + 1].Value = "9E";
                        dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex + 2].Value = "A2";
                        dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex + 2].Value = "9E";
                        dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 2].Value = "9E";
                      }
      // haus unten links von der inneren straße 
      for (int ColumnIndex = 1; ColumnIndex < 127; ColumnIndex += 1)
        for (int RowIndex = 2; RowIndex < 224; RowIndex += 1)
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("83") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("80"))
            if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex - 1].Value.Equals("A0") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex - 1].Value.Equals("84"))
              if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex - 1].Value.Equals("A0") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex - 1].Value.Equals("84"))
                if (dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex - 1].Value.Equals("A0"))
                  if (dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex - 2].Value.Equals("A0"))
                    if (dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex - 2].Value.Equals("A0"))
                      if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex - 2].Value.Equals("A0"))
                      {
                        dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex - 1].Value = "9E";
                        dataGridView1.Rows[RowIndex].Cells[ColumnIndex - 1].Value = "9E";
                        dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex - 1].Value = "9E";
                        dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex - 2].Value = "A1";
                        dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex - 2].Value = "9E";
                        dataGridView1.Rows[RowIndex].Cells[ColumnIndex - 2].Value = "9E";
                      }
      // fischer
      for (int ColumnIndex = 126; ColumnIndex > 0; ColumnIndex--)
        for (int RowIndex = 223; RowIndex > 2; RowIndex--)
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("0C"))
            if (dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex].Value.Equals("0D") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 1].Value.Equals("0D") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex - 1].Value.Equals("0D") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex - 1].Value.Equals("0D") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex + 1].Value.Equals("0D") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex + 1].Value.Equals("0D") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex - 1].Value.Equals("0D"))
              if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("0C"))
                if (dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex].Value.Equals("0C"))
                  if (dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex].Value.Equals("0C") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex].Value.Equals("0D"))
                    if (dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 1].Value.Equals("0C") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 1].Value.Equals("0D"))
                      if (dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 1].Value.Equals("0C") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 1].Value.Equals("0D"))
                        if (!dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex].Value.Equals("0E"))
                          if (!dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex].Value.Equals("0E"))
                            if (!dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex].Value.Equals("0E"))
                              if (!dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 1].Value.Equals("0E"))
                                if (!dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex + 1].Value.Equals("0E"))
                                  if (!dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex + 2].Value.Equals("0E"))
                                    if (!dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex + 1].Value.Equals("0E"))
                                      dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value = "0E";
      // restliches haus oben rechts von der inneren straße 
      for (int ColumnIndex = 1; ColumnIndex < 127; ColumnIndex += 1)
        for (int RowIndex = 2; RowIndex < 224; RowIndex += 1)
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("83") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("80"))
            if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("83") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("80"))
              if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 1].Value.Equals("83") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 1].Value.Equals("80"))
                if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex + 1].Value.Equals("84") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex + 1].Value.Equals("A0"))
                  if (dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 1].Value.Equals("84") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 1].Value.Equals("A0"))
                    if (dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 1].Value.Equals("84") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 1].Value.Equals("A0"))
                      if (dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 2].Value.Equals("84") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 2].Value.Equals("A0"))
                        if (dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 2].Value.Equals("84") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 2].Value.Equals("A0"))
                          if (dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 2].Value.Equals("84") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 2].Value.Equals("A0"))
                          //   if (!dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 3].Value.Equals("84"))
                          {
                            dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex + 1].Value = "A1";
                            dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 1].Value = "9E";
                            dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 1].Value = "9E";
                            dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 2].Value = "9E";
                            dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 2].Value = "9E";
                            dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 2].Value = "9E";
                          }
      // restliches haus unten links von der inneren straße 
      for (int ColumnIndex = 1; ColumnIndex < 127; ColumnIndex += 1)
        for (int RowIndex = 2; RowIndex < 224; RowIndex += 1)
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("83") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("80"))
            if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex - 1].Value.Equals("A0") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex - 1].Value.Equals("84"))
              if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex - 1].Value.Equals("A0") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex - 1].Value.Equals("84"))
                if (dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex - 1].Value.Equals("A0"))
                  if (dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex - 2].Value.Equals("A0"))
                    if (dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex - 2].Value.Equals("A0"))
                      if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex - 2].Value.Equals("A0") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex - 2].Value.Equals("84"))
                      {
                        dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex - 1].Value = "9E";
                        dataGridView1.Rows[RowIndex].Cells[ColumnIndex - 1].Value = "9E";
                        dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex - 1].Value = "9E";
                        dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex - 2].Value = "A1";
                        dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex - 2].Value = "9E";
                        dataGridView1.Rows[RowIndex].Cells[ColumnIndex - 2].Value = "9E";
                      }
      //     // arbeitsplatz alles reihe oben
      //     for (int ColumnIndex = 3; ColumnIndex < 125; ColumnIndex += 1)
      //       for (int RowIndex = 10; RowIndex < 222; RowIndex += 1)
      //
      //         if (dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex - 2].Value.Equals("04") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex - 2].Value.Equals("10") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex - 2].Value.Equals("11") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex - 2].Value.Equals("20") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex - 2].Value.Equals("3B"))
      //
      //           if (dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex - 1].Value.Equals("04") || dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex - 1].Value.Equals("10") || dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex - 1].Value.Equals("11") || dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex - 1].Value.Equals("20") || dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex - 1].Value.Equals("3B"))
      //             if (dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex - 1].Value.Equals("04") || dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex - 1].Value.Equals("10") || dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex - 1].Value.Equals("11") || dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex - 1].Value.Equals("20") || dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex - 1].Value.Equals("3B"))
      //               if (dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex - 1].Value.Equals("04") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex - 1].Value.Equals("10") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex - 1].Value.Equals("11") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex - 1].Value.Equals("20") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex - 1].Value.Equals("3B"))
      //                 if (dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex - 1].Value.Equals("04") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex - 1].Value.Equals("10") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex - 1].Value.Equals("11") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex - 1].Value.Equals("20") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex - 1].Value.Equals("3B"))
      //                   if (dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex - 1].Value.Equals("04") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex - 1].Value.Equals("10") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex - 1].Value.Equals("11") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex - 1].Value.Equals("20") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex - 1].Value.Equals("3B"))
      //
      //                     if (dataGridView1.Rows[RowIndex - 8].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex - 8].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex - 8].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex - 8].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex - 8].Cells[ColumnIndex].Value.Equals("3B"))
      //                       if (dataGridView1.Rows[RowIndex - 7].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex - 7].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex - 7].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex - 7].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex - 7].Cells[ColumnIndex].Value.Equals("3B"))
      //                         if (dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex].Value.Equals("3B"))
      //                           if (dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex].Value.Equals("3B"))
      //                             if (dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex].Value.Equals("3B"))
      //                               if (dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex].Value.Equals("3B"))
      //                                 if (dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex].Value.Equals("3B"))
      //                                   if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("3B"))
      //
      //                                     if (dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex + 1].Value.Equals("04") || dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex + 1].Value.Equals("10") || dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex + 1].Value.Equals("11") || dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex + 1].Value.Equals("20") || dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex + 1].Value.Equals("3B"))
      //                                       if (dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex + 1].Value.Equals("04") || dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex + 1].Value.Equals("10") || dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex + 1].Value.Equals("11") || dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex + 1].Value.Equals("20") || dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex + 1].Value.Equals("3B"))
      //                                         if (dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 1].Value.Equals("04") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 1].Value.Equals("10") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 1].Value.Equals("11") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 1].Value.Equals("20") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 1].Value.Equals("3B"))
      //                                           if (dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 1].Value.Equals("04") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 1].Value.Equals("10") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 1].Value.Equals("11") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 1].Value.Equals("20") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 1].Value.Equals("3B"))
      //                                             if (dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 1].Value.Equals("04") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 1].Value.Equals("10") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 1].Value.Equals("11") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 1].Value.Equals("20") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 1].Value.Equals("3B"))
      //
      //                                               if (dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 2].Value.Equals("04") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 2].Value.Equals("10") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 2].Value.Equals("11") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 2].Value.Equals("20") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 2].Value.Equals("3B"))
      //
      //                                                 if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("20"))
      //                                                   if (dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex].Value.Equals("03"))
      //                                                     dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value = "3B";
      //     // arbeitsplatz alles reihe unten
      //     for (int ColumnIndex = 3; ColumnIndex < 125; ColumnIndex += 1)
      //       for (int RowIndex = 4; RowIndex < 216; RowIndex += 1)
      //
      //         if (dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex - 2].Value.Equals("04") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex - 2].Value.Equals("10") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex - 2].Value.Equals("11") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex - 2].Value.Equals("20") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex - 2].Value.Equals("3B"))
      //
      //           if (dataGridView1.Rows[RowIndex + 6].Cells[ColumnIndex - 1].Value.Equals("04") || dataGridView1.Rows[RowIndex + 6].Cells[ColumnIndex - 1].Value.Equals("10") || dataGridView1.Rows[RowIndex + 6].Cells[ColumnIndex - 1].Value.Equals("11") || dataGridView1.Rows[RowIndex + 6].Cells[ColumnIndex - 1].Value.Equals("20") || dataGridView1.Rows[RowIndex + 6].Cells[ColumnIndex - 1].Value.Equals("3B"))
      //             if (dataGridView1.Rows[RowIndex + 5].Cells[ColumnIndex - 1].Value.Equals("04") || dataGridView1.Rows[RowIndex + 5].Cells[ColumnIndex - 1].Value.Equals("10") || dataGridView1.Rows[RowIndex + 5].Cells[ColumnIndex - 1].Value.Equals("11") || dataGridView1.Rows[RowIndex + 5].Cells[ColumnIndex - 1].Value.Equals("20") || dataGridView1.Rows[RowIndex + 5].Cells[ColumnIndex - 1].Value.Equals("3B"))
      //               if (dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex - 1].Value.Equals("04") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex - 1].Value.Equals("10") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex - 1].Value.Equals("11") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex - 1].Value.Equals("20") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex - 1].Value.Equals("3B"))
      //                 if (dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex - 1].Value.Equals("04") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex - 1].Value.Equals("10") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex - 1].Value.Equals("11") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex - 1].Value.Equals("20") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex - 1].Value.Equals("3B"))
      //                   if (dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex - 1].Value.Equals("04") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex - 1].Value.Equals("10") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex - 1].Value.Equals("11") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex - 1].Value.Equals("20") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex - 1].Value.Equals("3B"))
      //
      //                     if (dataGridView1.Rows[RowIndex + 7].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex + 7].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex + 7].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex + 7].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex + 7].Cells[ColumnIndex].Value.Equals("3B"))
      //                       if (dataGridView1.Rows[RowIndex + 6].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex + 6].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex + 6].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex + 6].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex + 6].Cells[ColumnIndex].Value.Equals("3B"))
      //                         if (dataGridView1.Rows[RowIndex + 5].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex + 5].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex + 5].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex + 5].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex + 5].Cells[ColumnIndex].Value.Equals("3B"))
      //                           if (dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex].Value.Equals("3B"))
      //                             if (dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex].Value.Equals("3B"))
      //                               if (dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex].Value.Equals("3B"))
      //                                 if (dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex].Value.Equals("3B"))
      //                                   if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("3B"))
      //
      //                                     if (dataGridView1.Rows[RowIndex + 6].Cells[ColumnIndex + 1].Value.Equals("04") || dataGridView1.Rows[RowIndex + 6].Cells[ColumnIndex + 1].Value.Equals("10") || dataGridView1.Rows[RowIndex + 6].Cells[ColumnIndex + 1].Value.Equals("11") || dataGridView1.Rows[RowIndex + 6].Cells[ColumnIndex + 1].Value.Equals("20") || dataGridView1.Rows[RowIndex + 6].Cells[ColumnIndex + 1].Value.Equals("3B"))
      //                                       if (dataGridView1.Rows[RowIndex + 5].Cells[ColumnIndex + 1].Value.Equals("04") || dataGridView1.Rows[RowIndex + 5].Cells[ColumnIndex + 1].Value.Equals("10") || dataGridView1.Rows[RowIndex + 5].Cells[ColumnIndex + 1].Value.Equals("11") || dataGridView1.Rows[RowIndex + 5].Cells[ColumnIndex + 1].Value.Equals("20") || dataGridView1.Rows[RowIndex + 5].Cells[ColumnIndex + 1].Value.Equals("3B"))
      //                                         if (dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex + 1].Value.Equals("04") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex + 1].Value.Equals("10") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex + 1].Value.Equals("11") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex + 1].Value.Equals("20") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex + 1].Value.Equals("3B"))
      //                                           if (dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex + 1].Value.Equals("04") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex + 1].Value.Equals("10") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex + 1].Value.Equals("11") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex + 1].Value.Equals("20") || dataGridView1.Rows[RowIndex + 3].Cells[ColumnIndex + 1].Value.Equals("3B"))
      //                                             if (dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex + 1].Value.Equals("04") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex + 1].Value.Equals("10") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex + 1].Value.Equals("11") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex + 1].Value.Equals("20") || dataGridView1.Rows[RowIndex + 2].Cells[ColumnIndex + 1].Value.Equals("3B"))
      //
      //                                               if (dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex + 2].Value.Equals("04") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex + 2].Value.Equals("10") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex + 2].Value.Equals("11") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex + 2].Value.Equals("20") || dataGridView1.Rows[RowIndex + 4].Cells[ColumnIndex + 2].Value.Equals("3B"))
      //
      //                                                 if (dataGridView1.Rows[RowIndex + 8].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex + 8].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex + 8].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex + 8].Cells[ColumnIndex].Value.Equals("20"))
      //                                                   if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("03"))
      //                                                     dataGridView1.Rows[RowIndex + 8].Cells[ColumnIndex].Value = "3B";

      //// äußerste straße gehweg entfernen => Achtung - man kann keine Brunnen dort mehr bauen!
      //for (int ColumnIndex = 1; ColumnIndex < 127; ColumnIndex += 1)
      //  for (int RowIndex = 2; RowIndex < 224; RowIndex += 1)
      //    if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("04"))
      //      dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value = "A0";

      //// äußerste mauer blockieren => sobald 20 gebäude in dem äußersten gebiet gebaut werden, will der rat alle 15 Tage die Stadtmauer erweitern
      //for (int ColumnIndex = 1; ColumnIndex < 127; ColumnIndex++)
      //  for (int RowIndex = 1; RowIndex < 225; RowIndex++)
      //    if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("10"))
      //      if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 1].Value.Equals("09") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex + 1].Value.Equals("11")
      //        || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex + 1].Value.Equals("09") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex + 1].Value.Equals("11")
      //        || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex - 1].Value.Equals("09") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex - 1].Value.Equals("11")
      //        || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex - 1].Value.Equals("09") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex - 1].Value.Equals("11")
      //        || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("09") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("11")
      //        || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex].Value.Equals("09") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex].Value.Equals("11")
      //        || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex + 1].Value.Equals("09") || dataGridView1.Rows[RowIndex + 1].Cells[ColumnIndex + 1].Value.Equals("11") 
      //        || dataGridView1.Rows[RowIndex].Cells[ColumnIndex - 1].Value.Equals("09") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex - 1].Value.Equals("11"))
      //      dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value = "06";

      // arbeitsplatz alles
      for (int ColumnIndex = 3; ColumnIndex < 125; ColumnIndex += 1)
        for (int RowIndex = 8; RowIndex < 224; RowIndex += 1)

          if (dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex - 2].Value.Equals("04") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex - 2].Value.Equals("10") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex - 2].Value.Equals("11") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex - 2].Value.Equals("20") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex - 2].Value.Equals("3B"))

            if (dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex - 1].Value.Equals("04") || dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex - 1].Value.Equals("10") || dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex - 1].Value.Equals("11") || dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex - 1].Value.Equals("20") || dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex - 1].Value.Equals("3B"))
              if (dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex - 1].Value.Equals("04") || dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex - 1].Value.Equals("10") || dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex - 1].Value.Equals("11") || dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex - 1].Value.Equals("20") || dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex - 1].Value.Equals("3B"))
                if (dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex - 1].Value.Equals("04") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex - 1].Value.Equals("10") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex - 1].Value.Equals("11") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex - 1].Value.Equals("20") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex - 1].Value.Equals("3B"))
                  if (dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex - 1].Value.Equals("04") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex - 1].Value.Equals("10") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex - 1].Value.Equals("11") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex - 1].Value.Equals("20") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex - 1].Value.Equals("3B"))
                    if (dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex - 1].Value.Equals("04") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex - 1].Value.Equals("10") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex - 1].Value.Equals("11") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex - 1].Value.Equals("20") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex - 1].Value.Equals("3B"))

                      if (dataGridView1.Rows[RowIndex - 8].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex - 8].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex - 8].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex - 8].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex - 8].Cells[ColumnIndex].Value.Equals("3B"))
                        if (dataGridView1.Rows[RowIndex - 7].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex - 7].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex - 7].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex - 7].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex - 7].Cells[ColumnIndex].Value.Equals("3B"))
                          if (dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex].Value.Equals("3B"))
                            if (dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex].Value.Equals("3B"))
                              if (dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex].Value.Equals("3B"))
                                if (dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex].Value.Equals("3B"))
                                  if (dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex].Value.Equals("3B"))
                                    if (dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("20") || dataGridView1.Rows[RowIndex - 1].Cells[ColumnIndex].Value.Equals("3B"))

                                      if (dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex + 1].Value.Equals("04") || dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex + 1].Value.Equals("10") || dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex + 1].Value.Equals("11") || dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex + 1].Value.Equals("20") || dataGridView1.Rows[RowIndex - 6].Cells[ColumnIndex + 1].Value.Equals("3B"))
                                        if (dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex + 1].Value.Equals("04") || dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex + 1].Value.Equals("10") || dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex + 1].Value.Equals("11") || dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex + 1].Value.Equals("20") || dataGridView1.Rows[RowIndex - 5].Cells[ColumnIndex + 1].Value.Equals("3B"))
                                          if (dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 1].Value.Equals("04") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 1].Value.Equals("10") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 1].Value.Equals("11") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 1].Value.Equals("20") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 1].Value.Equals("3B"))
                                            if (dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 1].Value.Equals("04") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 1].Value.Equals("10") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 1].Value.Equals("11") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 1].Value.Equals("20") || dataGridView1.Rows[RowIndex - 3].Cells[ColumnIndex + 1].Value.Equals("3B"))
                                              if (dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 1].Value.Equals("04") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 1].Value.Equals("10") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 1].Value.Equals("11") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 1].Value.Equals("20") || dataGridView1.Rows[RowIndex - 2].Cells[ColumnIndex + 1].Value.Equals("3B"))

                                                if (dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 2].Value.Equals("04") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 2].Value.Equals("10") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 2].Value.Equals("11") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 2].Value.Equals("20") || dataGridView1.Rows[RowIndex - 4].Cells[ColumnIndex + 2].Value.Equals("3B"))

                                                  if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("04") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("10") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("11") || dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("20"))
                                                    dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value = "3B";
      //// äußerste straße entfernen => Achtung - man kann den Feldweg nicht mehr upgraden!
      //for (int ColumnIndex = 0; ColumnIndex < 128; ColumnIndex++)
      //  for (int RowIndex = 0; RowIndex < 226; RowIndex++)
      //    if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("03"))
      //      dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value = "0D";

      // äußerstes gebiet bebaubar machen => Achtung - Stadtrat möchte alle 15 Tage die äußerste Stadtmauer erweitern!
      for (int ColumnIndex = 1; ColumnIndex < 127; ColumnIndex += 1)
        for (int RowIndex = 2; RowIndex < 224; RowIndex += 1)
          if (dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value.Equals("10"))
            dataGridView1.Rows[RowIndex].Cells[ColumnIndex].Value = "A0";
    }
  }
}
