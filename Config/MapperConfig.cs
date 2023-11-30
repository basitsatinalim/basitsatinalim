using AutoMapper;
using basitsatinalimuyg.Constants;
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
            CreateMap<User, UserViewModel>();
            CreateMap<Address, AddressViewModel>();

            CreateMap<Product, ProductDto>()
                .ForMember(o => o.Amount, b => b.MapFrom(z => z.Price.Amount))
                .ForMember(o => o.Currency, b => b.MapFrom(z => z.Price.Currency));

            CreateMap<UserDto, User>();
            CreateMap<AddresDto, Address>();
            CreateMap<RegisterDto, User>();
            CreateMap<LoginDto, User>();
            CreateMap<ProductDto, Product>()
            .ForMember(o => o.Price, b => b.MapFrom(z => new Money(z.Amount, z.Currency)));

            CreateMap<CheckoutDto, Order>()
                .ForMember(o => o.Payment, b => b.MapFrom(z => new Payment(z.CardNumber, z.HolderName, z.ExpirationDate, z.Cvv)))
                .ForMember(o => o.Total, b => b.MapFrom(z => new Money(z.Total, CurrencyEnum.TRY)));

            CreateMap<User, User>();

            CreateMap<CartItem, OrderLineItem>()
                .ForMember(o => o.ProductId, b => b.MapFrom(z => z.ProductId))
                .ForMember(o => o.Count, b => b.MapFrom(z => z.Count))
                .ForMember(o => o.Price, b => b.MapFrom(z => new Money(z.Amount, CurrencyEnum.TRY)));


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
