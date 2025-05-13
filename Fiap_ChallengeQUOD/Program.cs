using Fiap_ChallengeQUOD;
using Fiap_ChallengeQUOD.Services;
using Fiap_ChallengeQUOD.Utils;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<BiometriaService>();
builder.Services.AddSingleton<DocumentoService>();
builder.Services.AddSingleton<ValidacaoImagemService>();
builder.Services.AddSingleton<NotificacaoClient>();
builder.Services.AddSingleton<MongoDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
