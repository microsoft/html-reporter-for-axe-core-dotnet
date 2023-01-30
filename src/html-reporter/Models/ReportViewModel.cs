// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Deque.AxeCore.Commons;
using System.Globalization;

namespace AxeCore.HTMLReporter.Models
{
	/// <summary>
	/// View Model for Report markup
	/// </summary>
	public sealed class ReportViewModel
	{
		/// <summary>
		/// Language of the report
		/// </summary>
		public CultureInfo Language { get; }

		/// <summary>
		/// Axe Results
		/// </summary>
		public AxeResult Results { get; } 

		/// <summary>
		/// Constructor
		/// </summary>
		internal ReportViewModel(CultureInfo language, AxeResult results)
		{
			Language= language;
			Results= results;
		}
	}
}
