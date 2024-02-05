using Hangfire;
using Hangfire.Storage.SQLite;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// --------------------------------
// Hangfire 
// --------------------------------

// use SQLite
GlobalConfiguration.Configuration.UseSQLiteStorage();
builder.Services.AddHangfire(configuration => configuration.UseSQLiteStorage());

// add jobs
RecurringJob.AddOrUpdate<DummyHandler>("what time is it ?", (h) => h.EchoCurrentTime(), Cron.Minutely);
RecurringJob.AddOrUpdate<DummyHandler>("throw some error", (h) => h.ThrowException(), Cron.Minutely);
for (int i = 0; i < 5; i++)
{
    RecurringJob.AddOrUpdate<DummyHandler>("get html content - "+i, (h) => h.GetHtmlConetent(), Cron.MinuteInterval(2));
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// Hangfire UI and Server
app.UseHangfireDashboard();
app.UseHangfireServer();

app.Run();
