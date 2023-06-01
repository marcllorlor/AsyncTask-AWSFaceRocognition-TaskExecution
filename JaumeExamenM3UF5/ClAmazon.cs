using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Rekognition.Model;
using Amazon.Rekognition;
using Newtonsoft.Json;
using System.Windows;
using System.Windows.Forms;


namespace JaumeExamenM3UF5
{
    internal class ClAmazon
    {
        //Aqui declarem les claus del aws
        string awsKey = "INSERT KEY";
        string awsSecret = "INSERT SECRET KEY";
        string awsToken = "INSERT AWS TOKEN";


        RecognizeCelebritiesResponse respostaReconeixementCelebritats = null;







        //Aqui farem el constructor per saber les emocions que tenim
        public ClAmazon(Bitmap bmp)
        {
            //Aqui cridarem les dos funcions que farem servir per detectar el text i les emocions
            //A les dos els hi pasarem el bmp (És la imatge de la camara en forma de bitmap) i la seva paraula i emocio corresponent
            //detectartextos(bmp, paraulaaleatoriatriada);
            detectaremocions(bmp);

        }



        private void detectaremocions(Bitmap bmp)
        {
            try
            {
                //Declarem el convertor de imatges
                ImageConverter convertidor = new ImageConverter();
                //Declarem la imatge en bytes que tindra el valor del bitmap que ha capturat quan la camara ha apretat a fer la foto
                Byte[] imatgeEnBytes = (Byte[])convertidor.ConvertTo(bmp, typeof(byte[]));

                
                Amazon.Rekognition.Model.Image imatgeAWS = new Amazon.Rekognition.Model.Image();
                //Estem declarant el client de amazon amb les nostres credencials
                AmazonRekognitionClient clientAWSRekognition = new AmazonRekognitionClient(awsKey, awsSecret, awsToken, Amazon.RegionEndpoint.USEast1);
                RecognizeCelebritiesRequest peticioReconeixementCelebritats = new RecognizeCelebritiesRequest();

                
                CelebrityRecognition celebritatsDetectades = new CelebrityRecognition();
                imatgeAWS.Bytes = new MemoryStream(imatgeEnBytes);
                peticioReconeixementCelebritats.Image = imatgeAWS;
                respostaReconeixementCelebritats = clientAWSRekognition.RecognizeCelebrities(peticioReconeixementCelebritats);

                //Per cada cara que detecti a dins de la imatge fara una volta al bucle: 2 cara, 2 cops fara el bucle
                



            }
            catch (Exception excp)
            {
                //Si hi ha un error amb amazon, ens ho dira aqui. Aqui es a on cau quan les claus del Amazon estan outdateades o no son valides
                //MessageBox.Show(excp.Message);
            }
        }

        public RecognizeCelebritiesResponse retornaremociotrobades()
        {
            return respostaReconeixementCelebritats;
        }
    }
}
