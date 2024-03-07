using Project.Application.Infrastructure;

ProjectAssembly.ReadEnvFile();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInternalControllers();

builder.Services.AddEncryptionKeyStore();
builder.Services.AddCounterClient();

builder.AddLogging();
builder.Services.AddDbContext<EventStoreContext>("EventStore");
builder.Services.AddDbContext<TinkoffContext>("TinkoffStore");
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddRpcClient();
builder.Services.AddEventConsumers<TinkoffContext>();

var settings = new ApplicationSettings();
builder.Services.AddSingleton(settings);

builder.Services.AddTinkoffService(settings);

builder.Services.AddRpcServer<TinkoffRequests, TinkoffContext>();
builder.Services.AddRpcServer<TinkoffInternalRequests, TinkoffContext>();
builder.Services.AddRpcServer<TinkoffRegularJobs, TinkoffContext>();

builder.Services.AddTaskWorker<TinkoffIncomeWithdrawalTasks, TinkoffContext>();

var app = builder.Build();

app.UseInternalControllers();

app.UseCounterClient();
app.UseEncryptionKeyStoreMigration();
app.UpdateEventStore<EventStoreContext>();
app.UpdateDatabase<TinkoffContext>();

app.UseCounterClient();

app.MapControllers();
app.UseLogging();

app.Run();

