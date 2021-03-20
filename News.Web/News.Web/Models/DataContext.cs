using News.Web.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace News.Web.Models
{
    public class DataContext:DbContext
    {
        public DbSet<NewsEntity> NewsCollection { get; set; }

        public DbSet<NewsCategoryEntity> NewsCategoryCollection { get; set; }
        public DataContext() : base("baseConnection")
        {

        }

    }
}