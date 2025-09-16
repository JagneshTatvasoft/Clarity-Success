using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClarityAndSuccess.Entities.Models;

[Table("Kunden")]
[Index("DebtorNumber", Name = "IX_Kunden_DebitorenNr")]
[Index("Company", Name = "IX_Kunden_Firma")]
[Index("CustomerCardType", Name = "IX_Kunden_KundenKartenNrExt")]
[Index("LastName", Name = "IX_Kunden_Nachname")]
public partial class Customer
{
    [Key]
    [Column("KundenNr")]
    public long CustomerNumber { get; set; }

    [Column("FilialNr")]
    public short BranchNumber { get; set; } = -1;

    [StringLength(30)]
    [Column("EigeneKundenNr")]
    public string OwnCustomerNumber { get; set; } = "";

    [StringLength(100)]
    [Column("Firma")]
    public string Company { get; set; } = "";

    [Column("Geschlecht")]
    public byte Gender { get; set; }

    [StringLength(30)]
    [Column("Anrede")]
    public string Salutation { get; set; } = "";

    [StringLength(25)]
    [Column("Titel")]
    public string Title { get; set; } = "";

    [StringLength(30)]
    [Column("Vorname")]
    public string FirstName { get; set; } = "";

    [StringLength(40)]
    [Column("Nachname")]
    public string LastName { get; set; } = "";

    [StringLength(50)]
    [Column("Strasse")]
    public string Street { get; set; } = "";

    [StringLength(50)]
    [Column("Adresszusatz")]
    public string AddressSupplement { get; set; } = "";

    [Column("PLZ")]
    [StringLength(12)]
    public string ZipCode { get; set; } = "";

    [StringLength(30)]
    [Column("Ort")]
    public string City { get; set; } = "";

    [StringLength(50)]
    [Column("Bundesland")]
    public string State { get; set; } = "";

    [StringLength(3)]
    [Column("Landeskennung")]
    public string CountryCode { get; set; } = "";

    [StringLength(30)]
    [Column("Land")]
    public string Country { get; set; } = "";

    [Column("Breitengrad")]
    public double Latitude { get; set; }

    [Column("Laengengrad")]
    public double Longitude { get; set; }

    [StringLength(15)]
    [Column("Postfach")]
    public string PoBox { get; set; } = "";

    [Column("PostfachPLZ")]
    [StringLength(12)]
    public string PoBoxZipCode { get; set; } = "";

    [StringLength(30)]
    [Column("Telefon1")]
    public string Phone1 { get; set; } = "";

    [StringLength(30)]
    [Column("Telefon2")]
    public string Phone2 { get; set; } = "";

    [StringLength(30)]
    [Column("Fax")]
    public string Fax { get; set; } = "";

    [StringLength(30)]
    [Column("Mobil")]
    public string Mobile { get; set; } = "";

    [Column("EMail")]
    [StringLength(100)]
    public string Email { get; set; } = "";

    [StringLength(100)]
    [Column("SozialesNetzwerk1")]
    public string SocialNetwork1 { get; set; } = "";

    [StringLength(100)]
    [Column("SozialesNetzwerk2")]
    public string SocialNetwork2 { get; set; } = "";

    [StringLength(100)]
    [Column("Homepage")]
    public string Homepage { get; set; } = "";

    [Column("Geburtsdatum")]
    public DateTime? DateOfBirth { get; set; }

    [Column("IsEigenerKunde")]
    public bool IsOwnCustomer { get; set; }

    [StringLength(32)]
    [Column("EigenerKundeKennwort")]
    public string OwnCustomerPassword { get; set; } = "";

    [StringLength(20)]
    [Column("Kategorie1")]
    public string Category1 { get; set; } = "";

    [StringLength(20)]
    [Column("Kategorie2")]
    public string Category2 { get; set; } = "";

    [StringLength(20)]
    [Column("Kategorie3")]
    public string Category3 { get; set; } = "";

    [StringLength(20)]
    [Column("Kategorie4")]
    public string Category4 { get; set; } = "";

    [StringLength(20)]
    [Column("Kategorie5")]
    public string Category5 { get; set; } = "";

    [StringLength(20)]
    [Column("Kategorie6")]
    public string Category6 { get; set; } = "";

    [StringLength(20)]
    [Column("Kategorie7")]
    public string Category7 { get; set; } = "";

    [StringLength(20)]
    [Column("Kategorie8")]
    public string Category8 { get; set; } = "";

    [StringLength(20)]
    [Column("Kategorie9")]
    public string Category9 { get; set; } = "";

    [StringLength(20)]
    [Column("Kategorie10")]
    public string Category10 { get; set; } = "";

    [StringLength(20)]
    [Column("Beruf")]
    public string Profession { get; set; } = "";

    [StringLength(30)]
    [Column("Hobby")]
    public string Hobby { get; set; } = "";

    [Column("KundenKartenNr")]
    public int CustomerCardNumber { get; set; }

    [StringLength(20)]
    [Column("KundenKartenNrExt")]
    public string CustomerCardType { get; set; } = "";

    [Column("KundenNrVermittler")]
    public long AgentCustomerNumber { get; set; }

    [StringLength(50)]
    [Column("Identifikationsart")]
    public string IdentificationType { get; set; } = "";

    [StringLength(40)]
    [Column("IdentifikationsNr")]
    public string IdentificationNumber { get; set; } = "";

    [StringLength(40)]
    [Column("Ausstellungsbehoerde")]
    public string IssuingAuthority { get; set; } = "";

    [StringLength(30)]
    [Column("Staatsangehoerigkeit")]
    public string Nationality { get; set; } = "";

    [StringLength(30)]
    [Column("Geburtsort")]
    public string PlaceOfBirth { get; set; } = "";

    [Column("IsWerbungKeine")]
    public bool IsNoAdvertising { get; set; }

    [Column("IsWerbungPost")]
    public bool IsAdvertisingPost { get; set; }

    [Column("IsWerbungEMail")]
    public bool IsAdvertisingEmail { get; set; }

    [Column("IsWerbungSMS")]
    public bool IsAdvertisingSms { get; set; }

    [Column("IsWerbungAnruf")]
    public bool IsAdvertisingCall { get; set; }

    [Column("IsDatenschutzerklaerung")]
    public bool IsPrivacyDeclaration { get; set; }

    [Column("PersonalNrAussendienst")]
    public long StaffFieldServiceNumber { get; set; }

    [Column("PersonalNrAnsprechpartner")]
    public long StaffContactPersonNumber { get; set; }

    [Column("ZahlBedNr")]
    public int PaymentConditionNumber { get; set; }

    [Column("ZahlungsartenID")]
    public int PaymentMethodId { get; set; }

    [Column("VersandartNr")]
    public int ShippingMethodNumber { get; set; }

    [StringLength(30)]
    [Column("UstIdNr")]
    public string VatIdNumber { get; set; } = "";

    [StringLength(30)]
    [Column("SteuerNr")]
    public string TaxNumber { get; set; } = "";

    [StringLength(12)]
    [Column("DebitorenNr")]
    public string DebtorNumber { get; set; } = "";

    [Column("Rabatt1")]
    public double Discount1 { get; set; }

    [Column("Rabatt2")]
    public double Discount2 { get; set; }

    [Column("Kreditlimit")]
    public double CreditLimit { get; set; }

    [Column("UStGruppenNr")]
    public short VatGroupNumber { get; set; } = -1;

    [Column("IsUStPflicht")]
    public bool IsVatObligated { get; set; } = true;

    [StringLength(40)]
    [Column("Kontoinhaber")]
    public string AccountHolder { get; set; } = "";

    [StringLength(50)]
    [Column("IBAN")]
    public string Iban { get; set; } = "";

    [StringLength(20)]
    [Column("BIC")]
    public string Bic { get; set; } = "";

    [StringLength(255)]
    [Column("Kreditinstitut")]
    public string Bank { get; set; } = "";

    [StringLength(50)]
    [Column("KontoNr")]
    public string AccountNumber { get; set; } = "";

    [StringLength(50)]
    [Column("BLZ")]
    public string BankCode { get; set; } = "";

    [StringLength(40)]
    [Column("Mandatsreferenz")]
    public string MandateReference { get; set; } = "";

    [Column("IsMahnen")]
    public bool IsDunningEnabled { get; set; } = true;

    [Column("IsGesperrt")]
    public bool IsBlocked { get; set; }

    [Column("IsElLieferschein")]
    public bool IsElectronicDeliveryNote { get; set; }

    [Column("IsAktionspreis")]
    public bool IsPromotionalPrice { get; set; } = true;

    [Column("VKTyp")]
    public byte SalesType { get; set; } = 1;

    [StringLength(512)]
    [Column("BemerkungFinanzen")]
    public string FinancialRemark { get; set; } = "";

    [StringLength(30)]
    [Column("PartnerAnrede")]
    public string PartnerSalutation { get; set; } = "";

    [StringLength(25)]
    [Column("PartnerTitel")]
    public string PartnerTitle { get; set; } = "";

    [StringLength(30)]
    [Column("PartnerVorname")]
    public string PartnerFirstName { get; set; } = "";

    [StringLength(40)]
    [Column("PartnerNachname")]
    public string PartnerLastName { get; set; } = "";

    [Column("PartnerGeburtsdatum")]
    public DateTime? PartnerDateOfBirth { get; set; }

    [Column("IsOnlineShop")]
    public bool IsOnlineShopCustomer { get; set; }

    [StringLength(100)]
    [Column("OSAnmeldename")]
    public string OsLoginName { get; set; } = "";

    [StringLength(128)]
    [Column("OSKennwort")]
    public string OsPassword { get; set; } = "";

    [Column("Geloescht")]
    public bool IsDeleted { get; set; }

    [Precision(0)]
    [Column("AngelegtD")]
    public DateTime? CreatedDate { get; set; }

    [StringLength(12)]
    [Column("AngelegtV")]
    public string? CreatedByInitials { get; set; }

    [Column("AngelegtVNr")]
    public long CreatedByNumber { get; set; }

    [Precision(0)]
    [Column("GeaendertD")]
    public DateTime? ChangedDate { get; set; }

    [StringLength(12)]
    [Column("GeaendertV")]
    public string? ChangedByInitials { get; set; }

    [Column("GeaendertVNr")]
    public long ChangedByNumber { get; set; }

    [Column("Bemerkung")]
    public string Note { get; set; } = "";

    [Column("IsAVRechnungViaEMail")]
    public bool IsAvInvoiceViaEmail { get; set; }

    [StringLength(30)]
    [Column("MandatsreferenzTyp")]
    public string MandateReferenceType { get; set; } = "";

    [Column("MandatsreferenzDatum")]
    public DateTime? MandateReferenceDate { get; set; }

    [StringLength(24)]
    [Column("KreditorenNr")]
    public string? CreditorNumber { get; set; }

    [Column("IsPreisdarstellungBrutto")]
    public bool IsPriceDisplayGross { get; set; } = true;

    [StringLength(12)]
    [Column("SprachNr")]
    public string? LanguageNumber { get; set; }

    [StringLength(12)]
    [Column("ArtikelSprachNr")]
    public string? ArticleLanguageNumber { get; set; }

    [Precision(0)]
    [Column("WiederhergestelltDatum")]
    public DateTime? RestoredDate { get; set; }

    [StringLength(50)]
    [Column("WiederhergestelltVon")]
    public string? RestoredBy { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    [Column("NachweisderAdresse")]
    public string? ProofOfAddress { get; set; }

    [Column("NachweisderAdresseDatum")]
    public DateTime? ProofOfAddressDate { get; set; }

    [Column("IdentifikationsDatum")]
    public DateTime? IdentificationDate { get; set; }

    [StringLength(50)]
    [Column("Details")]
    public string? Details { get; set; }

    [Column("IsVerpfandungGesperrt")]
    public bool IsPledgingBlocked { get; set; }

    // [InverseProperty("KundenNrNavigation")]
    // public virtual ICollection<KundenAnsprechpartner> KundenAnsprechpartners { get; set; } = new List<KundenAnsprechpartner>();
}