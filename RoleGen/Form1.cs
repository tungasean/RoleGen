using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace RoleGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateScript_Click_1(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtUrlRole.Text))
            {
                MessageBox.Show("", "Chưa nhập đường dẫn đến ma trận phân quyền", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtSheetName.Text))
            {
                MessageBox.Show("", "Chưa nhập tên Sheet", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            if (chkMXV.Checked == false && chkTech.Checked == false && chkVietin.Checked == false)
            {
                MessageBox.Show("", "Chưa Chọn dự án", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook sheet = excel.Workbooks.Open(txtUrlRole.Text);

            try
            {
                #region Role For MXV
                //Danh cho MXV
                if (chkMXV.Checked)
                {
                    //ma tran phan quyen mxv
                    Microsoft.Office.Interop.Excel.Worksheet x = excel.ActiveWorkbook.Sheets[txtSheetName.Text] as Microsoft.Office.Interop.Excel.Worksheet;
                    Excel.Range userRange = x.UsedRange;
                    int countRecords = userRange.Rows.Count;
                    //so cot la nhom quyen
                    int rowRoleGroupStart = 8;
                    int rowRoleGroupEnd = 16;

                    //           var a = (x.Cells[5, 4] as Excel.Range).Value2;
                    string textGen = "";
                    string strRole = "";
                    string strRoleRef = "";
                    int id = 1;

                    String displayMxv = "";

                    displayMxv = displayMxv + "TRUNCATE TABLE RoleGroup;  " + "\r\n";
                    displayMxv = displayMxv + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, N'', 0, N'Full quyền', 1, NULL, 1, CAST(0x0000A409004BA08C AS DateTime));" + "\r\n";
                    displayMxv = displayMxv + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, N'', 0, N'Admin', 2, NULL, 1, CAST(0x0000A409004BA08C AS DateTime));" + "\r\n";
                    displayMxv = displayMxv + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, N'', 0, N'QLGD', 3, NULL, 1, CAST(0x0000A409004BA08C AS DateTime));" + "\r\n";
                    displayMxv = displayMxv + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, N'', 0, N'QLTV', 4, NULL, 1, CAST(0x0000A409004BA08C AS DateTime));" + "\r\n";
                    displayMxv = displayMxv + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, N'', 0, N'TTBT', 5, NULL, 1, CAST(0x0000A409004BA08C AS DateTime));" + "\r\n";
                    displayMxv = displayMxv + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, N'', 0, N'RR', 6, NULL, 1, CAST(0x0000A409004BA08C AS DateTime));" + "\r\n";
                    displayMxv = displayMxv + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, N'', 0, N'Kế toán', 7, NULL, 1, CAST(0x0000A409004BA08C AS DateTime));" + "\r\n";
                    displayMxv = displayMxv + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, N'', 0, N'TVKD', 8, NULL, 1, CAST(0x0000A409004BA08C AS DateTime));" + "\r\n";
                    displayMxv = displayMxv + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, N'', 0, N'MG', 9, NULL, 1, CAST(0x0000A409004BA08C AS DateTime));" + "\r\n";
                    displayMxv = displayMxv + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, N'', 0, N'TKGD', 10, NULL, 1, CAST(0x0000A409004BA08C AS DateTime)); " + "\r\n";

                    displayMxv = displayMxv + "TRUNCATE TABLE Role;" + "\r\n";
                    displayMxv = displayMxv + "TRUNCATE TABLE RoleGroupRef;" + "\r\n";
                    displayMxv = displayMxv + "SET IDENTITY_INSERT Role ON;" + "\r\n";

                    Dictionary<int, string> ArrNewKey = new Dictionary<int, string>();
                    Dictionary<int, string> ArrOldKey = new Dictionary<int, string>();
                    string groupType = "";
                    string roleTypeId = "";
                    for (var i = 2; i <= countRecords; i++)
                    {

                        var description = (x.Cells[i, 5] as Excel.Range).Value2;
                        var name = (x.Cells[i, 4] as Excel.Range).Value2;
                        if (description == null || name == null) continue;

                        if ((x.Cells[i, 7] as Excel.Range).Value2 != null)
                        {
                            roleTypeId = (x.Cells[i, 7] as Excel.Range).Value2.ToString();
                        }

                        var newKey = (x.Cells[i, 5] as Excel.Range).Value2.ToString();
                        var oldKey = "";
                        if ((x.Cells[i, 6] as Excel.Range).Value2 != null)
                            oldKey = (x.Cells[i, 6] as Excel.Range).Value2.ToString();
                        if (newKey != null)
                            ArrNewKey[i] = newKey.ToString();
                        if (oldKey != null)
                            ArrOldKey[i] = oldKey.ToString();
                        strRole =
                            "INSERT [dbo].[Role] ([RoleId], [Name], [Description], [Enable], [ActorChanged], [TimeChanged], [RoleType]) VALUES (" +
                            id + ", N'" + description + "', N'"
                            + name + "', 1, 1, CAST(0x0000A38100A8D31E AS DateTime)," + roleTypeId + " );";

                        displayMxv = displayMxv + strRole + "\r\n";
                        int count = 2;
                        for (var j = rowRoleGroupStart; j <= rowRoleGroupEnd; j++)
                        {
                            string check = (x.Cells[i, j] as Excel.Range).Value2;
                            if (check == "X")
                            {
                                strRoleRef =
                                    "INSERT INTO RoleGroupRef (ActorChanged, IsPendingChange, RoleGroupId, RoleId, TimeChanged) VALUES (0, 0, " +
                                    count + ", " + id + ", CAST(0x0000A409004BA08C AS DateTime));";
                                displayMxv = displayMxv + strRoleRef + "\r\n";
                            }
                            count++;
                        }
                        //add vao nhom full quyen
                        string strAddFull =
                            "INSERT INTO RoleGroupRef (ActorChanged, IsPendingChange, RoleGroupId, RoleId, TimeChanged) VALUES (0, 0, " +
                            1 + ", " + id + ", CAST(0x0000A409004BA08C AS DateTime));";
                        displayMxv = displayMxv + strAddFull + "\r\n";

                        id++;

                    }
                    sheet.Close();
                    excel.Workbooks.Close();
                    txtDisplay.Text = displayMxv;
                    MessageBox.Show("", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    #region Xu ly thay the role key cu boi role key moi
                    // Xu ly thay the key cu boi key moi
                    if (!string.IsNullOrEmpty(textUrl.Text))
                    {
                        foreach (var oldValue in ArrOldKey)
                        {
                            int k = oldValue.Key;
                            //doc all file
                            if (string.IsNullOrEmpty(textUrl.Text))
                                //textUrl.Text = @"C:\TungData\Quant-Edge\MXV-Commo\terminal-vtb-commo";
                                if (!string.IsNullOrEmpty(textUrl.Text))
                                {

                                    string[] files1 = Directory.GetFiles(textUrl.Text + @"\TerminalGUI.Base", "*.*", SearchOption.AllDirectories);
                                    foreach (string file in files1)
                                    {
                                        try
                                        {
                                            string contents = File.ReadAllText(file);
                                            if (contents.Contains(ArrOldKey[k]))
                                            {
                                                if (!string.IsNullOrEmpty(ArrOldKey[k]))
                                                {
                                                    contents = contents.Replace(ArrOldKey[k], ArrNewKey[k]);
                                                    File.SetAttributes(file, FileAttributes.Normal);
                                                    File.WriteAllText(file, contents);
                                                }

                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                    }
                                    string[] files2 = Directory.GetFiles(textUrl.Text + @"\TerminalGUI", "*.*", SearchOption.AllDirectories);
                                    foreach (string file in files2)
                                    {
                                        try
                                        {
                                            string contents = File.ReadAllText(file);
                                            if (contents.Contains(ArrOldKey[k]))
                                            {
                                                if (!string.IsNullOrEmpty(ArrOldKey[k]))
                                                {
                                                    contents = contents.Replace(ArrOldKey[k], ArrNewKey[k]);
                                                    File.SetAttributes(file, FileAttributes.Normal);
                                                    File.WriteAllText(file, contents);
                                                }
                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                    string[] files3 = Directory.GetFiles(textUrl.Text + @"\TerminalAPI", "*.*", SearchOption.AllDirectories);
                                    foreach (string file in files3)
                                    {
                                        try
                                        {
                                            string contents = File.ReadAllText(file);
                                            if (contents.Contains(ArrOldKey[k]))
                                            {
                                                if (!string.IsNullOrEmpty(ArrOldKey[k]))
                                                {
                                                    contents = contents.Replace(ArrOldKey[k], ArrNewKey[k]);
                                                    File.SetAttributes(file, FileAttributes.Normal);
                                                    File.WriteAllText(file, contents);
                                                }
                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                    string[] files4 = Directory.GetFiles(@"C:\TungData\Quant-Edge\MXV-Commo\vision-foundation\Common\Enum", "*.*", SearchOption.AllDirectories);
                                    foreach (string file in files4)
                                    {
                                        try
                                        {
                                            string contents = File.ReadAllText(file);
                                            if (contents.Contains(ArrOldKey[k]))
                                            {
                                                if (!string.IsNullOrEmpty(ArrOldKey[k]))
                                                {
                                                    contents = contents.Replace(ArrOldKey[k], ArrNewKey[k]);
                                                    File.SetAttributes(file, FileAttributes.Normal);
                                                    File.WriteAllText(file, contents);
                                                }
                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }

                                }
                        }
                    }
                    #endregion

                }
                #endregion

                #region Role For VietinBank
                //Danh cho viettin
                if (chkVietin.Checked)
                {
                    
                    Microsoft.Office.Interop.Excel.Worksheet x = excel.ActiveWorkbook.Sheets[txtSheetName.Text] as Microsoft.Office.Interop.Excel.Worksheet;
                    //ma tran phan quyen vietin
                    Excel.Range userRange = x.UsedRange;
                    int countRecords = userRange.Rows.Count;
                    //so cot la nhom quyen
                    int rowRoleGroupStart = 9;
                    int rowRoleGroupEnd = 24;

                    //           var a = (x.Cells[5, 4] as Excel.Range).Value2;
                    string textGen = "";
                    string strRole = "";
                    string strRoleRef = "";
                    int id = 1;

                    String displayVtb = "";

                    displayVtb = displayVtb + "TRUNCATE TABLE RoleGroup;  " + "\r\n";
                    displayVtb = displayVtb + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, '', 0, 'GDV CN', 1, NULL, 1, SYSDATE); " + "\r\n";
                    displayVtb = displayVtb + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, '', 0, 'GDV PGD', 2, NULL, 1, SYSDATE);" + "\r\n";
                    displayVtb = displayVtb + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, '', 0, 'KS CN', 3, NULL, 1, SYSDATE);" + "\r\n";
                    displayVtb = displayVtb + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, '', 0, 'KS PGD', 4, NULL, 1, SYSDATE);" + "\r\n";
                    displayVtb = displayVtb + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, '', 0, 'GĐ CN', 5, NULL, 1, SYSDATE);" + "\r\n";
                    displayVtb = displayVtb + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, '', 0, 'Sales', 6, NULL, 1, SYSDATE);" + "\r\n";
                    displayVtb = displayVtb + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, '', 0, 'Sales Mn', 7, NULL, 1, SYSDATE);" + "\r\n";
                    displayVtb = displayVtb + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, '', 0, 'Control (Sales)', 8, NULL, 1, SYSDATE);" + "\r\n";
                    displayVtb = displayVtb + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, '', 0, 'Trader', 9, NULL, 1, SYSDATE);" + "\r\n";
                    displayVtb = displayVtb + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, '', 0, 'Trader Mn', 10, NULL, 1, SYSDATE);" + "\r\n";
                    displayVtb = displayVtb + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, '', 0, 'MO', 11, NULL, 1, SYSDATE);" + "\r\n";
                    displayVtb = displayVtb + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, '', 0, 'BO', 12, NULL, 1, SYSDATE);" + "\r\n";
                    displayVtb = displayVtb + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, '', 0, 'IT', 13, NULL, 1, SYSDATE);" + "\r\n";
                    displayVtb = displayVtb + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, '', 0, 'Admin', 14, NULL, 1, SYSDATE);" + "\r\n";
                    displayVtb = displayVtb + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, '', 0, 'Full quyền', 15, NULL, 1, SYSDATE);" + "\r\n";
                    displayVtb = displayVtb + "INSERT INTO RoleGroup(ActorChanged, Description, IsPendingChange, Name, RoleGroupId, RoleGroupType, Status, TimeChanged) VALUES(0, '', 0, 'View', 16, NULL, 1, SYSDATE);" + "\r\n";
                    displayVtb = displayVtb + "TRUNCATE TABLE Role;" + "\r\n";
                    displayVtb = displayVtb + "TRUNCATE TABLE RoleGroupRef;" + "\r\n";
                    string groupType = "";
                    string roleTypeId = "";
                    for (var i = 3; i <= countRecords; i++)
                    {

                        var description = (x.Cells[i, 6] as Excel.Range).Value2;
                        var name = (x.Cells[i, 7] as Excel.Range).Value2;
                        if (description == null || name == null) continue;

                        if ((x.Cells[i, 8] as Excel.Range).Value2 != null)
                        {
                            roleTypeId = (x.Cells[i, 8] as Excel.Range).Value2.ToString();
                        }
                        strRole =
                            "INSERT INTO Role (ActorChanged, Description, Enable, Name, RoleId, RoleType, TimeChanged) VALUES (0,'" +
                            description + "','1', '" + name + "', " + id + "," + roleTypeId + ", SYSDATE);";

                        displayVtb = displayVtb + strRole + "\r\n";
                        int count = 1;
                        for (var j = rowRoleGroupStart; j <= rowRoleGroupEnd; j++)
                        {
                            string check = (x.Cells[i, j] as Excel.Range).Value2;
                            if (!string.IsNullOrEmpty(check))
                            {
                                strRoleRef =
                                    "INSERT INTO RoleGroupRef (ActorChanged, IsPendingChange, RoleGroupId, RoleId, TimeChanged) VALUES (0, 0, " +
                                    count + ", " + id + ", SYSDATE);";
                                displayVtb = displayVtb + strRoleRef + "\r\n";
                            }
                            count++;
                        }
                        //add vao nhom full quyen
                        //                        string strAddFull =
                        //                            "INSERT INTO RoleGroupRef (ActorChanged, IsPendingChange, RoleGroupId, RoleId, TimeChanged) VALUES (0, 0, " +
                        //                            10 + ", " + id + ", SYSDATE);";
                        //                        displayVtb = displayVtb + strAddFull + "\r\n";

                        id++;

                    }

                    txtDisplay.Text = displayVtb; 
                    MessageBox.Show("", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                #endregion

                #region Role For Techcombank
                if (chkTech.Checked)
                {
                    Microsoft.Office.Interop.Excel.Worksheet x = excel.ActiveWorkbook.Sheets[txtSheetName.Text] as Microsoft.Office.Interop.Excel.Worksheet;
                    //ma tran phan quyen TechCombank
                    Excel.Range userRange = x.UsedRange;
                    int countRecords = userRange.Rows.Count;
                    //so cot la nhom quyen
                    int rowRoleGroupStart = 5;
                    int rowRoleGroupEnd = 32;

                    //           var a = (x.Cells[5, 4] as Excel.Range).Value2;
                    string textGen = "";
                    string strRole = "";
                    string strRoleRef = "";

                    var arrayValue = userRange.Value2;
                    String display = "";

                    if (cb_RoleGroup.Checked)
                    {
                        //display = display + "TRUNCATE TABLE RoleGroup;  " + "\r\n";

                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'ADMIN', '1', '1', N'ADMIN', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'ADMIN');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'SND.GDV', '1', '1', N'SND.GDV', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'SND.GDV');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'SND.KSV', '1', '1', N'SND.KSV', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'SND.KSV');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'KNV.TRADER', '1', '1', N'KNV.TRADER', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'KNV.TRADER');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'KNV.TRADERMANAGER', '1', '1', N'KNV.TRADERMANAGER', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'KNV.TRADERMANAGER');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'KNV.SALE', '1', '1', N'KNV.SALE', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'KNV.SALE');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'KNV.SALEMANAGER', '1', '1', N'KNV.SALEMANAGER', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'KNV.SALEMANAGER');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'KNV.BSM', '1', '1', N'KNV.BSM', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'KNV.BSM');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'QTRR.CV', '1', '1', N'QTRR.CV', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'QTRR.CV');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'TCKH.TFC.CV', '1', '1', N'TCKH.TFC.CV', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'TCKH.TFC.CV');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'SND.THUQUY', '1', '1', N'SND.THUQUY', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'SND.THUQUY');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'KVH.TREAOPS.CV', '1', '1', N'KVH.TREAOPS.CV', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'KVH.TREAOPS.CV');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'KVH.TREAOPS.KSV', '1', '1', N'KVH.TREAOPS.KSV', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'KVH.TREAOPS.KSV');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'WB.WBS', '1', '1', N'WB.WBS', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'WB.WBS');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'WB.NHANLENH(MMDVACIB)', '1', '1', N'WB.NHANLENH(MMDVACIB)', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'WB.NHANLENH(MMDVACIB)');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'OT.ITO.VHUD.OPS', '1', '1', N'OT.ITO.VHUD.OPS', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'OT.ITO.VHUD.OPS');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'OT.ANTT', '1', '1', N'OT.ANTT', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'OT.ANTT');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'OT.VHUD.READONLY', '1', '1', N'OT.VHUD.READONLY', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'OT.VHUD.READONLY');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'OT.DVKH', '1', '1', N'OT.DVKH', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'OT.DVKH');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'SND.BAOCAO', '1', '1', N'SND.BAOCAO', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'SND.BAOCAO');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'SnD.CN_RM', '1', '1', N'SnD.CN_RM', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'SnD.CN_RM');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'SnD.CN_TTQT', '1', '1', N'SnD.CN_TTQT', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'SnD.CN_TTQT');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'SnD.CNDN_GDV', '1', '1', N'SnD.CNDN_GDV', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'SnD.CNDN_GDV');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'SnD.CN_GDV', '1', '1', N'SnD.CN_GDV', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'SnD.CN_GDV');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'KTNB.CV', '1', '1', N'KTNB.CV', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'KTNB.CV');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'WB.GDV', '1', '1', N'WB.GDV', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'WB.GDV');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'WB.KSV', '1', '1', N'WB.KSV', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'WB.KSV');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'KSS.CV', '1', '1', N'KSS.CV', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'KSS.CV');" + "\r\n";
                        display = display + "INSERT INTO RoleGroup (Name, RoleGroupType, Status, Description, ActorChanged, TimeChanged, IsPendingChange) SELECT N'SnD.FE_GDV', '1', '1', N'SnD.FE_GDV', '1', GETDATE(), '0' WHERE NOT EXISTS (SELECT 1 FROM RoleGroup WHERE Name = 'SnD.FE_GDV');" + "\r\n";

                    }


                    display = display + "TRUNCATE TABLE Role;" + "\r\n";
                    display = display + "TRUNCATE TABLE RoleGroupRef;" + "\r\n";
                    string groupType = "";
                    string roleTypeId = "";
                    for (var i = 4; i <= countRecords; i++)
                    {
                        var description = arrayValue[i, 3];
                        var name = arrayValue[i, 2];
                        if (description == null || name == null) continue;

                        if (arrayValue[i, 4] != null)
                        {
                            roleTypeId = arrayValue[i, 4].ToString();
                        }
                        strRole =
                            "INSERT INTO Role (Name, Description, Enable, ActorChanged, TimeChanged, RoleType) SELECT N'" +
                            description + "',N'" + name + "', '1', '0', GETDATE(), '" + roleTypeId + "' WHERE NOT EXISTS (SELECT RoleId FROM Role WHERE Name = '" + description + "');";

                        display = display + strRole + "\r\n";

                        for (var j = rowRoleGroupStart; j <= rowRoleGroupEnd; j++)
                        {
                            var a = arrayValue[i, j];
                            string check = null;
                            if (a != null) check = a.ToString();
                            if (!string.IsNullOrEmpty(check) && check == "x")
                            {
                                var nameGroup = arrayValue[3, j];
                                strRoleRef =
                                    "INSERT INTO RoleGroupRef (ActorChanged, IsPendingChange, RoleGroupId, RoleId, TimeChanged) SELECT '0', '0', (SELECT RoleGroupId FROM RoleGroup WHERE Name = '" +
                                    nameGroup + "'), (SELECT RoleId FROM Role WHERE Name = '" + description + "') , GETDATE() WHERE EXISTS (SELECT RoleGroupId FROM RoleGroup WHERE Name = '" + nameGroup + "') AND EXISTS (SELECT RoleId FROM Role WHERE Name = '" +
                                    description + "') AND NOT EXISTS (SELECT 1 FROM RoleGroupRef WHERE RoleGroupId = (SELECT RoleGroupId FROM RoleGroup WHERE Name = '" + nameGroup + "') AND RoleId = (SELECT RoleId FROM Role WHERE Name = '" + description + "'));";
                                display = display + strRoleRef + "\r\n";
                            }
                        }

                    }

                    txtDisplay.Text = display;
                    MessageBox.Show("", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                #endregion

            }
            catch (Exception exception)
            {
                sheet.Close();
                excel.Workbooks.Close();
                MessageBox.Show("", exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Copy text
            if (!string.IsNullOrWhiteSpace(txtDisplay.Text)) Clipboard.SetText(txtDisplay.Text);
        }

        private void chkMXV_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMXV.Checked)
            {
                txtSheetName.Text = "Phân Quyền MXV";
                cb_RoleGroup.Checked = false;
                cb_RoleGroup.Enabled = false;
                chkVietin.Checked = false;
                chkTech.Checked = false;
            }
        }

        private void chkVietin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVietin.Checked)
            {
                txtSheetName.Text = "Rules_Scrip";
                cb_RoleGroup.Checked = false;
                cb_RoleGroup.Enabled = false;
                chkMXV.Checked = false;
                chkTech.Checked = false;
            }
        }

        private void chkTech_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTech.Checked)
            {
                txtSheetName.Text = "Ma trận đầy đủ";
                cb_RoleGroup.Checked = false;
                cb_RoleGroup.Enabled = true;
                chkVietin.Checked = false;
                chkMXV.Checked = false;
            }
        }
    }
}
