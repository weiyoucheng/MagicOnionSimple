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
// ���Grpc����
builder.Services.AddGrpc();

//ע�����ʶ��ʹ���������ȷ�����ṩ����
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


