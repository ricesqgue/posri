using PosRi.BusinessLogic.Dtos;
using PosRi.BusinessLogic.Utils;
using PosRi.DataAccess.Context;
using PosRi.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PosRi.BusinessLogic.Managers
{
    public class UserManager
    {
        public IEnumerable<UserDto> GetUsers()
        {
            using (PosRiContext dbContext = new PosRiContext())
            {
                var users = dbContext.Users.Where(u => u.IsActive).ToList();
                var usersDto = new List<UserDto>();
                
                foreach (var user in users)
                {
                    usersDto.Add(new UserDto(user));
                }

                return usersDto;
            }
        }

        public bool IsValid(MethodTypes httpMethod, UserDto userDto, out string message)
        {
            message = "";
            switch (httpMethod)
            {
                case MethodTypes.Post:
                {
                    using (PosRiContext dbContext = new PosRiContext())
                    {
                        if (dbContext.Users.Any(u => u.IsActive &&
                                                     u.Name.Equals(userDto.Name,
                                                         StringComparison.CurrentCultureIgnoreCase)))
                        {
                            message = $"Ya existe usuario de nombre {userDto.Name}.";
                            return false;
                        }                        
                    }
                    break;
                }

                case MethodTypes.Put:
                {
                    using (PosRiContext dbContext = new PosRiContext())
                    {
                        var user = dbContext.Users.Find(userDto.Id);
                        if (user == null)
                        {
                            message = "Usuario no encontrado.";
                            return false;
                        }

                        if (dbContext.Users.Any(u => u.IsActive && u.Id != userDto.Id &&
                                                     u.Name.Equals(userDto.Name,
                                                         StringComparison.CurrentCultureIgnoreCase)))
                        {
                            message = $"Ya existe usuario de nombre {userDto.Name}.";
                            return false;
                        }
                    }
                    break;
                    }
            }
            return true;
        }

        public UserDto AddUser(UserDto userDto, out string message)
        {
            try
            {
                using (PosRiContext dbContext = new PosRiContext())
                {
                    message = "";
                    List<int> rolesId = userDto.Roles.Select(r => r.Id).ToList();
                    var roles = dbContext.Roles.Where(r => rolesId.Contains(r.Id)).ToList();
                    User user = new User
                    {
                        Name = userDto.Name,
                        Password = userDto.Password,
                        Username = userDto.Username,
                        Birthday = userDto.Birthday,
                        HireDate = userDto.HireDate,
                        Roles = roles,
                        IsActive = true
                    };

                    dbContext.Entry(user).State = EntityState.Added;
                    dbContext.Users.Add(user);

                    if (dbContext.SaveChanges() > 0)
                    {
                        userDto.Id = user.Id;
                        userDto.Password = string.Empty;
                        return userDto;
                    }

                    message = "No se pudo agregar el usuario.";
                    return null;
                }
            }
            catch (Exception e)
            {
                message = e.Message;
                return null;
            }
            
        }

        public UserDto UpdateUser(UserDto userDto, out string message)
        {
            try
            {
                using (PosRiContext dbContext = new PosRiContext())
                {

                    message = "";
                    var user = dbContext.Users.Find(userDto.Id);

                    if (user == null)
                    {
                        message = "Usuario no encontrado.";
                        return null;
                    }

                    List<int> rolesId = userDto.Roles.Select(r => r.Id).ToList();
                    var roles = dbContext.Roles.Where(r => rolesId.Contains(r.Id)).ToList();

                    user.Roles.Clear();
                    user.Roles = roles;

                    user.Name = userDto.Name;
                    user.Username = userDto.Username;
                    user.Birthday = userDto.Birthday;
                    user.HireDate = userDto.HireDate;

                    if (!string.IsNullOrEmpty(userDto.Password))
                    {
                        user.Password = userDto.Password;
                    }

                    dbContext.Entry(user).State = EntityState.Modified;

                    if (dbContext.SaveChanges() > 0)
                    {
                        return userDto;
                    }

                    message = "No se pudo actualizar el usuario.";
                    return null;

                }

            }
            catch (Exception e)
            {
                message = e.Message;
                return null;

            }
        }

        public bool DeleteUser(UserDto userDto, out string message)
        {
            try
            {
                using (PosRiContext dbContext = new PosRiContext())
                {
                    var user = dbContext.Users.Find(userDto.Id);

                    if (user == null)
                    {
                        message = "Usuario no encontrado.";
                        return false;
                    }

                    user.IsActive = false;
                    user.Roles.Clear();

                    dbContext.Entry(user).State = EntityState.Modified;

                    if (dbContext.SaveChanges() > 0)
                    {
                        message = "";
                        return true;
                    }

                    message = "No se pudo eliminar el usario.";
                    return false;
                }
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }
    }

}
