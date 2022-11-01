using ManagedIdentity.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(opt =>
{
    opt.UseSqlServer("Server=tcp:wizmanagedidentity.database.windows.net,1433;Initial Catalog=wizmanagedidentity;Persist Security Info=False;User ID=janduymonroe@wizsolucoes.com.br;MultipleActiveResultSets=False;Encrypt=True;Authentication=Active Directory Integrated");
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
