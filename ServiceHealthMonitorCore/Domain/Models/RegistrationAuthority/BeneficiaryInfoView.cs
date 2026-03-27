using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class BeneficiaryInfoView
{
    public int BeneficiaryId { get; set; }

    public string? SponsorName { get; set; }

    public string? BeneficiaryName { get; set; }

    public string SponsorDigitalId { get; set; } = null!;

    public string SponsorType { get; set; } = null!;

    public string? SponsorExternalId { get; set; }

    public string? BeneficiaryDigitalId { get; set; }

    public string BeneficiaryType { get; set; } = null!;

    public int? SponsorPaymentPriorityLevel { get; set; }

    public string? BeneficiaryNin { get; set; }

    public string? BeneficiaryPassport { get; set; }

    public string? BeneficiaryMobileNumber { get; set; }

    public string? BeneficiaryOfficeEmail { get; set; }

    public string? BeneficiaryUgpassEmail { get; set; }

    public sbyte BeneficiaryConsentAcquired { get; set; }

    public string? SignaturePhoto { get; set; }

    public string? Designation { get; set; }

    public string? BeneficiaryStatus { get; set; }

    public DateTime? BeneficiaryCreatedOn { get; set; }

    public DateTime? BeneficiaryUpdatedOn { get; set; }

    public int ValidityId { get; set; }

    public int? PrivilegeServiceId { get; set; }

    public sbyte? ValidityApplicable { get; set; }

    public DateTime? ValidFrom { get; set; }

    public DateTime? ValidUpto { get; set; }

    public string? ValidityStatus { get; set; }

    public DateTime? ValidityCreatedOn { get; set; }

    public DateTime? ValidityUpdatedOn { get; set; }

    public int PrivilegeId { get; set; }

    public string PrivilegeServiceName { get; set; } = null!;

    public string? PrivilegeServiceDisplayName { get; set; }

    public string? PrivilegeStatus { get; set; }

    public sbyte? IsChargeable { get; set; }
}
