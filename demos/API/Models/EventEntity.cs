namespace Orwell.API.Models {
    using System;
    using Microsoft.WindowsAzure.Storage.Table;

    public class EventEntity : TableEntity {
		public EventEntity() {
		}

		public EventEntity(DateTime eventDate) {
			PartitionKey = eventDate.ToString("yyyy-MM-dd");
			RowKey = eventDate.ToString().Replace("/", "-");
			Timestamp = eventDate;
			Date = eventDate;
		}

		public DateTime Date { get; set; }
		public string Message { get; set; }
		public string User { get; set; }
	}
}
