using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPhotoService
    {
        Task<Photo> SaveToDiskAsync(IFormFile photo);
        void DeleteFromDisk(Photo photo);
    }
}
