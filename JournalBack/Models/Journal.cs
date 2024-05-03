using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JournalBack.Models
{
    public class Journal 
    {
        [Key]
        public int Id { get; set;}
        public string? Title { get; set;}
        public string? Content { get; set;}
        public DateTime Date {get; set; } = DateTime.Now;
        [ForeignKey("User")]
        [MaxLength(450)]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}