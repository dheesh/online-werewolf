using System;
using System.Collections.Generic;
using System.IO;
using GameNight.Werewolf;
using Newtonsoft.Json;
using GameNight.NotificationService;

namespace GameNight
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Arrange
			PlayerList inputPlayers = new PlayerList();
			INotifyService notifyService = new RabbitNotificationService();

			//read config
			using (StreamReader file = File.OpenText(@"..\..\Config\prod-config.json"))
			{
				JsonSerializer serializer = new JsonSerializer();
				inputPlayers = (PlayerList)serializer.Deserialize(file, typeof(PlayerList));

			}

			if (inputPlayers.players.Count < 0)
			{
				Console.WriteLine("something went wrong while reading");
				Console.ReadLine();
			}

			// Create Roles
			//this creates 5 individual roles
			RoleFactory roleFactory = new RoleFactory();
			List<Role> roles = roleFactory.CreateAllRoles();

			//additional role if more than 5 players are playing.
			roles.Add(roleFactory.CreateVillager());
			roles.Add(roleFactory.CreateWereWolf());

			Console.WriteLine("Shuffling deck");


		Console.WriteLine("Assiging Players to Roles");
			Board newBoard = new Board(inputPlayers.players, roles, notifyService);
			newBoard.AssignRoles();
			Console.WriteLine("Players assigned roles");

			string line;
			do
			{
				Console.WriteLine("--------------------------------");
				line = Console.ReadLine();
				if (line.ToLower().Equals("shuffle"))
				{
					Console.WriteLine("Shuffling");
					newBoard.AssignRoles();
				}
				if (line.ToLower().Equals("display"))
				{
					foreach (var player in newBoard.players)
					{
						Console.WriteLine($"{player.PlayerName} is {player.GetRoleName()}");
					}
				}
				if (line.ToLower().Equals("notify"))
				{
					Console.WriteLine("=======Notifying players======== ");
					newBoard.NotifyPlayers();
				}
				if (line.ToLower().Equals("reset"))
				{
					Console.WriteLine("=====Resetting the board======");
				}

			} while (line != null && !string.IsNullOrEmpty(line));
		}
	}
}
