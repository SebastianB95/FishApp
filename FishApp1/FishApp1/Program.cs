
using FishApp1;
using FishApp1.Components.CsvReader;
using FishApp1.Components.CsvReader.Models;
using FishApp1.Data;
using FishApp1.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<SeaFishs>, ListRepository<SeaFishs>>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<ICvReader, CvReader>();

services.AddDbContext<FishApp1DbContex>(options => options
.UseSqlServer("Data Source=SEBASTIAN\\SQLEXPRESS;Initial Catalog=FishAapStorage;Integrated Security=True;Trust Server Certificate=True"));


var servicesProvider = services.BuildServiceProvider();
var app = servicesProvider.GetRequiredService<IApp>();
app.Run();