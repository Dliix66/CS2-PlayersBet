using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Memory;
using CounterStrikeSharp.API.Modules.Memory.DynamicFunctions;

namespace PlayersBet
{
	public static class StateChanger
	{
		public static void UpdateMoney(CCSPlayerController player)
		{
			SetStateChanged(player, "CCSPlayerController", "m_pInGameMoneyServices");
		}

#region Main Methods
		private static MemoryFunctionVoid<nint, nint, int, short, short> _stateChanged = new(@"\x55\x48\x89\xE5\x41\x57\x41\x56\x41\x55\x41\x54\x53\x89\xD3");
		private static MemoryFunctionVoid<nint, int, long> _networkStateChanged = new(@"\x4C\x8B\x07\x4D\x85\xC0\x74\x2A\x49\x8B\x40\x10");

		private static int FindSchemaChain(string classname) => Schema.GetSchemaOffset(classname, "__m_pChainEntity");

		public static void SetStateChanged(CBaseEntity entity, string classname, string fieldName, int extraOffset = 0)
		{
			int offset = Schema.GetSchemaOffset(classname, fieldName);
			int chainOffset = FindSchemaChain(classname);

			if (chainOffset != 0)
			{
				_networkStateChanged.Invoke(entity.Handle + chainOffset, offset, 0xFFFFFFFF);
				return; // No need to execute the rest of the things
			}

			_stateChanged.Invoke(entity.NetworkTransmitComponent.Handle, entity.Handle, offset + extraOffset, -1, -1);

			entity.LastNetworkChange = Server.CurrentTime;
			entity.IsSteadyState.Clear();
		}
#endregion
	}
}
