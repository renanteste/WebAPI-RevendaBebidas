namespace WebAPI_RevendaBebidas.Models
{
    public class RevendaModel
    {
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public List<TelefoneModel> Telefones { get; set; } = new List<TelefoneModel>();
        public List<EnderecoModel> Enderecos { get; set; } = new List<EnderecoModel>();
    }
}
