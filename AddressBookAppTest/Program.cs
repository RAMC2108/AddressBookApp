using AddressBookAppTest.Layers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IContactService, ContactService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 404)
    {
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync("{\"error\": \"Ruta no encontrada\"}");
    }
});
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.UseStatusCodePages(async context =>
{
    if (context.HttpContext.Response.StatusCode == 405)
    {
        context.HttpContext.Response.ContentType = "application/json";
        await context.HttpContext.Response.WriteAsync("{\"error\": \"Método no permitido en esta ruta\"}");
    }
});

app.Run();
