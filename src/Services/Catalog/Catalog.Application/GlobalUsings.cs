global using AutoMapper;
global using Catalog.Application.Behaviours;
global using Catalog.Application.Common;
global using Catalog.Application.Extensions;
global using Catalog.Application.Features.Catalog.Commands.AddCatalogItem;
global using Catalog.Application.Features.Catalog.Commands.AddCatalogWishlist;
global using Catalog.Application.Features.Catalog.Commands.UpdateCatalogItem;
global using Catalog.Application.Features.Catalog.Commands.UpdateCatalogWishlist;
global using Catalog.Application.Features.Catalog.Queries.GetCatalogItems;
global using Catalog.Application.Mapper.Converters;
global using Catalog.Application.Models;
global using Catalog.Application.Repositories;
global using Catalog.Domain.Common;
global using Catalog.Domain.Entities;
global using FluentValidation.Results;
global using FluentValidation;
global using MediatR;
global using Microsoft.AspNetCore.Http;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using System.Linq.Expressions;
global using System.Reflection;
global using System.Text.Json;