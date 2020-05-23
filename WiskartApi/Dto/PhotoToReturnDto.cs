using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WiskartApi.Dto
{
    public class PhotoToReturnDto
    {
        public int Id { get; set; }
        public string PictureUrl { get; set; }
        public string FileName { get; set; }
        public bool IsMain { get; set; }
    }
}
