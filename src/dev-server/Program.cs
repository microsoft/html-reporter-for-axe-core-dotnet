// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(config =>
{
    config.MapControllers();
});

app.Run();
