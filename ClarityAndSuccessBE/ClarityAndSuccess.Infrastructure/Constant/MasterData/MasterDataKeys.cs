namespace ClarityAndSuccess.Infrastructure.Constant.MasterData;

/// <summary>
/// Central list of master-data keys used in the Stammdaten table.
/// Each constant maps to the `Bezeichnung` column value.
/// </summary>
public class MasterDataKeys
{
    public const string CustomerDataOnlyMasterData = "KundenDatenNurStammdaten";
    public const string CustomerDataOnlyMasterDataSalutation = "Anrede";
}
