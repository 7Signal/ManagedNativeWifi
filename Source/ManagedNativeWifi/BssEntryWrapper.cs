using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ManagedNativeWifi.Win32.NativeMethod;

namespace ManagedNativeWifi
{
	/// <summary>
	/// Wrapper for native WLAN_BSS_ENTRY struct
	/// </summary>
	internal class BssEntryWrapper
	{
		/// <summary>
		/// BSS entry
		/// </summary>
		internal WLAN_BSS_ENTRY BssEntry { get; }

		/// <summary>
		/// IEs
		/// </summary>
		internal byte[] IEs { get; }

		internal BssEntryWrapper(
			WLAN_BSS_ENTRY bssEntry,
			byte[] ies)
		{
			this.BssEntry = bssEntry;
			this.IEs = ies;
		}
	}
}
