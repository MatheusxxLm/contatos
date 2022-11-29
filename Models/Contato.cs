using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Contatos.Models
{
    public class Contato 
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }

    }
}
