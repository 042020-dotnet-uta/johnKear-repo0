/*
 * Jayson
 * Tanner
 * John

	Requirements:
	1. Write pseudocode for a Rock/Paper/Scissors game.
	2. Get names from the users.
	3. Play a game of best 2 of 3 rounds. Each "choice" is a random assignment
	4. Report the winner and the results of each round.
	5. Report the ties as part of the output. "Round 1 - John chose paper, Jim chose rock. - John won"
	6. continue till one player has 2 points.
	7. "John wins 2-1 with 3 ties."
*/


using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RockPaperScissors
{

    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var game = host.Services.GetRequiredService<Game>();
            game.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging => logging.SetMinimumLevel(LogLevel.Trace))
                // Transient services create a new instance on each request.
                .ConfigureServices(serviceCollection => serviceCollection.AddTransient<Game>());
    }
}
