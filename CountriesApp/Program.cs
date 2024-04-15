var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();



app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/countries", async context => {
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("1, United States\n2, Canada\n3, United Kingdom\n4, Idia\n5, Japan");
    });
    endpoints.MapGet("/countries/{countryID:int?}", async context =>
    {
        int CountryId = Convert.ToInt32(context.Request.RouteValues["countryID"]);
        
        if(CountryId<1 || CountryId>5)
        {
            if(CountryId>100)
            {                
                await context.Response.WriteAsync("the CountryID should be between 1 and 100");
                context.Response.StatusCode = 400;
            }
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("[No Country]");
        }
        else  
            switch (CountryId)
            {
                case 1:
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync($"{CountryId} United States");
                    break;
                case 2:
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync($"{CountryId} Canada");
                    break;
                case 3:
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync($"{CountryId} United Kingdom");
                    break;
                case 4:
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync($"{CountryId} India");
                    break;
                case 5:
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync($"{CountryId} Japan");
                    break;
            };
    });   
});

app.Run();
