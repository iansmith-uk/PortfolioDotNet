using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioSite.Models
{
    public class PortfolioModel
    {

        [Key]
        public int id { get; set; }

        [Required]
        public string uID { get; set; }

        public byte[] image { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string testingURL { get; set; }

        public string codeURL { get; set; }
    }
}
