using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;



namespace Voice_Recognition
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            btnDisable.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Choices commands = new Choices();
            commands.Add(new string[] { "recibidos", "enviados", "redactar", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "contactos", "eliminar", "enviar" });
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);
            recEngine.LoadGrammarAsync(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += recEngine_SpeechRecognized;

        }

        void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "recibidos":
                    txtTexto.Text = txtTexto.Text + "RECIBIDOS ";
                    break;
                case "enviados":
                    txtTexto.Text = txtTexto.Text + "ENVIADOS ";
                    break;
                case "redactar":
                    txtTexto.Text = txtTexto.Text + "REDACTAR ";
                    break;
                case "uno":
                    txtTexto.Text = txtTexto.Text + "1 ";
                    break;
                case "dos":
                    txtTexto.Text = txtTexto.Text + "2 ";
                    break;
                case "tres":
                    txtTexto.Text = txtTexto.Text + "3 ";
                    break;
                case "cuatro":
                    txtTexto.Text = txtTexto.Text + "4 ";
                    break;
                case "cinco":
                    txtTexto.Text = txtTexto.Text + "5 ";
                    break;
                case "seis":
                    txtTexto.Text = txtTexto.Text + "6 ";
                    break;
                case "siete":
                    txtTexto.Text = txtTexto.Text + "7 ";
                    break;
                case "ocho":
                    txtTexto.Text = txtTexto.Text + "8 ";
                    break;
                case "nueve":
                    txtTexto.Text = txtTexto.Text + "9 ";
                    break;
                case "contactos":
                    txtTexto.Text = txtTexto.Text + "CONTACTOS ";
                    break;
                case "eliminar":
                    txtTexto.Text = txtTexto.Text + "ELIMINAR ";
                    break;
                case "enviar":
                    txtTexto.Text = txtTexto.Text + "ENVIAR ";
                    break;
            }
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsyncStop();
            btnDisable.Enabled = false;
        }
    }
}
