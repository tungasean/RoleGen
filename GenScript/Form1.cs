using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            //            if (!System.IO.File.Exists(txb_url.Text))
            //            {
            //                MessageBox.Show("", "Duong dan khong chinh xac, vui long thu lai..", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            //                return;
            //            }

            try
            {
                //                #region Gen script
                //                Excel.Application xlApp = new Excel.Application();
                //                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(txb_url.Text);
                //                // Lấy Sheet 1
                //                Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.Sheets.get_Item(1);
                //                // Lấy phạm vi dữ liệu
                //                Excel.Range xlRange = xlWorksheet.UsedRange;
                //                // Tạo mảng lưu trữ dữ liệu
                //                object[,] valueArray = (object[,])xlRange.get_Value(Excel.XlRangeValueDataType.xlRangeValueDefault);
                //
                //                string script = "";
                //
                //                // Hiển thị nọi dung
                //                for (int row = 2; row <= xlWorksheet.UsedRange.Rows.Count; ++row)//đọc row hiện có trong Excel
                //                {
                //                    var customerId = "";
                //                    var groupId = "";
                //                    string rowString = "";
                //                    for (int colum = 1; colum <= xlWorksheet.UsedRange.Columns.Count; ++colum)//đọc colum trong Excel
                //                    {
                //                        if(valueArray[row, colum] == null) continue;
                //                        String giatri = valueArray[row, colum].ToString();
                //                        if (colum == 1)
                //                        {
                //                            customerId = giatri;
                //                        }
                //                        if (colum == 2)
                //                        {
                //                            groupId = giatri;
                //                        }
                //                        
                //                        
                //                    }
                //
                //                    if (groupId != "" && customerId != "")
                //                    {
                //                        rowString =
                //                            "INSERT INTO CustomerAssigned(ActorChanged,MemberId_Branch,MemberId_GroupOnline,MemberId,Note,IsPendingChange,TimeChanged) SELECT 0,0, (SELECT MAX(MEMBERID) FROM MEMBERINFO WHERE DisplayMemberName = '" +
                //                            groupId + "'),(SELECT MAX(USERID) FROM USERINFO WHERE DISPLAYID = '" + customerId +
                //                            "'),'',0, GETDATE();";
                //                        script = script + "\r\n";
                //                        script = script + rowString;
                //                    }
                //                }
                //
                //                txtDisplay.Text = script;
                //                MessageBox.Show("", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //                Console.ReadLine();
                //                // Đóng Workbook.
                //                xlWorkbook.Close(false);
                //                // Đóng application
                //                xlApp.Quit();
                //                //Khử hết đối tượng
                //                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook);
                //                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                //
                //                #endregion


                #region Update form
                if (!string.IsNullOrEmpty(txb_url.Text))
                {
                    //doc all file
                    
                    var str = "(TOTAL TIMMER:) \\d*\\.\\d*";
                    string result = "";
                    
                    List<int> lstCount = new List<int> {2,11,21,31};
                    txb_url.Text = @"\\Mac\Home\Downloads\";

                    foreach (var count in lstCount)
                    {
                        result = result + "SO SERVICE LA: " + count + "\r\n";
                        
                        string url = txb_url.Text + "Log_" + count;
                        if (!string.IsNullOrEmpty(url))
                        {
                            for (var j = 1; j <= count; j++)
                            {
                                Dictionary<float, float> dic = new Dictionary<float, float>();
                                List<float> list11 = new List<float>();
                                float sum = 0;

                                string num = j <= 1 ? "" : j.ToString();
                                string[] files1 = Directory.GetFiles(url, "*" + "PricingCustomerCalculator" + num + "-" + "*.*", SearchOption.AllDirectories);
                                foreach (string file in files1)
                                {
                                    try
                                    {
                                        string contents = File.ReadAllText(file);
                                        if (contents.Contains("TOTAL TIMMER:"))
                                        {
                                            MatchCollection matchs = Regex.Matches(contents, str);
                                            foreach (Match match in matchs)
                                            {
                                                foreach (Capture capture in match.Captures)
                                                {
                                                    string text = capture.Value;
                                                    text = text.Replace("TOTAL TIMMER: ", "");
                                                    //text = text.Replace(".", ",");
                                                    float time = float.Parse(text);
                                                    sum = sum + time;
                                                    dic[time] = time;
                                                }
                                            }
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }

                                list11 = dic.Values.ToList();
                                if(list11.Count <= 0) continue;
                                //Lay 10 phan tu min
                                list11 = list11.OrderBy(q => q).ToList();
                                result = result + "PricingCustomerCalculator" + num + ":" + "\r\n";

                                result = result + "10 time Min:" + "\r\n";
                                for (int i = 0; i < 10; i++)
                                {
                                    result = result + list11[i] + "\r\n";
                                }

                                //Lay 10 phan tu Max
                                result = result + "10 time Max:" + "\r\n";
                                list11 = list11.OrderByDescending(q => q).ToList();
                                for (int i = 9; i >= 0; i--)
                                {
                                    result = result + list11[i] + "\r\n";
                                }

                                var trungBinh = sum / (list11.Count);
                                result = result + "Thoi gian trung binh: " + trungBinh + "\r\n";
                                
                            }
                            
                        }
                    }

                txtDisplay.Text = result;

                }


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

        private void button2_Click(object sender, EventArgs e)
        {
            //Copy text
            if (!string.IsNullOrWhiteSpace(txtDisplay.Text)) Clipboard.SetText(txtDisplay.Text);
        }
    }
}
