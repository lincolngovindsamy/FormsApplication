using System;
using System.Collections.Generic;
using System.Text;

namespace App10.Models
{
    public class UsersResponse
    {
        public int code { get; set; }
        public List<Users> data { get; set; }
    }
}
