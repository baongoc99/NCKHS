using Microsoft.EntityFrameworkCore;
using NCKH.Datta;
using NCKH.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<SalesService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<OrderDetailService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<OrderDetailCustomerService>();
builder.Services.AddScoped<PaymentService>();


builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
        ));
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=login}/{id?}");
app.MapControllerRoute(
name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.Run();
