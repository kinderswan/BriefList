﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLLModels
{
    public class BllSubItem
    {
        public int ID { get; set; }
        public string  Title { get; set; }
        public bool Completed { get; set; } 
        public int BllItemId { get; set; }
    }
}
