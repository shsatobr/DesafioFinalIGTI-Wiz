﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFinalIGTIWiz.Services.Auth.Jwt
{
    public class JwtAuthModelo
    {
        public string TokenAcesso { get; set; }
        public string Tokentype { get; set; }           // Bearer
        public int ExpiraEm { get; set; }
    }
}
