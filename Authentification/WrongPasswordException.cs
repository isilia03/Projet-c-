﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Authentification
{
    class WrongPasswordException : AuthentificationException
    {
        public WrongPasswordException(string mgs) : base(mgs)
        {

        }
    }
}
