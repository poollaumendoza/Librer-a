﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Entidades
{
    public class TipoMovimiento
    {
        public int IdTipoMovimiento { get; set; }
        public string NombreTipoMovimiento { get; set; }
        public Estado oEstado { get; set; }
    }
}