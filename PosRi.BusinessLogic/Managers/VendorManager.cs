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
    public class VendorManager
    {
        public IEnumerable<VendorDto> GetVendors()
        {
            using (PosRiContext dbContext = new PosRiContext())
            {
                var vendors = dbContext.Vendors
                    .Where(u => u.IsActive)
                    .Include(u => u.State)
                    .Include(v => v.Brands)
                    .ToList();

                var vendorsDto = new List<VendorDto>();

                foreach (var vendor in vendors)
                {
                    vendorsDto.Add(new VendorDto(vendor));
                }

                return vendorsDto;
            }
        }

        public bool IsValid(MethodTypes httpMethod, VendorDto vendorDto, out string message)
        {
            message = "";
            switch (httpMethod)
            {
                case MethodTypes.Post:
                {
                    using (PosRiContext dbContext = new PosRiContext())
                    {
                        if (dbContext.Vendors.Any(u => u.IsActive &&
                                                         u.Name.Equals(vendorDto.Name,
                                                             StringComparison.CurrentCultureIgnoreCase)))
                        {
                            message = $"Ya existe un provedeor con el nombre {vendorDto.Name}.";
                            return false;
                        }
                    }
                    break;
                }

                case MethodTypes.Put:
                {
                    using (PosRiContext dbContext = new PosRiContext())
                    {
                        var vendor = dbContext.Vendors.Find(vendorDto.Id);
                        if (vendor == null)
                        {
                            message = "Proveedor no encontrado.";
                            return false;
                        }

                        if (dbContext.Vendors.Any(u => u.IsActive && u.Id != vendorDto.Id &&
                                                         u.Name.Equals(vendorDto.Name,
                                                             StringComparison.CurrentCultureIgnoreCase)))
                        {
                            message = $"Ya existe un proveedor con el nombre {vendorDto.Name}.";
                            return false;
                        }
                    }
                    break;
                }
            }
            return true;
        }

        public VendorDto AddVendor(VendorDto vendorDto, out string message)
        {
            try
            {
                using (PosRiContext dbContext = new PosRiContext())
                {
                    message = "";

                    var idBrands = vendorDto.Brands.Select(b => b.Id).ToList();

                    var brands = dbContext.Brands.Where(b => idBrands.Contains(b.Id)).ToList();

                    Vendor vendor = new Vendor
                    {
                        Name = vendorDto.Name,
                        Address = vendorDto.Address,
                        City = vendorDto.City,
                        CreationDate = DateTime.Now,
                        Phone = vendorDto.Phone,
                        Email = vendorDto.Email,
                        Rfc = vendorDto.Email,
                        IsActive = true,
                        StateId = vendorDto.StateId,
                        Brands = brands
                    };

                    dbContext.Entry(vendor).State = EntityState.Added;
                    dbContext.Vendors.Add(vendor);

                    if (dbContext.SaveChanges() > 0)
                    {
                        vendorDto.Id = vendor.Id;
                        return vendorDto;
                    }

                    message = "No se pudo agregar el proveedor.";
                    return null;
                }
            }
            catch (Exception e)
            {
                message = $"No se pudo agregar el proveedor. {e.Message}";
                return null;
            }

        }

        public VendorDto UpdateVendor(VendorDto vendorDto, out string message)
        {
            try
            {
                using (PosRiContext dbContext = new PosRiContext())
                {

                    message = "";
                    var vendor = dbContext.Vendors.Find(vendorDto.Id);

                    if (vendor == null)
                    {
                        message = "Proveedor no encontrado.";
                        return null;
                    }

                    vendor.Brands.Clear();

                    var idBrands = vendorDto.Brands.Select(b => b.Id).ToList();

                    var brands = dbContext.Brands.Where(b => idBrands.Contains(b.Id)).ToList();

                    vendor.Name = vendorDto.Name;
                    vendor.Address = vendorDto.Address;
                    vendor.City = vendorDto.City;
                    vendor.Email = vendorDto.Email;
                    vendor.Phone = vendorDto.Phone;
                    vendor.Rfc = vendorDto.Rfc;
                    vendor.StateId = vendorDto.StateId;
                    vendor.Brands = brands;

                    dbContext.Entry(vendor).State = EntityState.Modified;

                    if (dbContext.SaveChanges() > 0)
                    {
                        return vendorDto;
                    }

                    message = "No se pudo actualizar el proveedor.";
                    return null;

                }

            }
            catch (Exception e)
            {
                message = $"No se pudo actualizar el proveedor. {e.Message}";
                return null;

            }
        }

        public bool DeleteVendor(VendorDto vendorDto, out string message)
        {
            try
            {
                using (PosRiContext dbContext = new PosRiContext())
                {
                    var vendor = dbContext.Vendors.Find(vendorDto.Id);

                    if (vendor == null)
                    {
                        message = "Proveedor no encontrado.";
                        return false;
                    }

                    vendor.IsActive = false;

                    dbContext.Entry(vendor).State = EntityState.Modified;

                    if (dbContext.SaveChanges() > 0)
                    {
                        message = "";
                        return true;
                    }

                    message = "No se pudo eliminar el proveedor.";
                    return false;
                }
            }
            catch (Exception e)
            {
                message = $"No se pudo eliminar el proveedor. {e.Message}";
                return false;
            }
        }

    }
}
