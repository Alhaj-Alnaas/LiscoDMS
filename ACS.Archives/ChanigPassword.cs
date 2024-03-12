using ACS.Core.Entities.Bases;
using ACS.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ACS.Archives
{
    public partial class ChangingPassword : Form

    {
        protected readonly DataContext _dataContext;
        public ChangingPassword(DataContext dataContext)
        {
            _dataContext = dataContext;
            InitializeComponent();
        }

        private void txtNewPassword_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void txtNewPassword_Enter(object sender, EventArgs e)
        {
            if (Decode(StaticParametrs.CurrentUser.ArchiveUserPassword) != txtOldPassword.Text.Trim())
            {
                MessageBox.Show("عفوا... كلمة المرور التي أدخلتها غير صحيحة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldPassword.Focus();

            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //===========================================================
            if (ValidatePassword(txtNewPassword.Text) == false)
            {
                MessageBox.Show("يجب أن لايقل طول كلمة المرور على 6 خانات ، ويجب أن تحتوي على حروف انجليزية كبيرة وصغيرة وأرقام", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                txtNewPassword.SelectAll();

            }
            else
            {
                //==========================================================
                if (txtNewPassword.Text == "" || txtNewPassword.Text == null || txtConfirmPassword.Text == "" || txtConfirmPassword.Text == null || txtNewPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("عفوا... كلمتي المرور اللتان أدخلتهما غير متطابقتين", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewPassword.Focus();
                }
                else
                {
                    BaseUser user = new BaseUser();
                    user = _dataContext.Users.Where(c => c.Id == StaticParametrs.CurrentUser.Id).FirstOrDefault();
                    user.ArchiveUserPassword = Encode(txtNewPassword.Text.Trim());
                    _dataContext.Update(user);
                    _dataContext.SaveChangesAsync();
                    MessageBox.Show("تم تغيير كلمة المرور بنجاح", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOldPassword.Text = null;
                    txtNewPassword.Text = null;
                    txtConfirmPassword.Text = null;
                   // txtOldPassword.Focus();
                    this.Close();

                }
            }
        }

        private void txtOldPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtNewPassword.Focus();
            }
        }

        private void txtNewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtConfirmPassword.Focus();
            }
        }

        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnLogin.Focus();
            }
        }

        
        public static string Encode(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }

        }

        public string Decode(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
        static bool ValidatePassword(string passWord)
        {
            int validConditions = 0;
            foreach (char c in passWord)
            {
                if (c >= 'a' && c <= 'z')
                {
                    validConditions++;
                    break;
                }
            }
            foreach (char c in passWord)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions == 0) return false;
            foreach (char c in passWord)
            {
                if (c >= '0' && c <= '9')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions == 1) return false;
            if (validConditions == 2)
            {
                if (passWord.Length < 6) return false;
            }
            return true;
        }
    }
}
