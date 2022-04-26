﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaDia.Areas.Contatos.Models
{
    public class Contato
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(30, ErrorMessage = "Nome deve ter no max. 30 caracteres!")]
        [MinLength(3, ErrorMessage = "Nome deve ter no min. 3 caracteres!")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [RegularExpression(@"^[1-9]{1}[0-9]{1}\s?([9][0-9]{4}|[1-8]{1}[0-9]{3})\-?[0-9]{4}$",
            ErrorMessage = "Número inválido")]
        public string? Telefone { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório!")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }

        public DateTime DataModificacao { get; set; }

        public string? FotoUrl { get; set; }
        [NotMapped]
        public IFormFile Foto { get; set; }
    }
}
