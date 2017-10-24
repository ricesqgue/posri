using PosRi.DataAccess.Context;
using PosRi.DataAccess.Model;
using PosRi.Utils.Dtos;
using PosRi.Utils.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PosRi.BusinessLogic.Managers
{
    public class CashRegisterManager
    {
        public IEnumerable<CashRegisterDto> GetCashRegisters()
        {
            using (PosRiContext dbContext = new PosRiContext())
            {
                var cashRegisters = dbContext.CashRegisters.Where(u => u.IsActive).ToList();
                var cashRegistersDto = new List<CashRegisterDto>();

                foreach (var cashRegister in cashRegisters)
                {
                    cashRegistersDto.Add(new CashRegisterDto(cashRegister));
                }

                return cashRegistersDto;
            }
        }

        public bool IsValid(MethodTypes httpMethod, CashRegisterDto cashRegisterDto, out string message)
        {
            message = "";
            switch (httpMethod)
            {
                case MethodTypes.Post:
                {
                    using (PosRiContext dbContext = new PosRiContext())
                    {
                        if (dbContext.CashRegisters.Any(u => u.IsActive &&
                                                      u.Name.Equals(cashRegisterDto.Name,
                                                          StringComparison.CurrentCultureIgnoreCase) && u.StoreId == cashRegisterDto.Store.Id))
                        {
                            message = $"Ya existe una caja llamada {cashRegisterDto.Name}.";
                            return false;
                        }
                    }
                    break;
                }

                case MethodTypes.Put:
                {
                    using (PosRiContext dbContext = new PosRiContext())
                    {
                        var cashRegister = dbContext.CashRegisters.Find(cashRegisterDto.Id);
                        if (cashRegister == null)
                        {
                            message = "Caja no encontrada.";
                            return false;
                        }

                        if (dbContext.CashRegisters.Any(u => u.IsActive && u.Id != cashRegisterDto.Id &&
                                                      u.Name.Equals(cashRegisterDto.Name,
                                                          StringComparison.CurrentCultureIgnoreCase) && u.StoreId == cashRegisterDto.Store.Id))
                        {
                            message = $"Ya existe una caja llamada {cashRegisterDto.Name}.";
                            return false;
                        }
                    }
                    break;
                }
            }
            return true;
        }

        public CashRegisterDto AddCashRegister(CashRegisterDto cashRegisterDto, out string message)
        {
            try
            {
                using (PosRiContext dbContext = new PosRiContext())
                {
                    message = string.Empty;

                    CashRegister cashRegister = new CashRegister
                    {
                        Name = cashRegisterDto.Name,
                        IsActive = true
                    };

                    CashFound cashFound = new CashFound
                    {
                        CashRegister = cashRegister,
                        Quantity = 0,
                        RegisterDate = DateTime.Now,
                        //UserId = cashRegisterDto.User.Id
                    };

                    dbContext.Entry(cashRegister).State = EntityState.Added;
                    dbContext.Entry(cashFound).State = EntityState.Added;
                    dbContext.CashRegisters.Add(cashRegister);
                    dbContext.CashFounds.Add(cashFound);

                    if (dbContext.SaveChanges() > 0)
                    {
                        cashRegisterDto.Id = cashRegister.Id;
                        return cashRegisterDto;
                    }

                    message = "No se pudo agregar la caja.";
                    return null;
                }
            }
            catch (Exception e)
            {
                message = $"No se pudo agregar la caja. {e.Message}";
                return null;
            }

        }

        public CashRegisterDto UpdateCashRegister(CashRegisterDto cashRegisterDto, out string message)
        {
            try
            {
                using (PosRiContext dbContext = new PosRiContext())
                {

                    message = "";
                    var cashRegister = dbContext.CashRegisters.Find(cashRegisterDto.Id);

                    if (cashRegister == null)
                    {
                        message = "Caja no encontrada.";
                        return null;
                    }

                    cashRegister.Name = cashRegisterDto.Name;

                    dbContext.Entry(cashRegister).State = EntityState.Modified;

                    if (dbContext.SaveChanges() > 0)
                    {
                        return cashRegisterDto;
                    }

                    message = "No se pudo actualizar la caja.";
                    return null;

                }

            }
            catch (Exception e)
            {
                message = e.Message;
                return null;

            }
        }

        public bool DeleteCashRegister(CashRegisterDto cashRegisterDto, out string message)
        {
            try
            {
                using (PosRiContext dbContext = new PosRiContext())
                {
                    var cashRegister = dbContext.CashRegisters.Find(cashRegisterDto.Id);

                    if (cashRegister == null)
                    {
                        message = "Caja no encontrada.";
                        return false;
                    }

                    cashRegister.IsActive = false;

                    dbContext.Entry(cashRegister).State = EntityState.Modified;

                    if (dbContext.SaveChanges() > 0)
                    {
                        message = "";
                        return true;
                    }

                    message = "No se pudo eliminar la caja.";
                    return false;
                }
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }

        public CashFoundDto SaveCashFound(CashFoundDto cashFoundDto, out string message)
        {
            try
            {
                using (PosRiContext dbContext = new PosRiContext())
                {

                    message = string.Empty;

                    CashFound cashFound = new CashFound
                    {
                        UserId = cashFoundDto.User.Id,
                        CashRegisterId = cashFoundDto.CashRegister.Id,
                        Quantity = cashFoundDto.Quantity,
                        RegisterDate = DateTime.Now
                    };

                    dbContext.Entry(cashFound).State = EntityState.Added;
                    dbContext.CashFounds.Add(cashFound);

                    if (dbContext.SaveChanges() > 0)
                    {
                        cashFoundDto.Id = cashFound.Id;
                        return cashFoundDto;
                    }

                    message = "No se pudo agregar el fondo de caja.";
                    return null;
                }
            }
            catch (Exception e)
            {
                message = $"No se pudo agregar el fondo de caja. {e.Message}";
                return null;
            }
        }

        public ICollection<CashFoundDto> GetCashFounds(int cashRegisterId, out string message)
        {
            try
            {
                using (PosRiContext dbContext = new PosRiContext())
                {
                    message = string.Empty;

                    var cashFounds = dbContext.CashFounds.Where(c => c.CashRegisterId == cashRegisterId).ToList();

                    var cashFoundsDto = new List<CashFoundDto>();

                    foreach (var cashFound in cashFounds)
                    {
                        cashFoundsDto.Add(new CashFoundDto(cashFound));
                    }

                    return cashFoundsDto;
                }
            }
            catch (Exception e)
            {
                message = e.Message;
                return null;
            }
        }

        public CashFoundDto GetCashFound(int cashRegisterId, out string message)
        {
            try
            {
                using (PosRiContext dbContext = new PosRiContext())
                {
                    message = string.Empty;

                    var cashfound = dbContext.CashFounds.LastOrDefault(c => c.CashRegisterId == cashRegisterId);

                    if (cashfound != null)
                    {
                        var cashFoundDto = new CashFoundDto(cashfound);
                        return cashFoundDto;
                    }

                    return new CashFoundDto();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
