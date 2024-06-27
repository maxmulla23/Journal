using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalBack.Dtos.Journal
{
    public class JournalDto
    {
         public int Id { get; set;}
        public string Title { get; set;} = string.Empty;
        public string Content { get; set;} = string.Empty;
        public DateTime Date {get; set; } = DateTime.Now;
    
    }
}