﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vehiculos.API.Data.Entities
{
    public class VehiculosType
    {
        public int Id { get; set; }
        [Display(Name = "tipo de vehiculo")]
        [MaxLength(50, ErrorMessage ="El campo {0} no puede tener más de {1} carácteres.")]
        [Required (ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; }

    }
}
