﻿using basitsatinalimuyg.Entities;

namespace basitsatinalimuyg.Models
{
	public class AddressViewModel : BaseViewModel
	{
		public string? AddressTitle { get; set; }
		public string? AddressLine { get; set; }
		public string? City { get; set; }
		public string? Country { get; set; }
		public string? PostalCode { get; set; }
	}
}
