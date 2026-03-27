using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class OrgSubscriberEmail
{
    public int OrgContactsId { get; set; }

    public string? OrganizationUid { get; set; }

    public string? EmployeeEmail { get; set; }

    public bool? IsEsealSignatory { get; set; }

    public bool? IsEsealPreparatory { get; set; }

    public bool? IsOrgSignatory { get; set; }

    public string? Designation { get; set; }

    public string? SignaturePhoto { get; set; }

    public sbyte? IsTemplate { get; set; }

    public sbyte? IsBulkSign { get; set; }

    public string? UgpassEmail { get; set; }

    public string? PassportNumber { get; set; }

    public string? NationalIdNumber { get; set; }

    public string? MobileNumber { get; set; }

    public sbyte? UgpassUserLinkApproved { get; set; }

    public string? SubscriberUid { get; set; }

    public string? Status { get; set; }

    public sbyte? IsDelegate { get; set; }

    public string? ShortSignature { get; set; }

    public virtual OrganizationDetail? OrganizationU { get; set; }
}
