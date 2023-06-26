
using FishApp1;
using FishApp1.Data;
using FishApp1.Entities;
using FishApp1.Repositories;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Fish>, FishInFile<Fish>>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IFishDataProvider, FishDataProvider>();



var servicesProvider = services.BuildServiceProvider();
var app = servicesProvider.GetRequiredService<IApp>();
app.Run();




























