using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class GenericCategory
{
    public int Id { get; set; }

    public string? Category { get; set; }

    public string? CategoryDisplayName { get; set; }

    public string? Stakeholder { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual ICollection<GenericCategoryPrivilege> GenericCategoryPrivileges { get; set; } = new List<GenericCategoryPrivilege>();

    public virtual ICollection<OrgCategoryPrivilege> OrgCategoryPrivileges { get; set; } = new List<OrgCategoryPrivilege>();
}
