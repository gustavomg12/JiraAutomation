using JiraAutomation.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<JiraService, JiraService>();
builder.Services.AddScoped<CommandService, CommandService>();
builder.Services.AddScoped<QueryService, QueryService>();
builder.Services.AddScoped<ModalService, ModalService>();
builder.Services.AddScoped<EmailService, EmailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();

app.MapControllers();

app.Run();
