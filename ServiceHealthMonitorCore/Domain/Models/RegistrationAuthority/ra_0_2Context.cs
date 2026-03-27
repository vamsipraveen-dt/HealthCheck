using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class ra_0_2Context : DbContext
{
    public ra_0_2Context()
    {
    }

    public ra_0_2Context(DbContextOptions<ra_0_2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AppConfig> AppConfigs { get; set; }

    public virtual DbSet<Beneficiary> Beneficiaries { get; set; }

    public virtual DbSet<BeneficiaryInfoView> BeneficiaryInfoViews { get; set; }

    public virtual DbSet<BeneficiaryValidity> BeneficiaryValidities { get; set; }

    public virtual DbSet<CertificateCountView> CertificateCountViews { get; set; }

    public virtual DbSet<Consent> Consents { get; set; }

    public virtual DbSet<ConsentHistory> ConsentHistories { get; set; }

    public virtual DbSet<DevicePolicy> DevicePolicies { get; set; }

    public virtual DbSet<FaceThreshold> FaceThresholds { get; set; }

    public virtual DbSet<GenericCategory> GenericCategories { get; set; }

    public virtual DbSet<GenericCategoryPrivilege> GenericCategoryPrivileges { get; set; }

    public virtual DbSet<GetAllTemplate> GetAllTemplates { get; set; }

    public virtual DbSet<HibernateSequence> HibernateSequences { get; set; }

    public virtual DbSet<MapMethodOnboardingStep> MapMethodOnboardingSteps { get; set; }

    public virtual DbSet<OnboardingLiveliness> OnboardingLivelinesses { get; set; }

    public virtual DbSet<OnboardingMethod> OnboardingMethods { get; set; }

    public virtual DbSet<OnboardingStep> OnboardingSteps { get; set; }

    public virtual DbSet<OnboardingStepDetail> OnboardingStepDetails { get; set; }

    public virtual DbSet<OrgBucket> OrgBuckets { get; set; }

    public virtual DbSet<OrgBucketsConfig> OrgBucketsConfigs { get; set; }

    public virtual DbSet<OrgCategoryPrivilege> OrgCategoryPrivileges { get; set; }

    public virtual DbSet<OrgCertificateEmailCounter> OrgCertificateEmailCounters { get; set; }

    public virtual DbSet<OrgClientAppConfig> OrgClientAppConfigs { get; set; }

    public virtual DbSet<OrgEmailDomain> OrgEmailDomains { get; set; }

    public virtual DbSet<OrgSignatureTemplate> OrgSignatureTemplates { get; set; }

    public virtual DbSet<OrgSubscriberEmail> OrgSubscriberEmails { get; set; }

    public virtual DbSet<OrganizationCertificate> OrganizationCertificates { get; set; }

    public virtual DbSet<OrganizationCertificateLifeCycle> OrganizationCertificateLifeCycles { get; set; }

    public virtual DbSet<OrganizationDetail> OrganizationDetails { get; set; }

    public virtual DbSet<OrganizationDirector> OrganizationDirectors { get; set; }

    public virtual DbSet<OrganizationDocument> OrganizationDocuments { get; set; }

    public virtual DbSet<OrganizationDocumentCheck> OrganizationDocumentChecks { get; set; }

    public virtual DbSet<OrganizationStatus> OrganizationStatuses { get; set; }

    public virtual DbSet<OrganizationWrappedKey> OrganizationWrappedKeys { get; set; }

    public virtual DbSet<PhotoFeature> PhotoFeatures { get; set; }

    public virtual DbSet<PhotoFeaturesView> PhotoFeaturesViews { get; set; }

    public virtual DbSet<Privilege> Privileges { get; set; }

    public virtual DbSet<SignatureTemplate> SignatureTemplates { get; set; }

    public virtual DbSet<SignatureTemplatesDetail> SignatureTemplatesDetails { get; set; }

    public virtual DbSet<SoftwareLicense> SoftwareLicenses { get; set; }

    public virtual DbSet<SoftwareLicenseApprovalRequest> SoftwareLicenseApprovalRequests { get; set; }

    public virtual DbSet<SoftwareLicensesHistory> SoftwareLicensesHistories { get; set; }

    public virtual DbSet<Subscriber> Subscribers { get; set; }

    public virtual DbSet<SubscriberCertificate> SubscriberCertificates { get; set; }

    public virtual DbSet<SubscriberCertificateLifeCycle> SubscriberCertificateLifeCycles { get; set; }

    public virtual DbSet<SubscriberCertificatePinHistory> SubscriberCertificatePinHistories { get; set; }

    public virtual DbSet<SubscriberCertificatesDetail> SubscriberCertificatesDetails { get; set; }

    public virtual DbSet<SubscriberCompleteDetail> SubscriberCompleteDetails { get; set; }

    public virtual DbSet<SubscriberConsent> SubscriberConsents { get; set; }

    public virtual DbSet<SubscriberContactHistory> SubscriberContactHistories { get; set; }

    public virtual DbSet<SubscriberCountView> SubscriberCountViews { get; set; }

    public virtual DbSet<SubscriberDevice> SubscriberDevices { get; set; }

    public virtual DbSet<SubscriberDevicesHistory> SubscriberDevicesHistories { get; set; }

    public virtual DbSet<SubscriberFcmToken> SubscriberFcmTokens { get; set; }

    public virtual DbSet<SubscriberIdDocCount> SubscriberIdDocCounts { get; set; }

    public virtual DbSet<SubscriberInfo> SubscriberInfos { get; set; }

    public virtual DbSet<SubscriberOnboardingDatum> SubscriberOnboardingData { get; set; }

    public virtual DbSet<SubscriberOnboardingTemplate> SubscriberOnboardingTemplates { get; set; }

    public virtual DbSet<SubscriberPaymentHistory> SubscriberPaymentHistories { get; set; }

    public virtual DbSet<SubscriberRaDatum> SubscriberRaData { get; set; }

    public virtual DbSet<SubscriberStatus> SubscriberStatuses { get; set; }

    public virtual DbSet<SubscriberView> SubscriberViews { get; set; }

    public virtual DbSet<SubscriberWrappedKey> SubscriberWrappedKeys { get; set; }

    public virtual DbSet<SusbcriberDetail> SusbcriberDetails { get; set; }

    public virtual DbSet<TemporaryTable> TemporaryTables { get; set; }

    public virtual DbSet<TrustedUser> TrustedUsers { get; set; }

    public virtual DbSet<ViewClientApp> ViewClientApps { get; set; }

    public virtual DbSet<ViewOrgUserEmailList> ViewOrgUserEmailLists { get; set; }

    public virtual DbSet<ViewOrgsMini> ViewOrgsMinis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=164.52.214.184;port=4436;user=dt;password=dt@2021;database=ra_0_2", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AppConfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("app_config");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LatestVersion)
                .HasMaxLength(45)
                .HasColumnName("latest_version");
            entity.Property(e => e.MinimumVersion)
                .HasMaxLength(45)
                .HasColumnName("minimum_version");
            entity.Property(e => e.OsVersion)
                .HasMaxLength(45)
                .HasColumnName("os_version");
            entity.Property(e => e.UpdateLink)
                .HasMaxLength(250)
                .HasColumnName("updateLink");
        });

        modelBuilder.Entity<Beneficiary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("beneficiaries");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BeneficiaryConsentAcquired).HasColumnName("beneficiary_consent_acquired");
            entity.Property(e => e.BeneficiaryDigitalId)
                .HasMaxLength(100)
                .HasColumnName("beneficiary_digital_id");
            entity.Property(e => e.BeneficiaryMobileNumber)
                .HasMaxLength(100)
                .HasColumnName("beneficiary_mobile_number");
            entity.Property(e => e.BeneficiaryName)
                .HasMaxLength(100)
                .HasColumnName("beneficiary_name");
            entity.Property(e => e.BeneficiaryNin)
                .HasMaxLength(100)
                .HasColumnName("beneficiary_nin");
            entity.Property(e => e.BeneficiaryOfficeEmail)
                .HasMaxLength(100)
                .HasColumnName("beneficiary_office_email");
            entity.Property(e => e.BeneficiaryPassport)
                .HasMaxLength(100)
                .HasColumnName("beneficiary_passport");
            entity.Property(e => e.BeneficiaryType)
                .HasMaxLength(100)
                .HasColumnName("beneficiary_type");
            entity.Property(e => e.BeneficiaryUgpassEmail)
                .HasMaxLength(100)
                .HasColumnName("beneficiary_ugpass_email");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.Designation)
                .HasMaxLength(100)
                .HasColumnName("designation");
            entity.Property(e => e.SignaturePhoto).HasColumnName("signature_photo");
            entity.Property(e => e.SponsorDigitalId)
                .HasMaxLength(100)
                .HasColumnName("sponsor_digital_id");
            entity.Property(e => e.SponsorExternalId)
                .HasMaxLength(100)
                .HasColumnName("sponsor_external_id");
            entity.Property(e => e.SponsorName)
                .HasMaxLength(100)
                .HasColumnName("sponsor_name");
            entity.Property(e => e.SponsorPaymentPriorityLevel).HasColumnName("sponsor_payment_priority_level");
            entity.Property(e => e.SponsorType)
                .HasMaxLength(100)
                .HasColumnName("sponsor_type");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");
        });

        modelBuilder.Entity<BeneficiaryInfoView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("beneficiary_info_view");

            entity.Property(e => e.BeneficiaryConsentAcquired).HasColumnName("beneficiary_consent_acquired");
            entity.Property(e => e.BeneficiaryCreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("beneficiary_created_on");
            entity.Property(e => e.BeneficiaryDigitalId)
                .HasMaxLength(100)
                .HasColumnName("beneficiary_digital_id");
            entity.Property(e => e.BeneficiaryId).HasColumnName("beneficiary_id");
            entity.Property(e => e.BeneficiaryMobileNumber)
                .HasMaxLength(100)
                .HasColumnName("beneficiary_mobile_number");
            entity.Property(e => e.BeneficiaryName)
                .HasMaxLength(100)
                .HasColumnName("beneficiary_name");
            entity.Property(e => e.BeneficiaryNin)
                .HasMaxLength(100)
                .HasColumnName("beneficiary_nin");
            entity.Property(e => e.BeneficiaryOfficeEmail)
                .HasMaxLength(100)
                .HasColumnName("beneficiary_office_email");
            entity.Property(e => e.BeneficiaryPassport)
                .HasMaxLength(100)
                .HasColumnName("beneficiary_passport");
            entity.Property(e => e.BeneficiaryStatus)
                .HasMaxLength(100)
                .HasColumnName("beneficiary_status");
            entity.Property(e => e.BeneficiaryType)
                .HasMaxLength(100)
                .HasColumnName("beneficiary_type");
            entity.Property(e => e.BeneficiaryUgpassEmail)
                .HasMaxLength(100)
                .HasColumnName("beneficiary_ugpass_email");
            entity.Property(e => e.BeneficiaryUpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("beneficiary_updated_on");
            entity.Property(e => e.Designation)
                .HasMaxLength(100)
                .HasColumnName("designation");
            entity.Property(e => e.IsChargeable).HasColumnName("is_chargeable");
            entity.Property(e => e.PrivilegeId).HasColumnName("privilege_id");
            entity.Property(e => e.PrivilegeServiceDisplayName)
                .HasMaxLength(100)
                .HasColumnName("privilege_service_display_name");
            entity.Property(e => e.PrivilegeServiceId).HasColumnName("privilege_service_id");
            entity.Property(e => e.PrivilegeServiceName)
                .HasMaxLength(100)
                .HasColumnName("privilege_service_name");
            entity.Property(e => e.PrivilegeStatus)
                .HasMaxLength(20)
                .HasColumnName("privilege_status");
            entity.Property(e => e.SignaturePhoto).HasColumnName("signature_photo");
            entity.Property(e => e.SponsorDigitalId)
                .HasMaxLength(100)
                .HasColumnName("sponsor_digital_id");
            entity.Property(e => e.SponsorExternalId)
                .HasMaxLength(100)
                .HasColumnName("sponsor_external_id");
            entity.Property(e => e.SponsorName)
                .HasMaxLength(100)
                .HasColumnName("sponsor_name");
            entity.Property(e => e.SponsorPaymentPriorityLevel).HasColumnName("sponsor_payment_priority_level");
            entity.Property(e => e.SponsorType)
                .HasMaxLength(100)
                .HasColumnName("sponsor_type");
            entity.Property(e => e.ValidFrom)
                .HasColumnType("datetime")
                .HasColumnName("valid_from");
            entity.Property(e => e.ValidUpto)
                .HasColumnType("datetime")
                .HasColumnName("valid_upto");
            entity.Property(e => e.ValidityApplicable).HasColumnName("validity_applicable");
            entity.Property(e => e.ValidityCreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("validity_created_on");
            entity.Property(e => e.ValidityId).HasColumnName("validity_id");
            entity.Property(e => e.ValidityStatus)
                .HasMaxLength(100)
                .HasColumnName("validity_status");
            entity.Property(e => e.ValidityUpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("validity_updated_on");
        });

        modelBuilder.Entity<BeneficiaryValidity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("beneficiary_validity");

            entity.HasIndex(e => e.BeneficiaryId, "beneficiary_validity_FK");

            entity.HasIndex(e => e.PrivilegeServiceId, "beneficiary_validity_FK_1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BeneficiaryId).HasColumnName("beneficiary_id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.PrivilegeServiceId).HasColumnName("privilege_service_id");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");
            entity.Property(e => e.ValidFrom)
                .HasColumnType("datetime")
                .HasColumnName("valid_from");
            entity.Property(e => e.ValidUpto)
                .HasColumnType("datetime")
                .HasColumnName("valid_upto");
            entity.Property(e => e.ValidityApplicable).HasColumnName("validity_applicable");

            entity.HasOne(d => d.Beneficiary).WithMany(p => p.BeneficiaryValidities)
                .HasForeignKey(d => d.BeneficiaryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("beneficiary_validity_FK");

            entity.HasOne(d => d.PrivilegeService).WithMany(p => p.BeneficiaryValidities)
                .HasForeignKey(d => d.PrivilegeServiceId)
                .HasConstraintName("beneficiary_validity_FK_1");
        });

        modelBuilder.Entity<CertificateCountView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("certificate_count_view");

            entity.Property(e => e.ActiveCertCount).HasColumnName("active_cert_count");
            entity.Property(e => e.CertCount).HasColumnName("cert_count");
            entity.Property(e => e.ExpiredCertCount).HasColumnName("expired_cert_count");
            entity.Property(e => e.RevokeCertCount).HasColumnName("revoke_cert_count");
        });

        modelBuilder.Entity<Consent>(entity =>
        {
            entity.HasKey(e => e.ConsentId).HasName("PRIMARY");

            entity
                .ToTable("consent")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.ConsentId).HasColumnName("consent_id");
            entity.Property(e => e.Consent1).HasColumnName("consent");
            entity.Property(e => e.ConsentType)
                .HasMaxLength(100)
                .HasColumnName("consent_type");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.PrivacyConsent)
                .HasColumnType("text")
                .HasColumnName("privacy_consent");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");
        });

        modelBuilder.Entity<ConsentHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("consent_history");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Consent).HasColumnName("consent");
            entity.Property(e => e.ConsentId).HasColumnName("consent_id");
            entity.Property(e => e.ConsentRequired).HasColumnName("consent_required");
            entity.Property(e => e.ConsentType)
                .HasMaxLength(100)
                .HasColumnName("consent_type");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_On");
            entity.Property(e => e.OptionalDataAndPrivacy).HasColumnName("optional_data_and_privacy");
            entity.Property(e => e.OptionalTermsAndConditions).HasColumnName("optional_terms_and_conditions");
            entity.Property(e => e.PrivacyConsent).HasColumnName("privacy_consent");
        });

        modelBuilder.Entity<DevicePolicy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("device_policy");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DeviceChangePolicyHour).HasColumnName("device_change_policy_hour");
        });

        modelBuilder.Entity<FaceThreshold>(entity =>
        {
            entity.HasKey(e => e.MapMethodOnboardingStepId).HasName("PRIMARY");

            entity.ToTable("face_threshold");

            entity.Property(e => e.MapMethodOnboardingStepId).HasColumnName("map_method_onboarding_step_id");
            entity.Property(e => e.AndriodDttThreshold).HasColumnName("andriod_dtt_threshold");
            entity.Property(e => e.AndroidDlibThreshold).HasColumnName("android_dlib_threshold");
            entity.Property(e => e.AndroidTfliteThreshold).HasColumnName("android_tflite_threshold");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.IntegrationUrl)
                .HasMaxLength(128)
                .HasColumnName("integration_url");
            entity.Property(e => e.IosDlibThreshold).HasColumnName("ios_dlib_threshold");
            entity.Property(e => e.IosDttThreshold).HasColumnName("ios_dtt_threshold");
            entity.Property(e => e.IosTfliteThreshold).HasColumnName("ios_tflite_threshold");
            entity.Property(e => e.MethodName)
                .HasMaxLength(36)
                .HasColumnName("method_name");
            entity.Property(e => e.OnboardingStep)
                .HasMaxLength(36)
                .HasColumnName("onboarding_step");
            entity.Property(e => e.OnboardingStepThreshold).HasColumnName("onboarding_step_threshold");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.TemplateId).HasColumnName("template_id");
            entity.Property(e => e.WebDttThreshold).HasColumnName("web_dtt_threshold");
        });

        modelBuilder.Entity<GenericCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("generic_categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category)
                .HasMaxLength(20)
                .HasColumnName("category");
            entity.Property(e => e.CategoryDisplayName)
                .HasMaxLength(20)
                .HasColumnName("category_display_name");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.Stakeholder)
                .HasMaxLength(20)
                .HasColumnName("stakeholder");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");
        });

        modelBuilder.Entity<GenericCategoryPrivilege>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("generic_category_privileges");

            entity.HasIndex(e => e.CategoryId, "generic_category_privileges_FK");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.Privilege)
                .HasMaxLength(50)
                .HasColumnName("privilege");
            entity.Property(e => e.PrivilegeDisplayName)
                .HasMaxLength(50)
                .HasColumnName("privilege_display_name");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");

            entity.HasOne(d => d.Category).WithMany(p => p.GenericCategoryPrivileges)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("generic_category_privileges_FK");
        });

        modelBuilder.Entity<GetAllTemplate>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("get_all_template");

            entity.Property(e => e.ApprovedBy)
                .HasMaxLength(255)
                .HasColumnName("approved_by")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .HasColumnName("created_by")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.PublishedStatus)
                .HasMaxLength(16)
                .HasColumnName("published_status")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Remarks)
                .HasMaxLength(255)
                .HasColumnName("remarks")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.State)
                .HasMaxLength(16)
                .HasColumnName("state")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.TemplateId).HasColumnName("template_id");
            entity.Property(e => e.TemplateMethod)
                .HasMaxLength(32)
                .HasColumnName("template_method")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.TemplateName)
                .HasMaxLength(32)
                .HasColumnName("template_name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.UpatedDate)
                .HasColumnType("datetime")
                .HasColumnName("upated_date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .HasColumnName("updated_by")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
        });

        modelBuilder.Entity<HibernateSequence>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("hibernate_sequence")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.NextVal).HasColumnName("next_val");
        });

        modelBuilder.Entity<MapMethodOnboardingStep>(entity =>
        {
            entity.HasKey(e => e.MapMethodOnboardingStepId).HasName("PRIMARY");

            entity
                .ToTable("map_method_onboarding_steps")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.TemplateId, "map_method_onboarding_steps_FK");

            entity.HasIndex(e => e.OnboardingStep, "map_method_onboarding_steps_FK_1");

            entity.Property(e => e.MapMethodOnboardingStepId).HasColumnName("map_method_onboarding_step_id");
            entity.Property(e => e.AndriodDttThreshold).HasColumnName("andriod_dtt_threshold");
            entity.Property(e => e.AndroidTfliteThreshold).HasColumnName("android_tflite_threshold");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.IntegrationUrl)
                .HasMaxLength(128)
                .HasColumnName("integration_url");
            entity.Property(e => e.IosDttThreshold).HasColumnName("ios_dtt_threshold");
            entity.Property(e => e.IosTfliteThreshold).HasColumnName("ios_tflite_threshold");
            entity.Property(e => e.MethodName)
                .HasMaxLength(32)
                .HasColumnName("method_name");
            entity.Property(e => e.OnboardingStep)
                .HasMaxLength(32)
                .HasColumnName("onboarding_step");
            entity.Property(e => e.OnboardingStepThreshold).HasColumnName("onboarding_step_threshold");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.TemplateId).HasColumnName("template_id");

            entity.HasOne(d => d.OnboardingStepNavigation).WithMany(p => p.MapMethodOnboardingSteps)
                .HasPrincipalKey(p => p.OnboardingStep1)
                .HasForeignKey(d => d.OnboardingStep)
                .HasConstraintName("map_method_onboarding_steps_FK_1");

            entity.HasOne(d => d.Template).WithMany(p => p.MapMethodOnboardingSteps)
                .HasForeignKey(d => d.TemplateId)
                .HasConstraintName("map_method_onboarding_steps_FK");
        });

        modelBuilder.Entity<OnboardingLiveliness>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.SubscriberUid })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity
                .ToTable("onboarding_liveliness")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.SubscriberUid)
                .HasMaxLength(50)
                .HasColumnName("subscriber_uid");
            entity.Property(e => e.File)
                .HasMaxLength(100)
                .HasColumnName("file");
            entity.Property(e => e.RecordedGeoLocation)
                .HasMaxLength(50)
                .HasColumnName("recorded_geo_location");
            entity.Property(e => e.RecordedTime)
                .HasMaxLength(50)
                .HasColumnName("recorded_time");
            entity.Property(e => e.TypeOfService)
                .HasMaxLength(50)
                .HasColumnName("type_of_service");
            entity.Property(e => e.Url)
                .HasMaxLength(600)
                .HasColumnName("url");
            entity.Property(e => e.VerificationFirst)
                .HasMaxLength(50)
                .HasColumnName("verification_first");
            entity.Property(e => e.VerificationSecond)
                .HasMaxLength(50)
                .HasColumnName("verification_second");
            entity.Property(e => e.VerificationThird)
                .HasMaxLength(50)
                .HasColumnName("verification_third");
        });

        modelBuilder.Entity<OnboardingMethod>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("onboarding_methods")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.OnboardingMethod1, "onboarding_methods_un").IsUnique();

            entity.Property(e => e.IdDocumentType)
                .HasMaxLength(16)
                .HasColumnName("id_document_type");
            entity.Property(e => e.LevelOfAssurance)
                .HasMaxLength(16)
                .HasColumnName("level_of_assurance");
            entity.Property(e => e.OnboardingMethod1)
                .HasMaxLength(16)
                .HasColumnName("onboarding_method");
            entity.Property(e => e.OnboardingMethodId).HasColumnName("onboarding_method_id");
            entity.Property(e => e.SubscriberType)
                .HasMaxLength(16)
                .HasColumnName("subscriber_type");
        });

        modelBuilder.Entity<OnboardingStep>(entity =>
        {
            entity.HasKey(e => e.OnboardingStepId).HasName("PRIMARY");

            entity
                .ToTable("onboarding_steps")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.OnboardingStep1, "onboarding_steps_un").IsUnique();

            entity.Property(e => e.OnboardingStepId)
                .ValueGeneratedNever()
                .HasColumnName("onboarding_step_id");
            entity.Property(e => e.AndriodDttThreshold).HasColumnName("andriod_dtt_threshold");
            entity.Property(e => e.AndroidTfliteThreshold).HasColumnName("android_tflite_threshold");
            entity.Property(e => e.IntegrationUrl)
                .HasMaxLength(128)
                .HasColumnName("integration_url");
            entity.Property(e => e.IosDttThreshold).HasColumnName("ios_dtt_threshold");
            entity.Property(e => e.IosTfliteThreshold).HasColumnName("ios_tflite_threshold");
            entity.Property(e => e.OnboardingStep1)
                .HasMaxLength(32)
                .HasColumnName("onboarding_step");
            entity.Property(e => e.OnboardingStepDisplayName)
                .HasMaxLength(32)
                .HasColumnName("onboarding_step_display_name");
            entity.Property(e => e.OnboardingStepThreshold).HasColumnName("onboarding_step_threshold");
        });

        modelBuilder.Entity<OnboardingStepDetail>(entity =>
        {
            entity.HasKey(e => e.StepId).HasName("PRIMARY");

            entity.ToTable("onboarding_step_details");

            entity.Property(e => e.StepId)
                .ValueGeneratedNever()
                .HasColumnName("step_id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasColumnName("status");
            entity.Property(e => e.StepDescription)
                .HasMaxLength(100)
                .HasColumnName("step_description");
            entity.Property(e => e.StepName)
                .HasMaxLength(100)
                .HasColumnName("step_name");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");
        });

        modelBuilder.Entity<OrgBucket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("org_buckets");

            entity.HasIndex(e => e.BucketId, "bucket_details_un").IsUnique();

            entity.HasIndex(e => e.BucketConfigurationId, "org_buckets_FK");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdditionalDsremaining).HasColumnName("additionalDSRemaining");
            entity.Property(e => e.AdditionalEdsremaining).HasColumnName("additionalEDSRemaining");
            entity.Property(e => e.BucketConfigurationId).HasColumnName("bucket_configuration_id");
            entity.Property(e => e.BucketId)
                .HasMaxLength(100)
                .HasColumnName("bucket_id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.LastSignatoryId)
                .HasMaxLength(100)
                .HasColumnName("last_signatory_id");
            entity.Property(e => e.PaymentRecieved).HasColumnName("payment_recieved");
            entity.Property(e => e.PaymentRecievedOn)
                .HasColumnType("datetime")
                .HasColumnName("payment_recieved_on");
            entity.Property(e => e.SponsorId)
                .HasMaxLength(100)
                .HasColumnName("sponsor_id");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasColumnName("status");
            entity.Property(e => e.TotalDigitalSignatures).HasColumnName("total_digital_signatures");
            entity.Property(e => e.TotalEseal).HasColumnName("total_eseal");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");

            entity.HasOne(d => d.BucketConfiguration).WithMany(p => p.OrgBuckets)
                .HasForeignKey(d => d.BucketConfigurationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("org_buckets_FK");
        });

        modelBuilder.Entity<OrgBucketsConfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("org_buckets_config");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdditionalDs).HasColumnName("additional_ds");
            entity.Property(e => e.AdditionalEds).HasColumnName("additional_eds");
            entity.Property(e => e.AppId)
                .HasMaxLength(100)
                .HasColumnName("app_id");
            entity.Property(e => e.BucketClosingMessage)
                .HasMaxLength(100)
                .HasColumnName("bucket_closing_message");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.Label)
                .HasMaxLength(100)
                .HasColumnName("label");
            entity.Property(e => e.OrgId)
                .HasMaxLength(100)
                .HasColumnName("org_id");
            entity.Property(e => e.OrgName)
                .HasMaxLength(100)
                .HasColumnName("org_name");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");
        });

        modelBuilder.Entity<OrgCategoryPrivilege>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("org_category_privileges");

            entity.HasIndex(e => e.CategoryId, "org_category_privileges_FK");

            entity.HasIndex(e => e.PrivlegeId, "org_category_privileges_FK_1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.OrganizationUid)
                .HasMaxLength(100)
                .HasColumnName("organization_uid");
            entity.Property(e => e.PrivlegeId).HasColumnName("privlege_id");
            entity.Property(e => e.PrivlegeStatus).HasColumnName("privlege_status");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");

            entity.HasOne(d => d.Category).WithMany(p => p.OrgCategoryPrivileges)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("org_category_privileges_FK");

            entity.HasOne(d => d.Privlege).WithMany(p => p.OrgCategoryPrivileges)
                .HasForeignKey(d => d.PrivlegeId)
                .HasConstraintName("org_category_privileges_FK_1");
        });

        modelBuilder.Entity<OrgCertificateEmailCounter>(entity =>
        {
            entity.HasKey(e => e.OrganizationUid).HasName("PRIMARY");

            entity.ToTable("org_certificate_email_counter");

            entity.Property(e => e.OrganizationUid)
                .HasMaxLength(100)
                .HasColumnName("organization_uid");
            entity.Property(e => e.Counter0Day)
                .HasMaxLength(45)
                .HasColumnName("counter_0_day");
            entity.Property(e => e.Counter10Day)
                .HasMaxLength(45)
                .HasColumnName("counter_10_day");
            entity.Property(e => e.Counter15Day)
                .HasMaxLength(45)
                .HasColumnName("counter_15_day");
            entity.Property(e => e.Counter5Day)
                .HasMaxLength(45)
                .HasColumnName("counter_5_day");
            entity.Property(e => e.OrganizationName)
                .HasMaxLength(100)
                .HasColumnName("organization_name");
            entity.Property(e => e.SpocUgpassEmail)
                .HasMaxLength(100)
                .HasColumnName("spoc_ugpass_email");
        });

        modelBuilder.Entity<OrgClientAppConfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("org_client_app_config");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppId)
                .HasMaxLength(100)
                .HasColumnName("app_id");
            entity.Property(e => e.ConfigValue)
                .HasMaxLength(100)
                .HasColumnName("config_value");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.OrgId)
                .HasMaxLength(100)
                .HasColumnName("org_id");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");
        });

        modelBuilder.Entity<OrgEmailDomain>(entity =>
        {
            entity.HasKey(e => e.OrgDomainId).HasName("PRIMARY");

            entity.ToTable("org_email_domains");

            entity.HasIndex(e => e.OrganizationUid, "org_email_domains_FK");

            entity.Property(e => e.OrgDomainId).HasColumnName("org_domain_id");
            entity.Property(e => e.CreatedOn)
                .HasMaxLength(100)
                .HasColumnName("created_on");
            entity.Property(e => e.EmailDomain)
                .HasMaxLength(100)
                .HasColumnName("email_domain");
            entity.Property(e => e.OrganizationUid)
                .HasMaxLength(100)
                .HasColumnName("organization_uid");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedOn)
                .HasMaxLength(100)
                .HasColumnName("updated_on");

            entity.HasOne(d => d.OrganizationU).WithMany(p => p.OrgEmailDomains)
                .HasPrincipalKey(p => p.OrganizationUid)
                .HasForeignKey(d => d.OrganizationUid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("org_email_domains_FK");
        });

        modelBuilder.Entity<OrgSignatureTemplate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("org_signature_templates");

            entity.HasIndex(e => e.OrganizationUid, "org_signature_templates_FK");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrganizationUid)
                .HasMaxLength(100)
                .HasColumnName("organization_uid");
            entity.Property(e => e.TemplateId).HasColumnName("template_id");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .HasColumnName("type");

            entity.HasOne(d => d.OrganizationU).WithMany(p => p.OrgSignatureTemplates)
                .HasPrincipalKey(p => p.OrganizationUid)
                .HasForeignKey(d => d.OrganizationUid)
                .HasConstraintName("org_signature_templates_FK");
        });

        modelBuilder.Entity<OrgSubscriberEmail>(entity =>
        {
            entity.HasKey(e => e.OrgContactsId).HasName("PRIMARY");

            entity.ToTable("org_subscriber_email");

            entity.HasIndex(e => e.OrganizationUid, "org_subscriber_email_FK");

            entity.Property(e => e.OrgContactsId).HasColumnName("org_contacts_id");
            entity.Property(e => e.Designation)
                .HasMaxLength(100)
                .HasColumnName("designation");
            entity.Property(e => e.EmployeeEmail)
                .HasMaxLength(255)
                .HasColumnName("employee_email");
            entity.Property(e => e.IsBulkSign).HasColumnName("is_bulk_sign");
            entity.Property(e => e.IsDelegate).HasColumnName("is_delegate");
            entity.Property(e => e.IsEsealPreparatory).HasColumnName("is_eseal_preparatory");
            entity.Property(e => e.IsEsealSignatory).HasColumnName("is_eseal_signatory");
            entity.Property(e => e.IsOrgSignatory).HasColumnName("is_org_signatory");
            entity.Property(e => e.IsTemplate).HasColumnName("is_template");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(100)
                .HasColumnName("mobile_number");
            entity.Property(e => e.NationalIdNumber)
                .HasMaxLength(100)
                .HasColumnName("national_id_number");
            entity.Property(e => e.OrganizationUid)
                .HasMaxLength(100)
                .HasColumnName("organization_uid");
            entity.Property(e => e.PassportNumber)
                .HasMaxLength(100)
                .HasColumnName("passport_number");
            entity.Property(e => e.ShortSignature).HasColumnName("short_signature");
            entity.Property(e => e.SignaturePhoto).HasColumnName("signature_photo");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .HasColumnName("status");
            entity.Property(e => e.SubscriberUid)
                .HasMaxLength(100)
                .HasColumnName("subscriber_uid");
            entity.Property(e => e.UgpassEmail)
                .HasMaxLength(100)
                .HasColumnName("ugpass_email");
            entity.Property(e => e.UgpassUserLinkApproved).HasColumnName("ugpass_user_link_approved");

            entity.HasOne(d => d.OrganizationU).WithMany(p => p.OrgSubscriberEmails)
                .HasPrincipalKey(p => p.OrganizationUid)
                .HasForeignKey(d => d.OrganizationUid)
                .HasConstraintName("org_subscriber_email_FK");
        });

        modelBuilder.Entity<OrganizationCertificate>(entity =>
        {
            entity.HasKey(e => e.CertificateSerialNumber).HasName("PRIMARY");

            entity.ToTable("organization_certificates");

            entity.HasIndex(e => e.OrganizationUid, "organization_certificates_FK");

            entity.HasIndex(e => new { e.CertificateStatus, e.OrganizationUid }, "organization_certificates_certificate_status_IDX");

            entity.HasIndex(e => e.PkiKeyId, "pki_key_id_UNIQUE").IsUnique();

            entity.Property(e => e.CertificateSerialNumber)
                .HasMaxLength(500)
                .HasColumnName("certificate_serial_number");
            entity.Property(e => e.CerificateExpiryDate)
                .HasMaxLength(6)
                .HasColumnName("cerificate_expiry_date");
            entity.Property(e => e.CertificateData)
                .HasMaxLength(8048)
                .HasColumnName("certificate_data");
            entity.Property(e => e.CertificateIssueDate)
                .HasMaxLength(6)
                .HasColumnName("certificate_issue_date");
            entity.Property(e => e.CertificateStatus)
                .HasMaxLength(45)
                .HasColumnName("certificate_status");
            entity.Property(e => e.CertificateType)
                .HasMaxLength(100)
                .HasColumnName("certificate_type");
            entity.Property(e => e.CreatedDate)
                .HasMaxLength(6)
                .HasColumnName("created_date");
            entity.Property(e => e.OrganizationUid)
                .HasMaxLength(45)
                .HasColumnName("organization_uid");
            entity.Property(e => e.PkiKeyId)
                .HasMaxLength(200)
                .HasColumnName("pki_key_id");
            entity.Property(e => e.Remarks)
                .HasMaxLength(128)
                .HasColumnName("remarks");
            entity.Property(e => e.TransactionReferenceId)
                .HasMaxLength(100)
                .HasColumnName("transaction_reference_id");
            entity.Property(e => e.UpdatedDate)
                .HasMaxLength(6)
                .HasColumnName("updated_date");
            entity.Property(e => e.WrappedKey)
                .HasMaxLength(5000)
                .HasColumnName("wrapped_key");

            entity.HasOne(d => d.OrganizationU).WithMany(p => p.OrganizationCertificates)
                .HasPrincipalKey(p => p.OrganizationUid)
                .HasForeignKey(d => d.OrganizationUid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("organization_certificates_FK");
        });

        modelBuilder.Entity<OrganizationCertificateLifeCycle>(entity =>
        {
            entity.HasKey(e => e.OrganizationCertificateLifeCycleId).HasName("PRIMARY");

            entity.ToTable("organization_certificate_life_cycle");

            entity.HasIndex(e => e.OrganizationUid, "organization_certificate_life_cycle_FK");

            entity.Property(e => e.OrganizationCertificateLifeCycleId).HasColumnName("organization_certificate_life_cycle_id");
            entity.Property(e => e.CertificateSerialNumber)
                .HasMaxLength(500)
                .HasColumnName("certificate_serial_number");
            entity.Property(e => e.CertificateStatus)
                .HasMaxLength(16)
                .HasColumnName("certificate_status");
            entity.Property(e => e.CertificateType)
                .HasMaxLength(100)
                .HasColumnName("certificate_type");
            entity.Property(e => e.CreatedDate)
                .HasMaxLength(6)
                .HasColumnName("created_date");
            entity.Property(e => e.OrganizationUid)
                .HasMaxLength(45)
                .HasColumnName("organization_uid");
            entity.Property(e => e.RevocationReason)
                .HasMaxLength(128)
                .HasColumnName("revocation_reason");

            entity.HasOne(d => d.OrganizationU).WithMany(p => p.OrganizationCertificateLifeCycles)
                .HasPrincipalKey(p => p.OrganizationUid)
                .HasForeignKey(d => d.OrganizationUid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("organization_certificate_life_cycle_FK");
        });

        modelBuilder.Entity<OrganizationDetail>(entity =>
        {
            entity.HasKey(e => e.OrganizationDetailsId).HasName("PRIMARY");

            entity.ToTable("organization_details");

            entity.HasIndex(e => e.OrganizationUid, "organization_details_UN").IsUnique();

            entity.Property(e => e.OrganizationDetailsId).HasColumnName("organization_details_id");
            entity.Property(e => e.AgentUrl)
                .HasMaxLength(100)
                .HasColumnName("agent_url");
            entity.Property(e => e.AuthorizedLetterForSignatories).HasColumnName("authorized_letter_for_signatories");
            entity.Property(e => e.CorporateOfficeAddress)
                .HasMaxLength(500)
                .HasColumnName("corporate_office_address");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasMaxLength(100)
                .HasColumnName("created_on");
            entity.Property(e => e.ESealImage).HasColumnName("e_seal_image");
            entity.Property(e => e.EnablePostPaidOption).HasColumnName("enable_post_paid_option");
            entity.Property(e => e.IncorporationFile).HasColumnName("incorporation_file");
            entity.Property(e => e.OrgName)
                .HasMaxLength(100)
                .HasColumnName("org_name");
            entity.Property(e => e.OrganizationEmail)
                .HasMaxLength(100)
                .HasColumnName("organization_email");
            entity.Property(e => e.OrganizationSegments)
                .HasMaxLength(100)
                .HasColumnName("organization_segments");
            entity.Property(e => e.OrganizationStatus)
                .HasMaxLength(100)
                .HasColumnName("organization_status");
            entity.Property(e => e.OrganizationUid)
                .HasMaxLength(100)
                .HasColumnName("organization_uid");
            entity.Property(e => e.OtherEsealDocument).HasColumnName("other_eseal_document");
            entity.Property(e => e.OtherLegalDocument).HasColumnName("other_legal_document");
            entity.Property(e => e.SignedPdf).HasColumnName("signed_pdf");
            entity.Property(e => e.SpocUgpassEmail)
                .HasMaxLength(100)
                .HasColumnName("spoc_ugpass_email");
            entity.Property(e => e.TaxFile).HasColumnName("tax_file");
            entity.Property(e => e.TaxNo)
                .HasMaxLength(100)
                .HasColumnName("tax_no");
            entity.Property(e => e.UniqueRegdNo)
                .HasMaxLength(100)
                .HasColumnName("unique_regd_no");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedOn)
                .HasMaxLength(100)
                .HasColumnName("updated_on");
        });

        modelBuilder.Entity<OrganizationDirector>(entity =>
        {
            entity.HasKey(e => e.OrganizationDirectorsId).HasName("PRIMARY");

            entity.ToTable("organization_directors");

            entity.HasIndex(e => e.OrganizationUid, "organization_directors_FK");

            entity.Property(e => e.OrganizationDirectorsId).HasColumnName("organization_directors_id");
            entity.Property(e => e.DirectorsEmails)
                .HasColumnType("text")
                .HasColumnName("directors_emails");
            entity.Property(e => e.OrganizationUid)
                .HasMaxLength(100)
                .HasColumnName("organization_uid");

            entity.HasOne(d => d.OrganizationU).WithMany(p => p.OrganizationDirectors)
                .HasPrincipalKey(p => p.OrganizationUid)
                .HasForeignKey(d => d.OrganizationUid)
                .HasConstraintName("organization_directors_FK");
        });

        modelBuilder.Entity<OrganizationDocument>(entity =>
        {
            entity.HasKey(e => e.OrganizationDocumentsId).HasName("PRIMARY");

            entity.ToTable("organization_documents");

            entity.HasIndex(e => e.OrganizationUid, "organization_documents_FK");

            entity.Property(e => e.OrganizationDocumentsId).HasColumnName("organization_documents_id");
            entity.Property(e => e.AnyOtherDoc)
                .HasMaxLength(100)
                .HasColumnName("any_other_doc");
            entity.Property(e => e.ESealImage)
                .HasMaxLength(100)
                .HasColumnName("e_seal_image");
            entity.Property(e => e.IncorporationFile)
                .HasMaxLength(100)
                .HasColumnName("incorporation_file");
            entity.Property(e => e.OrgDetailsPdf)
                .HasMaxLength(100)
                .HasColumnName("org_details_pdf");
            entity.Property(e => e.OrganizationUid)
                .HasMaxLength(100)
                .HasColumnName("organization_uid");
            entity.Property(e => e.TaxFile)
                .HasMaxLength(100)
                .HasColumnName("tax_file");

            entity.HasOne(d => d.OrganizationU).WithMany(p => p.OrganizationDocuments)
                .HasPrincipalKey(p => p.OrganizationUid)
                .HasForeignKey(d => d.OrganizationUid)
                .HasConstraintName("organization_documents_FK");
        });

        modelBuilder.Entity<OrganizationDocumentCheck>(entity =>
        {
            entity.HasKey(e => e.OrganizationDocCheckId).HasName("PRIMARY");

            entity.ToTable("organization_document_check");

            entity.HasIndex(e => e.OrganizationUid, "organization_document_check_FK");

            entity.Property(e => e.OrganizationDocCheckId).HasColumnName("organizationDoc_check_id");
            entity.Property(e => e.DocumentCheckBox)
                .HasMaxLength(100)
                .HasColumnName("document_check_box");
            entity.Property(e => e.OrganizationUid)
                .HasMaxLength(100)
                .HasColumnName("organization_uid");

            entity.HasOne(d => d.OrganizationU).WithMany(p => p.OrganizationDocumentChecks)
                .HasPrincipalKey(p => p.OrganizationUid)
                .HasForeignKey(d => d.OrganizationUid)
                .HasConstraintName("organization_document_check_FK");
        });

        modelBuilder.Entity<OrganizationStatus>(entity =>
        {
            entity.HasKey(e => e.OrganizationStatusId).HasName("PRIMARY");

            entity.ToTable("organization_status");

            entity.HasIndex(e => e.OrganizationUid, "organization_status_FK");

            entity.Property(e => e.OrganizationStatusId).HasColumnName("organization_status_id");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.OrganizationStatus1)
                .HasMaxLength(100)
                .HasColumnName("organization_status");
            entity.Property(e => e.OrganizationStatusDescription)
                .HasMaxLength(255)
                .HasColumnName("organization_status_description");
            entity.Property(e => e.OrganizationUid)
                .HasMaxLength(100)
                .HasColumnName("organization_uid");
            entity.Property(e => e.OtpVerifiedStatus)
                .HasMaxLength(100)
                .HasColumnName("otp_verified_status");
            entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");

            entity.HasOne(d => d.OrganizationU).WithMany(p => p.OrganizationStatuses)
                .HasPrincipalKey(p => p.OrganizationUid)
                .HasForeignKey(d => d.OrganizationUid)
                .HasConstraintName("organization_status_FK");
        });

        modelBuilder.Entity<OrganizationWrappedKey>(entity =>
        {
            entity.HasKey(e => e.CertificateSerialNumber).HasName("PRIMARY");

            entity.ToTable("organization_wrapped_key");

            entity.Property(e => e.CertificateSerialNumber)
                .HasMaxLength(500)
                .HasColumnName("certificate_serial_number");
            entity.Property(e => e.WrappedKey)
                .HasMaxLength(5000)
                .HasColumnName("wrapped_key");
        });

        modelBuilder.Entity<PhotoFeature>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("photo_features");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.PhotoFeatures)
                .HasColumnType("blob")
                .HasColumnName("photo_features");
            entity.Property(e => e.SubscriberUid)
                .HasMaxLength(100)
                .HasColumnName("subscriber_uid");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");
        });

        modelBuilder.Entity<PhotoFeaturesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("photo_features_view");

            entity.Property(e => e.PhotoFeatures)
                .HasColumnType("blob")
                .HasColumnName("photo_features");
            entity.Property(e => e.PhotoFeaturesId).HasColumnName("photo_features_id");
        });

        modelBuilder.Entity<Privilege>(entity =>
        {
            entity.HasKey(e => e.PrivilegeId).HasName("PRIMARY");

            entity.ToTable("privilege");

            entity.Property(e => e.PrivilegeId).HasColumnName("privilege_id");
            entity.Property(e => e.IsChargeable).HasColumnName("is_chargeable");
            entity.Property(e => e.PrivilegeServiceDisplayName)
                .HasMaxLength(100)
                .HasColumnName("privilege_service_display_name");
            entity.Property(e => e.PrivilegeServiceName)
                .HasMaxLength(100)
                .HasColumnName("privilege_service_name");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
        });

        modelBuilder.Entity<SignatureTemplate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("signature_templates");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(100)
                .HasColumnName("display_name");
            entity.Property(e => e.SamplePreview).HasColumnName("sample_preview");
            entity.Property(e => e.TemplateId)
                .HasMaxLength(100)
                .HasColumnName("template_id");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .HasColumnName("type");
        });

        modelBuilder.Entity<SignatureTemplatesDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("signature_templates_details");

            entity.Property(e => e.Designation)
                .HasMaxLength(100)
                .HasColumnName("designation");
            entity.Property(e => e.OrgName)
                .HasMaxLength(100)
                .HasColumnName("org_name");
            entity.Property(e => e.OrganizationUid)
                .HasMaxLength(100)
                .HasColumnName("organization_uid");
            entity.Property(e => e.SamplePreview).HasColumnName("sample_preview");
            entity.Property(e => e.SignaturePhoto).HasColumnName("signature_photo");
            entity.Property(e => e.TemplateId).HasColumnName("template_id");
        });

        modelBuilder.Entity<SoftwareLicense>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("software_licenses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicationName)
                .HasMaxLength(100)
                .HasColumnName("application_name");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("created_date_time");
            entity.Property(e => e.FirstActivated)
                .HasMaxLength(100)
                .HasColumnName("first_activated");
            entity.Property(e => e.IssuedOn)
                .HasColumnType("datetime")
                .HasColumnName("issued_on");
            entity.Property(e => e.LastActivated)
                .HasMaxLength(100)
                .HasColumnName("last_activated");
            entity.Property(e => e.LicenceStatus)
                .HasMaxLength(100)
                .HasColumnName("licence_status");
            entity.Property(e => e.LicenseInfo).HasColumnName("license_info");
            entity.Property(e => e.LicenseType)
                .HasMaxLength(100)
                .HasColumnName("license_type");
            entity.Property(e => e.OrgName)
                .HasMaxLength(100)
                .HasColumnName("org_name");
            entity.Property(e => e.Ouid)
                .HasMaxLength(100)
                .HasColumnName("ouid");
            entity.Property(e => e.SoftwareName)
                .HasMaxLength(100)
                .HasColumnName("software_name");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("updated_date_time");
            entity.Property(e => e.ValidUpto)
                .HasColumnType("datetime")
                .HasColumnName("valid_upto");
        });

        modelBuilder.Entity<SoftwareLicenseApprovalRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("software_license_approval_requests");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApprovalStatus)
                .HasMaxLength(50)
                .HasColumnName("approval_status");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("created_date_time");
            entity.Property(e => e.LicenseType)
                .HasMaxLength(50)
                .HasColumnName("license_type");
            entity.Property(e => e.Ouid)
                .HasMaxLength(100)
                .HasColumnName("ouid");
            entity.Property(e => e.SoftwareName)
                .HasMaxLength(100)
                .HasColumnName("software_name");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("updated_date_time");
        });

        modelBuilder.Entity<SoftwareLicensesHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("software_licenses_history");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("created_date_time");
            entity.Property(e => e.IssuedOn)
                .HasColumnType("datetime")
                .HasColumnName("issued_on");
            entity.Property(e => e.LicenseInfo).HasColumnName("license_info");
            entity.Property(e => e.LicenseType)
                .HasMaxLength(100)
                .HasColumnName("license_type");
            entity.Property(e => e.Ouid)
                .HasMaxLength(100)
                .HasColumnName("ouid");
            entity.Property(e => e.SoftwareName)
                .HasMaxLength(100)
                .HasColumnName("software_name");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("updated_date_time");
            entity.Property(e => e.ValidUpto)
                .HasColumnType("datetime")
                .HasColumnName("valid_upto");
        });

        modelBuilder.Entity<Subscriber>(entity =>
        {
            entity.HasKey(e => e.SubscriberId).HasName("PRIMARY");

            entity
                .ToTable("subscribers")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.EmailId, "subscribers_email_UN").IsUnique();

            entity.HasIndex(e => e.IdDocNumber, "subscribers_id_doc_number_IDX");

            entity.HasIndex(e => e.MobileNumber, "subscribers_mobno_UN").IsUnique();

            entity.HasIndex(e => e.NationalId, "subscribers_national_id").IsUnique();

            entity.HasIndex(e => e.SubscriberUid, "subscribers_un").IsUnique();

            entity.Property(e => e.SubscriberId).HasColumnName("subscriber_id");
            entity.Property(e => e.AppVersion)
                .HasMaxLength(100)
                .HasColumnName("app_version");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("datetime")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.DeviceInfo)
                .HasMaxLength(100)
                .HasColumnName("device_info");
            entity.Property(e => e.EmailId)
                .HasMaxLength(64)
                .HasColumnName("email_id");
            entity.Property(e => e.FullName)
                .HasMaxLength(128)
                .HasColumnName("full_name");
            entity.Property(e => e.IdDocNumber)
                .HasMaxLength(100)
                .HasColumnName("id_doc_number");
            entity.Property(e => e.IdDocType)
                .HasMaxLength(16)
                .HasColumnName("id_doc_type");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(16)
                .HasColumnName("mobile_number");
            entity.Property(e => e.NationalId)
                .HasMaxLength(100)
                .HasColumnName("national_id");
            entity.Property(e => e.OsName)
                .HasMaxLength(36)
                .HasColumnName("os_name");
            entity.Property(e => e.OsVersion)
                .HasMaxLength(100)
                .HasColumnName("os_version");
            entity.Property(e => e.SubscriberUid)
                .HasMaxLength(36)
                .HasColumnName("subscriber_uid");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updated_date");
        });

        modelBuilder.Entity<SubscriberCertificate>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("subscriber_certificates")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.PkiKeyId, "UK_b7wip0t9axf5w1egnjwiw77qp").IsUnique();

            entity.HasIndex(e => new { e.SubscriberUid, e.CertificateStatus }, "subscriber_certificates_subscriber_uid_IDX");

            entity.Property(e => e.CerificateExpiryDate)
                .HasColumnType("datetime")
                .HasColumnName("cerificate_expiry_date");
            entity.Property(e => e.CertificateData)
                .HasMaxLength(4096)
                .HasColumnName("certificate_data");
            entity.Property(e => e.CertificateIssueDate)
                .HasColumnType("datetime")
                .HasColumnName("certificate_issue_date");
            entity.Property(e => e.CertificateSerialNumber)
                .HasMaxLength(100)
                .HasColumnName("certificate_serial_number");
            entity.Property(e => e.CertificateStatus)
                .HasMaxLength(16)
                .HasColumnName("certificate_status");
            entity.Property(e => e.CertificateType)
                .HasMaxLength(16)
                .HasColumnName("certificate_type");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.PkiKeyId)
                .HasMaxLength(36)
                .HasColumnName("pki_key_id");
            entity.Property(e => e.Remarks)
                .HasMaxLength(128)
                .HasColumnName("remarks");
            entity.Property(e => e.SubscriberUid)
                .HasMaxLength(36)
                .HasColumnName("subscriber_uid");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updated_date");
        });

        modelBuilder.Entity<SubscriberCertificateLifeCycle>(entity =>
        {
            entity.HasKey(e => e.SubscriberCertificateLifeCycleId).HasName("PRIMARY");

            entity
                .ToTable("subscriber_certificate_life_cycle")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.SubscriberCertificateLifeCycleId).HasColumnName("subscriber_certificate_life_cycle_id");
            entity.Property(e => e.CertificateSerialNumber)
                .HasMaxLength(100)
                .HasColumnName("certificate_serial_number");
            entity.Property(e => e.CertificateStatus)
                .HasMaxLength(16)
                .HasColumnName("certificate_status");
            entity.Property(e => e.CertificateType)
                .HasMaxLength(16)
                .HasColumnName("certificate_type");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.RevocationReason)
                .HasMaxLength(128)
                .HasColumnName("revocation_reason");
            entity.Property(e => e.SubscriberUid)
                .HasMaxLength(36)
                .HasColumnName("subscriber_uid");
        });

        modelBuilder.Entity<SubscriberCertificatePinHistory>(entity =>
        {
            entity.HasKey(e => e.SubscriberCertificatePinHistoryId).HasName("PRIMARY");

            entity
                .ToTable("subscriber_certificate_pin_history")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.SubscriberUid, "UK_qgkg08tei48gwbr2bnap878c7").IsUnique();

            entity.Property(e => e.SubscriberCertificatePinHistoryId).HasColumnName("subscriber_certificate_pin_history_id");
            entity.Property(e => e.AuthPinList)
                .HasMaxLength(255)
                .HasColumnName("auth_pin_list");
            entity.Property(e => e.AuthPinSetDate)
                .HasColumnType("datetime")
                .HasColumnName("auth_pin_set_date");
            entity.Property(e => e.SignPinList)
                .HasMaxLength(255)
                .HasColumnName("sign_pin_list");
            entity.Property(e => e.SignPinSetDate)
                .HasColumnType("datetime")
                .HasColumnName("sign_pin_set_date");
            entity.Property(e => e.SubscriberUid)
                .HasMaxLength(36)
                .HasColumnName("subscriber_uid");
        });

        modelBuilder.Entity<SubscriberCertificatesDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("subscriber_certificates_details");

            entity.Property(e => e.CerificateExpiryDate)
                .HasColumnType("datetime")
                .HasColumnName("cerificate_expiry_date");
            entity.Property(e => e.CertificateIssueDate)
                .HasColumnType("datetime")
                .HasColumnName("certificate_issue_date");
            entity.Property(e => e.CertificateSerialNumber)
                .HasMaxLength(100)
                .HasColumnName("certificate_serial_number")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.CertificateStatus)
                .HasMaxLength(16)
                .HasColumnName("certificate_status")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.CertificateType)
                .HasMaxLength(16)
                .HasColumnName("certificate_type")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.FullName)
                .HasMaxLength(128)
                .HasColumnName("full_name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.IdDocNumber)
                .HasMaxLength(100)
                .HasColumnName("id_doc_number")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.IdDocType)
                .HasMaxLength(16)
                .HasColumnName("id_doc_type")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.OnBoardingMethod)
                .HasMaxLength(16)
                .HasColumnName("on_boarding_method")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.SubscriberUid)
                .HasMaxLength(36)
                .HasColumnName("subscriber_uid")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
        });

        modelBuilder.Entity<SubscriberCompleteDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("subscriber_complete_details");

            entity.Property(e => e.AuthPinSetDate)
                .HasColumnType("datetime")
                .HasColumnName("auth_pin_set_date");
            entity.Property(e => e.CerificateExpiryDate)
                .HasColumnType("datetime")
                .HasColumnName("cerificate_expiry_date");
            entity.Property(e => e.CertificateIssueDate)
                .HasColumnType("datetime")
                .HasColumnName("certificate_issue_date");
            entity.Property(e => e.CertificateSerialNumber)
                .HasMaxLength(100)
                .HasColumnName("certificate_serial_number")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.CertificateStatus)
                .HasMaxLength(16)
                .HasColumnName("certificate_status")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("datetime")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.DeviceRegistrationTime)
                .HasColumnType("datetime")
                .HasColumnName("device_registration_time");
            entity.Property(e => e.DeviceStatus)
                .HasMaxLength(16)
                .HasColumnName("device_status")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.EmailId)
                .HasMaxLength(64)
                .HasColumnName("email_id")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.FullName)
                .HasMaxLength(128)
                .HasColumnName("full_name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Gender)
                .HasMaxLength(16)
                .HasColumnName("gender")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.GeoLocation)
                .HasMaxLength(255)
                .HasColumnName("geo_location")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.IdDocNumber)
                .HasMaxLength(100)
                .HasColumnName("id_doc_number")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.IdDocType)
                .HasMaxLength(16)
                .HasColumnName("id_doc_type")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.LevelOfAssurance)
                .HasMaxLength(16)
                .HasColumnName("level_of_assurance")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(16)
                .HasColumnName("mobile_number")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.OnBoardingMethod)
                .HasMaxLength(16)
                .HasColumnName("on_boarding_method")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.OnBoardingTime)
                .HasColumnType("datetime")
                .HasColumnName("on_boarding_time");
            entity.Property(e => e.RevocationDate)
                .HasColumnType("datetime")
                .HasColumnName("revocation_date");
            entity.Property(e => e.RevocationReason)
                .HasMaxLength(128)
                .HasColumnName("revocation_reason")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.SelfieThumbnailUri)
                .HasColumnName("selfie_thumbnail_uri")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.SelfieUri)
                .HasColumnName("selfie_uri")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.SignPinSetDate)
                .HasColumnType("datetime")
                .HasColumnName("sign_pin_set_date");
            entity.Property(e => e.SubscriberStatus)
                .HasMaxLength(16)
                .HasColumnName("subscriber_status")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.SubscriberType)
                .HasMaxLength(16)
                .HasColumnName("subscriber_type")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.SubscriberUid)
                .HasMaxLength(36)
                .HasColumnName("subscriber_uid")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.VideoType)
                .HasMaxLength(50)
                .HasColumnName("video_type")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.VideoUrl)
                .HasMaxLength(600)
                .HasColumnName("video_url")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
        });

        modelBuilder.Entity<SubscriberConsent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("subscriber_consents");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConsentData).HasColumnName("consent_data");
            entity.Property(e => e.ConsentId).HasColumnName("consent_id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.SignedConsentData).HasColumnName("signed_consent_data");
            entity.Property(e => e.SubscriberUid)
                .HasMaxLength(100)
                .HasColumnName("subscriber_uid");
        });

        modelBuilder.Entity<SubscriberContactHistory>(entity =>
        {
            entity.HasKey(e => e.SubscriberContactHistoryId).HasName("PRIMARY");

            entity
                .ToTable("subscriber_contact_history")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.SubscriberContactHistoryId).HasColumnName("subscriber_contact_history_id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.EmailId)
                .HasMaxLength(64)
                .HasColumnName("email_id");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(16)
                .HasColumnName("mobile_number");
            entity.Property(e => e.SubscriberUid)
                .HasMaxLength(36)
                .HasColumnName("subscriber_uid");
        });

        modelBuilder.Entity<SubscriberCountView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("subscriber_count_view");

            entity.Property(e => e.ActiveSubscriberCount).HasColumnName("active_subscriber_count");
            entity.Property(e => e.CertExpiredSubscriberCount).HasColumnName("cert_expired_subscriber_count");
            entity.Property(e => e.CertRevokeSubscriberCount).HasColumnName("cert_revoke_subscriber_count");
            entity.Property(e => e.DisableSubscriberCount).HasColumnName("disable_subscriber_count");
            entity.Property(e => e.InactiveSubscriberCount).HasColumnName("inactive_subscriber_count");
            entity.Property(e => e.OnboardedSubscriberCount).HasColumnName("onboarded_subscriber_count");
            entity.Property(e => e.RegisteredSubscriberCount).HasColumnName("registered_subscriber_count");
            entity.Property(e => e.SubscriberCount).HasColumnName("subscriber_count");
        });

        modelBuilder.Entity<SubscriberDevice>(entity =>
        {
            entity.HasKey(e => e.SubscriberDeviceId).HasName("PRIMARY");

            entity
                .ToTable("subscriber_devices")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.SubscriberUid, "subscriber_devices_FK");

            entity.Property(e => e.SubscriberDeviceId).HasColumnName("subscriber_device_id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.DeviceStatus)
                .HasMaxLength(16)
                .HasColumnName("device_status");
            entity.Property(e => e.DeviceUid)
                .HasMaxLength(36)
                .HasColumnName("device_uid");
            entity.Property(e => e.SubscriberUid)
                .HasMaxLength(36)
                .HasColumnName("subscriber_uid");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updated_date");

            entity.HasOne(d => d.SubscriberU).WithMany(p => p.SubscriberDevices)
                .HasPrincipalKey(p => p.SubscriberUid)
                .HasForeignKey(d => d.SubscriberUid)
                .HasConstraintName("subscriber_devices_FK");
        });

        modelBuilder.Entity<SubscriberDevicesHistory>(entity =>
        {
            entity.HasKey(e => e.SubscriberDeviceHistoryId).HasName("PRIMARY");

            entity
                .ToTable("subscriber_devices_history")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.SubscriberUid, "subscriber_devices_FK");

            entity.Property(e => e.SubscriberDeviceHistoryId).HasColumnName("subscriber_device_history_id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.DeviceStatus)
                .HasMaxLength(16)
                .HasColumnName("device_status");
            entity.Property(e => e.DeviceUid)
                .HasMaxLength(36)
                .HasColumnName("device_uid");
            entity.Property(e => e.SubscriberUid)
                .HasMaxLength(36)
                .HasColumnName("subscriber_uid");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updated_date");

            entity.HasOne(d => d.SubscriberU).WithMany(p => p.SubscriberDevicesHistories)
                .HasPrincipalKey(p => p.SubscriberUid)
                .HasForeignKey(d => d.SubscriberUid)
                .HasConstraintName("subscriber_devices_FK_copy");
        });

        modelBuilder.Entity<SubscriberFcmToken>(entity =>
        {
            entity.HasKey(e => e.SubscriberFcmTokenId).HasName("PRIMARY");

            entity
                .ToTable("subscriber_fcm_token")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.SubscriberUid, "subscriber_fcm_token_un").IsUnique();

            entity.Property(e => e.SubscriberFcmTokenId).HasColumnName("subscriber_fcm_token_id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.FcmToken)
                .HasMaxLength(255)
                .HasColumnName("fcm_token");
            entity.Property(e => e.SubscriberUid)
                .HasMaxLength(36)
                .HasColumnName("subscriber_uid");

            entity.HasOne(d => d.SubscriberU).WithOne(p => p.SubscriberFcmToken)
                .HasPrincipalKey<Subscriber>(p => p.SubscriberUid)
                .HasForeignKey<SubscriberFcmToken>(d => d.SubscriberUid)
                .HasConstraintName("subscriber_fcm_token_FK");
        });

        modelBuilder.Entity<SubscriberIdDocCount>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("subscriber_id_doc_count");

            entity.Property(e => e.CountIdDocNumber).HasColumnName("count(id_doc_number)");
        });

        modelBuilder.Entity<SubscriberInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("subscriber_info");

            entity.Property(e => e.DisplayName)
                .HasMaxLength(128)
                .HasColumnName("display_name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .HasColumnName("email")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.FcmToken)
                .HasMaxLength(255)
                .HasColumnName("fcm_token")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(16)
                .HasColumnName("mobile_number")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.SubscriberStatus)
                .HasMaxLength(16)
                .HasColumnName("subscriber_status")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.SubscriberUid)
                .HasMaxLength(36)
                .HasColumnName("subscriber_uid")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
        });

        modelBuilder.Entity<SubscriberOnboardingDatum>(entity =>
        {
            entity.HasKey(e => e.SubscriberOnboardingDataId).HasName("PRIMARY");

            entity
                .ToTable("subscriber_onboarding_data")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.SubscriberUid, "subscriber_onboarding_data_FK");

            entity.Property(e => e.SubscriberOnboardingDataId).HasColumnName("subscriber_onboarding_data_id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.DateOfExpiry)
                .HasMaxLength(100)
                .HasColumnName("date_of_expiry");
            entity.Property(e => e.DocumentsLocation)
                .HasMaxLength(128)
                .HasColumnName("documents_location");
            entity.Property(e => e.Gender)
                .HasMaxLength(16)
                .HasColumnName("gender");
            entity.Property(e => e.Geolocation)
                .HasMaxLength(255)
                .HasColumnName("geolocation");
            entity.Property(e => e.IdDocCode)
                .HasMaxLength(100)
                .HasColumnName("id_doc_code");
            entity.Property(e => e.IdDocNumber)
                .HasMaxLength(100)
                .HasColumnName("id_doc_number");
            entity.Property(e => e.IdDocType)
                .HasMaxLength(16)
                .HasColumnName("id_doc_type");
            entity.Property(e => e.IdDocUri).HasColumnName("id_doc_uri");
            entity.Property(e => e.LevelOfAssurance)
                .HasMaxLength(16)
                .HasColumnName("level_of_assurance");
            entity.Property(e => e.OnboardingDataFieldsJson).HasColumnName("onboarding_data_fields_json");
            entity.Property(e => e.OnboardingMethod)
                .HasMaxLength(16)
                .HasColumnName("onboarding_method");
            entity.Property(e => e.OptionalData1)
                .HasMaxLength(100)
                .HasColumnName("optional_data1");
            entity.Property(e => e.PrevIdDocNumber)
                .HasMaxLength(16)
                .HasColumnName("prev_id_doc_number");
            entity.Property(e => e.Remarks).HasColumnName("remarks");
            entity.Property(e => e.SelfieThumbnailUri).HasColumnName("selfie_thumbnail_uri");
            entity.Property(e => e.SelfieUri).HasColumnName("selfie_uri");
            entity.Property(e => e.SubscriberType)
                .HasMaxLength(16)
                .HasColumnName("subscriber_type");
            entity.Property(e => e.SubscriberUid)
                .HasMaxLength(56)
                .HasColumnName("subscriber_uid");
            entity.Property(e => e.TemplateId).HasColumnName("template_id");

            entity.HasOne(d => d.SubscriberU).WithMany(p => p.SubscriberOnboardingData)
                .HasPrincipalKey(p => p.SubscriberUid)
                .HasForeignKey(d => d.SubscriberUid)
                .HasConstraintName("subscriber_onboarding_data_FK");
        });

        modelBuilder.Entity<SubscriberOnboardingTemplate>(entity =>
        {
            entity.HasKey(e => e.TemplateId).HasName("PRIMARY");

            entity
                .ToTable("subscriber_onboarding_templates")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.TemplateName, "subscriber_onboarding_templates_un").IsUnique();

            entity.Property(e => e.TemplateId).HasColumnName("template_id");
            entity.Property(e => e.ApprovedBy)
                .HasMaxLength(255)
                .HasColumnName("approved_by");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.PublishedStatus)
                .HasMaxLength(16)
                .HasColumnName("published_status");
            entity.Property(e => e.Remarks)
                .HasMaxLength(255)
                .HasColumnName("remarks");
            entity.Property(e => e.State)
                .HasMaxLength(16)
                .HasColumnName("state");
            entity.Property(e => e.TemplateMethod)
                .HasMaxLength(32)
                .HasColumnName("template_method");
            entity.Property(e => e.TemplateName)
                .HasMaxLength(32)
                .HasColumnName("template_name");
            entity.Property(e => e.UpatedDate)
                .HasColumnType("datetime")
                .HasColumnName("upated_date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .HasColumnName("updated_by");
        });

        modelBuilder.Entity<SubscriberPaymentHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("subscriber_payment_history");

            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.OrganizationId)
                .HasMaxLength(100)
                .HasComment("if payment done for organization")
                .HasColumnName("organization_id");
            entity.Property(e => e.PaymentCategory)
                .HasMaxLength(100)
                .HasColumnName("payment_category");
            entity.Property(e => e.PaymentInfo).HasColumnName("payment_info");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(16)
                .HasColumnName("payment_status");
            entity.Property(e => e.SubscriberStatus)
                .HasMaxLength(16)
                .HasColumnName("subscriber_status")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.SubscriberSuid)
                .HasMaxLength(100)
                .HasColumnName("subscriber_suid");
            entity.Property(e => e.TotalAmount).HasColumnName("total_amount");
            entity.Property(e => e.TransactionReferenceId)
                .HasMaxLength(100)
                .HasColumnName("transaction_reference_id");
        });

        modelBuilder.Entity<SubscriberRaDatum>(entity =>
        {
            entity.HasKey(e => e.SubscriberUid).HasName("PRIMARY");

            entity
                .ToTable("subscriber_ra_data")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.SubscriberUid)
                .HasMaxLength(36)
                .HasColumnName("subscriber_uid");
            entity.Property(e => e.CertificateType)
                .HasMaxLength(16)
                .HasColumnName("certificate_type");
            entity.Property(e => e.CommonName)
                .HasMaxLength(36)
                .HasColumnName("common_name");
            entity.Property(e => e.CountryName)
                .HasMaxLength(8)
                .HasColumnName("country_name");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.PkiPassword)
                .HasMaxLength(255)
                .HasColumnName("pki_password");
            entity.Property(e => e.PkiPasswordHash)
                .HasMaxLength(255)
                .HasColumnName("pki_password_hash");
            entity.Property(e => e.PkiUserName)
                .HasMaxLength(255)
                .HasColumnName("pki_user_name");
            entity.Property(e => e.PkiUserNameHash)
                .HasMaxLength(255)
                .HasColumnName("pki_user_name_hash");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updated_date");
        });

        modelBuilder.Entity<SubscriberStatus>(entity =>
        {
            entity.HasKey(e => e.SubscriberStatusId).HasName("PRIMARY");

            entity
                .ToTable("subscriber_status")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.SubscriberUid, "subscriber_status_un").IsUnique();

            entity.Property(e => e.SubscriberStatusId).HasColumnName("subscriber_status_id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.OtpVerifiedStatus)
                .HasMaxLength(16)
                .HasColumnName("otp_verified_status");
            entity.Property(e => e.SubscriberStatus1)
                .HasMaxLength(16)
                .HasColumnName("subscriber_status");
            entity.Property(e => e.SubscriberStatusDescription)
                .HasMaxLength(128)
                .HasColumnName("subscriber_status_description");
            entity.Property(e => e.SubscriberUid)
                .HasMaxLength(36)
                .HasColumnName("subscriber_uid");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updated_date");

            entity.HasOne(d => d.SubscriberU).WithOne(p => p.SubscriberStatus)
                .HasPrincipalKey<Subscriber>(p => p.SubscriberUid)
                .HasForeignKey<SubscriberStatus>(d => d.SubscriberUid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("subscriber_status_FK");
        });

        modelBuilder.Entity<SubscriberView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("subscriber_view");

            entity.Property(e => e.CertificateStatus)
                .HasMaxLength(16)
                .HasColumnName("certificate_status")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Country)
                .HasMaxLength(8)
                .HasColumnName("country")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("datetime")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.DateOfExpiry)
                .HasMaxLength(100)
                .HasColumnName("date_of_expiry")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(128)
                .HasColumnName("display_name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .HasColumnName("email")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.FcmToken)
                .HasMaxLength(255)
                .HasColumnName("fcm_token")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Gender)
                .HasMaxLength(16)
                .HasColumnName("gender")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.IdDocNumber)
                .HasMaxLength(100)
                .HasColumnName("id_doc_number")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.IdDocType)
                .HasMaxLength(16)
                .HasColumnName("id_doc_type")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Loa)
                .HasMaxLength(16)
                .HasColumnName("loa")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(16)
                .HasColumnName("mobile_number")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.OrgEmailsList)
                .HasColumnType("text")
                .HasColumnName("org_emails_list");
            entity.Property(e => e.SelfieUri)
                .HasColumnName("selfie_uri")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.SubscriberStatus)
                .HasMaxLength(16)
                .HasColumnName("subscriber_status")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.SubscriberUid)
                .HasMaxLength(36)
                .HasColumnName("subscriber_uid")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
        });

        modelBuilder.Entity<SubscriberWrappedKey>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("subscriber_wrapped_key")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.CertificateSerialNumber)
                .HasMaxLength(100)
                .HasColumnName("certificate_serial_number");
            entity.Property(e => e.WrappedKey)
                .HasMaxLength(3048)
                .HasColumnName("wrapped_key");
        });

        modelBuilder.Entity<SusbcriberDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("susbcriber_details");

            entity.Property(e => e.AppVersion)
                .HasMaxLength(100)
                .HasColumnName("app_version")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("datetime")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.DeviceInfo)
                .HasMaxLength(100)
                .HasColumnName("device_info")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.DeviceStatus)
                .HasMaxLength(16)
                .HasColumnName("device_status")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.DeviceUid)
                .HasMaxLength(36)
                .HasColumnName("device_uid")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.EmailId)
                .HasMaxLength(64)
                .HasColumnName("email_id")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.FullName)
                .HasMaxLength(128)
                .HasColumnName("full_name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.IdDocNumber)
                .HasMaxLength(100)
                .HasColumnName("id_doc_number")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.IdDocType)
                .HasMaxLength(16)
                .HasColumnName("id_doc_type")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(16)
                .HasColumnName("mobile_number")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.OsName)
                .HasMaxLength(36)
                .HasColumnName("os_name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.OsVersion)
                .HasMaxLength(100)
                .HasColumnName("os_version")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.SubscriberStatus)
                .HasMaxLength(16)
                .HasColumnName("subscriber_status")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.SubscriberUid)
                .HasMaxLength(36)
                .HasColumnName("subscriber_uid")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
        });

        modelBuilder.Entity<TemporaryTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("temporary_table");

            entity.HasIndex(e => e.IdDocNumber, "temporary_table_2_UN").IsUnique();

            entity.HasIndex(e => e.DeviceId, "temporary_table_2_UN_1").IsUnique();

            entity.HasIndex(e => e.OptionalData1, "temporary_table_2_UN_2").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.DeviceId)
                .HasMaxLength(100)
                .HasColumnName("device_id");
            entity.Property(e => e.DeviceInfo).HasColumnName("device_info");
            entity.Property(e => e.IdDocNumber)
                .HasMaxLength(100)
                .HasColumnName("id_doc_number");
            entity.Property(e => e.LivelinessVideo).HasColumnName("liveliness_video");
            entity.Property(e => e.NextStep).HasColumnName("next_step");
            entity.Property(e => e.OptionalData1)
                .HasMaxLength(100)
                .HasColumnName("optional_data1");
            entity.Property(e => e.Selfie).HasColumnName("selfie");
            entity.Property(e => e.Step1Data).HasColumnName("step_1_data");
            entity.Property(e => e.Step1Status)
                .HasMaxLength(100)
                .HasColumnName("step_1_status");
            entity.Property(e => e.Step2Data).HasColumnName("step_2_data");
            entity.Property(e => e.Step2Status)
                .HasMaxLength(100)
                .HasColumnName("step_2_status");
            entity.Property(e => e.Step3Data).HasColumnName("step_3_data");
            entity.Property(e => e.Step3Status)
                .HasMaxLength(100)
                .HasColumnName("step_3_status");
            entity.Property(e => e.Step4Data).HasColumnName("step_4_data");
            entity.Property(e => e.Step4Status)
                .HasMaxLength(100)
                .HasColumnName("step_4_status");
            entity.Property(e => e.Step5Data).HasColumnName("step_5_data");
            entity.Property(e => e.Step5Status)
                .HasMaxLength(100)
                .HasColumnName("step_5_status");
            entity.Property(e => e.StepCompleted).HasColumnName("step_completed");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");
        });

        modelBuilder.Entity<TrustedUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("trusted_users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Mobile)
                .HasMaxLength(100)
                .HasColumnName("mobile");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
        });

        modelBuilder.Entity<ViewClientApp>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("view_client_apps");

            entity.Property(e => e.ApplicationName)
                .HasMaxLength(50)
                .HasColumnName("application_name")
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.ClientAppStatus)
                .HasMaxLength(50)
                .HasColumnName("client_app_status")
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.ClientId)
                .HasMaxLength(64)
                .HasColumnName("client_id")
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.EnablePostPaidOption).HasColumnName("enable_post_paid_option");
            entity.Property(e => e.OrgName)
                .HasMaxLength(100)
                .HasColumnName("org_name");
            entity.Property(e => e.OrganizationStatus)
                .HasMaxLength(100)
                .HasColumnName("organization_status");
            entity.Property(e => e.OrganizationUid)
                .HasMaxLength(100)
                .HasColumnName("organization_uid");
        });

        modelBuilder.Entity<ViewOrgUserEmailList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("view_org_user_email_list");

            entity.Property(e => e.OrgEmailsList)
                .HasColumnType("text")
                .HasColumnName("org_emails_list");
            entity.Property(e => e.SubscriberUid)
                .HasMaxLength(100)
                .HasColumnName("subscriber_uid");
        });

        modelBuilder.Entity<ViewOrgsMini>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("view_orgs_mini");

            entity.Property(e => e.AgentUrl)
                .HasMaxLength(100)
                .HasColumnName("agent_url");
            entity.Property(e => e.EnablePostPaidOption).HasColumnName("enable_post_paid_option");
            entity.Property(e => e.OrgName)
                .HasMaxLength(100)
                .HasColumnName("org_name");
            entity.Property(e => e.OrganizationDetailsId).HasColumnName("organization_details_id");
            entity.Property(e => e.OrganizationStatus)
                .HasMaxLength(100)
                .HasColumnName("organization_status");
            entity.Property(e => e.OrganizationUid)
                .HasMaxLength(100)
                .HasColumnName("organization_uid");
            entity.Property(e => e.SpocUgpassEmail)
                .HasMaxLength(100)
                .HasColumnName("spoc_ugpass_email");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
