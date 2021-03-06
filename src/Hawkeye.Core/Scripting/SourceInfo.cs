﻿using System.Collections.Generic;

namespace Hawkeye.Scripting
{
	public class SourceInfo
	{
		public SourceInfo()
		{
			this.Usings = new List<string>();
			this.References = new List<string>();
		}

		public string SourceCode { get; set; }
		public List<string> Usings { get; set; }
		public List<string> References { get; set; }
	}
}
