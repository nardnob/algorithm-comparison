using nardnob.AlgorithmComparison.Sorting.Files;
using System.Windows.Forms;

namespace nardnob.AlgorithmComparison.WinForms.Views
{
    public partial class FileExportedView : Form
    {
        #region " Private Members "

        private readonly string _fileName;

        #endregion

        #region " Constructors "

        public FileExportedView(string fileName)
        {
            InitializeComponent();
            _fileName = fileName;
        }

        #endregion

        #region " Event Handlers "

        private void FileExportedView_Load(object sender, System.EventArgs e)
        {
            txtFilePath.Text = _fileName;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnOpenFile_Click(object sender, System.EventArgs e)
        {
            FileHandler.OpenWithDefaultProgram(_fileName);
        }

        #endregion
    }
}
