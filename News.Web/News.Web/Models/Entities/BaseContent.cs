using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Web.Models.Entities
{
    public class BaseContent
    {
        public long Id { get; set; }

        public string Title { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        public string PictureUrl { get; set; }

        public DateTime CreateDate { get; set; }

        public BaseContent()
        {
            CreateDate = DateTime.Now;
        }
    }
}