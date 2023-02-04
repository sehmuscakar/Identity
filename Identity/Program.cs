using Identity.Context;
using Identity.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{//�ifre k�sm� zorunluklar�n� burdan de��tirebiliriz ama iyi bir �ey de�il bu 
    opt.Password.RequireDigit = false;
    opt.Password.RequiredLength = 1;//�ifre uzunlu�u
    opt.Password.RequireLowercase = false; //k���k harf zorunlu�u yok 
    opt.Password.RequireUppercase = false;  //buuyk harf zorunlu�u yok 
    opt.Password.RequireNonAlphanumeric = false;
    opt.SignIn.RequireConfirmedEmail = true;

}).AddEntityFrameworkStores<IdentityContext>();//buda entity k�t�phanesini ekledi�imiz i�in ve hangi roler i yazm��san e�er �zele�tirmi�sen onlar� de�ilse di�erleri yazman laz�m parmetreler olarak

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.Cookie.HttpOnly = true;// ilgili coki de�erline ula��lm�yor
    opt.Cookie.SameSite = SameSiteMode.Strict;//sadece ilgili domainde kullan�labilir
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;//httpi onlarda �al��s�n
    opt.Cookie.Name = "UdemyCookie";//coki namesi
    opt.ExpireTimeSpan = TimeSpan.FromDays(25);//ilgiil kullan�c�n bilsini 25 g�n boyunca hat�rlar
    opt.LoginPath = new PathString("/Home/SignIn");

});
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IdentityContext>();//bu veritaban�n� ba�lant�s� i�in �nemli olan 


var app = builder.Build();//service �eylerini yazacaksan iki var i�inde olmas� laz�m 
//app.MapControllerRoute(
//	name: "default",
//	pattern: "{controller=Home}/{action=Index}/{id?}");
//bu midelviewlerin s�ras� �nemli
app.UseStaticFiles();//wwwroot ,bootstrap� yuklemek i�in wwwroot ta client side labrary de (twiter bunu yazmasan da olabilir) bootstrap� yuklemen laz�m
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();
app.Run();
