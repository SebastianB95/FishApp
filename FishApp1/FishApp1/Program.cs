
using FishApp1;
using FishApp1.Components.CsvReader;
using FishApp1.Components.DataProvider;
using FishApp1.Data.Entities;
using FishApp1.Repositories;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Fish>, FileRepository<Fish>>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IFishDataProvider, FishDataProvider>();
services.AddSingleton<ICvReader, CvReader>();


var servicesProvider = services.BuildServiceProvider();
var app = servicesProvider.GetRequiredService<IApp>();
app.Run();

