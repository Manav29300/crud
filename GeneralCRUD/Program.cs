using GeneralCRUD;
using GeneralCRUD.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register your services
builder.Services.AddSingleton<DbExecutor>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("PostgresConnection");
    var connection = DbConnection.GetConnection(connectionString);
    return new DbExecutor(connection);
});

builder.Services.AddTransient<ProductService>();
builder.Services.AddTransient<CategoryService>();
builder.Services.AddTransient<CustomerService>();
builder.Services.AddTransient<VendorService>();
builder.Services.AddTransient<PurchaseOrderService>(); // Register the PurchaseOrderService
builder.Services.AddTransient<PurchaseOrderService>();
builder.Services.AddTransient<WarrantyConfigurationService>();


var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
