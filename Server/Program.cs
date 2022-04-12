using Codedash.Server.Data;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProblemDbContext>(options =>
{
    options.UseSqlite("Data source = Problems.db");
});
builder.Services.AddScoped<ProblemServices>();
builder.Services.AddDbContext<AccountDbContext>(options =>
{
    options.UseSqlite("Data source = Accounts.db");
});
builder.Services.AddScoped<AccountServices>();
builder.Services.AddDbContext<TokenDbContext>(options =>
{
    options.UseSqlite("Data source = Tokens.db");
});
builder.Services.AddScoped<TokenServices>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Codedash API v1"));


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
