using BaseLoop.Core.IoC;
using BaseLoop.Identity.IoC;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddAuthenticationService(config);
builder.Services.AddAuthorization();
builder.Services.AddCoreDbContext(builder.Configuration);
builder.Services.AddSerilog(builder.Configuration);
builder.Services.AddCoreMediatR().AddIdentityMediatR();

builder.Services.AddIdentityCommonServices();
builder.Services.AddUserRepository();

builder.Services.AddValidationPipelineBehavior();
builder.Services.AddCommandHandlers();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddPermissionsService();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Creating CoreDbContext
// using (var serviceScope = app.Services?.GetService<IServiceScopeFactory>()?.CreateScope())
// {
//     var context = serviceScope?.ServiceProvider.GetRequiredService<CoreDbContext>();
//     context?.Database.Migrate();
// }

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();