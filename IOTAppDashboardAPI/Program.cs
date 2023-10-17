﻿using IOTAppDashboardAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
var a = builder.Configuration["JWT:Issuer"];
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(
    (builder) => builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("http://localhost:4200")
        );

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
