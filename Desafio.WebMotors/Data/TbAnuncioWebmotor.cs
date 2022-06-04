using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Desafio.WebMotors.Data
{
    public partial class TbAnuncioWebmotor
    {
        [Display(Name = "id")]
        public int Id { get; set; }

        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [Display(Name = "Modelo")]
        public string Modelo { get; set; }

        [Display(Name = "Versao")]
        public string Versao { get; set; }

        [Display(Name = "Ano")]
        public int Ano { get; set; }

        [Display(Name = "Quilometragem")]
        public int Quilometragem { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; } = null!;
    }
}
