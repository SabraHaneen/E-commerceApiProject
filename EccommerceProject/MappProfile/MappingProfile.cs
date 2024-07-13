using AutoMapper;
using Eccommerce.Core.Entities;
using Eccommerce.Core.Entities.DTO;

namespace EccommerceProject.MappProfile
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Products,ProductDTO>( ).ForMember(To => To.Category_Name, from => from.MapFrom(x => x.Categories != null ? x.Categories.Name : null));
            CreateMap<Orders, OrdersDTO>().ForMember(To => To.Users_Name, from => from.MapFrom(x => x.Users != null ? x.Users.UserName : null));

        }
    }
}
