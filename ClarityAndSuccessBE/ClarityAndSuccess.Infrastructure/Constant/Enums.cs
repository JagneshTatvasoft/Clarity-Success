namespace ClarityAndSuccess.Infrastructure.Constant;

public class Enums
{
    // Types for the database field
    public enum TypeId
    {
        none = 0,
        Personnel = 1,
        Supplier = 2,
        Customer = 3,
        Branch = 4,
        SupplierContactPerson = 5,
        CustomerContactPerson = 6,
        CustomerPartner = 7
    }

    /// <summary>
    /// Enum used in Appointment Events
    /// </summary>
    public enum AppointmentEvent
    {
        Birthday = 0,
        Anniversary = 1,
        ContactPersonBirthday = 2,
        PartnerBirthday = 3,
        AfterSalesReminder = 4,
        Warranty = 5,
        JewelleryService = 6,
        WatchBatteryChange = 7,
        WatchRevision = 8
    }

    /// <summary>
    /// Reference Names
    /// </summary>
    public enum ReferenceType
    {
        None = 0,
        Customer = 1,
        Supplier = 2,
        Employee = 3,
        Article = 4
    }

    /// <summary>
    /// Appointment events Color
    /// </summary>
    public enum TVLabels
    {
        Gold = 0,
        Yellow = 1,
        Orange = 2,
        SpringGreen = 3,
        Aquamarine = 4,
        YellowGreen = 5,
        PowderBlue = 6,
        LightSteelBlue = 7,
        LightSkyBlue = 8,
        LightBlue = 9,
        SkyBlue = 10
    }

    /// <summary>
    /// Data Transfer Person Code
    /// </summary>
    public enum DfuePersonCode
    {
        Suppliers = 1,
        Customers = 2,
        Personnel = 3
    }
}
