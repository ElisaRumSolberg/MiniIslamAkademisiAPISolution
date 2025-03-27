using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ Servisleri ekle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// 2️⃣ Swagger yapılandırması (model çakışmalarını önler)
builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type => type.FullName); // Model adları aynıysa karışmasın diye
});

var app = builder.Build();

// 3️⃣ Geliştirme ortamında Swagger'ı etkinleştir
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 4️⃣ wwwroot klasörüne erişim izni (JSON, resim, dosya vs.)
app.UseStaticFiles();

// 5️⃣ Geri kalan middleware'ler
app.UseHttpsRedirection();
app.UseAuthorization();

// 6️⃣ Controller'ları eşleştir
app.MapControllers();

// 7️⃣ Uygulamayı başlat
app.Run();
