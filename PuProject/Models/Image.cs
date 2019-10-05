using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TServices.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Title { get; set; }
        public byte[] Image1 { get; set; }

    }
}