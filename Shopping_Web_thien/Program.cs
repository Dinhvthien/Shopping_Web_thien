using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.AspNetCore.Mvc.Razor;
using Shopping_Web_thien.IServices;
using Shopping_Website.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddNotyf(config => { config.DurationInSeconds = 3;config.IsDismissable= true;config.Position = NotyfPosition.TopRight; });
// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddTransient<IProductServices, ProductServices>();

// builder.Services.AddSingleton<IProductServices, ProductServices>();
// builder.Services.AddScoped<IProductServices, ProductServices>();
/*
 * AddSingleton: Nếu Service được khởi tạo, nó sẽ tồn tại cho đến khi vòng đời
 * của ứng dụng kết thúc. Nếu các Request khác mà triển khai thì sẽ dùng lại 
 * chính service đó. Phù hợp cho các services có tính toàn cục và không thay đổi
 * AddScoped: Mỗi lần có http Request thì sẽ tạo ra services 1 lần và được giữ
 * nguyên trong quá trình request được xử lý. Loại này sẽ được sử dụng cho các
 * services với những yêu cầu http cụ thể.
 * Adđ transient: Tạo mới services mỗi khi có request. Với mỗi yêu cầu http sẽ 
 * nhận được một đối tượng services khác nhau. Phù hợp cho các services mà có thể
 * phụ vụ nhiều yêu cầu http request.
 */
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(5);
});
// Đăng ký Session với thời gian là 15 giây cho đến khi timeout

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseNotyf();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseStatusCodePagesWithReExecute("/Home/Index");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();
