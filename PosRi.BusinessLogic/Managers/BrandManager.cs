
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
    public class BrandManager
    {
        public IEnumerable<BrandDto> GetBrands()
        {
            using (PosRiContext dbContext = new PosRiContext())
            {
                var brands = dbContext.Brands.Where(u => u.IsActive).ToList();
                var brandsDto = new List<BrandDto>();

                foreach (var brand in brands)
                {
                    brandsDto.Add(new BrandDto(brand));
                }

                return brandsDto;
            }
        }

        public bool IsValid(MethodTypes httpMethod, BrandDto brandDto, out string message)
        {
            message = "";
            switch (httpMethod)
            {
                case MethodTypes.Post:
                {
                    using (PosRiContext dbContext = new PosRiContext())
                    {
                        if (dbContext.Brands.Any(u => u.IsActive &&
                                                     u.Name.Equals(brandDto.Name,
                                                         StringComparison.CurrentCultureIgnoreCase)))
                        {
                            message = $"Ya existe una marca llamada {brandDto.Name}.";
                            return false;
                        }
                    }
                    break;
                }

                case MethodTypes.Put:
                {
                    using (PosRiContext dbContext = new PosRiContext())
                    {
                        var brand = dbContext.Brands.Find(brandDto.Id);
                        if (brand == null)
                        {
                            message = "Marca no encontrada.";
                            return false;
                        }

                        if (dbContext.Brands.Any(u => u.IsActive && u.Id != brandDto.Id &&
                                                     u.Name.Equals(brandDto.Name,
                                                         StringComparison.CurrentCultureIgnoreCase)))
                        {
                            message = $"Ya existe una marca llamada {brandDto.Name}.";
                                return false;
                        }
                    }
                    break;
                }
            }
            return true;
        }

        public BrandDto AddBrand(BrandDto brandDto, out string message)
        {
            try
            {
                using (PosRiContext dbContext = new PosRiContext())
                {
                    message = "";

                    Brand brand = new Brand
                    {
                        Name = brandDto.Name,
                        IsActive = true
                    };

                    dbContext.Entry(brand).State = EntityState.Added;
                    dbContext.Brands.Add(brand);

                    if (dbContext.SaveChanges() > 0)
                    {
                        brandDto.Id = brand.Id;
                        return brandDto;
                    }

                    message = "No se pudo agregar la marca.";
                    return null;
                }
            }
            catch (Exception e)
            {
                message = e.Message;
                return null;
            }

        }

        public BrandDto UpdateBrand(BrandDto brandDto, out string message)
        {
            try
            {
                using (PosRiContext dbContext = new PosRiContext())
                {

                    message = "";
                    var brand = dbContext.Brands.Find(brandDto.Id);

                    if (brand == null)
                    {
                        message = "Marca no encontrada.";
                        return null;
                    }

                    brand.Name = brandDto.Name;

                    dbContext.Entry(brand).State = EntityState.Modified;

                    if (dbContext.SaveChanges() > 0)
                    {
                        return brandDto;
                    }

                    message = "No se pudo actualizar la marca.";
                    return null;

                }

            }
            catch (Exception e)
            {
                message = e.Message;
                return null;

            }
        }

        public bool DeleteBrand(BrandDto brandDto, out string message)
        {
            try
            {
                using (PosRiContext dbContext = new PosRiContext())
                {
                    var brand = dbContext.Brands.Find(brandDto.Id);

                    if (brand == null)
                    {
                        message = "Marca no encontrada.";
                        return false;
                    }

                    brand.IsActive = false;

                    dbContext.Entry(brand).State = EntityState.Modified;

                    if (dbContext.SaveChanges() > 0)
                    {
                        message = "";
                        return true;
                    }

                    message = "No se pudo eliminar la marca.";
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
