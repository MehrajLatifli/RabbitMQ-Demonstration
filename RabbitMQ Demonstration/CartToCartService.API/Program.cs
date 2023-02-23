using Database.ClassLibrary.DataAccess;
using Database.ClassLibrary.DatabaseFirst;
using RabbitMQInfrastructure.ClassLibrary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddControllers().AddJsonOptions(o =>
{

    o.JsonSerializerOptions.PropertyNamingPolicy = null;
    o.JsonSerializerOptions.DictionaryKeyPolicy = null;
});


builder.Services.AddScoped<ICartToCartDal, EfCartToCartDal>();
builder.Services.AddSqlServer<RabbitMQ_DbContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddScoped<IRabbitMQService, RabbitMQService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
