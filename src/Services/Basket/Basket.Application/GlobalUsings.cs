global using MediatR;
global using AutoMapper;
global using Basket.Domain.Repositories.Persistence;
global using System.Reflection;
global using FluentValidation;
global using Microsoft.Extensions.DependencyInjection;
global using Basket.Domain.Entities;
global using Microsoft.Extensions.Logging;
global using Basket.Application.Common;
global using Basket.Application.Mapper.Converters;
global using Basket.Application.Behaviours;
global using Basket.Application.Features.Basket.Queries.GetBasketByBuyerId;
global using Basket.Application.Features.Basket.Commands.UpdateBasketItems;
global using EventBus.Messages.Events;
global using Basket.Application.Features.Basket.Commands.CheckoutBasket;
global using MassTransit;