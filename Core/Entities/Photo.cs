using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Photo : BaseEntity
    {
        public string PictureUrl { get; set; }
        public string FileName { get; set; }
        public bool IsMain { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
