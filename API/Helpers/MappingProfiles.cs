using API.Core.DbModels;
using API.Dtos;
using AutoMapper;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Productı gördüğünde ProductToolReturnDto çevir demek
            CreateMap<Product, ProductToolReturnDto>()
                .ForMember(x => x.ProductBrand, O => O.MapFrom(s => s.ProductBrand.Name))
            .ForMember(x => x.ProductType, O => O.MapFrom(s => s.ProductType.Name))
             .ForMember(x => x.PictureUrl, O => O.MapFrom<ProductUrlResolver>());
        }
    }
}
