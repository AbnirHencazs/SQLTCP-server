﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testApp
{
    public class PIC
    {
        public string DireccionIP { get; set; }
        public bool IsConnected { get; set; } = false; //Estado Conexión false por Default
        public bool Ping { get; set; }
    }
}
