using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI7Q84_HFT_2023241.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }


        [NotMapped]
        public virtual ICollection<Song> Songs { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public Author()
        {
            Songs = new HashSet<Song>();
            Albums = new HashSet<Album>();
        }


    }
}
