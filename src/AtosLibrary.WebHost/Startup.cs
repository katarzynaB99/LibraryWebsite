using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtosLibrary.Application.Features.EditReader;
using AtosLibrary.Application.Features.RegistrationBook;
using AtosLibrary.Application.Features.RegistrationReader;
using AtosLibrary.Application.Features.ReserveBook;
using AtosLibrary.Application.Features.DeleteReader;
using AtosLibrary.Application.Features.DeleteBook;
using AtosLibrary.Application.Features.EditBook;
using AtosLibrary.Application.Features.PrepareBook;
using AtosLibrary.Application.Features.ReadyBook;
using AtosLibrary.Application.Features.RentBook;
using AtosLibrary.Application.Features.ReturnBook;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Book;
using AtosLibrary.Domain.Reader;
using AtosLibrary.Domain.Record;
using AtosLibrary.Infrastructure;
using AtosLibrary.Presentation.Book;
using AtosLibrary.Presentation.Reader;
using AtosLibrary.Presentation.Record;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AtosLibrary.WebHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            
            services.AddDbContext<AtosLibraryContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("AtosLibrary")));

            services.AddScoped<ICommandHandler<DeleteBookCommand>, DeleteBookCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteReaderCommand>, DeleteReaderCommandHandler>();
            services.AddScoped<ICommandHandler<EditBookCommand>, EditBookCommandHandler>();
            services.AddScoped<ICommandHandler<EditReaderCommand>, EditReaderCommandHandler>();
            services.AddScoped<ICommandHandler<PrepareBookCommand>, PrepareBookCommandHandler>();
            services.AddScoped<ICommandHandler<ReadyBookCommand>, ReadyBookCommandHandler>();
            services.AddScoped<ICommandHandler<RegistrationBookCommand>, RegistrationBookCommandHandler>();
            services.AddScoped<ICommandHandler<RegistrationReaderCommand>, RegistrationReaderCommandHandler>();
            services.AddScoped<ICommandHandler<RentBookCommand>, RentBookCommandHandler>();
            services.AddScoped<ICommandHandler<ReserveBookCommand>, ReserveBookCommandHandler>();
            services.AddScoped<ICommandHandler<ReturnBookCommand>, ReturnBookCommandHandler>();
            
            services.AddScoped<IBookFactory, BookFactory>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IReaderFactory, ReaderFactory>();
            services.AddScoped<IReaderRepository, ReaderRepository>();
            services.AddScoped<IRecordFactory, RecordFactory>();
            services.AddScoped<IRecordRepository, RecordRepository>();

            services.AddScoped<IReaderPresentationRepository, ReaderPresentationRepository>();
            services.AddScoped<IBookPresentationRepository, BookPresentationRepository>();
            services.AddScoped<IRecordPresentationRepository, RecordPresentationRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
