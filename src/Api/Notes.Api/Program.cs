using Microsoft.EntityFrameworkCore;
using Notes.Api.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionStr =(string) builder.Configuration.GetConnectionString("Test");

//builder.Services.AddDbContext<NoteDbContext>(options =>
//    options.UseSqlite(
//        builder.Configuration.GetConnectionString("Test"),
//        b => b.MigrationsAssembly(typeof(NoteDbContext).Assembly.FullName))
//);

builder.Services.AddTransient(typeof(INoteRepository), x => new NoteRepository(connectionStr));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
