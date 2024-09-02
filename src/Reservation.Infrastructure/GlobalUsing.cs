global using Reservation.Application.Finances.BusinessRequestPays.Queries.GetBusinessRequestPays;
global using Reservation.Application.Finances.BusinessRequestPays.Queries.GetBusinessRequestPay;
global using Reservation.Application.Finances.UserRequestPays.Queries.GetUserRequestPays;
global using Reservation.Application.Finances.UserRequestPays.Queries.GetUserRequestPay;
global using Reservation.Application.BusinessServices.Queries.GetServicesByBusinessId;
global using Reservation.Application.Categories.Queries.GetCategoryBusinesses;
global using Reservation.Infrastructure.ExternalServices.UploadImageProviders;
global using Reservation.Infrastructure.ExternalServices.Jwt.TokenValidators;
global using Reservation.Application.Artists.Queries.GetArtistByBusinessId;
global using Reservation.Application.ExternalServices.UploadImageProvider;
global using Reservation.Application.SmsTemplates.Queries.GetSmsTemplates;
global using Reservation.Application.Wallets.Queries.GetUserTransactions;
global using Reservation.Application.SmsTemplates.Queries.GetSmsTemplate;
global using Reservation.Application.TransferFees.Queries.GetTransferFee;
global using Reservation.Application.Categories.Queries.GetMainCategory;
global using Reservation.Infrastructure.Persistance.SeedData.Categories;
global using Reservation.Application.Artists.Queries.GetArtistServices;
global using Reservation.Application.Wallets.Queries.GetBusinessWallet;
global using Reservation.Application.Categories.Queries.SearchCategory;
global using Reservation.Infrastructure.Persistance.SeedData.TestData;
global using Reservation.Application.Categories.Queries.GetCategories;
global using Reservation.Infrastructure.ExternalServices.SmsProvider;
global using Reservation.Application.Categories.Queries.GetCategory;
global using Reservation.Application.Businesses.Queries.GetBusiness;
global using Reservation.Application.Wallets.Queries.GetUserWallet;
global using Reservation.Infrastructure.Persistance.Configuration;
global using Reservation.Application.ExternalServices.SmsProvider;
global using Reservation.Application.SmsPlans.Queries.GetSmsPlans;
global using Reservation.Infrastructure.ExternalServices.Payments;
global using Reservation.Infrastructure.Persistance.Repositories;
global using Reservation.Application.Account.Queries.GetUserInfo;
global using Reservation.Infrastructure.Persistance.UnitOfWorks;
global using Reservation.Infrastructure.Persistance.Interceptor;
global using Reservation.Application.Account.Queries.LoginInit;
global using Reservation.Application.Artists.Queries.GetArtist;
global using Reservation.Application.Businesses.Queries.Search;
global using Reservation.Application.Cities.Queries.GetCities;
global using Reservation.Infrastructure.ExternalServices.Cash;
global using Reservation.Application.ExternalServices.Payment;
global using Reservation.Infrastructure.ExternalServices.Jwt;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Reservation.Infrastructure.ExternalServices.Job;
global using Reservation.Application.Posts.Queries.GetPosts;
global using Reservation.Infrastructure.Persistance.Context;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Reservation.Application.Posts.Queries.GetPost;
global using Reservation.Application.ExternalServices.Cash;
global using Microsoft.EntityFrameworkCore.Infrastructure;
global using Reservation.Application.ReserveTimes.Queries;
global using Reservation.Application.ExternalServices.Jwt;
global using Reservation.Application.ExternalServices.Job;
global using Microsoft.EntityFrameworkCore.Diagnostics;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.EntityFrameworkCore.Migrations;
global using Microsoft.Extensions.Caching.Distributed;
global using Reservation.Infrastructure.Persistance;
global using Reservation.Domain.Entities.Businesses;
global using Reservation.Domain.Entities.Categories;
global using Microsoft.IdentityModel.JsonWebTokens;
global using Reservation.Domain.Entities.Finances;
global using Reservation.Domain.Entities.Account;
global using Reservation.Domain.Entities.Wallets;
global using Reservation.Domain.Entities.Reserve;
global using Reservation.Application.Common.DTOs;
global using Reservation.Domain.Entities.Cities;
global using Microsoft.Extensions.Configuration;
global using Reservation.Domain.Entities.Points;
global using Reservation.Share.Abstract.Helper;
global using Reservation.Domain.Entities.Admin;
global using Reservation.Domain.Repositories;
global using System.IdentityModel.Tokens.Jwt;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.EntityFrameworkCore;
global using Reservation.Domain.UnitOfWork;
global using Microsoft.Extensions.Options;
global using Microsoft.AspNetCore.Builder;
global using Kavenegar.Core.Models.Enums;
global using Microsoft.AspNetCore.Http;
global using Kavenegar.Core.Exceptions;
global using System.Security.Claims;
global using Hangfire.PostgreSql;
global using System.Reflection;
global using System.Text.Json;
global using Amazon.S3.Model;
global using Amazon.Runtime;
global using ZarinPal.Class;
global using System.Text;
global using Amazon.S3;
global using DotNetEnv;
global using Kavenegar;
global using Hangfire;
