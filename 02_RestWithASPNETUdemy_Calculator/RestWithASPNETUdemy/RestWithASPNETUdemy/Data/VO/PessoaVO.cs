using System.Text.Json.Serialization;

namespace RestWithASPNETUdemy.Data.VO
{

    public class PessoaVO
    {
    //  [JsonPropertyName("code")]
        public int Id { get; set; }
        //[JsonPropertyName("name")]
        public string PrimeiroNome { get; set; }
        public string SobreNome { get; set; }
        //[JsonIgnore]
        public string Endereco { get; set; }
        //[JsonPropertyName("sex")]
        public string Genero { get; set; }
    }
}
