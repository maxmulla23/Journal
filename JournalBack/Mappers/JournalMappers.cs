using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JournalBack.Dtos.Journal;
using JournalBack.Models;

namespace JournalBack.Mappers
{
    public static class JournalMappers
    {
        public static JournalDto ToJournalDto(this Journal journal)
        {
            return new JournalDto
            {
                Id = journal.Id,
                Title = journal.Title,
                Content = journal.Content,
                Date = journal.Date,
            };
        }

        public static Journal ToJournalFromCreate(this CreateJournalDto journalDto)
        {
            return new Journal
            {
                Title = journalDto.Title,
                Content = journalDto.Content
            };
        }

        public static Journal ToJournalFromUpdate(this UpdateJournalDto journalDto)
        {
            return new Journal{
                Title = journalDto.Title,
                Content = journalDto.Content,
            };
        }
    }
}