using System.Threading.Tasks;
using AutoMapper;
using ClarityAndSuccess.Application.Interface;
using ClarityAndSuccess.Entities.Models;
using ClarityAndSuccess.Infrastructure.DTO;
using ClarityAndSuccess.Infrastructure.Interface;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace ClarityAndSuccess.Application.Service;

public class CustomerService(IGenericRepository<Customer> customerRepository, IGenericRepository<MasterData> masterDataRepository, IGenericRepository<BranchCustomerNumber> branchCustomerNumberRepository, IGenericRepository<Branch> branchRepository, IMapper mapper) : ICustomerService
{
    private readonly IGenericRepository<Branch> _branchRepository = branchRepository;
    private readonly IGenericRepository<BranchCustomerNumber> _branchCustomerNumberRepository = branchCustomerNumberRepository;
    private readonly IGenericRepository<MasterData> _masterDataRepository = masterDataRepository;

    private readonly IGenericRepository<Customer> _customerRepository = customerRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<AddUpdateCustomerDTO?> GetCustomerByIdAsync(long customerNumber)
    {
        var customer = await _customerRepository.GetFirstOrDefaultProjectedAsync<AddUpdateCustomerDTO>(filter: f => f.CustomerNumber == customerNumber, mapperConfig: _mapper.ConfigurationProvider);

        if (customer == null)
            return null;

        return customer;
    }

    public async Task<bool> AddUpdateCustomer(AddUpdateCustomerDTO customerDTO)
    {
        bool bIsAdding = false;
        long lCustomerNumber = 0;

        // Check for mode
        // if (customerDTO.currentMode == CurrentMode.Add)
        // {
        //     isAdding = true;
        // }

        //Chek for authority

        //Checking authorization

        //save customer
        lCustomerNumber = await SaveCustomer(customerDTO);

        // Save customer appointment for his birthday & partner birthday
        // csAppointmentSettings.CreateOrUpdateAppointmentWhenSavingCustomer
        // Usea above thing if createOrUpdateAppointmentWhenSavingCustomer is true
        if (false)
        {
            // Customer Birthday
            // DateTime customerBirthDate = DateTime.MinValue;
            // if (!string.IsNullOrWhiteSpace(this.txtBirthDate.Text))
            // {
            //     customerBirthDate = DateTime.Parse(this.txtBirthDate.Text);
            // }

            // this.SaveCustomerRelatedAppointment(
            //     cn,
            //     customerNumber,
            //     customerBirthDate,
            //     csAppointmentEventsTab.GetEventName(csAppointmentEventsTab.AppointmentEvent.Birthday),
            //     csIdentifierType.Identifier.Customer
            // );

            // Customer Partner Birthday
            // DateTime partnerBirthDate = DateTime.MinValue;
            // if (!string.IsNullOrWhiteSpace(this.txtPartnerBirthDate.Text))
            // {
            //     partnerBirthDate = DateTime.Parse(this.txtPartnerBirthDate.Text);
            // }

            // 11.06.2020, Hiral: Update identifier type - CustomerPartner for customer partner.
            // this.SaveCustomerRelatedAppointment(
            //     cn,
            //     customerNumber,
            //     partnerBirthDate,
            //     csAppointmentEventsTab.GetEventName(csAppointmentEventsTab.AppointmentEvent.PartnerBirthday),
            //     csIdentifierType.Identifier.CustomerPartner
            // );
        }

        // Save contact person
        // await SaveContactPersonsAsync();
        // await SaveCreationDate();



        return false;
    }

    // Save Concat person
    // public async Task SaveContactPersonsAsync(long customerId, List<int> appointmentIds)
    // {
    //     // 1. Get the original contact persons from DB
    //     var existingContacts = await _dbContext.ContactPersons
    //         .Where(cp => cp.CustomerId == customerId)
    //         .ToListAsync();

    //     // 2. Get the new/updated contact persons from the UI (example: bound DTOs)
    //     var updatedContacts = _currentContactPersonsFromUI; // replace with your binding source

    //     // --- Handle Deleted Contacts ---
    //     var deletedContacts = existingContacts
    //         .Where(ec => !updatedContacts.Any(uc => uc.ContactPersonId == ec.ContactPersonId))
    //         .ToList();

    //     if (deletedContacts.Any())
    //     {
    //         _dbContext.ContactPersons.RemoveRange(deletedContacts);

    //         // Also remove related appointments
    //         var deletedContactIds = deletedContacts.Select(c => c.ContactPersonId).ToList();
    //         var relatedAppointments = await _dbContext.Appointments
    //             .Where(a => deletedContactIds.Contains(a.KennNr) && a.KennTyp == (int)KennTyp.ContactPerson)
    //             .ToListAsync();

    //         _dbContext.Appointments.RemoveRange(relatedAppointments);
    //     }

    //     // --- Handle Added & Updated Contacts ---
    //     foreach (var updated in updatedContacts)
    //     {
    //         var existing = existingContacts.FirstOrDefault(c => c.ContactPersonId == updated.ContactPersonId);

    //         if (existing == null)
    //         {
    //             // New contact
    //             updated.CustomerId = customerId;
    //             updated.CreatedDate = DateTime.Now;
    //             updated.CreatedBy = _currentUser.LastName;
    //             updated.CreatedById = _currentUser.PersonalNr;
    //             updated.ContactPersonGuid = Guid.NewGuid().ToString();

    //             if (CustomerSettings.CapitalizeFirstLetter)
    //             {
    //                 updated.FirstName = CapitalizeFirstLetter(updated.FirstName);
    //                 updated.LastName = CapitalizeFirstLetter(updated.LastName);
    //             }

    //             updated.InitLogData(LogArea.Editing, _currentUser.PersonalNr);
    //             await _dbContext.ContactPersons.AddAsync(updated);

    //             // Create birthday appointment if required
    //             if (AppointmentSettings.CreateOrUpdateOnCustomerSave)
    //             {
    //                 int saveStatus = await SaveCustomerRelatedAppointmentAsync(
    //                     updated.ContactPersonId,
    //                     updated.BirthDate,
    //                     AppointmentEvent.ContactPersonBirthday,
    //                     KennTyp.ContactPerson
    //                 );

    //                 if (saveStatus == 1 || saveStatus == 2)
    //                     appointmentIds.Add(updated.ContactPersonId);
    //             }
    //         }
    //         else
    //         {
    //             // Update existing
    //             existing.FirstName = updated.FirstName;
    //             existing.LastName = updated.LastName;
    //             existing.BirthDate = updated.BirthDate;

    //             if (CustomerSettings.CapitalizeFirstLetter)
    //             {
    //                 existing.FirstName = CapitalizeFirstLetter(existing.FirstName);
    //                 existing.LastName = CapitalizeFirstLetter(existing.LastName);
    //             }

    //             existing.ModifiedDate = DateTime.Now;
    //             existing.ModifiedBy = _currentUser.LastName;
    //             existing.ModifiedById = _currentUser.PersonalNr;

    //             existing.InitLogData(LogArea.Editing, _currentUser.PersonalNr);

    //             _dbContext.ContactPersons.Update(existing);

    //             // Update birthday appointment if required
    //             if (AppointmentSettings.CreateOrUpdateOnCustomerSave)
    //             {
    //                 int saveStatus = await SaveCustomerRelatedAppointmentAsync(
    //                     existing.ContactPersonId,
    //                     existing.BirthDate,
    //                     AppointmentEvent.ContactPersonBirthday,
    //                     KennTyp.ContactPerson
    //                 );

    //                 if (saveStatus == 1 || saveStatus == 2)
    //                     appointmentIds.Add(existing.ContactPersonId);
    //             }
    //         }
    //     }

    //     await _dbContext.SaveChangesAsync();
    // }

    // Save customer relatedAppointment
    // private int SaveCustomerRelatedAppointment(
    // SqlConnection connection,
    // long customerId,
    // DateTime birthDate,
    // string eventName,
    // csKennTyp.KennTyp kennType)
    // {
    //     int saveStatus = 0;

    //     // Get the matching appointment event for the customer birthday
    //     csTerminEreignisseTab eventDefinition = this.GetCustomerBirthdayEvent(connection, eventName);

    //     // Find the existing appointment (if any)
    //     csTermineTab existingAppointment = csTermineTab.GetAppointment(
    //         connection,
    //         eventDefinition.TerminEreignisID,
    //         customerId,
    //         kennType
    //     );

    //     if (existingAppointment.IsExist)
    //     {
    //         // Case 1: If no valid birthdate -> delete appointment
    //         if (DateTime.MinValue.Equals(birthDate))
    //         {
    //             csTermineTab.DeleteAppointment(connection, existingAppointment.TerminID);
    //             saveStatus = 3; // Deleted
    //         }
    //         // Case 2: If birthdate has changed -> update appointment
    //         else if (existingAppointment.Datum != birthDate)
    //         {
    //             csTermineTab appointmentBeforeEdit = new csTermineTab(existingAppointment);

    //             existingAppointment.Datum = new DateTime(
    //                 birthDate.Year,
    //                 birthDate.Month,
    //                 birthDate.Day,
    //                 0, 0, 0
    //             );
    //             existingAppointment.IsSerie = eventDefinition.IsSerie;
    //             existingAppointment.Betreff = eventName;
    //             existingAppointment.TerminEreignisID = eventDefinition.TerminEreignisID;
    //             existingAppointment.PersonalNrBearbeiter = eventDefinition.PersonalNrBearbeiter;
    //             existingAppointment.IsLoeschen = eventDefinition.IsLoeschen;
    //             existingAppointment.GeaendertVNr = (int)localAnmeldung.PersonalNr;
    //             existingAppointment.GeaendertD = DateTime.Now;

    //             existingAppointment.Save(connection, appointmentBeforeEdit);
    //             saveStatus = 2; // Updated
    //         }
    //     }
    //     else
    //     {
    //         // Case 3: No existing appointment but valid birthdate -> create new
    //         if (!DateTime.MinValue.Equals(birthDate))
    //         {
    //             existingAppointment.KennNr = customerId;
    //             existingAppointment.KennTyp = (byte)kennType;
    //             existingAppointment.Datum = new DateTime(
    //                 birthDate.Year,
    //                 birthDate.Month,
    //                 birthDate.Day,
    //                 0, 0, 0
    //             );
    //             existingAppointment.IsSerie = eventDefinition.IsSerie;
    //             existingAppointment.Betreff = eventName;
    //             existingAppointment.TerminEreignisID = eventDefinition.TerminEreignisID;
    //             existingAppointment.PersonalNrBearbeiter = eventDefinition.PersonalNrBearbeiter;
    //             existingAppointment.IsLoeschen = eventDefinition.IsLoeschen;
    //             existingAppointment.FilialNr = csEinstellungFilialen.EigeneFilialeFilialNr;
    //             existingAppointment.TermineGuid = csConvert.GuidToString(Guid.NewGuid());
    //             existingAppointment.AngelegtVNr = (int)localAnmeldung.PersonalNr;
    //             existingAppointment.AngelegtD = DateTime.Now;

    //             existingAppointment.Save(connection, null);
    //             saveStatus = 1; // Created
    //         }
    //     }

    //     return saveStatus;
    // }

    private async Task<long> SaveCustomer(AddUpdateCustomerDTO customerDTO)
    {
        bool bISAddressChanged = false;

        Customer? objCurrentCustomer;
        if (customerDTO.CustomerNumber == 0)
        {
            objCurrentCustomer = new Customer();
        }
        else
        {
            objCurrentCustomer = await _customerRepository.GetFirstOrDefaultAsync(filter: f => f.CustomerNumber == customerDTO.CustomerNumber);
            bISAddressChanged =
            objCurrentCustomer!.Street != customerDTO.Street ||
            objCurrentCustomer.AddressSupplement != customerDTO.AddressSupplement ||
            objCurrentCustomer.ZipCode != customerDTO.ZipCode ||
            objCurrentCustomer.City != customerDTO.City ||
            objCurrentCustomer.State != customerDTO.State ||
            objCurrentCustomer.CountryCode != customerDTO.CountryCode ||
            objCurrentCustomer.Country != customerDTO.Country;
        }

        _mapper.Map(customerDTO, objCurrentCustomer);

        // objCurrentCustomer.BranchNumber = customerDTO.BranchNumber;
        // objCurrentCustomer.OwnCustomerNumber = customerDTO.OwnCustomerNumber;
        // objCurrentCustomer.Company = customerDTO.Company;
        // objCurrentCustomer.Salutation = customerDTO.Salutation;
        // objCurrentCustomer.Title = customerDTO.Title;

        // here we need to capitalize as per the settings
        // objCurrentCustomer.FirstName = customerDTO.FirstName;
        // objCurrentCustomer.LastName = customerDTO.LastName;

        // objCurrentCustomer.Street = customerDTO.Street;
        // objCurrentCustomer.AddressSupplement = customerDTO.AddressSupplement;
        // objCurrentCustomer.ZipCode = customerDTO.ZipCode;
        // objCurrentCustomer.City = customerDTO.City;
        // objCurrentCustomer.State = customerDTO.State;
        // objCurrentCustomer.CountryCode = customerDTO.CountryCode;
        // objCurrentCustomer.Country = customerDTO.Country;

        if (bISAddressChanged)
        {
            objCurrentCustomer.Latitude = 0;
            objCurrentCustomer.Longitude = 0;
        }
        else
        {
            // Here we need to find somethign latitude and longitude using some method
            // objCurrentCustomer.Latitude = gc.Latitude;
            // objCurrentCustomer.Longitude = gc.Longitude;
        }

        // objCurrentCustomer.PoBox = customerDTO.PoBox;
        // objCurrentCustomer.PoBoxZipCode = customerDTO.PoBoxZipCode;
        // objCurrentCustomer.Phone1 = customerDTO.Phone1;
        // objCurrentCustomer.Phone2 = customerDTO.Phone2;
        // objCurrentCustomer.Fax = customerDTO.Fax;
        // objCurrentCustomer.Mobile = customerDTO.Mobile;
        // objCurrentCustomer.Email = customerDTO.Email;
        // objCurrentCustomer.SocialNetwork1 = customerDTO.SocialNetwork1;
        // objCurrentCustomer.SocialNetwork2 = customerDTO.SocialNetwork2;
        // objCurrentCustomer.Homepage = customerDTO.Homepage;

        // objCurrentCustomer.DateOfBirth = string.IsNullOrEmpty(customerDTO.DateOfBirth)
        //     ? null
        //     : DateTime.Parse(customerDTO.DateOfBirth);

        // objCurrentCustomer.IsOwnCustomer = customerDTO.IsOwnCustomer;
        // objCurrentCustomer.OwnCustomerPassword = customerDTO.OwnCustomerPassword ?? "";

        // Further data 1
        // objCurrentCustomer.Category1 = customerDTO.Category1;
        // objCurrentCustomer.Category2 = customerDTO.Category2;
        // objCurrentCustomer.Category3 = customerDTO.Category3;
        // objCurrentCustomer.Category4 = customerDTO.Category4;
        // objCurrentCustomer.Category5 = customerDTO.Category5;
        // objCurrentCustomer.Category6 = customerDTO.Category6;
        // objCurrentCustomer.Category7 = customerDTO.Category7;
        // objCurrentCustomer.Category8 = customerDTO.Category8;
        // objCurrentCustomer.Category9 = customerDTO.Category9;
        // objCurrentCustomer.Category10 = customerDTO.Category10;
        // objCurrentCustomer.Profession = customerDTO.Profession;
        // objCurrentCustomer.Hobby = customerDTO.Hobby;
        // objCurrentCustomer.CustomerCardNumber = customerDTO.CustomerCardNumber;
        // objCurrentCustomer.CustomerCardType = customerDTO.CustomerCardType;
        // objCurrentCustomer.AgentCustomerNumber = customerDTO.AgentCustomerNumber;

        // Here gender is in byte
        // objCurrentCustomer.Gender = customerDTO.Gender;
        // objCurrentCustomer.PlaceOfBirth = customerDTO.PlaceOfBirth;
        // objCurrentCustomer.Nationality = customerDTO.Nationality;
        // objCurrentCustomer.IdentificationType = customerDTO.IdentificationType;
        // objCurrentCustomer.IdentificationNumber = customerDTO.IdentificationNumber;
        // objCurrentCustomer.IssuingAuthority = customerDTO.IssuingAuthority;
        // objCurrentCustomer.ProofOfAddress = customerDTO.ProofOfAddress;

        // objCurrentCustomer.PartnerSalutation = customerDTO.PartnerSalutation;
        // objCurrentCustomer.PartnerTitle = customerDTO.PartnerTitle;
        // objCurrentCustomer.PartnerFirstName = customerDTO.PartnerFirstName;
        // objCurrentCustomer.PartnerLastName = customerDTO.PartnerLastName;
        // objCurrentCustomer.PartnerFirstName = capitalizeFirstLetter
        //     ? CapitalizeFirstLetter(customerDTO.PartnerFirstName)
        //     : customerDTO.PartnerFirstName;
        // objCurrentCustomer.PartnerLastName = capitalizeFirstLetter
        //     ? CapitalizeFirstLetter(customerDTO.PartnerLastName)
        //     : customerDTO.PartnerLastName;
        // objCurrentCustomer.PartnerDateOfBirth = string.IsNullOrEmpty(customerDTO.PartnerDateOfBirth)
        //     ? null
        //     : DateTime.Parse(customerDTO.PartnerDateOfBirth);

        // objCurrentCustomer.IsOnlineShopCustomer = customerDTO.IsOnlineShopCustomer;
        // objCurrentCustomer.OsLoginName = customerDTO.OsLoginName;

        // objCurrentCustomer.IsNoAdvertising = customerDTO.IsNoAdvertising;
        // objCurrentCustomer.IsAdvertisingPost = customerDTO.IsAdvertisingPost;
        // objCurrentCustomer.IsAdvertisingEmail = customerDTO.IsAdvertisingEmail;
        // objCurrentCustomer.IsAdvertisingSms = customerDTO.IsAdvertisingSms;
        // objCurrentCustomer.IsAdvertisingCall = customerDTO.IsAdvertisingCall;
        // objCurrentCustomer.IsPrivacyDeclaration = customerDTO.IsPrivacyDeclaration;

        // objCurrentCustomer.StaffFieldServiceNumber = customerDTO.StaffFieldServiceNumber;
        // objCurrentCustomer.StaffContactPersonNumber = customerDTO.StaffContactPersonNumber;
        // objCurrentCustomer.PaymentConditionNumber = customerDTO.PaymentConditionNumber;
        // objCurrentCustomer.PaymentMethodId = customerDTO.PaymentMethodId;

        // objCurrentCustomer.VatIdNumber = customerDTO.VatIdNumber;
        // objCurrentCustomer.TaxNumber = customerDTO.TaxNumber;
        // objCurrentCustomer.DebtorNumber = customerDTO.DebtorNumber;
        // objCurrentCustomer.CreditorNumber = customerDTO.CreditorNumber;
        // objCurrentCustomer.Discount1 = customerDTO.Discount1;
        // objCurrentCustomer.Discount2 = customerDTO.Discount2;
        // objCurrentCustomer.CreditLimit = customerDTO.CreditLimit;

        // objCurrentCustomer.ShippingMethodNumber = customerDTO.ShippingMethodNumber;
        // objCurrentCustomer.VatGroupNumber = customerDTO.VatGroupNumber;
        // objCurrentCustomer.IsVatObligated = customerDTO.VatGroupNumber != 0;

        // objCurrentCustomer.SalesType = customerDTO.SalesType;
        // objCurrentCustomer.AccountHolder = customerDTO.AccountHolder;
        // objCurrentCustomer.Iban = customerDTO.Iban;
        // objCurrentCustomer.Bic = customerDTO.Bic;
        // objCurrentCustomer.Bank = customerDTO.Bank;
        // objCurrentCustomer.AccountNumber = customerDTO.AccountNumber;
        // objCurrentCustomer.BankCode = customerDTO.BankCode;
        // objCurrentCustomer.MandateReference = customerDTO.MandateReference;
        // objCurrentCustomer.MandateReferenceDate = customerDTO.MandateReferenceDate;
        // objCurrentCustomer.MandateReferenceType = customerDTO.MandateReferenceType;

        // objCurrentCustomer.IsDunningEnabled = customerDTO.IsDunningEnabled;
        // objCurrentCustomer.IsBlocked = customerDTO.IsBlocked;
        // objCurrentCustomer.IsElectronicDeliveryNote = customerDTO.IsElectronicDeliveryNote;
        // objCurrentCustomer.IsPromotionalPrice = customerDTO.IsPromotionalPrice;
        // objCurrentCustomer.IsPledgingBlocked = customerDTO.IsPledgingBlocked;

        // objCurrentCustomer.FinancialRemark = customerDTO.FinancialRemark;

        // Here removing special symbols we need to put note
        // objCurrentCustomer.Note = RemoveSpecialSymbols(customerDTO.Note);
        objCurrentCustomer.Note = customerDTO.Note;

        //This functionality is need to check
        // if (isPlatinumPack)
        // {
        //     objCurrentCustomer.LanguageNumber = customerDTO.LanguageNumber;
        //     objCurrentCustomer.ArticleLanguageNumber = customerDTO.ArticleLanguageNumber;
        // }

        if (customerDTO.CustomerNumber == 0)
        {
            objCurrentCustomer.CustomerNumber = await GetNextCustomerNumber();
            objCurrentCustomer.CreatedDate = DateTime.Now;
            // objCurrentCustomer.CreatedByInitials = localLogin.Initials;
            // objCurrentCustomer.CreatedByNumber = localLogin.PersonnelNumber;
        }
        else
        {
            objCurrentCustomer.ChangedDate = DateTime.Now;
            // objCurrentCustomer.ChangedByInitials = localLogin.Initials;
            // objCurrentCustomer.ChangedByNumber = localLogin.PersonnelNumber;
        }

        objCurrentCustomer.IsAvInvoiceViaEmail = customerDTO.IsAvInvoiceViaEmail;

        bool isBranchGreen = false;
        if (isBranchGreen) // Only for green branch
        {
            // Price display gross
            if (customerDTO.PriceDisplayGross)
            {
                objCurrentCustomer.IsPriceDisplayGross = true;
            }
            else
            {
                objCurrentCustomer.IsPriceDisplayGross = false;
            }
        }

        // this is for log
        // customerObj.InitLogData(csTableLog.Areas.Processing, this.localLogin.PersonnelNumber);
        // End If

        // Here we need to put catch if it not add correctly
        await _customerRepository.AddAsync(objCurrentCustomer);

        return objCurrentCustomer.CustomerNumber;
    }

    private async Task<long> GetNextCustomerNumber()
    {
        long lNextCustomerNumber = 0;

        // Default number range
        bool bIsCustomerNumberActive = true;
        long lNumberRangeFrom = 1;
        long lNumberRangeTo = long.MaxValue;

        var result = await _branchCustomerNumberRepository.GetFirstOrDefaultSelectAsync(
            filter: f => f.BranchNumberNavigation.IsOwn == true,
            selector: s => new { s.IsActive, s.CustomerNumberFrom, s.CustomerNumberTo });

        if (result != null)
        {
            bIsCustomerNumberActive = result.IsActive;
            lNumberRangeFrom = result.CustomerNumberFrom;
            lNumberRangeTo = result.CustomerNumberTo;
        }

        if (!bIsCustomerNumberActive)
        {
            return lNextCustomerNumber;
        }

        if (lNumberRangeFrom > lNumberRangeTo)
        {
            lNumberRangeFrom = lNumberRangeTo;
        }

        lNextCustomerNumber = lNumberRangeFrom;

        long lCustomerNoFromMasterData = 0;
        long lCustomerNoFromCustomers = 0;

        // Last customer number from customer number 
        // Here check if there is no data ome then did not assign to this one
        var CustomerNumberResult = await _customerRepository.GetFirstOrDefaultSelectAsync(
            filter: f => f.CustomerNumber >= lNumberRangeFrom && f.CustomerNumber <= lNumberRangeTo,
            orderBy: o => o.OrderByDescending(c => c.CustomerNumber),
            selector: s => s.CustomerNumber
        );
        if (CustomerNumberResult != 0)
        {
            lCustomerNoFromCustomers = CustomerNumberResult;
        }
        var MasterDataResult = await _masterDataRepository.GetFirstOrDefaultSelectAsync(
            filter: f => f.Description == "KundenNr",
            selector: s => s.Data1
        );
        if (!string.IsNullOrEmpty(MasterDataResult) && long.TryParse(MasterDataResult, out var parsed))
        {
            lCustomerNoFromMasterData = parsed;
        }

        if (lNextCustomerNumber <= lCustomerNoFromCustomers)
        {
            lNextCustomerNumber = lCustomerNoFromCustomers + 1;
        }
        if (lNextCustomerNumber <= lCustomerNoFromMasterData)
        {
            lNextCustomerNumber = lCustomerNoFromMasterData + 1;
        }

        // update the counter in master data
        var existingMasterData = await _masterDataRepository.GetFirstOrDefaultAsync(
            filter: f => f.Description == "KundenNr"
        );

        if (existingMasterData != null)
        {
            existingMasterData.Data1 = lNextCustomerNumber.ToString();
            await _masterDataRepository.UpdateAsync(existingMasterData);
        }
        else
        {
            MasterData newMasterData = new MasterData
            {
                Description = "KundenNr",
                Data1 = lNextCustomerNumber.ToString()
            };

            await _masterDataRepository.AddAsync(newMasterData);
        }

        return lNextCustomerNumber;
    }

}
