﻿using System;
using System.Collections.Generic;

namespace DAL.Interfaces.DALModels
{
    public partial class DalUserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Photo { get; set; }
        public DateTime TimeRegister { get; set; }
    }
}
