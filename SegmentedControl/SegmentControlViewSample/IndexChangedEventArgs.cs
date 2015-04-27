using System;

namespace SegmentControlViewSample
{
	public class IndexChangedEventArgs : EventArgs
	{
		public IndexChangedEventArgs ()
		{
		}

		public int OldValue { get; set; }

		public int NewValue{ get; set; }
	}
}

