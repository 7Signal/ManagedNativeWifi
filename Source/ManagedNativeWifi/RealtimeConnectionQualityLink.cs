using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static ManagedNativeWifi.Win32.NativeMethod;

namespace ManagedNativeWifi
{
	/// <summary>
	/// Realtime connection quality link information
	/// </summary>
	public class RealtimeConnectionQualityLink
	{
		/// <summary>
		/// Link ID
		/// </summary>
		public byte LinkId { get; }

		/// <summary>
		/// Frequency (MHz)
		/// </summary>
		public uint Frequency { get; }

		/// <summary>
		/// Bandwidth (MHz)
		/// </summary>
		public uint Bandwidth { get; }

		/// <summary>
		/// Rssi (dBm)
		/// </summary>
		public int Rssi { get; }

		/// <summary>
		/// Constructor
		/// </summary>
		public RealtimeConnectionQualityLink(byte linkId, uint frequency, uint bandwidth, int rssi)
		{
			this.LinkId = linkId;
			this.Frequency = frequency;
			this.Bandwidth = bandwidth;
			this.Rssi = rssi;
		}

		internal RealtimeConnectionQualityLink(WLAN_REALTIME_CONNECTION_QUALITY_LINK_INFO info)
		{
			LinkId = info.ucLinkID;
			Frequency = info.ulChannelCenterFrequencyMhz;
			Bandwidth = info.ulBandwidth;
			Rssi = info.lRssi;
		}
	}
}