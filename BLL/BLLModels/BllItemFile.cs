﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLLModels
{
    public class BllItemFile
    {
        public int Id { get; set; }
        public string Filename { get; set; }

        public byte[] File { get; set; }

        public int BllItemId { get; set; }
    }
}
