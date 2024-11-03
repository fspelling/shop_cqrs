using AutoMapper;
using Poc.ShopCqrs.Application.Customer.Commands.Requests;
using Poc.ShopCqrs.Application.Customer.Queries.Responses;
using Poc.ShopCqrs.Application.Customer.ViewModel;

namespace Poc.ShopCqrs.Application.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerViewModel, CreateCustomerCommandRequest>();
            CreateMap<FindCustomerByIdQueryResponse, CustomerViewModel>();
        }
    }
}
