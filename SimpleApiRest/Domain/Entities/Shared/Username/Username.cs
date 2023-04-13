using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace SimpleApiRest.Domain.Entities.Shared.Username;

public class UsernameEntity
{
    public string Value { get; private set; }
    
    private UsernameEntity(string username)
    {
        Value = username;
    }

    public static UsernameEntity Create(string username)
    {
        var userNameEntity = new UsernameEntity(username);
        new UsernameEntityValidator().Validate(userNameEntity , strategy => strategy.ThrowOnFailures());
        return userNameEntity;
    }
    
    
    
    
}




