using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Queries.GetAllProducts;
using Application.Features.Projects.Commands.CreateProject;
using Application.Features.Projects.Queries.GetAllProjects;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();

            CreateMap<Project, GetAllProjectsViewModel>().ReverseMap();
            CreateMap<CreateProjectCommand, Project>();
            CreateMap<GetAllProjectsQuery, GetAllProjectsParameter>();
        }
    }
}
