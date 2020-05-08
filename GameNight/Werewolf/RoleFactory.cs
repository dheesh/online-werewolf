using GameNight.Werewolf.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameNight.Werewolf
{
	public class RoleFactory
	{
		public List<Role> CreateRoles(List<string> roleNames)
		{
			List<Role> roles = new List<Role>();
			return roles;
		}

		public List<Role> CreateAllRoles()
		{
			List<Role> roles = new List<Role>();
			roles.Add(CreateHunter());
			roles.Add(CreateWereWolf());
			roles.Add(CreateVillager());
			roles.Add(CreateSorcerer());
			roles.Add(CreateSeer());
			return roles;
		}

		public Role CreateHunter()
		{
			return new Hunter();
		}

		public Role CreateWereWolf()
		{
			return new WereWolfRole();
		}

		public Role CreateVillager()
		{
			return new Villager();
		}

		public Role CreateSeer()
		{
			return new Seer();
		}

		public Role CreateSorcerer()
		{
			return new Sorcerer();
		}



	}
}
