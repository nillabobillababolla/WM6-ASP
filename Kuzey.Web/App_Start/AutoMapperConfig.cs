using System;
using AutoMapper;
using Kuzey.Models.Entities;
using Kuzey.Models.ViewModels;

namespace Kuzey.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                CategoryMapping(cfg);
                ProductMapping(cfg);
                EmployeeMapping(cfg);
            });
        }

        private static void EmployeeMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Employee, EmployeeViewModel>().ReverseMap();
        }

        private static void ProductMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(x => x.Category.CategoryName))
                .ReverseMap();
        }

        private static void CategoryMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Category, CategoryViewModel>()
                .ForMember(dest => dest.ProductCount, opt => opt.MapFrom(x => x.Products.Count))
                .ReverseMap();
        }
    }
}