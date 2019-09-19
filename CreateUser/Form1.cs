using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateUser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chk_tsc.Checked = true;
            chk_cn.Checked = false;
            chk_fx.Checked = true;
        }

        private void Chk_tsc_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_tsc.Checked)
            {
                chk_cn.Checked = false;
            }
            else
            {
                chk_cn.Checked = true;
            }
        }

        private void Chk_cn_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_cn.Checked)
            {
                chk_tsc.Checked = false;
            }
            else
            {
                chk_tsc.Checked = true;
            }
        }

        private void Btn_create_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_name.Text))
                {
                    MessageBox.Show("", "Chưa nhập tên người dùng", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    return;
                }
                //Tao so luong nguoi dung
                var listUser = txt_name.Text.Split(',');
                string script = "";
                script = script +
                         "DECLARE \r\n p_memberId NUMBER; \r\n p_userId NUMBER; \r\n BEGIN \r\n SELECT MAX(MemberId) INTO p_memberId FROM MemberInfo; \r\n SELECT MAX(UserId) INTO p_userId FROM UserInfo; \r\n";

                var i = 0;
                foreach (var username in listUser)
                {
                    i = i + 1;
                    string name = username;
                    string nameResult = name;
                    if (chk_fx.Checked)
                    {
                        nameResult = "fx." + name;
                    }
                    script = script + "\r\n";
                    script = script + "--Init " + nameResult + "\r\n";
                    if (chk_tsc.Checked)
                    {
                        script = script + "INSERT INTO MemberInfo (AccountName, ActorChanged, ActorCreater, BrandId, ClosedTime, CreatedTime, CustomerGroup, DisplayMemberName, FCMAccountNumber, IsPendingChange, MemberId, MemberName, MemberParent, MemberType, Note, Status, TimeChanged, TradingType, WithdrawRuleType) VALUES (NULL, 0, 0, 2, NULL, SYSDATE, 0, '" + nameResult + "', NULL, 0, p_memberId + " + i +", '" + nameResult + "', NULL, 1, NULL, 1, SYSDATE, NULL, 0);";
                    }
                    else if (chk_cn.Checked)
                    {
                        script = script + "INSERT INTO MemberInfo (AccountName, ActorChanged, ActorCreater, BrandId, ClosedTime, CreatedTime, CustomerGroup, DisplayMemberName, FCMAccountNumber, IsPendingChange, MemberId, MemberName, MemberParent, MemberType, Note, Status, TimeChanged, TradingType, WithdrawRuleType) VALUES (NULL, 0, 0, 2, NULL, SYSDATE, 0, '" + nameResult + "', NULL, 0, p_memberId + " + i + ", '" + nameResult + "', 1, 2, NULL, 1, SYSDATE, NULL, 0);";
                    }
                    script = script + "\r\n";
                    script = script + "\r\n";
                    script = script +
                             "INSERT INTO UserInfo (AcctOfficerId, ActorChanged, ActorCreater, Address, BankAccount, BankName, Birthday, CardNo, ClosedTime, ContactAddress, CreatedTime, DepartmentId, DisplayId, Email, ExpiredDate, Fax, FullName, Gender, IdNoTypeId, IsBlackList, IsNotifySms, IsNotifySmsOrder, IsNotityfyEmail, IsPendingChange, IssueDate, IssuedOrg, MemberId, Mnemonic, Mobile, Note, Status, TaxIdNo, Tel, TimeChanged, UserId) VALUES (NULL, 0, 0, NULL, NULL, NULL, SYSDATE, NULL, NULL, NULL, SYSDATE, 'PB', '" + nameResult + "', '" + name + "@quant-edge.com', NULL, NULL, '" + nameResult + "', NULL, 0, 0, 0, 0, 0, 0, NULL, NULL, p_memberId + " + i + ", NULL, '09857584455', NULL, 1, NULL, NULL, SYSDATE, p_userId + " + i + ");";
                    script = script + "\r\n";
                    script = script + "\r\n";
                    script = script +
                             "INSERT INTO UserLogin (ActorChanged, ActorCreated, ExpiredDay, ExpiredDayAlert, FailCount, FailNumber, IsExpriedChanged, IsExpriedCheck, IsPendingChange, LastestLogin, LoginCount, OtpPass, PassChangedDate, Password, Status, TimeChanged, UserId, UserName, WorkingQueue) VALUES (0, 0, 0, 0, 0, 0, 1, 0, 0, SYSDATE, 10, '1', SYSDATE, 'c4ca4238a0b923820dcc509a6f75849b', 1, SYSDATE, p_userId + " + i + ", '" + nameResult + "', NULL);";
                    script = script + "\r\n";
                    script = script + "\r\n";
                    script = script + "DELETE UserRoleGroup WHERE ROLEGROUPID = 15 AND UserId > p_userId;";
                    script = script + "\r\n";
                    script = script + "INSERT INTO UserRoleGroup (ActorChanged, IsPendingChange, RoleGroupId, TimeChanged, UserId) SELECT 0, 0, 15, SYSDATE, UserId FROM UserInfo WHERE UserId > p_userId;";
                    script = script + "\r\n";
                    
                    
                }
                script = script + "UPDATE UserLogin SET LASTESTLOGIN = NULL;";
                script = script + "\r\n";
                script = script + "END;";

                txt_result.Text = script;
                MessageBox.Show("", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show("", exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }
            
        }

        private void Btn_copy_Click(object sender, EventArgs e)
        {
            //Copy text
            if (!string.IsNullOrWhiteSpace(txt_result.Text)) Clipboard.SetText(txt_result.Text);
        }
    }
}
