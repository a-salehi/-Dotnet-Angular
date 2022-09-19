using Dotnet_Angular.Database;
using Dotnet_Angular.Domain;
using Dotnet_Angular.Model;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.Objects;
using DotNetCore.Results;
using DotNetCore.Validation;

namespace Dotnet_Angular.Application;

public sealed class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserFactory _userFactory;
    private readonly IUserRepository _userRepository;

    public UserService
    (
        IUnitOfWork unitOfWork,
        IUserFactory userFactory,
        IUserRepository userRepository
    )
    {
        _unitOfWork = unitOfWork;
        _userFactory = userFactory;
        _userRepository = userRepository;
    }

    public async Task<IResult<long>> AddAsync(UserModel model)
    {
        var validation = new AddUserModelValidator().Validation(model);

        if (validation.Failed) return validation.Fail<long>();


        var user = _userFactory.Create(model);

        await _userRepository.AddAsync(user);

        await _unitOfWork.SaveChangesAsync();

        return user.Id.Success();
    }

    public async Task<IResult> DeleteAsync(long id)
    {

        await _userRepository.DeleteAsync(id);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }

    public Task<UserModel> GetAsync(long id)
    {
        return _userRepository.GetModelAsync(id);
    }

    public Task<Grid<UserModel>> GridAsync(GridParameters parameters)
    {
        return _userRepository.GridAsync(parameters);
    }

    public async Task<IResult> InactivateAsync(long id)
    {
        var user = new User(id);

        user.Inactivate();

        await _userRepository.UpdateStatusAsync(user);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<IEnumerable<UserModel>> ListAsync()
    {
        return await _userRepository.ListModelAsync();
    }

    public async Task<IResult> UpdateAsync(UserModel model)
    {
        var validation = new UpdateUserModelValidator().Validation(model);

        if (validation.Failed) return validation;

        var user = await _userRepository.GetAsync(model.Id);

        if (user is null) return Result.Success();

        user.Update(model.FirstName, model.LastName, model.Email, model.Place);

        await _userRepository.UpdateAsync(user);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
