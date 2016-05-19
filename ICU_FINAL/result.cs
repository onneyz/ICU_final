using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MaterialSkin.Controls;


namespace ICU_FINAL
{

    
    public partial class result : MaterialForm
    {
        public result()
        {
            InitializeComponent();
            Thread thread = new Thread(carve);
            thread.Start();
            //carve();
            //BackgroundWorker bg = new BackgroundWorker();
            //bg.DoWork += new DoWorkEventHandler(doCarve);
            //bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(carveCompleted);

            //bg.RunWorkerAsync();

            //Show.this

            //sep sepThread = new sep();
            //Thread cThread = new Thread(() => sepThread.carve(filelistBox));
            //cThread.Start();
            //Console.WriteLine("--------------th start-----------");
            //while (!cThread.IsAlive)
            //    Thread.Sleep(1000);
            //Console.WriteLine("--------------th stop-----------");
            //cThread.Abort();
            //cThread.Join();
            //Console.WriteLine("--------------JOIN-----------");
        }
         public void carve()
        {
            Carve carve = new Carve();
            carve.searchHF(main.SelectedHDD, filelistBox,this,progressBar);

        }
         private void doCarve(object sender, DoWorkEventArgs e)
         {
             carve();
         }
         private void carveCompleted(object sender, RunWorkerCompletedEventHandler e)
         {
             Console.WriteLine("hihi");
         }
        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search form = new search();
            this.Hide();
            form.Show();
        }

        private void result_Load(object sender, EventArgs e)
        {
            Console.WriteLine("form load");
            //carve();
        }

        //public class sep
        //{
        //    public void carve(ListBox filelistBox)
        //    {
        //        Carve carve = new Carve();
        //        carve.searchHF(main.SelectedHDD, filelistBox);

        //    }

        //}


    }
}
