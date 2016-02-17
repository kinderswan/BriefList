using System;

namespace BLL.Interfaces.BLLModels
{
    public class BllUserProfile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public byte[] Photo { get; set; }

        public DateTime TimeRegister { get; set; }


    }
}
