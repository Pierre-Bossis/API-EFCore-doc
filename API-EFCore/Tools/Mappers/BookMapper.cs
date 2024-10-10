using API_EFCore.DAL.Entities;
using API_EFCore.Models;

namespace API_EFCore.Tools.Mappers
{
    public static class BookMapper
    {
        public static BookDTO ToDto(this BookEntity entity)
        {
            if(entity is not null)
            {
                return new BookDTO
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Author = entity.Author,
                    Description = entity.Description,
                    ReleaseDate = entity.ReleaseDate
                };
            }
            return null;
        }
    }
}
