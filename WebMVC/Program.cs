var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddHttpClient();
builder.Services.AddSession(o =>
{
    o.IdleTimeout = TimeSpan.FromSeconds(1800);
});
//builder.Services.AddHttpContextAccessor();
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddSession(options =>
//{
//    // Set a short timeout for easy testing.
//    options.IdleTimeout = TimeSpan.FromMinutes(120);
//    options.Cookie.HttpOnly = true;
//    // Make the session cookie essential
//    options.Cookie.IsEssential = true;
//});

var app = builder.Build();
app.UseSession();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MovieConsumed}/{action=Index}/{id?}");

app.Run();
