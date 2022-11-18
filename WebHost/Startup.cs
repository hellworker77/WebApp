using Microsoft.OpenApi.Models;
using System;
using FluentValidation;
using Validation.Validators;
using WebHost.Abstractions;
using WebHost.Services;

namespace WebHost;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations();
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ilya.App", Version = "v1" });
        });

        #region Services

        services.AddScoped<IArrayOperationsService, ArrayOperationsService>();
        services.AddScoped<IStringOperationsService, StringOperationsService>();
        services.AddScoped<ILinkedListOperationsService, LinkedListOperationsService>();

        #endregion

        #region Validators

        services.AddScoped<IValidator<String>, StringValidator>();

        #endregion
    }

    protected virtual void ConfigureAuth(IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Tasks v1");
            });
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
        });

    }
}