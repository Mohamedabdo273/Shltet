using Shltet.Repository;
using Shltet.Repository.IRepo;
using Shltet.Services.IServices;
using Shltet.Services;
using Microsoft.EntityFrameworkCore;
using Shltet.Data;
using Microsoft.AspNetCore.Identity;
using Shltet.Modles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<IdentityOptions>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
{
    option.User.RequireUniqueEmail = true;

})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPetRepo, PetRepository>();
builder.Services.AddScoped<IPetCategoryRepo, PetCategoryRepository>();
builder.Services.AddScoped<IAdoptionRequestRepo, AdoptionRequestRepository>();
builder.Services.AddScoped<ISupportRequestRepo, SupportRequestRepository>();
builder.Services.AddScoped<IMessageRepo, MessageRepository>();
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IPetCategoryService, PetCategoryService>();
builder.Services.AddScoped<IAdoptionRequestService, AdoptionRequestService>();
builder.Services.AddScoped<ISupportRequestService, SupportRequestService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // React dev server
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowFrontend");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
