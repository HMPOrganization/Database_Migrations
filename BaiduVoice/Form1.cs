using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Web;
using System.Net;



namespace BaiduVoice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 设置APPID/AK/SK
            var APP_ID = "15206499";
            var API_KEY = "qLq1FHkCUdGGoKRaabFuNCh7";
            var SECRET_KEY = "246GQ7qzIzTZu7XBxy8iVikARvIIYzuN ";

            var client = new Baidu.Aip.Speech.Asr(APP_ID, API_KEY,SECRET_KEY)
            {
                Timeout = 60000  // 修改超时时间
            };

            var data = File.ReadAllBytes("D:\\旧桌面\\Desktop\\hello.wav");
            client.Timeout = 120000; // 若语音较长，建议设置更大的超时时间. ms
            var result = client.Recognize(data, "wav", 16000);
            Console.Write(result);


        }

        private void button2_Click(object sender, EventArgs e)
        {
   

         


            SoundPlayer sound = new SoundPlayer("https://tsn.baidu.com/text2audio?tex="+ System.Web.HttpUtility.UrlEncode(this.textBox1.Text) +"&tok=24.69787ffe25aeb80f0b3ad0cace446672.2592000.1547785526.282335-15206499&cuid=ct&ctp=1&lan=zh&spd=5&pit=5&vol=5&per=0&aue=6");
            sound.Play();
        }


      
        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = System.Web.HttpUtility.UrlEncode(this.textBox1.Text);

            
         

        }

        private void button4_Click(object sender, EventArgs e)
        {
          //spd 选填  语速，取值0 - 15，默认为5中语速
          //pit 选填 音调，取值0 - 15，默认为5中语调
          //vol 选填 音量，取值0 - 15，默认为5中音量
          //per 选填 发音人选择, 0为普通女声，1为普通男生，3为情感合成 - 度逍遥，4为情感合成 - 度丫丫，默认为普通女声
          //aue 选填  3为mp3格式(默认)； 4为pcm - 16k；5为pcm - 8k；6为wav（内容同pcm - 16k）; 注意aue = 4或者6是语音识别要求的格式，但是音频内容不是语音识别要求的自然人发音，所以识别效果会受影响。
            var option = new Dictionary<string, object>()
                {
                    {"spd", 5}, // 语速
                    {"vol", 7}, // 音量
                    {"per", 4},  // 发音人，4：情感度丫丫童声
                    {"aue",6 }
                };

            var _ttsClient = new Baidu.Aip.Speech.Tts("qLq1FHkCUdGGoKRaabFuNCh7", "246GQ7qzIzTZu7XBxy8iVikARvIIYzuN ");

             var result = _ttsClient.Synthesis(this.textBox1.Text, option);

            if (result.ErrorCode == 0)  // 或 result.Success
            {
                File.WriteAllBytes("d:\\1.wav", result.Data);
            }

            Stream stream = new MemoryStream(result.Data);

            SoundPlayer sound = new SoundPlayer(stream);
            sound.Play();


        }
    }
}
