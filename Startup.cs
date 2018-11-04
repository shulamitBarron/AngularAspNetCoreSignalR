using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AngularAspNetCoreSignalR {
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices (IServiceCollection services) {
            services.AddCors (o => o.AddPolicy ("CorsPolicy", builder => {
                builder
                    .AllowAnyMethod ()
                    .AllowAnyHeader ()
                    .WithOrigins ("*");
            }));

            services.AddSignalR ();
            services.AddMvc ();
            //.SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            //.ConfigureApiBehaviorOptions(options =>
            //{
            //    options.SuppressConsumesConstraintForFormFileParameters = true;
            //    options.SuppressInferBindingSourcesForParameters = true;
            //    options.SuppressModelStateInvalidFilter = true;
            //    options.SuppressMapClientErrors = true;

            //    options.ClientErrorMapping[404] = "https://httpstatuses.com/404";
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseCors ("CorsPolicy");

            app.UseSignalR (routes => {
                routes.MapHub<ChatHub> ("chat");
            });

            //   List<string> angularRoutes = new List<string>(){
            //    "/home"
            //};

            //app.Use(async (context, next) =>
            //{
            //    if (context.Request.Path.HasValue && context.Request.Path.Value.StartsWith("/home"))
            //    {
            //        context.Request.Path = new PathString("/");
            //    }
            //    await next();
            //});

            app.UseDefaultFiles ();
            app.UseStaticFiles ();
            app.UseMvc (routes => {
                routes.MapRoute (
                    name: "default",
                    template: "{controller}/{action}/{id?}");
            });
            app.UseStaticFiles (new StaticFileOptions {
                    ServeUnknownFileTypes = true, //allow unkown file types also to be served
                        DefaultContentType = "Whatver you want eg: plain/text" //content type to returned if fileType is not known.
                });
            }
        }
    }