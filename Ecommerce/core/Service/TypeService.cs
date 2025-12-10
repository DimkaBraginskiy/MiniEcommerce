using Ecommerce.core.dtos;
using Ecommerce.core.dtos.request;
using Ecommerce.core.Interface;
using Type = Ecommerce.core.Entities.Type;

namespace Ecommerce.core.Service;

public class TypeService : ITypeService
{
    private readonly ITypeRepository _typeRepository;

    public TypeService(ITypeRepository typeRepository)
    {
        _typeRepository = typeRepository;
    }
    
    public async Task<IEnumerable<TypeResponseDto>> GetTypesAsync(CancellationToken token)
    {
        var types = await _typeRepository.GetTypesAsync(token);

        var result = new List<TypeResponseDto>();
        
        foreach (var type in types)
        {
            var typeDto = new TypeResponseDto()
            {
                Name = type.Name
            };
            result.Add(typeDto);
        }

        return result;
    }

    public async Task<TypeResponseDto> CreateTypeAsync(CancellationToken token, TypeRequestDto dto)
    {

        var typeObj = new Type()
        {
            Name = dto.Name
        };

        if (typeObj.Equals(null) || string.IsNullOrEmpty(typeObj.Name))
        {
            throw new ArgumentException("Type can not be null or the Name be empty or null");
        }

        if (await _typeRepository.IsTypeAlreadyPresentAsync(token, typeObj))
        {
            throw new ArgumentException("Type with name " + typeObj.Name + " already exists");
        }

        var result = await _typeRepository.CreateTypeAsync(token, typeObj);


        return new TypeResponseDto()
        { 
            Name = result.Name
        };

    }

    public async Task<bool> RemoveTypeAsync(CancellationToken token, string name)
    {
        try
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("The name can not be empty or null");
            }

            if (await _typeRepository.RemoveTypeAsync(token, name) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}