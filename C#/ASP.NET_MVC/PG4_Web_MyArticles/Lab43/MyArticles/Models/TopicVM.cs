using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyArticles.Models
{
    public class TopicVM
    {
        public IEnumerable<Topic> Topics { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}