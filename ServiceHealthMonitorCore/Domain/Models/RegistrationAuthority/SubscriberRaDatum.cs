using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class SubscriberRaDatum
{
    public string SubscriberUid { get; set; } = null!;

    public string CommonName { get; set; } = null!;

    public string CountryName { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string CertificateType { get; set; } = null!;

    public string PkiPassword { get; set; } = null!;

    public string PkiPasswordHash { get; set; } = null!;

    public string PkiUserName { get; set; } = null!;

    public string PkiUserNameHash { get; set; } = null!;

    public DateTime? UpdatedDate { get; set; }
}
