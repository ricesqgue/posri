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
    public class StoreManager
    {
        public IEnumerable<StoreDto> GetStores()
        {
            using (PosRiContext dbContext = new PosRiContext())
            {
                var stores = dbContext.Stores.Where(u => u.IsActive).ToList();
                var storesDto = new List<StoreDto>();

                foreach (var store in stores)
                {
                    storesDto.Add(new StoreDto(store));
                }

                return storesDto;
            }
        }

        public bool IsValid(MethodTypes httpMethod, StoreDto storeDto, out string message)
        {
            message = "";
            switch (httpMethod)
            {
                case MethodTypes.Post:
                {
                    using (PosRiContext dbContext = new PosRiContext())
                    {
                        if (dbContext.Stores.Any(u => u.IsActive &&
                                                      u.Name.Equals(storeDto.Name,
                                                          StringComparison.CurrentCultureIgnoreCase)))
                        {
                            message = $"Ya existe una sucursal llamada {storeDto.Name}.";
                            return false;
                        }
                    }
                    break;
                }

                case MethodTypes.Put:
                {
                    using (PosRiContext dbContext = new PosRiContext())
                    {
                        var store = dbContext.Stores.Find(storeDto.Id);
                        if (store == null)
                        {
                            message = "Sucursal no encontrada.";
                            return false;
                        }

                        if (dbContext.Stores.Any(u => u.IsActive && u.Id != storeDto.Id &&
                                                      u.Name.Equals(storeDto.Name,
                                                          StringComparison.CurrentCultureIgnoreCase)))
                        {
                            message = $"Ya existe una sucursal llamada {storeDto.Name}.";
                            return false;
                        }
                    }
                    break;
                }
            }
            return true;
        }

        public StoreDto AddStore(StoreDto storeDto, out string message)
        {
            try
            {
                using (PosRiContext dbContext = new PosRiContext())
                {
                    message = "";

                    Store store = new Store
                    {
                        Name = storeDto.Name,
                        Address = storeDto.Address,
                        Phone = storeDto.Phone,
                        IsActive = true
                    };

                    dbContext.Entry(store).State = EntityState.Added;
                    dbContext.Stores.Add(store);

                    if (dbContext.SaveChanges() > 0)
                    {
                        storeDto.Id = store.Id;
                        return storeDto;
                    }

                    message = "No se pudo agregar la sucursal.";
                    return null;
                }
            }
            catch (Exception e)
            {
                message = e.Message;
                return null;
            }

        }

        public StoreDto UpdateStore(StoreDto storeDto, out string message)
        {
            try
            {
                using (PosRiContext dbContext = new PosRiContext())
                {

                    message = "";
                    var store = dbContext.Stores.Find(storeDto.Id);

                    if (store == null)
                    {
                        message = "Sucursal no encontrada.";
                        return null;
                    }

                    store.Name = storeDto.Name;
                    store.Address = store.Address;
                    store.Phone = store.Phone;

                    dbContext.Entry(store).State = EntityState.Modified;

                    if (dbContext.SaveChanges() > 0)
                    {
                        return storeDto;
                    }

                    message = "No se pudo actualizar la sucursal.";
                    return null;

                }

            }
            catch (Exception e)
            {
                message = e.Message;
                return null;

            }
        }

        public bool DeleteStore(StoreDto storeDto, out string message)
        {
            try
            {
                using (PosRiContext dbContext = new PosRiContext())
                {
                    var store = dbContext.Stores.Find(storeDto.Id);

                    if (store == null)
                    {
                        message = "Sucursal no encontrada.";
                        return false;
                    }

                    store.IsActive = false;

                    foreach (var storeCashRegister in store.CashRegisters)
                    {
                        storeCashRegister.IsActive = false;
                        dbContext.Entry(storeCashRegister).State = EntityState.Modified;
                    }

                    dbContext.Entry(store).State = EntityState.Modified;

                    if (dbContext.SaveChanges() > 0)
                    {
                        message = "";
                        return true;
                    }

                    message = "No se pudo eliminar la sucursal.";
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
