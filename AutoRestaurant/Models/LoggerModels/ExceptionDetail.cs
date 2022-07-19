using AutoRestaurant.Models.BaseModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace AutoRestaurant.Models
{
    public class ExceptionDetail : BaseEntity
    {
        [Required]
        public string Message { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public string StackTrace { get; set; }
        [Required]
        public string TargetSite { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public ExceptionDetail(Exception ex)
        {
            this.Message = ex.Message;
            this.Source = ex.Source;
            this.StackTrace = ex.StackTrace;
            this.TargetSite = ex.TargetSite.Name;
            this.Date = DateTime.Now;
        }
    }
}
