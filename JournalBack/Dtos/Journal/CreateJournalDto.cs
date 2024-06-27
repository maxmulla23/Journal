using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JournalBack.Dtos.Journal
{
    public class CreateJournalDto
    {
        [Required]
        public string Title { get; set;} = string.Empty;
        [Required]
        public string Content { get; set;} = string.Empty;

    }
}