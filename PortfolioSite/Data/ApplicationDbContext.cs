using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortfolioSite.Models;

namespace PortfolioSite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public readonly IHttpContextAccessor _httpContextAccessor;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<InfoModel> InfoModels { get; set; }
        public DbSet<PortfolioModel> PortfolioModels { get; set; }
    }
}
