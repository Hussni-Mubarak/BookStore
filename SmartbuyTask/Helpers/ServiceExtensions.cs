using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BookStore.ApplictaionDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Services.Interface.BookStore;
using BookStore.Services.Repository.BookStoreRepository;
using BookStore.Helpers.Paginations;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using BookStore.Services.Interface.External;
using BookStore.Services.Repository.External;

namespace BookStore.Helpers
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", x => x.AllowAnyHeader()
                 .AllowAnyMethod()
                 .AllowAnyOrigin());

            });
        }

        public static void ConfigureSqlConnect(this IServiceCollection services, IConfiguration config)
        {
            var Conn = config["SqlConnection:cnn"];
            services.AddDbContext<DataContext>(x => x.UseSqlServer(Conn));
        }

        public static void ConfigureScoped(this IServiceCollection services)
        {
            services.AddScoped<IAuthor, AuthorRepository>();
            services.AddScoped<IBook, BookRepository>();
            services.AddScoped<ICategory, CategoryRepository>();
            services.AddScoped<IRanking, RankingRepository>();


        }

        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
        public static void AddPagination(this HttpResponse response, int currentPage,
            int itemsPerPage, int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHeader(currentPage, itemsPerPage, totalItems, totalPages);
            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination-Error");
        }
    }
}
