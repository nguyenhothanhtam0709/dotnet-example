using DotnetExample.Core.App;

var builder = WebApplication.CreateBuilder(args);

new BuilderConfigure(builder).Configure();

var app = builder.Build();

new AppConfigure(app).Configure();

app.Run();
