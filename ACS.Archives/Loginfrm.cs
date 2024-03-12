using ACS.Core.Entities;
using ACS.DataAccess;
using SearchInOldSystem.DatabaseEntity;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ACS.Archives
{
    public partial class Loginfrm : Form
    {
        protected readonly DataContext _dataContext;
        protected readonly OldSysDBContext _OldDataContext;


        public Loginfrm(DataContext dataContext)
        {
            _dataContext = dataContext;
            InitializeComponent();
        }

        private void Loginfrm_Load(object sender, EventArgs e)
        {
            //var Curruser = _dataContext.Users.FirstOrDefault(c => c.FileNumber == "6894" && c.JobStatus == "AE");

            //txtUserId.Text =  Decode(Curruser.ArchiveUserPassword).ToString();

        }

        private void txtUserId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtPassword.Focus();
            }
        }
        public void LogInValidation()
        {
            var Curruser = _dataContext.Users.FirstOrDefault(c => c.FileNumber == txtUserId.Text.Trim() && c.JobStatus == "AE");

            var OrgUser = (ApplicationUser)_dataContext.Users.FirstOrDefault(c => c.UserName == "0000");

            //txtUserId.Text =  Decode(Curruser.ArchiveUserPassword).ToString();

            if (Curruser != null && txtPassword.Text == Decode(Curruser.ArchiveUserPassword))
            {
                StaticParametrs.CurrentUser = Curruser;
                StaticParametrs.OrgnaizationUser = OrgUser;

                // btnLogin.DialogResult = DialogResult.OK;
                ArchiveMainScreen mainForm = new ArchiveMainScreen(_dataContext, _OldDataContext);

                this.Hide();
                mainForm.Show();

            }

            else
            {
                MessageBox.Show("نأمل التأكد من رقم الملف وكلمة المرور", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
            }

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                LogInValidation();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LogInValidation();

        }

        private void btnLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                LogInValidation();
            }
        }
       
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
            //result = result;
            return result;
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

       
    }
    
}
