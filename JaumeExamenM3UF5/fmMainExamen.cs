using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

using System.Threading;

using AForge.Video;                 // hem instal·lat els paquets (Nuget) Aforge, Aforge.Video i Aforge.Video.DirectShow
using AForge.Video.DirectShow;

using QRCoder;          // hem instal·lat el paquet (NuGet) QR Coder de Raffael Herrmann
using ZXing;

using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;


using System.IO;
using System.Net.Http;
using System.Globalization;

//using System.Web.Script.Serialization;


namespace JaumeExamenM3UF5
{
    public partial class fmMainExamen : Form
    {
        FilterInfoCollection filtreCameres;
        VideoCaptureDevice kam = null; //Aqui declarem la camara i la posem en null per no ocupar res
        System.Drawing.Bitmap bmp = null;

        //Aqui es a on declarem la llista de musica
        List<ClMusica> llMusica = new List<ClMusica>();
        
        
        //Aqui es a on declarem el nom de la camara per treballar amb ella
        string nomcamara = null;

        //Aqui es a on declarem la classe i treballarem amb ella
        ClAmazon classeAmazon = null;

        //Aqui es on es declaren les cares trobades
        RecognizeCelebritiesResponse respostaReconeixementCelebritats = null;


        string[] cançons = new string[8] { "sweet child o mine guns n' roses", "happy pharrell williams", "you shook me all night long acdc", "boulevard of broken dreams green day", "the lazy song bruno mars lyrics", "not afraid eminem", "numb linkin park", "smells like teen spirit nirvana" };

        public fmMainExamen()
        {
            InitializeComponent();
        }

        private void fmMainExamen_Load(object sender, EventArgs e)
        {
            //Aqui fem el form en petit, encara que desde les propietats ja el tenim en petit
            this.WindowState = FormWindowState.Minimized;
            getCameres();
        }

        private void getCameres()
        {
            //Fem una array que ens mostrara totes les camares del ordinador
            filtreCameres = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            //Per cada camara que trobi, farem una volta al bucle
            foreach (FilterInfo p in filtreCameres)
            {
                //Si el nom de la camara ES DIFERENT a OBS Virtual Cam, entrara a dins del if
                if (p.Name != "OBS Virtual Camera")
                {
                    //Aqui el valor de nomcamara ha de ser una cosa generica com "HD Webcam" o alguna cosa aixi
                    nomcamara = (p.Name);
                }

            }
        }

        private void obrirCamara()
        {
            //Aquesta es la funcio que farem servir per obrir les camares
            kam = new VideoCaptureDevice(filtreCameres[0].MonikerString);
            kam.NewFrame += nouFotograma;
            kam.Start(); //Com que encara no tenim el programa acabat no executarem la camara fins que no vagi tot be
        }

        private void nouFotograma(object sender, NewFrameEventArgs eventArgs)
        {
            
            bmp = (Bitmap)(System.Drawing.Image)eventArgs.Frame.Clone();
            pbCameraWeb.Image = bmp;




        }

        private void activarCamaratoolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Aqui es a on activarem la camara web
            obrirCamara();
            this.WindowState = FormWindowState.Normal;
        }

        private void sortirtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Aqui es a on farem el close
            this.Close();
        }

        private void desactivarCamaratoolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Aqui es a on desactivarem la camara web
            if ((kam != null) && (kam.IsRunning))
            {
                this.WindowState = FormWindowState.Minimized;
                aturarcam();
            }
            
            
            
        }

        private void btnEnviarFoto_Click(object sender, EventArgs e)
        {
            //Aqui es a on farem el codi per enviar la foto
            funcioFerFoto();
            
            respostaReconeixementCelebritats = classeAmazon.retornaremociotrobades();
            carregarJson();
        }

        private void aturarcam()
        {
            //Com que no sabem si la camara esta oberta o no, farem un if per comprovar-ho
            if ((kam != null) && (kam.IsRunning))
            {
                //Si la camara esta encesa, la tancarem
                kam.Stop();
                //I declararem la KAM a null per no ocupar espai en ram
                kam = null;
            }
        }

        private void fmMainExamen_FormClosing(object sender, FormClosingEventArgs e)
        {
            aturarcam();
        }

        private void funcioFerFoto()
        {
            //Si la camara esta encesa farem la foto, si no no farem la foto
            if (kam.IsRunning)
            {
                //Aqui guardarem la imatge en bitmap
                bmp = (Bitmap)pbCameraWeb.Image.Clone();

                //Aqui donarem la classe
                classeAmazon = new ClAmazon(bmp);

            }

        }

        private async void carregarJson()
        {

            // deserialitzem des d'un fitxer
            StreamReader sR = new StreamReader("C:\\Users\\llorca\\Downloads\\ArxiusTXT\\musica.txt");
            using (JsonReader Reader = new JsonTextReader(sR))
            {
                JsonSerializer Serializer = new JsonSerializer();
                llMusica = Serializer.Deserialize<List<ClMusica>>(Reader);
            }

            
            foreach (ClMusica p in llMusica)
            {
                //Aqui hem de fer un bucle per cada emocio
                foreach (ComparedFace c in respostaReconeixementCelebritats.UnrecognizedFaces)
                {
                    //Per cada emocio que presenti la persona fara una volta al bucle
                    //Com que cada cara té minim i maxim 6 emocions, el bucle sempre fara 6 voltes
                    foreach (Emotion e in c.Emotions)
                    {
                        string valoremocio = p.tpc.ToString();
                        if(p.emotion.ToLower() == e.Type.Value.ToLower() && e.Confidence >= float.Parse(valoremocio, System.Globalization.CultureInfo.InvariantCulture))
                        {
                            Task consultamusica = ferconsulta(p.song);
                            //El await és perque esperi a que acabi la tasca per a continuar //Indirectament aixo es una funcio syncrona, fins que no s'acaba no continua
                            await consultamusica;
                            
                        }
                        
                    }
                }
            }

        }

        private async Task ferconsulta(string song)
        {
            string linkfinal = "https://youtube138.p.rapidapi.com/auto-complete/?q=" + song + "&hl=en&gl=US";
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(linkfinal),
                Headers =
                    {
                        { "X-RapidAPI-Key", "INSERT KEY" },
                        { "X-RapidAPI-Host", "youtube138.p.rapidapi.com" },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    ClCançons myDeserializedClass = JsonConvert.DeserializeObject<ClCançons>(body);
                    Int32 exemple = 0;
                switch (myDeserializedClass.results[0].ToString())
                {
                    case "happy phareell williams": Process.Start("https://www.youtube.com/watch?v=ZbZSe6N_BXs&ab_channel=PharrellWilliamsVEVO"); break;
                    case "you shook me all night long acdc": Process.Start("https://www.youtube.com/watch?v=Lo2qQmj0_h4&ab_channel=acdcVEVO");break;
                    case "boulevard of broken dreams green day": Process.Start("https://www.youtube.com/watch?v=Soa3gO7tL-c&ab_channel=GreenDay");break;
                    case "the lazy song bruno mars lyrics": Process.Start("https://www.youtube.com/watch?v=GYW87vbSxjg&ab_channel=VibeMusic");break;
                    case "not afraid eminem": Process.Start("https://www.youtube.com/watch?v=j5-yKhDd64s&ab_channel=EminemVEVO"); break;
                    case "numb linkin park": Process.Start("https://www.youtube.com/watch?v=kXYiU_JCYtU&ab_channel=LinkinPark"); break;
                    case "smells like teen spirit nirvana": Process.Start("https://www.youtube.com/watch?v=hTWKbfoikeg&ab_channel=NirvanaVEVO"); break;
                    case "sweet child o mine guns n' roses": Process.Start("https://www.youtube.com/watch?v=1w7OgIMMRc4&ab_channel=GunsNRosesVEVO"); break;
                    default: break; 
                }
            }
        }
    }
}
