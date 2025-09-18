using System.Threading.Tasks;
using AutoMapper;
using ClarityAndSuccess.Application.Interface;
using ClarityAndSuccess.Entities.Models;
using ClarityAndSuccess.Infrastructure.DTO;
using ClarityAndSuccess.Infrastructure.Interface;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using ClarityAndSuccess.Infrastructure.DTO.CustomerContactPerson;
using ClarityAndSuccess.Domain.Entities;
using ClarityAndSuccess.Infrastructure.Constant;
using Microsoft.AspNetCore.Http;
using ClarityAndSuccess.Infrastructure.DTO.Global;

namespace ClarityAndSuccess.Application.Service;

public class CustomerService(IGenericRepository<Customer> customerRepository, IGenericRepository<Tvlabel> tvlabelRepository, IGenericRepository<AppointmentEvent> appointmentEventRepository, IGenericRepository<Appointment> appointmentRepository, IGenericRepository<CustomerContactPerson> contactPersonRepository, IGenericRepository<MasterData> masterDataRepository, IGenericRepository<BranchCustomerNumber> branchCustomerNumberRepository, IGenericRepository<Branch> branchRepository, IMapper mapper) : ICustomerService
{
    private readonly IGenericRepository<Tvlabel> _tvlabelRepository = tvlabelRepository;
    private readonly IGenericRepository<CustomerContactPerson> _contactPersonRepository = contactPersonRepository;
    private readonly IGenericRepository<BranchCustomerNumber> _branchCustomerNumberRepository = branchCustomerNumberRepository;
    private readonly IGenericRepository<MasterData> _masterDataRepository = masterDataRepository;
    private readonly IGenericRepository<AppointmentEvent> _appointmentEventRepository = appointmentEventRepository;

    private readonly IGenericRepository<Customer> _customerRepository = customerRepository;
    private readonly IGenericRepository<Appointment> _appointmentRepository = appointmentRepository;
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
        if (true)
        {
            // Customer Birthday
            DateTime customerBirthDate = DateTime.MinValue;
            if (!string.IsNullOrWhiteSpace(customerDTO.DateOfBirth))
            {
                customerBirthDate = DateTime.Parse(customerDTO.DateOfBirth);
            }

            await SaveCustomerRelatedAppointmentAsync(
                lCustomerNumber,
                customerBirthDate,
                Enums.AppointmentEvent.Birthday.ToString(),
                Enums.TypeId.Customer
            );

            // Customer Partner Birthday
            DateTime partnerBirthDate = DateTime.MinValue;
            if (!string.IsNullOrWhiteSpace(customerDTO.PartnerDateOfBirth))
            {
                partnerBirthDate = DateTime.Parse(customerDTO.PartnerDateOfBirth);
            }

            await SaveCustomerRelatedAppointmentAsync(
                lCustomerNumber,
                partnerBirthDate,
                Enums.AppointmentEvent.PartnerBirthday.ToString(),
                Enums.TypeId.CustomerPartner
            );
        }

        // Save contact person
        List<int> appointmentIds = await SaveContactPersonsAsync(lCustomerNumber, customerDTO.ContactPersonList);

        //Save Picture 
        await SavePicturesAsync(customerDTO.customerPictures, lCustomerNumber, @"E:\C&SUI\Images\Customer");


        // if (csEinstellungFilialen.EigeneFilialeHauptfiliale)
        // {

        // }
        // else
        // {

        // }
        // await SaveCreationDate();
        return false;
    }

    // Save Creation Date
    private async Task SaveCreationDate(Enums.DfuePersonCode dfueCode)
    {
        // MasterData masterData = _masterDataRepository.
    }
    //Save Appointment Event
    private async Task<int> SaveCustomerRelatedAppointmentAsync(
        long customerNumber, DateTime birthdayDate, string eventName, Enums.TypeId idType
    )
    {
        int saveStatus = 0;
        AppointmentEvent? appointmentEvent = await _appointmentEventRepository.GetFirstOrDefaultAsync(
            filter: f => f.Reference == (byte)Enums.ReferenceType.Customer && f.Event == eventName.ToString() && f.IsStandardAppointmentEvent && f.IsActive
        );

        if (appointmentEvent == null)
        {
            // there color is sate according evetn 
            string color = string.Empty;
            if (eventName == Enums.AppointmentEvent.Birthday.ToString())
            {
                color = Enums.TVLabels.SpringGreen.ToString();
            }
            else if (eventName == Enums.AppointmentEvent.PartnerBirthday.ToString())
            {
                color = Enums.TVLabels.Aquamarine.ToString();
            }
            else if (eventName == Enums.AppointmentEvent.ContactPersonBirthday.ToString())
            {
                color = Enums.TVLabels.YellowGreen.ToString();
            }

            var tvlabel = await _tvlabelRepository.GetFirstOrDefaultAsync(
                filter: f => f.Color == color
            );

            appointmentEvent = new AppointmentEvent();
            appointmentEvent.Reference = (byte)Enums.ReferenceType.Customer;
            appointmentEvent.Event = eventName;
            appointmentEvent.IsDelete = false;
            appointmentEvent.RemindBefore = 5;
            appointmentEvent.RemindAfter = 2;
            appointmentEvent.IsActive = true;
            appointmentEvent.IsSeries = true;
            appointmentEvent.LabelId = tvlabel!.LabelId;
            appointmentEvent.IsReminder = true;
            appointmentEvent.IsStandardAppointmentEvent = true;
            appointmentEvent.AppointmentEventGuid = Guid.NewGuid().ToString();
        }

        //Here get appointment
        Appointment? appointmentChanged = await _appointmentRepository.GetFirstOrDefaultAsync(
            filter: f => f.AppointmentEventId == appointmentEvent.AppointmentEventId && f.IdNumber == customerNumber && f.IdType == 3 && !f.IsDeleted
        );

        if (appointmentChanged != null)
        {
            if (DateTime.MinValue == birthdayDate)
            {
                appointmentChanged.IsDeleted = true;
                await _appointmentRepository.UpdateAsync(appointmentChanged);
                saveStatus = 3;
            }
            else if (appointmentChanged.Date != birthdayDate)
            {
                saveStatus = 2;
            }
        }
        else
        {
            if (DateTime.MinValue != birthdayDate)
            {
                appointmentChanged!.IdNumber = customerNumber;
                appointmentChanged.IdType = (byte)idType;
                appointmentChanged.Date = new DateTime(birthdayDate.Year, birthdayDate.Month, birthdayDate.Day, 0, 0, 0);
                appointmentChanged.IsSeries = appointmentEvent.IsSeries;
                appointmentChanged.Subject = eventName;
                appointmentChanged.AppointmentEventId = appointmentEvent.AppointmentEventId;
                appointmentChanged.HandlerStaffNumber = appointmentEvent.HandlerStaffNumber;
                appointmentChanged.IsDelete = appointmentEvent.IsDelete;
                // appointmentChanged.BranchNumber = csEinstellungFilialen.EigeneFilialeFilialNr; // Assuming this is a static property
                appointmentChanged.AppointmentGuid = Guid.NewGuid().ToString();
                appointmentChanged.CreatedByNumber = 371;
                appointmentChanged.CreatedDate = DateTime.Now;

                // Save the new appointment to the database.
                await _appointmentRepository.AddAsync(appointmentChanged);
                saveStatus = 1;
            }
        }
        return saveStatus;
    }

    //Save Customer
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

    // Save Concat person
    public async Task<List<int>> SaveContactPersonsAsync(long customerNumber, List<CustomerContactPersonDTO> contactPersons)
    {
        List<int> appointmentIds = new List<int>();

        // 1. Get the original contact persons from DB
        List<CustomerContactPerson> existingContacts = (await _contactPersonRepository.GetAllAsync(
            filter: f => f.CustomerNumber == customerNumber
        )).ToList();

        // 2. Handle Deleted Contacts
        var deletedContacts = existingContacts
            .Where(w => !contactPersons.Any(a => a.CustomerContactPersonId == w.CustomerContactPersonId))
            .ToList();

        if (deletedContacts.Any())
        {
            await _contactPersonRepository.DeleteRangeAsync(deletedContacts);

            // Also remove related appointments
            List<long> deletedContactIds = deletedContacts.Select(c => (long)c.CustomerContactPersonId).ToList();

            IEnumerable<Appointment> relatedAppointment = await _appointmentRepository.GetAllAsync(
                filter: f => deletedContactIds.Contains(f.IdNumber) && f.IdType == (byte)Enums.TypeId.CustomerContactPerson
            );

            if (relatedAppointment.Any())
            {
                await _appointmentRepository.DeleteRangeAsync(relatedAppointment);
            }
        }

        List<CustomerContactPersonDTO> updatedContactsDto = contactPersons.Where(w => w.IsUpdated).ToList();
        List<CustomerContactPersonDTO> newContactsDto = contactPersons.Where(w => !w.IsUpdated).ToList();

        // 3. New Contacts
        if (newContactsDto.Any())
        {
            IEnumerable<CustomerContactPerson> newContacts = newContactsDto.Select(
                s =>
                {
                    var e = _mapper.Map<CustomerContactPerson>(s);
                    e.CustomerNumber = customerNumber;
                    e.CustomerContactPersonGuid = Guid.NewGuid().ToString();
                    e.CreatedDate = DateTime.UtcNow;
                    e.CreatedBy = "Jd";
                    e.CreatedByNumber = 371;

                    // if (CustomerSettings.CapitalizeFirstLetter)
                    // {
                    //     e.FirstName = CapitalizeFirstLetter(e.FirstName);
                    //     e.LastName = CapitalizeFirstLetter(e.LastName);
                    // }

                    //log logic here

                    return e;
                }
            );
            await _contactPersonRepository.AddRangeAsync(newContacts);

            // Create birthday appointment if required
            // if (AppointmentSettings.CreateOrUpdateOnCustomerSave)
            // {
            //     foreach (var contact in newContacts)
            //     {
            //         if (contact.DateOfBirth == null) continue;

            //         int status = await SaveCustomerRelatedAppointmentAsync(
            //             contact.CustomerContactPersonId,
            //             contact.DateOfBirth.Value,
            //             Enums.AppointmentEvent.ContactPersonBirthday,
            //             Enums.TypeId.CustomerContactPerson);

            //         if (status is 1 or 2)
            //             appointmentIds.Add(contact.CustomerContactPersonId);
            //     }
            // }
        }

        // 4. Updated Contacts
        if (updatedContactsDto.Any())
        {
            // Quick lookup dictionary to avoid nested loops
            var existingMap = existingContacts.ToDictionary(c => c.CustomerContactPersonId);

            foreach (var dto in updatedContactsDto)
            {
                if (!existingMap.TryGetValue(dto.CustomerContactPersonId, out var updatedContact))
                    continue; // skip if not found

                // Map changed fields onto the tracked entity
                _mapper.Map(dto, updatedContact);

                updatedContact.ChangedDate = DateTime.UtcNow;
                updatedContact.ChangedBy = "Jd";
                updatedContact.ChangedByNumber = 371;

                // if (CustomerSettings.CapitalizeFirstLetter)
                // {
                //     entity.FirstName = CapitalizeFirstLetter(entity.FirstName);
                //     entity.LastName = CapitalizeFirstLetter(entity.LastName);
                // }

                // entity.InitLogData(LogArea.Editing, _currentUser.PersonalNr);
                await _contactPersonRepository.SaveChangesAsync();

                // Update birthday appointment if required
                // if (AppointmentSettings.CreateOrUpdateOnCustomerSave)
                // {
                //     foreach (var contact in updatedContact)
                //     {
                //         if (contact.DateOfBirth == null) continue;

                //         int status = await SaveCustomerRelatedAppointmentAsync(
                //             contact.CustomerContactPersonId,
                //             contact.DateOfBirth.Value,
                //             Enums.AppointmentEvent.ContactPersonBirthday,
                //             Enums.TypeId.CustomerContactPerson);

                //         if (status is 1 or 2)
                //             appointmentIds.Add(contact.CustomerContactPersonId);
                //     }
                // }
            }
        }
        return appointmentIds;
    }

    // Generate Next customer number
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

    // Save Picture
    public static async Task SavePicturesAsync(List<PictureDTO> files, long customerNumber, string basePath)
    {

        if (files == null || files.Count == 0)
            return;


        if (!Directory.Exists(basePath))
            return;

        if (!basePath.EndsWith(Path.DirectorySeparatorChar))
            basePath += Path.DirectorySeparatorChar;

        int counterFileNumber = 0;

        foreach (var pic in files.OrderByDescending(p => p.IsDeleted))
        {
            // Handle deletions
            if (pic.IsDeleted)
            {
                if (!string.IsNullOrWhiteSpace(pic.FileName))
                {
                    var fullPath = Path.Combine(basePath, Path.GetFileName(pic.FileName));
                    DeleteFileSafe(fullPath);
                }
                continue;
            }

            // Build new sequential name
            var targetName = counterFileNumber == 0
            ? $"{customerNumber}.jpg"
            : $"{customerNumber}_{counterFileNumber}.jpg";
            var targetPath = Path.Combine(basePath, targetName);

            // If there is a new upload, save it to the new name
            if (pic.NewFile != null && pic.NewFile.Length > 0)
            {
                // Remove any existing file at target
                DeleteFileSafe(targetPath);

                await using var fs = new FileStream(
                    targetPath,
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None,
                    bufferSize: 81920,
                    useAsync: true);

                await pic.NewFile.CopyToAsync(fs);
            }
            else if (!string.IsNullOrWhiteSpace(pic.FileName))
            {
                // No new upload—just move/rename the existing file if its number changed
                //rotate functionality is reamaning
                var currentNumber = GetFileNumber(pic.FileName);
                if (currentNumber != counterFileNumber || pic.IsRotated)
                {
                    var oldPath = Path.Combine(basePath, Path.GetFileName(pic.FileName));
                    if (File.Exists(oldPath))
                    {
                        DeleteFileSafe(targetPath);
                        File.Move(oldPath, targetPath, overwrite: true);
                    }
                }
            }
            counterFileNumber++;
        }
    }

    private static void DeleteFileSafe(string path)
    {
        if (string.IsNullOrWhiteSpace(path)) return;
        try { File.Delete(path); }
        catch (IOException)
        {
            Thread.Sleep(100);
            try { File.Delete(path); } catch { /* optional log */ }
        }
    }

    private static int GetFileNumber(string fileName)
    {
        if (string.IsNullOrEmpty(fileName)) return 0;
        var name = Path.GetFileNameWithoutExtension(fileName);
        var parts = name.Split('_');
        return (parts.Length > 1 && int.TryParse(parts[^1], out var n)) ? n : 0;
    }



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
}
