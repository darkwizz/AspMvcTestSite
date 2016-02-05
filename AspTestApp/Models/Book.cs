using System;
using System.ComponentModel.DataAnnotations;

namespace AspTestApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int PageCount { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReceivingDate { get; set; }
        [Required]
        public string Author { get; set; }
    }
}
