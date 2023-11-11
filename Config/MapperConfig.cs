using AutoMapper;
using basitsatinalimuyg.Dtos;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Models;
using System.Collections;

namespace basitsatinalimuyg.Config
{
    public class MapperConfig : Profile
    {

        public MapperConfig()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductDto, Product>();

            CreateMap<User, UserViewModel>();
            CreateMap<UserDto, User>();

            CreateMap<RegisterDto, User>();
            CreateMap<LoginDto, User>();

        }
    }

    public static class AutoMapperExtensions
    {
        public static ICollection<T> CastListObject<T, R>(this IMapper mapper, R list) where R : IEnumerable
        {
            var result = new List<T>();

            foreach (var item in list)
            {
                result.Add(mapper.Map<T>(item));
            }

            return result;

		}

}
}
