using System.Drawing;
using System.Threading;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace DataParallelismWithForEach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // New window-level variable
        private CancellationTokenSource cancelToken = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            cancelToken.Cancel();
        }

        private void cmdProcess_Click(object sender, EventArgs e)
        {
            //ProcessFiles();
            Task.Factory.StartNew(() => ProcessFiles());
        }


        private void ProcessFiles()
        {
            cancelToken = new CancellationTokenSource();
            ParallelOptions parOpts = new ParallelOptions();
            parOpts.CancellationToken = cancelToken.Token;
            parOpts.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

            // Load up all JPGs and make a new folder for the modifed data
            string[] files = Directory.GetFiles(@".\TestPictures", "*.jpg", SearchOption.AllDirectories);
            string newDir = @".\ModifiedPictures";
            Directory.CreateDirectory(newDir);

            // Process the image data in a blocking manner
            // FOREACH would process the files synchronously in a single thread
            //            foreach (string currentFile in files)

            // PARALLEL.FOREACH will parallelise the operation across all CPUs

            try
            {
                Parallel.ForEach(files, parOpts, currentFile =>
               {
                   parOpts.CancellationToken.ThrowIfCancellationRequested();

                   string filename = Path.GetFileName(currentFile);
                   using (Bitmap bitmap = new Bitmap(currentFile))
                   {
                       bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                       bitmap.Save(Path.Combine(newDir, filename));

                       // Print out the Id of the thread processing the current image

                       // ONLY WORKS WHEN RUNNING ON THE PRIMARY THREAD (THE SAMER THREAD AS THE WPF CONTROLS
                       //this.Title = $"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}";

                       // WHEN RUNNING UNDER SECONDARY THREADS, USE THE BELOW
                       this.Dispatcher.Invoke((Action)delegate
                           {
                               this.Title = $"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId} and is background? {Thread.CurrentThread.IsBackground}";
                           });
                   }
               });
                this.Dispatcher.Invoke((Action)delegate
               {
                   this.Title = "Done!";
               });
            }
            catch (OperationCanceledException ex)
            {
                this.Dispatcher.Invoke((Action)delegate
                {
                    this.Title = ex.Message;
                });
            }
        }
    }
}
