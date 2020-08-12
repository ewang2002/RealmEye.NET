﻿using System.Collections.Generic;
using RealmEyeNET.Constants;

namespace RealmEyeNET.Definition
{
	public class NameHistoryData
	{
		public ApiStatusCode Status { get; set; }
		public IList<NameHistoryEntry> NameHistory { get; set; }
	}

	public class NameHistoryEntry
	{
		public string Name { get; set; }
		public string From { get; set; }
		public string To { get; set; }
	}
}