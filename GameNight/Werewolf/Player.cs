using System;
using System.Collections.Generic;
using System.Text;

namespace GameNight.Werewolf
{
	public class Player
	{
		public String PlayerName;

		public String Contact;

		public Role PlayerRole;

		public Player(string name)
		{
			PlayerName = name;
		}

		public String GetRoleName()
		{
			return PlayerRole.RoleName;
		}

	}

	public class PlayerList
	{
		public List<Player> players { get; set; }
	}
}
