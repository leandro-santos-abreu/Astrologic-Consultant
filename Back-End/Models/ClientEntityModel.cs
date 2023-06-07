using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace Back_End.Models
{
    public class ClientEntityModel
    {
        public ClientEntityModel()
        {
        }
        public int ClientId { get; set; }
        public string? Nome { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public DateTime? DataNascimento { get; set; }
        public void Update(ClientEntityModel atualizado)
        {
            Nome = atualizado.Nome;
            Login = atualizado.Login;
            Senha = atualizado.Senha;
        }
    }

}
