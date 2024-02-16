using System.Reflection;

namespace REFLEXE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ZkusZavolatNaPrvku("Nakrm");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ZkusZavolatNaPrvku("VypniZapni");
           
        }
        private void ZkusZavolatNaPrvku(string metoda)
        {
            foreach (Control prvek in flowLayoutPanel1.Controls)
            {
                //if(prvek is Tucnak)
                //{
                //    ((Tucnak)prvek).Nakrm();
                //}
                PropertyInfo[] promenne = prvek.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
                string text = "";
                foreach (PropertyInfo promenna in promenne)
                {
                    text += promenna.Name + "\n";
                }
                MethodInfo metodaNakrm = prvek.GetType().GetMethod(metoda,BindingFlags.NonPublic | BindingFlags.Instance);
                if (metodaNakrm != null)
                {
                    metodaNakrm.Invoke(prvek, null);
                }

            }
        }
    }
}