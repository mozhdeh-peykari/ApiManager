using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Common
{

    public class AppSettings
    {
        public JwtSettings JwtSettings { get; set; }
    }

    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public int ExpirationMinutes { get; set; }
    }
}
