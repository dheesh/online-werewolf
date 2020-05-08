using System;
using System.Collections.Generic;

namespace GameNight.Werewolf.Helpers
{
	public static class ShuffleExtension
	{
		public static List<T> Shuffle<T>(this List<T> list) 
		{
			int max = list.Count;
			if (list.Count < 1) return list;
			var rand = new Random();
			for(int i=0;i < max; i++)
			{
				int range = max - i - 1;
				int exchange = rand.Next(0, range);
				T temp = list[range];
				list[range] = list[exchange];
				list[exchange] = temp;
			}
			return list;
		}
	}
}
