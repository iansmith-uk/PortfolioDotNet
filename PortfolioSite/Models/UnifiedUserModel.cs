using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioSite.Models
{
    public class UnifiedUserModel
    {

        public InfoModel InfoModel { get; set; }

        public ICollection<PortfolioModel> PortfolioModels { get; set; }
    }
}
