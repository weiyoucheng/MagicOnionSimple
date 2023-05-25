using Grpc.Core;
using Grpc.Core.Interceptors;
using MagicOnionSimple.Server;
using MagicOnionSimple.Server.GrpcService;
using MagicOnionSimple.Server.MagicOnionService;
using MagicOnionSimple.ServerInterface;
using ProtoBuf.Grpc.Configuration;
using ProtoBuf.Grpc.Server;
using MessagePack.Formatters;
using MessagePack.AspNetCoreMvcFormatter;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// 添加Grpc服务
builder.Services.AddGrpc();

//注册可以识别和处理代码优先服务的提供程序
builder.Services.AddCodeFirstGrpc();
builder.Services.AddControllers().AddMvcOptions(options =>
{
    options.OutputFormatters.Clear();
    options.OutputFormatters.Add(new MessagePackOutputFormatter());
    options.InputFormatters.Clear();
    options.InputFormatters.Add(new MessagePackInputFormatter());
});
builder.Services.AddMagicOnion();
builder.Services.AddSingleton<DbContextBase, SQLContext>();
var app = builder.Build();
app.MapGrpcService<EmployeeGrpcService>();
app.MapMagicOnionService();

app.Run();


