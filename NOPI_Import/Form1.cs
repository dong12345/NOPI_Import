using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NOPI_Import
{
    public partial class Form1 : Form
    {
        private string _sqlConnectionSreing = string.Empty;
        private string _tableName = string.Empty;
        private string _filePath = string.Empty;
        public  Form1()
        {
            InitializeComponent();
        }

        private void bt_ChooseFile_Click(object sender, EventArgs e)
        {
            this.txt_log.Text = string.Empty;
            OperateExcel();
        }


        private bool Valid()
        {
            if (string.IsNullOrEmpty(_sqlConnectionSreing))
            {
                MessageBox.Show("请填写数据库连接字符串", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(_tableName))
            {
                MessageBox.Show("请填写要操作的数据库表名称", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void OperateExcel()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*xls*)|*.xls*"; //设置要选择的文件的类型
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                _filePath = fileDialog.FileName;//返回文件的完整路径   
            }
        }
        private void WriteMessage(string msg)
        {
            this.txt_log.AppendText(string.Format("{0}{1}", msg, Environment.NewLine));
        }

        private async void bt_Insert_Click(object sender, EventArgs e)
        {
            this.txt_log.Text = string.Empty;
            _sqlConnectionSreing = txtSqlConnection.Text.Trim();
            _tableName = txt_tableName.Text.Trim();
            if (Valid())
            {
                if (!string.IsNullOrEmpty(_filePath))
                {
                    this.bt_Insert.Enabled = false;
                    this.bt_ChooseFile.Enabled = false;
                    WriteMessage("数据导入中………………");
                    var str= await InsertDB();
                    WriteMessage(str);
                    this.bt_Insert.Enabled = true;
                    this.bt_ChooseFile.Enabled = true;
                    _filePath = string.Empty;
                }
                else
                {
                    MessageBox.Show("请选择Excel文件", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }

        private Task<string> InsertDB()
        {
            return Task.Run(()=> {
                ImportHelper helper = new ImportHelper(_filePath, _tableName, _sqlConnectionSreing);
                var data = helper.Import();
                return data.Message;
            });
        }

    }
}
