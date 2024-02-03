using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;

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
			else if (finalAmount > 16000)
			{
				int extra = finalAmount - 16000;
				Server.ExecuteCommand($"wcs_mark_extra_money {player.SteamID} {extra}");
				finalAmount = 16000;
			}

			player.InGameMoneyServices.Account = finalAmount;
			StateChanger.UpdateMoney(player);
		}
	}
}
