﻿using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models.ViewModels
{
    public class DutyViewModel
    {
        public Guid DutyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(7);

        [EnumDataType(typeof(DutyStatus))]
        public DutyStatus DutyStatus { get; set; }
    }
}
