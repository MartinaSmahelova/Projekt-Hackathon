using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Projekt_Hackathon
{
    public partial class rozhovor_sam_so_sebou : Form
    {
        public rozhovor_sam_so_sebou()
        {
            InitializeComponent();
        }

        Dotazník dotaznik = new Dotazník();
        List<String> souborCilu = new List<string>();
        List<String> splneneCile = new List<string>();
        String smajlikText;
        String organizaceCasuText;

        private void Form1_Load(object sender, EventArgs e)
        {
            label_citat.Text = dotaznik.VypisCitat();

            String line;

            StreamReader nacitacCilu = new StreamReader(@"C:\Users\marti\source\repos\Projekt Hackathon\Projekt Hackathon\Resources\txtSouborCilu.txt");
            while ((line = nacitacCilu.ReadLine()) != null)
            {
                souborCilu.Add(line);
                checkedListBox_splneneCile.Items.Add(line);
            }
            nacitacCilu.Close();
        }

        public void ZmensiObrazek(Button btnName)
        {
            if (btnName.Name != "btn_wink")
            {
                btn_wink.Image = dotaznik.NahrajZmensenyObrazekWink();
            }

            if (btnName.Name != "btn_smile")
            {
                btn_smile.Image = dotaznik.NahrajZmensenyObrazekSmile();
            }

            if (btnName.Name != "btn_neutral")
            {
                btn_neutral.Image = dotaznik.NahrajZmensenyObrazekNeutral();
            }

            if (btnName.Name != "btn_sad")
            {
                btn_sad.Image = dotaznik.NahrajZmensenyObrazekSad();
            }

            if (btnName.Name != "btn_angry")
            {
                btn_angry.Image = dotaznik.NahrajZmensenyObrazekAngry();
            }
        }


        private void btn_wink_Click(object sender, EventArgs e)
        {
            ZmensiObrazek(btn_wink);
            btn_wink.Image = Properties.Resources.wink;
            smajlikText = "Můj život je skvělý";
            
        }

        private void btn_smile_Click(object sender, EventArgs e)
        {
            ZmensiObrazek(btn_smile);
            btn_smile.Image = Properties.Resources.smile;
            smajlikText = "Mám se fajn";
        }

        private void btn_neutral_Click(object sender, EventArgs e)
        {
            ZmensiObrazek(btn_neutral);
            btn_neutral.Image = Properties.Resources.neutral;
            smajlikText = "Nějak bylo, nějak bude";
        }

        private void btn_sad_Click(object sender, EventArgs e)
        {
            ZmensiObrazek(btn_sad);
            btn_sad.Image = Properties.Resources.sad;
            smajlikText = "Bylo to i lepší";
        }

        private void btn_angry_Click(object sender, EventArgs e)
        {
            ZmensiObrazek(btn_angry);
            btn_angry.Image = Properties.Resources.anger;
            smajlikText = "Jdu chcípnout do křoví";
        }

        private void btn_odeslatCil_Click(object sender, EventArgs e)
        {
            
            souborCilu.Add(txtbox_cile.Text);
            checkedListBox_splneneCile.Items.Clear();

            for (int i = 0; i < souborCilu.Count; i++)
            {
                checkedListBox_splneneCile.Items.Add(souborCilu[i]);
            }

            txtbox_cile.Text = "";
           
        }

        private void btn_ulozit_Click(object sender, EventArgs e)
        {

            StreamWriter txtSouborCilu = new StreamWriter(@"C:\Users\marti\source\repos\Projekt Hackathon\Projekt Hackathon\Resources\txtSouborCilu.txt", false);

            for (int i = 0; i < souborCilu.Count; i++)
            {
                if (checkedListBox_splneneCile.GetItemCheckState(i) == CheckState.Unchecked)
                {
                    txtSouborCilu.WriteLine(souborCilu[i]);
                }

                else
                {
                    splneneCile.Add(souborCilu[i]);
                }
            }

            txtSouborCilu.Close();

            StreamWriter report = new StreamWriter(@"C:\Users\marti\source\repos\Projekt Hackathon\Projekt Hackathon\Resources\Report.txt", true);
            report.WriteLine(DateTime.Now);
            report.WriteLine("Jak se mám: " + smajlikText);
            report.WriteLine("Moje organizace času je: " + organizaceCasuText);
            report.WriteLine("Na své organizaci času bych chtěl vylepšit: " + textBox_vylepseniOrganizaceCasu.Text);
            report.WriteLine("Mám v plánu: ");
            for (int i = 0; i < souborCilu.Count; i++)
            {
                report.WriteLine(souborCilu[i]);
            }
            report.WriteLine("Z toho jsem splnil: ");
            for (int i = 0; i < splneneCile.Count; i++)
            {
                report.WriteLine(splneneCile[i]);
            }
            report.WriteLine("Moje priority jsou: " + textBox_priority.Text);
            report.WriteLine("Mojí oporou je: " + textBox_opora.Text);
            report.WriteLine("*********************************************************************** \n");
            report.Close();

            System.Windows.Forms.Application.Exit();

        }

        private void rbtn_odpovedi_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton; 
            organizaceCasuText = radioButton.Text;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
    }
