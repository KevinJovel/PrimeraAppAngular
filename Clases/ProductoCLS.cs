﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp.Clases
{
    public class ProductoCLS
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        public string nombreCategoria { get; set; }
        public int idMarca { get; set; }
        public int idCategoria { get; set; }

    }
}
