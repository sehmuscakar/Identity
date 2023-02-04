using Identity.Context;
using Identity.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{//þifre kýsmý zorunluklarýný burdan deðþtirebiliriz ama iyi bir þey deðil bu 
    opt.Password.RequireDigit = false;
    opt.Password.RequiredLength = 1;//þifre uzunluðu
    opt.Password.RequireLowercase = false; //küçük harf zorunluðu yok 
    opt.Password.RequireUppercase = false;  //buuyk harf zorunluðu yok 
    opt.Password.RequireNonAlphanumeric = false;
    opt.SignIn.RequireConfirmedEmail = true;

}).AddEntityFrameworkStores<IdentityContext>();//buda entity kütüphanesini eklediðimiz için ve hangi roler i yazmýþsan eðer üzeleþtirmiþsen onlarý deðilse diðerleri yazman lazým parmetreler olarak

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.Cookie.HttpOnly = true;// ilgili coki deðerline ulaþýlmýyor
    opt.Cookie.SameSite = SameSiteMode.Strict;//sadece ilgili domainde kullanýlabilir
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;//httpi onlarda çalýþsýn
    opt.Cookie.Name = "UdemyCookie";//coki namesi
    opt.ExpireTimeSpan = TimeSpan.FromDays(25);//ilgiil kullanýcýn bilsini 25 gün boyunca hatýrlar
    opt.LoginPath = new PathString("/Home/SignIn");

});
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IdentityContext>();//bu veritabanýný baðlantýsý için önemli olan 


var app = builder.Build();//service þeylerini yazacaksan iki var içinde olmasý lazým 
//app.MapControllerRoute(
//	name: "default",
//	pattern: "{controller=Home}/{action=Index}/{id?}");
//bu midelviewlerin sýrasý önemli
app.UseStaticFiles();//wwwroot ,bootstrapý yuklemek için wwwroot ta client side labrary de (twiter bunu yazmasan da olabilir) bootstrapý yuklemen lazým
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();
app.Run();
