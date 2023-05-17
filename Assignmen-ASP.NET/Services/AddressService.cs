using Assignmen_ASP.NET.Helpers.Repositories;
using Assignmen_ASP.NET.Models.Entities;
using Assignmen_ASP.NET.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Assignmen_ASP.NET.Services;

public class AddressService
{
    private readonly AddressRepository _addressRepo;
    private readonly UserAddressRepository _userAddressRepo;

    public AddressService(AddressRepository addressRepo, UserAddressRepository userAddressRepo)
    {
        _addressRepo = addressRepo;
        _userAddressRepo = userAddressRepo;
    }

    public async Task<AddressEntity> GetOrCreateAsync(AddressEntity addressEntity)
    {
        var entity = await _addressRepo.GetAsync(x =>
        x.StreetName == addressEntity.StreetName &&
        x.PostalCode == addressEntity.PostalCode &&
        x.City == addressEntity.City
        );

        entity ??= await _addressRepo.AddAsync(addressEntity);
        return entity!;
    }


    public async Task<AddressEntity> GetAsync(Expression<Func<AddressEntity, bool>> expression)
    {
        var entities = await _addressRepo.GetAllAsync(expression);
        var entity = entities.FirstOrDefault();
        return entity ?? new AddressEntity();
    }




    public async Task AddAddressAsync(AppUser user, AddressEntity addressEntity)
    {
        await _userAddressRepo.AddAsync(new UserAddressEntity
        {
            UserId = user.Id,
            AddressId = addressEntity.Id
        });
    }


    public async Task<IEnumerable<AddressEntity>> GetAllAddressesAsync()
    {
        return await _addressRepo.GetAllAsync();
    }


    public async Task<bool> UpdateUserAddressAsync(UserAddressEntity userAddress)
    {
        try
        {
            await _userAddressRepo.UpdateAsync(userAddress);
            return true;
        }
        catch
        {
            return false;
        }
    }



}
