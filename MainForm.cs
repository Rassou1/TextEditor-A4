using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;
using Assignment4_CS_GUI.Handlers;

namespace Assignment4_CS_GUI
{
    public partial class MainForm : Form
    {
        private FileManager fileMngr = new FileManager();
        string[] lines;

        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            toolTip1.SetToolTip(txtFind, "Select a text from the source and copy here!");
            toolTip1.SetToolTip(txtReplace, "Select a text to replace the above with!");
            toolTip1.SetToolTip(rtxtSource, "You can also write or change the text here manually!");
        }
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open file for reading as txt!";

            openFileDialog1.Filter = "Text files |*.txt| All files |*.*";
            openFileDialog1.FilterIndex = 0;

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;  //important
                readDataFromTextFile(fileName);
            }

        }

       

        private void readDataFromTextFile(string fileName)
        {
            rtxtSource.Clear();
            lstStatus.Items.Clear();
            string errorMsg = string.Empty;
            lines = fileMngr.ReadFromTextFile(fileName, out errorMsg).ToArray();
            //lblSource.Text = fileName;
            if (lines != null)
            {
                foreach (string line in lines)
                {
                    rtxtSource.AppendText(line + "\n");
                }
                lstStatus.Items.Add("Lines read from the file: " + lines.Length);
            }
            else
                MessageBox.Show(errorMsg);
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (lines == null || rtxtSource.Text == "" || txtFind.Text == "")
            {
                MessageBox.Show("Missing Input", "Error :(");
                return;
            }
           
                Controller controller = new Controller(rtxtDest, lstStatus);
            rtxtDest.Text = null;

            controller.Execute(lines, txtFind.Text, txtReplace.Text);

        }

        void txtFind_TextChanged(object sender, EventArgs e)
        {

        }

        int HighlightText(string find, RichTextBox richTextBox)
        {
            richTextBox.SelectionStart = 0;
            richTextBox.SelectAll();
            richTextBox.SelectionBackColor = Color.White;

            int instancesFound = 0;
            int index = 0;

            while (index < richTextBox.Text.Length)
            {
                int wordStartIndex = richTextBox.Find(find, index, RichTextBoxFinds.None);

                if (wordStartIndex != -1)
                {
                    richTextBox.SelectionStart = wordStartIndex;
                    richTextBox.SelectionLength = find.Length;
                    richTextBox.SelectionBackColor = Color.Azure;

                    index = wordStartIndex + find.Length;
                    instancesFound++;
                }
                else
                {
                    index++;
                }
                
            }
            return instancesFound;
        }

        private void txtFind_TextChanged_1(object sender, EventArgs e)
        {
            HighlightText(txtFind.Text, rtxtSource);
        }

        private void txtReplace_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtxtSource_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtxtDest_TextChanged(object sender, EventArgs e)
        {

        }

        private void lstStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
