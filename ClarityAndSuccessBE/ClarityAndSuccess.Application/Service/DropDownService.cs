using ClarityAndSuccess.Application.Interface;
using ClarityAndSuccess.Infrastructure.Constant.MasterData;
using ClarityAndSuccess.Infrastructure.DTO.DropDown;
using ClarityAndSuccess.Infrastructure.Interface;

namespace ClarityAndSuccess.Application.Service;

public class DropDownService(IMasterDataRepository masterDataRepository,IArticleMasterDataRepository articleMasterDataRepository) : IDropDownService
{
    private readonly IMasterDataRepository _masterDataRepository = masterDataRepository;
    private readonly IArticleMasterDataRepository _articleMasterDataRepository = articleMasterDataRepository;
    public async Task<AllDropDownDTO> GetAllDropdownAsync()
    {
        return new AllDropDownDTO();
    }

    public Task<List<DropDownOptionDTO>> LoadSalutation(bool? isActive)
    {
        List<DropDownOptionDTO> dropDownOption = [];

        string data2 = _masterDataRepository.GetDataAsync(
            description: MasterDataKeys.CustomerDataOnlyMasterData,
            data1: MasterDataKeys.CustomerDataOnlyMasterDataSalutation,
            dataNo: 2);

        if (!string.IsNullOrWhiteSpace(data2))
        {
            data2 = "";
        }
        if (data2 == "1")
        {
            //  IsErlaubtEigeneEingabenAnrede = False 'Keine eigenen Texteingaben in der Comboboxk
            dropDownOption = _articleMasterDataRepository.GetSelectAsync(
                
            );
        }
    }
}
