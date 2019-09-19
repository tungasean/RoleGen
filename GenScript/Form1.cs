using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using ExcelDataReader;

namespace GenScript
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Gen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txb_url.Text))
            {
                MessageBox.Show("", "Chưa nhập đường dẫn URL", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }

            if (!System.IO.File.Exists(txb_url.Text))
            {
                MessageBox.Show("", "Duong dan khong chinh xac, vui long thu lai..", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }

            try
            {
                #region Gen script
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(txb_url.Text);
                // Lấy Sheet 1
                Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.Sheets.get_Item(1);
                // Lấy phạm vi dữ liệu
                Excel.Range xlRange = xlWorksheet.UsedRange;
                // Tạo mảng lưu trữ dữ liệu
                object[,] valueArray = (object[,])xlRange.get_Value(Excel.XlRangeValueDataType.xlRangeValueDefault);

                string script = "";

                // Hiển thị nọi dung
                for (int row = 2; row <= xlWorksheet.UsedRange.Rows.Count; ++row)//đọc row hiện có trong Excel
                {
                    var customerId = "";
                    var groupId = "";
                    string rowString = "";
                    for (int colum = 1; colum <= xlWorksheet.UsedRange.Columns.Count; ++colum)//đọc colum trong Excel
                    {
                        if(valueArray[row, colum] == null) continue;
                        String giatri = valueArray[row, colum].ToString();
                        if (colum == 1)
                        {
                            customerId = giatri;
                        }
                        if (colum == 2)
                        {
                            groupId = giatri;
                        }
                        
                        
                    }

                    if (groupId != "" && customerId != "")
                    {
                        rowString =
                            "INSERT INTO CustomerAssigned(ActorChanged,MemberId_Branch,MemberId_GroupOnline,MemberId,Note,IsPendingChange,TimeChanged) SELECT 0,0, (SELECT MAX(MEMBERID) FROM MEMBERINFO WHERE DisplayMemberName = '" +
                            groupId + "'),(SELECT MAX(USERID) FROM USERINFO WHERE DISPLAYID = '" + customerId +
                            "'),'',0, GETDATE();";
                        script = script + "\r\n";
                        script = script + rowString;
                    }
                }

                txtDisplay.Text = script;
                MessageBox.Show("", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Console.ReadLine();
                // Đóng Workbook.
                xlWorkbook.Close(false);
                // Đóng application.
                xlApp.Quit();
                //Khử hết đối tượng
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

                #endregion

            }
            catch (Exception exception)
            {
                MessageBox.Show("", exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Btn_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                //DefaultExt = "xlsx",
                Filter = "All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txb_url.Text = openFileDialog1.FileName;
            }
        }
    }
}
