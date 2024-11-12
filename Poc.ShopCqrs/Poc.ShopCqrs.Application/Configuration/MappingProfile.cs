﻿using AutoMapper;
using Poc.ShopCqrs.Application.Customer.Commands;
using Poc.ShopCqrs.Application.Customer.Model.Views;
using Poc.ShopCqrs.Application.Customer.Queries.Responses;

namespace Poc.ShopCqrs.Application.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerViewModel, CreateCustomerCommand>();
            CreateMap<FindCustomerByIdQueryResponse, CustomerViewModel>();
        }
    }
}
