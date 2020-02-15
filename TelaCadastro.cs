using AudioVisual.br.com.imepac.utils;
using Json.Net;
using PointBarber.br.com.imepac.entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace PointBarber
{
    public partial class TelaCadastro : Form
    {
        public TelaCadastro()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (nome.Text == "")
            {
                MessageBox.Show("O campo 'Descrição' é obrigatório e não pode ficar vazio.", "Alerta do sistema", MessageBoxButtons.OK);
            }
            else
            {
                Cliente cliente = new Cliente();
                cliente.nome = nome.Text;
                cliente.cpf = cpf.Text;
                cliente.rg = rg.Text;
                cliente.nascimento = nascimento.Value.Date;

                nascimento.CustomFormat = "dd/MM/yyyy";
                Console.WriteLine(nascimento.Value);
                //int selectedIndex = plano.SelectedIndex;
                int selectedValue = (int)plano.SelectedValue;

                cliente.plano = selectedValue;
                cliente.valor = preco.Text;
                Console.WriteLine(selectedValue);
                string DATA = JsonNet.Serialize(cliente);

                string URL = "http://localhost:21529/PointBarber/clientes";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.ContentLength = DATA.Length;

                try
                {
                    using (Stream webStream = request.GetRequestStream())
                    using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
                    {
                        requestWriter.Write(DATA);
                    }
                    WebResponse webResponse = request.GetResponse();
                    HttpStatusCode response_code = ((HttpWebResponse)webResponse).StatusCode;

                    if (response_code == HttpStatusCode.Created)
                    {
                        nome.Text = preco.Text = "";
                        if (MessageBox.Show("Registro salvo com sucesso!" + Environment.NewLine + "Gostaria de cadastrar outra barbearia?", "Alerta do sistema", MessageBoxButtons.YesNo) == DialogResult.Yes )
                        {
                            TelaCadastro telaCadastrar = new TelaCadastro();
                            telaCadastrar.MdiParent = this;
                            telaCadastrar.Show();
                        }
                    }
                    else
                    {
                        Stream webStream = webResponse.GetResponseStream();
                        StreamReader responseReader = new StreamReader(webStream);

                        string response = responseReader.ReadToEnd();
                        MessageBox.Show("Erro no servidor:", "Alerta do sistema", MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro no lado do servidor." , "Alerta do sistema", MessageBoxButtons.OK);
                }
            }

        }

        private void TelaCadastro_Load(object sender, EventArgs e)
        {
            plano.DataSource = new BindingSource(EnumPlano.Itens, null);
            plano.DisplayMember = "Value";
            plano.ValueMember = "Key";
        }
    }
}
