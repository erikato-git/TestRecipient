using Digst.DigitalPost.SSLClient.Clients;
using Digst.DigitalPost.UtilityLibrary.Memos.Configuration;
using Digst.DigitalPost.UtilityLibrary.Memos.Services.Logging;
using Digst.DigitalPost.UtilityLibrary.Memos.Services.MemoBuilder;
using Digst.DigitalPost.UtilityLibrary.Memos.Services.Parser;
using Digst.DigitalPost.UtilityLibrary.Memos.Services.Persistence;
using Digst.DigitalPost.UtilityLibrary.Receipts.Configuration;
using Digst.DigitalPost.UtilityLibrary.Receipts.Sender;
using Digst.DigitalPost.UtilityLibrary.Receipts.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

builder.Services.AddScoped<RecipientSystemConfiguration>();
builder.Services.AddScoped<RestClient>();
builder.Services.AddScoped<MemoConfiguration>();
builder.Services.AddScoped<IMemoService, ParseMemoService>();
builder.Services.AddScoped<IBusinessReceiptFactory, BusinessReceiptFactory>();
builder.Services.AddScoped<IBusinessReceiptService, BusinessReceiptService>();
builder.Services.AddScoped<IMemoBuilder, MemoBuilder>();
builder.Services.AddScoped<IMeMoPersister, MeMoPersister>();
builder.Services.AddScoped<IMemoLogging, MemoLoggingService>();
//builder.Services.AddScoped<MeMoPushService>();
builder.Services.AddScoped<IReceivedBusinessReceiptLoggingService, ReceivedBusinessReceiptLoggingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
