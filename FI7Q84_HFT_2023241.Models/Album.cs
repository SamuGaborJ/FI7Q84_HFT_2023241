using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI7Q84_HFT_2023241.Models
{
    public class Album
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ReleaseYear { get; set; }

        public double AmountSold { get; set; }

        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
        [NotMapped]
        public virtual Author Author { get; set; }

        [NotMapped]
        public virtual ICollection<Song> Songs { get; set; }
        public Album()
        {
            Songs = new HashSet<Song>();
        }
    }
}
