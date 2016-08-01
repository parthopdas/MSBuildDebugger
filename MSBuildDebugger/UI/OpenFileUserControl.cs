using System.Windows.Forms;

namespace MSBuildDebugger.UI
{
    public partial class OpenFileUserControl : UserControl
    {
        internal string OpenedFilePath { get; private set; }

        public OpenFileUserControl()
        {
            InitializeComponent();
        }

        internal OpenFileUserControl(string openedFilePath)
            : this()
        {
            OpenedFilePath = openedFilePath;
        }

        private string _lastSearchedString = string.Empty;
        private void richTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control || (e.KeyCode != Keys.F)) return;

            using (FindStringForm fsf = new FindStringForm())
            {
                fsf.textBox1.Text = _lastSearchedString;
                if ((fsf.ShowDialog() == DialogResult.OK) && !string.IsNullOrEmpty(fsf.textBox1.Text))
                {
                    _lastSearchedString = fsf.textBox1.Text;
                    richTextBox.Find(fsf.textBox1.Text);
                }
            }

            e.Handled = true;
        }
    }
}
