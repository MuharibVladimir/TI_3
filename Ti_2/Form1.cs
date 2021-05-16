using System;
using System.Numerics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ti_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }

        private RSA _rsa;

        private void GenerateSignature(object sender, EventArgs e)
        {
            _rsa = new RSA();

            textBoxP.Text = _rsa.p.ToString();
            textBoxQ.Text = _rsa.q.ToString();
            textBoxR.Text = _rsa.r.ToString();
            textBoxKo.Text = _rsa.e.ToString();
            textBoxKs.Text = _rsa.d.ToString();

            var hash = DigitalSignature.GetHash(textBoxInput.Text, 1019, 1901, 100);
            var signature = BigInteger.ModPow(hash, _rsa.d, _rsa.r);

            textBoxOutput.Text = signature.ToString();
        }

        private void Verify(object sender, EventArgs e)
        {
            var hash = DigitalSignature.GetHash(textBoxInput.Text, 1019, 1901, 100);
            BigInteger numberE = Convert.ToInt64(textBoxKo.Text);
            BigInteger numberR = Convert.ToInt64(textBoxR.Text);
            BigInteger signature = Convert.ToInt64(textBoxOutput.Text);
            var result = BigInteger.ModPow(signature, numberE, numberR);

            if (result == hash)
            {
                textBoxDS.Text = "ЭЦП подлинная!";
            }
            else
            {
                textBoxDS.Text = string.Format(
                    "Ошибка! ЭЦП не является подлинной.\n" +
                    "Первичный хэш-образ: {0};\n" +
                    "Полученный хэш-образ: {1}.", hash, result);
            }
        }

        public long GetSecretNumberP()
        {
            return Convert.ToInt64(textBoxP.Text);
        }

        public long GetSecretNumberQ()
        {
            return Convert.ToInt64(textBoxQ.Text);
        }

        public long GetSecretNumberD()
        {
            return Convert.ToInt64(textBoxKs.Text);
        }

        public long GetNumberE()
        {
            return Convert.ToInt64(textBoxKo.Text);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Verify(sender, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void BtnEncr_Click(object sender, EventArgs e)
        {
            GenerateSignature(sender, e);
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
