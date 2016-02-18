﻿using System;

namespace BLL.Interfaces.BLLModels
{
    public class BllItem
    {
        public int Id { get; set; }
        public bool Completed { get; set; }
        public bool Starred { get; set; }
        public string Title { get; set; }
        public DateTime? TimeComplete { get; set; }
        public int BllListId { get; set; }      
    }
}
