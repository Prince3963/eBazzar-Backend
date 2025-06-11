using System.Text;
using eBazzar.DBcontext;
using eBazzar.HelperService;
using eBazzar.Repository;
using eBazzar.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.ConfigureKestrel(sop =>
//{
//    sop.ListenAnyIP(7072);
//});


//Database Connectivity service
builder.Services.AddDbContext<AppDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("myConn"));
});




//Dependecies Injection
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUsers, UserServices>();
builder.Services.AddScoped<JwtTokenService>();
builder.Services.AddScoped<IServiceProduct, ProductService>();
builder.Services.AddScoped<IProduct, ProductRepo>();
builder.Services.AddScoped<IEmailService, EmailService>() ;
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<ICategoryService, CategoryServices>();
builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<eBazzar.Repository.IAddressRepo, AddrressRepo>();
builder.Services.AddScoped<eBazzar.Services.IAddressService, AddressService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPaymentRepo, PayemntRepo>();
builder.Services.AddScoped<IPaymentService, PaymentService>();


//builder.Services.AddScoped<ServiceResponse>();


builder.Services.Configure<RazorpaySettings>(builder.Configuration.GetSection("RazorpaySettings"));

// Add services to the container.
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CROS Solution
builder.Services.AddCors(option =>
{
    option.AddPolicy("forntend",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

//JSON services
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["JwtToken:Issuer"],
        ValidAudience = builder.Configuration["JwtToken:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtToken:SecurityKey"])),
        ValidateIssuerSigningKey = true
    };
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("forntend");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.Run();
