﻿namespace DAL.Interfaces.DALModels
{
    public class DalSubItem
    {
        public int Id { get; set; }
        public string  Title { get; set; }
        public bool Completed { get; set; }
        public int DalItemId { get; set; }
    }
}
