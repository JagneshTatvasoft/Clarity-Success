using System.ComponentModel.DataAnnotations;

namespace ClarityAndSuccess.Infrastructure.DTO;

public class AddUpdateCustomerDTO
{
    public int currentMode { get; set; }

    public long CustomerNumber { get; set; }
    // Strasse
    [StringLength(50)]
    public string Street { get; set; }

    // Adresszusatz
    [StringLength(50)]
    public string AddressSupplement { get; set; }

    // PLZ (Postleitzahl)
    [StringLength(12)]
    public string ZipCode { get; set; }

    // Ort
    [StringLength(30)]
    public string City { get; set; }

    // Bundesland
    [StringLength(50)]
    public string State { get; set; }

    // Landeskennung
    [StringLength(3)]
    public string CountryCode { get; set; }

    // Land
    [StringLength(30)]
    public string Country { get; set; }

    public short BranchNumber { get; set; }
    public string OwnCustomerNumber { get; set; }

    public string Company { get; set; }
    public string Salutation { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PoBox { get; set; }
    public string PoBoxZipCode { get; set; }
    public string Phone1 { get; set; }
    public string Phone2 { get; set; }
    public string Fax { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string SocialNetwork1 { get; set; }
    public string SocialNetwork2 { get; set; }
    public string Homepage { get; set; }
    public string DateOfBirth { get; set; }
    public bool IsOwnCustomer { get; set; }
    public string OwnCustomerPassword { get; set; }
    // Categories
    public string Category1 { get; set; }
    public string Category2 { get; set; }
    public string Category3 { get; set; }
    public string Category4 { get; set; }
    public string Category5 { get; set; }
    public string Category6 { get; set; }
    public string Category7 { get; set; }
    public string Category8 { get; set; }
    public string Category9 { get; set; }
    public string Category10 { get; set; }
    // Extra Fields
    public string Profession { get; set; }
    public string Hobby { get; set; }
    public int CustomerCardNumber { get; set; }
    public string CustomerCardType { get; set; }
    public long AgentCustomerNumber { get; set; }
    // From mapping block
    public byte Gender { get; set; }
    public string PlaceOfBirth { get; set; }
    public string Nationality { get; set; }
    public string IdentificationType { get; set; }
    public string IdentificationNumber { get; set; }
    public string IssuingAuthority { get; set; }
    public string ProofOfAddress { get; set; }
    // Partner
    public string PartnerSalutation { get; set; }
    public string PartnerTitle { get; set; }
    public string PartnerFirstName { get; set; }
    public string PartnerLastName { get; set; }
    public string PartnerDateOfBirth { get; set; }
    // Online Shop
    public bool IsOnlineShopCustomer { get; set; }
    public string OsLoginName { get; set; }
    // Advertising
    public bool IsNoAdvertising { get; set; }
    public bool IsAdvertisingPost { get; set; }
    public bool IsAdvertisingEmail { get; set; }
    public bool IsAdvertisingSms { get; set; }
    public bool IsAdvertisingCall { get; set; }
    public bool IsPrivacyDeclaration { get; set; }
    // Personnel & Payment
    public long StaffFieldServiceNumber { get; set; }
    public long StaffContactPersonNumber { get; set; }
    public int PaymentConditionNumber { get; set; }
    public int PaymentMethodId { get; set; }
    // Tax & Finance
    public string VatIdNumber { get; set; }
    public string TaxNumber { get; set; }
    public string DebtorNumber { get; set; }
    public string CreditorNumber { get; set; }
    public double Discount1 { get; set; }
    public double Discount2 { get; set; }
    public double CreditLimit { get; set; }
    // Shipping & VAT
    public int ShippingMethodNumber { get; set; }
    public short VatGroupNumber { get; set; }
    public bool IsVatObligated { get; set; }
    // Bank Info
    public byte SalesType { get; set; }
    public string AccountHolder { get; set; }
    public string Iban { get; set; }
    public string Bic { get; set; }
    public string Bank { get; set; }
    public string AccountNumber { get; set; }
    public string BankCode { get; set; }
    // Mandate
    public string MandateReference { get; set; }
    public DateTime? MandateReferenceDate { get; set; }
    public string MandateReferenceType { get; set; }

    // Flags
    public bool IsDunningEnabled { get; set; }
    public bool IsBlocked { get; set; }
    public bool IsElectronicDeliveryNote { get; set; }
    public bool IsPromotionalPrice { get; set; }
    public bool IsPledgingBlocked { get; set; }

    // Notes
    public string FinancialRemark { get; set; }
    public string Note { get; set; }

    // Platinum Pack
    public string? LanguageNumber { get; set; }
    public string? ArticleLanguageNumber { get; set; }

    // Invoice
    public bool IsAvInvoiceViaEmail { get; set; }
}
