using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using JWTAuth.Data.Entities;
using JWTAuth.Model;
namespace JWTAuth.Mapper
{
    public static class BookMapper
    {
        public static BookDTO MapToDTO(Book bok)
        {
            return new BookDTO
            {
                Id = bok.Id,
                Title =  bok.Title,              
                Description = bok.Description,
                PublishDateUtc = bok.PublishDateUtc
            };
        }
    }
}
