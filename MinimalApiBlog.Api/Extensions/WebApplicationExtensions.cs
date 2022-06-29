namespace MinimalApiBlog.Api.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplication ConfigureApplication(this WebApplication app)
        {

            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            return app;
        }
    }
}
