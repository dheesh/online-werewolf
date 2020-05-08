using System;
using System.Collections.Generic;
using System.Text;

namespace GameNight.Werewolf
{
	public class PlayerFactory
	{
		public List<Player> CreatePlayers(List<String> names)
		{
			List<Player> players = new List<Player>();
			foreach(string name in names)
			{
				players.Add(CreatePlayer(name));
			}
			return players;
		}

		public Player CreatePlayer(string name)
		{
			return new Player(name);
		}
	}
}
