using System.Collections.Generic;

namespace DotNetSurfer.Web.Models
{
    public class Header
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<SideNode> SideNodes { get; set; }

        public class SideNode
        {
            public int Id { get; set; }

            public string Title { get; set; }
        }
    }
}
