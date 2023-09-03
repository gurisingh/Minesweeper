using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Minesweeper;

var serviceCollection = new ServiceCollection();

serviceCollection.AddTransient<IGameBoardService, GameBoardService>();
serviceCollection.AddTransient<IPlayerService, PlayerService>();
serviceCollection.AddTransient<Game>();

var serviceProvider = serviceCollection.BuildServiceProvider();

var game = serviceProvider.GetRequiredService<Game>();
game.Start();