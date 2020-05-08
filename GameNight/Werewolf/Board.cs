using System;
using System.Collections.Generic;
using System.Linq;
using GameNight.NotificationService;
using GameNight.Werewolf.Helpers;

namespace GameNight.Werewolf
{
	public class Board
	{
		public List<Player> players;
		public List<Role> roles;
		public INotifyService notifier;
		private Boolean isRolesAssigned; 

		public Board(List<Player> players, List<Role> roles,INotifyService notifyService)
		{
			this.players = players;
			this.roles = roles;
			this.notifier = notifyService;
			isRolesAssigned = false;
		}

		public void AssignRoles()
		{
			var shuffledPlayers = players.Shuffle();
			var shuffledRoles = roles.Shuffle();

			for(int i=0;i < shuffledPlayers.Count; i++)
			{
				shuffledPlayers[i].PlayerRole = shuffledRoles[i];
			}
			players = shuffledPlayers;
			isRolesAssigned = true;
		}

		public List<String> GetRoles()
		{
			List<String> playerRolesTxt = new List<string>();
			foreach(var player in players)
			{
				playerRolesTxt.Add($"{player.PlayerName} is {player.GetRoleName()}");
			}
			return playerRolesTxt;
		}

		public void NotifyPlayers()
		{
			if (isRolesAssigned)
			{
				foreach(var player in players)
				{
					MessageModel messageDto = new MessageModel()
					{
						Contact = player.Contact,
						Message = $"Your {player.PlayerName}:Werewolf code is {player.GetRoleName()}"
					};
					notifier.SendMessage(messageDto);
				}
			}
		}
	}
}
