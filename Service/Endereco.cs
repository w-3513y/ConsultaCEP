using System;
using System.Windows.Forms;

namespace ConsultarCEP.Service

{
    class Endereco
    {
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Complemento { get; set; }

        public async void ConsultaCEP(string cep)
        {
            using var ws = new WsCorreios.AtendeClienteClient();
            try
            {
                var endereco = await ws.consultaCEPAsync(cep.Trim());
                Estado = endereco.@return.uf;
                Municipio = endereco.@return.cidade;
                Bairro = endereco.@return.bairro;
                Rua = endereco.@return.end;
                Complemento = endereco.@return.complemento2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Consulta CEP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
