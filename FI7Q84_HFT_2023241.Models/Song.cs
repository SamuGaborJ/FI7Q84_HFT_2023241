﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FI7Q84_HFT_2023241.Models
{
    public class Song
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public int ReleaseYear { get; set; }

        public int Length { get; set; }

        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Author Author { get; set; }

        public int AlbumId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Album Album { get; set; }
    }
}
