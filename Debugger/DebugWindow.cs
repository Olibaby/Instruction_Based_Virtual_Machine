using SVM.VirtualMachine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Debugger
{
    public partial class DebugWindow : Form
    {
        public DebugWindow()
        {
            InitializeComponent();
        }

        public void passInstruction(List<IInstruction> instructions, IInstruction instruction, IVirtualMachine virtualMachine)
        {
            var selected = 0;
            foreach (var item in instructions)
            {               
                listBox1.Items.Add(item.ToString());
                if(item == instruction)
                {
                    selected = instructions.IndexOf(item);
                    
                }
            }
            
            listBox1.SetSelected(selected, true);

            foreach (var item in virtualMachine.Stack)
            {
                listBox2.Items.Add(item.ToString());
            }
        }

        public int contineDebug(int counter)
        {
            return counter + 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will close down the whole application. Confirm?", "Close Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show("The application has been closed successfully.", "Application Closed!", MessageBoxButtons.OK);
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                this.Activate();
            }
        }

        private void DebugWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
