using System;
using System.Windows.Forms;

namespace ConsultarCEP
{
    public partial class FrmConsultarCEPs : Form
    {
        public FrmConsultarCEPs()
        {
            InitializeComponent();
        }
        //connected service: https://apps.correios.com.br/SigepMasterJPA/AtendeClienteService/AtendeCliente?wsdl 
        private async void BtnConsultar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCEP.Text))
            {
                using var ws = new WsCorreios.AtendeClienteClient();
                try
                {
                    var endereco = await ws.consultaCEPAsync(txtCEP.Text.Trim());
                    txtUF.Text = endereco.@return.uf;
                    txtCidade.Text = endereco.@return.cidade;
                    txtBairro.Text = endereco.@return.bairro;
                    txtRua.Text = endereco.@return.end;
                    txtComplemento.Text = endereco.@return.complemento2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Informe um CEP válido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            txtCEP.Text = string.Empty;
            txtUF.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtRua.Text = string.Empty;
            txtComplemento.Text = string.Empty;
        }
    }
}
