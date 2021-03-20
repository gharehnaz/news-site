using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace News.Web.Models.Entities
{
    public class NewsEntity:BaseContent
    {
        public string Author { get; set; }

        [ForeignKey("NewsCategory_Id")]
        public virtual NewsCategoryEntity NewsCategory { get; set; }


        public long NewsCategory_Id { get; set; }
    }
}