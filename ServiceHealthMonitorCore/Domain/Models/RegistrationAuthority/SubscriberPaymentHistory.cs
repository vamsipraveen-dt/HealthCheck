using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class SubscriberPaymentHistory
{
    public string SubscriberSuid { get; set; } = null!;

    public string PaymentInfo { get; set; } = null!;

    public double TotalAmount { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public string? PaymentCategory { get; set; }

    public string? SubscriberStatus { get; set; }

    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// if payment done for organization
    /// </summary>
    public string? OrganizationId { get; set; }

    public string TransactionReferenceId { get; set; } = null!;
}
