// StatusService.cs
using Ecommerce.core.dtos;
using Ecommerce.core.dtos.request;
using Ecommerce.core.Interface;
using Status = Ecommerce.core.Entities.Status; // Assuming you have a Status entity

namespace Ecommerce.core.Service;

public class StatusService : IStatusService
{
    private readonly IStatusRepository _statusRepository;

    public StatusService(IStatusRepository statusRepository)
    {
        _statusRepository = statusRepository;
    }
    

    public async Task<IEnumerable<StatusResponseDto>> GetStatusesAsync(CancellationToken token)
    {
        var statuses = await _statusRepository.GetStatusesAsync(token);
        var result = new List<StatusResponseDto>();
        
        foreach (var status in statuses)
        {
            result.Add(new StatusResponseDto() { Name = status.Name });
        }
        return result;
    }


    public async Task<StatusResponseDto> CreateStatusAsync(CancellationToken token, StatusRequestDto dto)
    {

        var statusObj = new Status()
        {
            Name = dto.Name
        };


        if (statusObj.Equals(null) || string.IsNullOrEmpty(statusObj.Name))
        {
            throw new ArgumentException("Status can not be null or the Name be empty or null");
        }
        if (await _statusRepository.IsStatusAlreadyPresentAsync(token, statusObj))
        {
            throw new ArgumentException("Status with name " + statusObj.Name + " already exists");
        }


        var result = await _statusRepository.CreateStatusAsync(token, statusObj);


        return new StatusResponseDto() { Name = result.Name };
    }


    public async Task<bool> RemoveStatusAsync(CancellationToken token, string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("The name can not be empty or null");
        }
        
        return await _statusRepository.RemoveStatusAsync(token, name) > 0;
    }
}