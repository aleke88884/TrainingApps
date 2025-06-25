using System;
using System.Collections.Generic;
using System.Text;

namespace AlbertSession2Mobile
{
    public class LoginResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int? userId { get; set; }
    }
}
