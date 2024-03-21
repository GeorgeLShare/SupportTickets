using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SupportTickets.Interfaces;
using SupportTickets.Models.Database;
using SupportTickets.Repositories;
using SupportTickets.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Set up Dependencies
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<ITicketRepository, TicketRepository>();
builder.Services.AddTransient<ITicketService, TicketService>();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication();
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<SupportTicketContext>();

builder.Services.AddDbContext<SupportTicketContext>(options => 
        options.UseLazyLoadingProxies()
        .UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
