﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahaMucasiroglu.Application.Managers.PasswordManager
{
    public interface IPasswordManager
    {
        public string GenerateSalt();
        public string HashPassword();
    }
}
