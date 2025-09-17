using System.ComponentModel.DataAnnotations;

namespace ClarityAndSuccess.Infrastructure.DTO;

public class AddUpdateCustomerDTO
{
    public int currentMode { get; set; } = 0;

    public long CustomerNumber { get; set; } = 0;
    [StringLength(50)]
    public string Street { get; set; } = string.Empty;

    [StringLength(50)]
    public string AddressSupplement { get; set; } = string.Empty;

    [StringLength(12)]
    public string ZipCode { get; set; } = string.Empty;

    [StringLength(30)]
    public string City { get; set; } = string.Empty;

    [StringLength(50)]
    public string State { get; set; } = string.Empty;

    [StringLength(3)]
    public string CountryCode { get; set; } = string.Empty;

    [StringLength(30)]
    public string Country { get; set; } = string.Empty;

    public short BranchNumber { get; set; } = 0;
    public string OwnCustomerNumber { get; set; } = string.Empty;

    public string Company { get; set; } = string.Empty;
    public string Salutation { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PoBox { get; set; } = string.Empty;
    public string PoBoxZipCode { get; set; } = string.Empty;
    public string Phone1 { get; set; } = string.Empty;
    public string Phone2 { get; set; } = string.Empty;
    public string Fax { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string SocialNetwork1 { get; set; } = string.Empty;
    public string SocialNetwork2 { get; set; } = string.Empty;
    public string Homepage { get; set; } = string.Empty;

    // Use ISO string for compatibility, e.g. "2025-09-17"
    public string DateOfBirth { get; set; } = string.Empty;

    public bool IsOwnCustomer { get; set; } = false;
    public string OwnCustomerPassword { get; set; } = string.Empty;

    // Categories
    public string Category1 { get; set; } = string.Empty;
    public string Category2 { get; set; } = string.Empty;
    public string Category3 { get; set; } = string.Empty;
    public string Category4 { get; set; } = string.Empty;
    public string Category5 { get; set; } = string.Empty;
    public string Category6 { get; set; } = string.Empty;
    public string Category7 { get; set; } = string.Empty;
    public string Category8 { get; set; } = string.Empty;
    public string Category9 { get; set; } = string.Empty;
    public string Category10 { get; set; } = string.Empty;

    // Extra Fields
    public string Profession { get; set; } = string.Empty;
    public string Hobby { get; set; } = string.Empty;
    public int CustomerCardNumber { get; set; } = 0;
    public string CustomerCardType { get; set; } = string.Empty;
    public long AgentCustomerNumber { get; set; } = 0;

    public byte Gender { get; set; } = 0;
    public string PlaceOfBirth { get; set; } = string.Empty;
    public string Nationality { get; set; } = string.Empty;
    public string IdentificationType { get; set; } = string.Empty;
    public string IdentificationNumber { get; set; } = string.Empty;
    public string IssuingAuthority { get; set; } = string.Empty;
    public string ProofOfAddress { get; set; } = string.Empty;

    // Partner
    public string PartnerSalutation { get; set; } = string.Empty;
    public string PartnerTitle { get; set; } = string.Empty;
    public string PartnerFirstName { get; set; } = string.Empty;
    public string PartnerLastName { get; set; } = string.Empty;
    public string PartnerDateOfBirth { get; set; } = string.Empty;

    // Online Shop
    public bool IsOnlineShopCustomer { get; set; } = false;
    public string OsLoginName { get; set; } = string.Empty;

    // Advertising
    public bool IsNoAdvertising { get; set; } = false;
    public bool IsAdvertisingPost { get; set; } = false;
    public bool IsAdvertisingEmail { get; set; } = false;
    public bool IsAdvertisingSms { get; set; } = false;
    public bool IsAdvertisingCall { get; set; } = false;
    public bool IsPrivacyDeclaration { get; set; } = false;

    // Personnel & Payment
    public long StaffFieldServiceNumber { get; set; } = 0;
    public long StaffContactPersonNumber { get; set; } = 0;
    public int PaymentConditionNumber { get; set; } = 0;
    public int PaymentMethodId { get; set; } = 0;
    public bool PriceDisplayGross { get; set; } = false;

    // Tax & Finance
    public string VatIdNumber { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
    public string DebtorNumber { get; set; } = string.Empty;
    public string CreditorNumber { get; set; } = string.Empty;
    public double Discount1 { get; set; } = 0.0;
    public double Discount2 { get; set; } = 0.0;
    public double CreditLimit { get; set; } = 0.0;

    // Shipping & VAT
    public int ShippingMethodNumber { get; set; } = 0;
    public short VatGroupNumber { get; set; } = 0;
    public bool IsVatObligated { get; set; } = false;

    // Bank Info
    public byte SalesType { get; set; } = 0;
    public string AccountHolder { get; set; } = string.Empty;
    public string Iban { get; set; } = string.Empty;
    public string Bic { get; set; } = string.Empty;
    public string Bank { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public string BankCode { get; set; } = string.Empty;

    // Mandate
    public string MandateReference { get; set; } = string.Empty;
    public DateTime? MandateReferenceDate { get; set; } = null;
    public string MandateReferenceType { get; set; } = string.Empty;

    // Flags
    public bool IsDunningEnabled { get; set; } = false;
    public bool IsBlocked { get; set; } = false;
    public bool IsElectronicDeliveryNote { get; set; } = false;
    public bool IsPromotionalPrice { get; set; } = false;
    public bool IsPledgingBlocked { get; set; } = false;

    // Notes
    public string FinancialRemark { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;

    // Platinum Pack
    public string? LanguageNumber { get; set; } = string.Empty;
    public string? ArticleLanguageNumber { get; set; } = string.Empty;

    // Invoice
    public bool IsAvInvoiceViaEmail { get; set; } = false;
}
