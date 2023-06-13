using Gpt4All;

namespace GPT4allTest
{
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            // load the model
            var modelFactory = new Gpt4All.Gpt4AllModelFactory();
            //var modelFactory = new ModelFactory();

            using var model = modelFactory.LoadModel("C:\\Users\\bobth\\AppData\\Local\\nomic.ai\\GPT4All\\ggml-v3-13b-hermes-q5_1.bin");

            var input = txtSend.Text;
            updateLog(txtSend.Text);
            txtSend.Text = "";
            var reqOP = new PredictRequestOptions();
            var result = model.GetPredictionAsync(input, PredictRequestOptions.Defaults);
            var output = await result;
            if (output != null)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                string resultText = output.GetPredictionAsync().Result;
#pragma warning restore CS8604 // Possible null reference argument.
                updateLog(resultText);
            }
        }

        private void mainform_Load(object sender, EventArgs e)
        {
            AddContextMenu(rtbConver);
            AddContextMenu(rtbLogOutput);
        }


        public static void AddContextMenu(RichTextBox rtb)
        {
            if (rtb.ContextMenuStrip == null)
            {
                ContextMenuStrip cms = new ContextMenuStrip()
                {
                    ShowImageMargin = false
                };

                ToolStripMenuItem tsmiUndo = new ToolStripMenuItem("Undo");
                tsmiUndo.Click += (sender, e) => rtb.Undo();
                cms.Items.Add(tsmiUndo);

                ToolStripMenuItem tsmiRedo = new ToolStripMenuItem("Redo");
                tsmiRedo.Click += (sender, e) => rtb.Redo();
                cms.Items.Add(tsmiRedo);

                cms.Items.Add(new ToolStripSeparator());

                ToolStripMenuItem tsmiCut = new ToolStripMenuItem("Cut");
                tsmiCut.Click += (sender, e) => rtb.Cut();
                cms.Items.Add(tsmiCut);

                ToolStripMenuItem tsmiCopy = new ToolStripMenuItem("Copy");
                tsmiCopy.Click += (sender, e) => rtb.Copy();
                cms.Items.Add(tsmiCopy);

                ToolStripMenuItem tsmiPaste = new ToolStripMenuItem("Paste");
                tsmiPaste.Click += (sender, e) => rtb.Paste();
                cms.Items.Add(tsmiPaste);

                ToolStripMenuItem tsmiDelete = new ToolStripMenuItem("Delete");
                tsmiDelete.Click += (sender, e) => rtb.SelectedText = "";
                cms.Items.Add(tsmiDelete);

                cms.Items.Add(new ToolStripSeparator());

                ToolStripMenuItem tsmiSelectAll = new ToolStripMenuItem("Select All");
                tsmiSelectAll.Click += (sender, e) => rtb.SelectAll();
                cms.Items.Add(tsmiSelectAll);

                cms.Opening += (sender, e) =>
                {
                    tsmiUndo.Enabled = !rtb.ReadOnly && rtb.CanUndo;
                    tsmiRedo.Enabled = !rtb.ReadOnly && rtb.CanRedo;
                    tsmiCut.Enabled = !rtb.ReadOnly && rtb.SelectionLength > 0;
                    tsmiCopy.Enabled = rtb.SelectionLength > 0;
                    tsmiPaste.Enabled = !rtb.ReadOnly && Clipboard.ContainsText();
                    tsmiDelete.Enabled = !rtb.ReadOnly && rtb.SelectionLength > 0;
                    tsmiSelectAll.Enabled = rtb.TextLength > 0 && rtb.SelectionLength < rtb.TextLength;
                };

                rtb.ContextMenuStrip = cms;
            }
        }
        private void updateLog(string update)
        {
            appendColorText(rtbLogOutput, update, Color.Black);
        }

        void appendColorText(RichTextBox rtb, string newText, Color textColor)
        {
            Invoke(new Action(() =>
            {
                rtb.SelectionStart = rtb.TextLength;
                rtb.SelectionLength = 0;
                rtb.SelectionColor = textColor;
                rtb.AppendText(newText + "\n");
                rtb.SelectionColor = rtb.ForeColor;
            }));
        }
    }
}
