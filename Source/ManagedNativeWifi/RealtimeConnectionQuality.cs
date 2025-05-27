using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static ManagedNativeWifi.Win32.NativeMethod;

namespace ManagedNativeWifi
{
	/// <summary>
	/// Realtime connection quality information
	/// </summary>
	public class RealtimeConnectionQuality
	{
		/// <summary>
		/// PHY type
		/// </summary>
		public PhyType PhyType { get; }

		/// <summary>
		/// Link quality (0-100)
		/// </summary>
		public uint LinkQuality { get; }

		/// <summary>
		/// Receive rate (kbps)
		/// </summary>
		public uint RxRate { get; }

		/// <summary>
		/// Transmit rate (kbps)
		/// </summary>
		public uint TxRate { get; }

		/// <summary>
		/// Multi-Link connection
		/// </summary>
		public bool MultiLinkConnection { get; }

		/// <summary>
		/// Links
		/// </summary>
		public IReadOnlyList<RealtimeConnectionQualityLink> Links { get; }

		/// <summary>
		/// Constructor
		/// </summary>
		public RealtimeConnectionQuality(PhyType phyType, uint linkQuality, uint rxRate, uint txRate, bool multiLinkConnection, IEnumerable<RealtimeConnectionQualityLink> links)
		{
			this.PhyType = phyType;
			this.LinkQuality = linkQuality;
			this.RxRate = rxRate;
			this.TxRate = txRate;
			this.MultiLinkConnection = multiLinkConnection;
			this.Links = Array.AsReadOnly(links?.ToArray() ?? Array.Empty<RealtimeConnectionQualityLink>());
		}

		internal RealtimeConnectionQuality(WLAN_REALTIME_CONNECTION_QUALITY quality)
		{
			PhyType = PhyTypeConverter.Convert(quality.dot11PhyType);
			LinkQuality = quality.ulLinkQuality;
			RxRate = quality.ulRxRate;
			TxRate = quality.ulTxRate;
			MultiLinkConnection = quality.bIsMLOConnection;
			Links = quality.LinksInfo?.Select(x => new RealtimeConnectionQualityLink(x)).ToArray() ?? Array.Empty<RealtimeConnectionQualityLink>();
		}
	}
}