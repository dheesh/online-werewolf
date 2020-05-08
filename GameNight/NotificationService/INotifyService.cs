using System;
using System.Collections.Generic;
using System.Text;

namespace GameNight.NotificationService
{
	public interface INotifyService
	{
		void SendMessage(MessageModel messageDto);
	}
}
