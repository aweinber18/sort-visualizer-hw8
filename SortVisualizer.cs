namespace Sorting_Visualization
{
    public partial class SortVisualizer : Form
    {
        IList<RichTextBox> rtb = new List<RichTextBox>(12);
        int[] array = new int[12];
        Sorter<int> sorter;
        public SortVisualizer(int[] ints)
        {
            InitializeComponent();
            InitRTB();
            array = ints;
            sorter = new ShellSorter<int>(this);
            ResetRTB();
        }

        private void InitRTB()
        {
            rtb.Add(richTextBox1);
            rtb.Add(richTextBox2);
            rtb.Add(richTextBox3);
            rtb.Add(richTextBox4);
            rtb.Add(richTextBox5);
            rtb.Add(richTextBox6);
            rtb.Add(richTextBox7);
            rtb.Add(richTextBox8);
            rtb.Add(richTextBox9);
            rtb.Add(richTextBox10);
            rtb.Add(richTextBox11);
            rtb.Add(richTextBox12);
        }

        public void ResetRTB()
        {
            for (int i = 0; i < array.Length; i++)
            {
                rtb[i].Text = array[i].ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sorter.Sort(array);
        }
    }
}