using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static ManagedNativeWifi.Win32.NativeMethod;

namespace ManagedNativeWifi
{
	/// <summary>
	/// Corresponds to native WLAN_BSS_LIST struct
	/// </summary>
	internal class BssEntryWrapperList
	{
		/// <summary>
		/// Total size (bytes)
		/// </summary>
		internal uint DwTotalSize { get; }

		/// <summary>
		/// Number of items
		/// </summary>
		internal uint DwNumberOfItems { get; }

		/// <summary>
		/// BSS entry wrappers
		/// </summary>
		internal BssEntryWrapper[] BssEntryWrappers { get; }

		internal BssEntryWrapperList(IntPtr ppWlanBssList)
		{
			var uintSize = Marshal.SizeOf<uint>(); // 4

			WLAN_BSS_LIST bssList = new WLAN_BSS_LIST(ppWlanBssList);
			this.DwTotalSize = bssList.dwTotalSize;
			this.DwNumberOfItems = bssList.dwNumberOfItems;
			this.BssEntryWrappers = new BssEntryWrapper[bssList.dwNumberOfItems];

			for (int i = 0; i < bssList.dwNumberOfItems; i++)
			{
				var bssEntry = bssList.wlanBssEntries[i];
				var ppIe = new IntPtr(ppWlanBssList.ToInt64()
					+ (uintSize * 2) /* Offset for dwTotalSize and dwNumberOfItems */
					+ (Marshal.SizeOf<WLAN_BSS_ENTRY>() * i) /* Offset for preceding items */
					+ bssEntry.ulIeOffset /* Offset for IEs */);

				this.BssEntryWrappers[i] = new BssEntryWrapper(
					bssEntry: bssEntry,
					ies: new byte[bssEntry.ulIeSize]);
				Marshal.Copy(ppIe, this.BssEntryWrappers[i].IEs, 0, (int)bssEntry.ulIeSize);
			}
		}
	}
}
