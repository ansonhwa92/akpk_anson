﻿using FEP.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FEP.WebApiModel.eEvent
{
	public class EventRefundModel
	{
		public EventRefundModel() { }
		public int Id { get; set; }

		[Required]
		[Display(Name = "RefundEventId", ResourceType = typeof(Language.EventRefund))]
		public int? EventId { get; set; }

		[Display(Name = "RefundEventName", ResourceType = typeof(Language.EventRefund))]
		public string EventName { get; set; }

		[Required]
		[Display(Name = "RefundUserId", ResourceType = typeof(Language.EventRefund))]
		public int? UserId { get; set; }

		[Display(Name = "RefundUserName", ResourceType = typeof(Language.EventRefund))]
		public string UserName { get; set; }

		[Required]
		[Display(Name = "RefundBankInformationId", ResourceType = typeof(Language.EventRefund))]
		public int? BankInformationId { get; set; }

		[Display(Name = "RefundBankInformationName", ResourceType = typeof(Language.EventRefund))]
		public string BankInformationName { get; set; }

		[Required(ErrorMessage = "Please insert Account Number")]
		[Display(Name = "RefundAccountNumber", ResourceType = typeof(Language.EventRefund))]
		public string AccountNumber { get; set; }



		public IEnumerable<SelectListItem> UserIds { get; set; } 
		public IEnumerable<SelectListItem> BankInformationIds { get; set; }
		public IEnumerable<SelectListItem> EventIds { get; set; }
	}


	public class FilterEventRefundModel : DataTableModel 
	{
		[Display(Name = "RefundEventId", ResourceType = typeof(Language.EventRefund))]
		public int? EventId { get; set; }

		[Display(Name = "RefundEventName", ResourceType = typeof(Language.EventRefund))]
		public string EventName { get; set; }

		[Display(Name = "RefundUserId", ResourceType = typeof(Language.EventRefund))]
		public int? UserId { get; set; }

		[Display(Name = "RefundUserName", ResourceType = typeof(Language.EventRefund))]
		public string UserName { get; set; }

		[Display(Name = "RefundBankInformationId", ResourceType = typeof(Language.EventRefund))]
		public int? BankInformationId { get; set; }

		[Display(Name = "RefundBankInformationName", ResourceType = typeof(Language.EventRefund))]
		public int? BankInformationName { get; set; }

		[Display(Name = "RefundAccountNumber", ResourceType = typeof(Language.EventRefund))]
		public string AccountNumber { get; set; }


		public IEnumerable<SelectListItem> UserIds { get; set; }
		public IEnumerable<SelectListItem> BankInformationIds { get; set; }
		public IEnumerable<SelectListItem> EventIds { get; set; }
	}


	public class ListEventRefundModel
	{
		public FilterEventRefundModel Filter { get; set; }

		public EventRefundModel List { get; set; }
	}

	public class CreateEventRefundModel : EventRefundModel
	{
		public CreateEventRefundModel() { } 	
	}

	public class EditEventRefundModel : CreateEventRefundModel
	{
		public EditEventRefundModel() { }
	}

	public class DetailsEventRefundModel : EventRefundModel
	{
		public DetailsEventRefundModel() { }
	}

	public class DeleteEventRefundModel : DetailsEventRefundModel
	{
		public DeleteEventRefundModel() { } 
	}

}