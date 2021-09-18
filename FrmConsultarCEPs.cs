using ConsultarCEP.Service;
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
        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCEP.Text))
            {
                Endereco endereco = new();
                endereco.ConsultaCEP(txtCEP.Text);
                txtUF.Text = endereco.Estado;
                txtCidade.Text = endereco.Municipio;
                txtBairro.Text = endereco.Bairro;
                txtRua.Text = endereco.Rua;
                txtComplemento.Text = endereco.Complemento;
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
