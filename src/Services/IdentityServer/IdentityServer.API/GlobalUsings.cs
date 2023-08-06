global using IdentityServer.Infrastructure;
global using Microsoft.EntityFrameworkCore;
global using IdentityServer.API.Extensions;
global using IdentityServer.Infrastructure.Persistence;
global using Npgsql;
global using IdentityServer.Application.Common.Jwt;
global using Microsoft.Extensions.Options;
global using IdentityServer.Application;
global using IdentityServer.Application.Common;
global using IdentityServer.Application.Contracts;
global using IdentityServer.Application.Models;
global using Microsoft.AspNetCore.Mvc;
global using System.Net;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using IdentityServer.Domain.Entities;
global using Microsoft.AspNetCore.Identity;
global using MediatR;
global using IdentityServer.Application.Features.User.Commands.DeleteUser;
global using IdentityServer.Application.Features.User.Commands.UpdateUser;
global using IdentityServer.Application.Features.User.Queries.GetUserById;