using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Memory;
using CounterStrikeSharp.API.Modules.Utils;

namespace PlayersBet
{
	public static class CCSPlayerExtension
	{
		public static void AddMoney(this CCSPlayerController player, int amount)
		{
			if (player.IsValid == false || player.InGameMoneyServices == null)
				return;
			int finalAmount = player.InGameMoneyServices.Account + amount;

			if (finalAmount < 0)
			{
				finalAmount = 0;
			}
			// TODO: @val: Add config to set max money
			//else if (finalAmount > 16000)
			//{
			//	finalAmount = 16000;
			//}

			player.InGameMoneyServices.Account = finalAmount;
			// TODO: @val: Refresh money HUD with userMessages once available in CSSharp
		}
	}
}
