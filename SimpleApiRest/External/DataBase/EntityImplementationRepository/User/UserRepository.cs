﻿using SimpleApiRest.Domain.Entity;
using SimpleApiRest.Domain.Models;
using SimpleApiRest.Domain.Ports.Repository;
using SimpleApiRest.Domain.Ports.Repository.User;
using SimpleApiRest.Infra;

namespace SimpleApiRest.External.DataBase.EntityImplementationRepository.User;

public class UserEntityImplRepository : IUserRepository
{
    private readonly AppDataContext _dbContext;
    public UserEntityImplRepository(
        AppDataContext dbContext
    )
    {
        _dbContext = dbContext;
    }
    
    public async Task<UserModel> Add(UserEntity entity)
    {
        var userCreated = await _dbContext.Users.AddAsync(entity.GetModel());
        await _dbContext.SaveChangesAsync();
        return userCreated.Entity;
    }
    
    public Task<UserModel> FindById(Guid guid)
    {
        throw new NotImplementedException();
    }

    public void Remove(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<UserModel> Update(Guid guid, UserEntity model)
    {
        throw new NotImplementedException();
    }

    public Task<UserModel> Update(Guid guid, UserEntityInput entity)
    {
        throw new NotImplementedException();
    }
}