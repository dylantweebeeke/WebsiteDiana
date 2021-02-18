using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteMama.Models
{
    public class BlogEntry
    {
        [Key]
        public int ID { get; set; }
        public String Title { get; set; }
        public String Inhoud { get; set; }
        public DateTime Date { get; set; }

        public void SetCurrentDate() 
        {
            this.Date = DateTime.Now;
        }
    }
}
