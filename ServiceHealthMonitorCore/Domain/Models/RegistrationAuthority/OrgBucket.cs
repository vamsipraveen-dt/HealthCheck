using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class OrgBucket
{
    public int Id { get; set; }

    public string BucketId { get; set; } = null!;

    public int BucketConfigurationId { get; set; }

    public int? TotalDigitalSignatures { get; set; }

    public int? TotalEseal { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? Status { get; set; }

    public string? LastSignatoryId { get; set; }

    public string? SponsorId { get; set; }

    public DateTime? PaymentRecievedOn { get; set; }

    public sbyte PaymentRecieved { get; set; }

    public int? AdditionalDsremaining { get; set; }

    public int? AdditionalEdsremaining { get; set; }

    public virtual OrgBucketsConfig BucketConfiguration { get; set; } = null!;
}
