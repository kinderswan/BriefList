﻿namespace Epam.BriefList.WebUI.Models.ApiModels
{
    public class ApiSubItem
    {
        public int Id { get; set; }
        public string  Title { get; set; }
        public bool Completed { get; set; } 
        public int BllItemId { get; set; }
    }
}