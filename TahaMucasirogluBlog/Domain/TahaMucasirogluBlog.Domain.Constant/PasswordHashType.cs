using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahaMucasirogluBlog.Domain.Constant
{
    public enum PasswordHashType
    {
        MD5_BASE64,
        MD5_HEX,
        SHA1_BASE64,
        SHA1_HEX,
        SHA256_BASE64,
        SHA256_HEX,
        SHA384_BASE64,
        SHA384_HEX,
        SHA512_BASE64,
        SHA512_HEX
    }
}
