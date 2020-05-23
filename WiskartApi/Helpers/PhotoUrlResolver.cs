using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiskartApi.Dto;

namespace WiskartApi.Helpers
{
    public class PhotoUrlResolver : IValueResolver<Photo, PhotoToReturnDto, string>
    {
        private readonly IConfiguration _config;

        public PhotoUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Photo source, PhotoToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}
