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
    public class CustomerManager
    {
        public IEnumerable<CustomerDto> GetCustomers()
        {
            using (PosRiContext dbContext = new PosRiContext())
            {
                var customers = dbContext.Customers
                    .Where(u => u.IsActive)
                    .Include(u => u.State)
                    .ToList();

                var customersDto = new List<CustomerDto>();

                foreach (var customer in customers)
                {
                    customersDto.Add(new CustomerDto(customer));
                }

                return customersDto;
            }
        }

        public bool IsValid(MethodTypes httpMethod, CustomerDto customerDto, out string message)
        {
            message = "";
            switch (httpMethod)
            {
                case MethodTypes.Post:
                {
                    using (PosRiContext dbContext = new PosRiContext())
                    {
                        if (dbContext.Customers.Any(u => u.IsActive &&
                                                      u.Name.Equals(customerDto.Name,
                                                          StringComparison.CurrentCultureIgnoreCase)))
                        {
                            message = $"Ya existe un cliente con el nombre {customerDto.Name}.";
                            return false;
                        }
                    }
                    break;
                }

                case MethodTypes.Put:
                {
                    using (PosRiContext dbContext = new PosRiContext())
                    {
                        var customer = dbContext.Customers.Find(customerDto.Id);
                        if (customer == null)
                        {
                            message = "Cliente no encontrado.";
                            return false;
                        }

                        if (dbContext.Customers.Any(u => u.IsActive && u.Id != customerDto.Id &&
                                                      u.Name.Equals(customerDto.Name,
                                                          StringComparison.CurrentCultureIgnoreCase)))
                        {
                            message = $"Ya existe un cliente con el nombre {customerDto.Name}.";
                            return false;
                        }
                    }
                    break;
                }
            }
            return true;
        }

        public CustomerDto AddCustomer(CustomerDto customerDto, out string message)
        {
            try
            {
                using (PosRiContext dbContext = new PosRiContext())
                {
                    message = "";

                    Customer customer = new Customer
                    {
                        Name = customerDto.Name,
                        Address = customerDto.Address,
                        City = customerDto.City,
                        CreationDate = DateTime.Now,
                        Phone = customerDto.Phone,
                        Email = customerDto.Email,
                        Rfc = customerDto.Email,
                        IsActive = true,
                        StateId = customerDto.State.Id
                    };

                    dbContext.Entry(customer).State = EntityState.Added;
                    dbContext.Customers.Add(customer);

                    if (dbContext.SaveChanges() > 0)
                    {
                        customerDto.Id = customer.Id;
                        return customerDto;
                    }

                    message = "No se pudo agregar el cliente.";
                    return null;
                }
            }
            catch (Exception e)
            {
                message = $"No se pudo agregar el cliente. {e.Message}";
                return null;
            }

        }

        public CustomerDto UpdateCustomer(CustomerDto customerDto, out string message)
        {
            try
            {
                using (PosRiContext dbContext = new PosRiContext())
                {

                    message = "";
                    var customer = dbContext.Customers.Find(customerDto.Id);

                    if (customer == null)
                    {
                        message = "Cliente no encontrado.";
                        return null;
                    }

                    customer.Name = customerDto.Name;
                    customer.Address = customerDto.Address;
                    customer.City = customerDto.City;
                    customer.Email = customerDto.Email;
                    customer.Phone = customerDto.Phone;
                    customer.Rfc = customerDto.Rfc;
                    customer.StateId = customerDto.State.Id;

                    dbContext.Entry(customer).State = EntityState.Modified;

                    if (dbContext.SaveChanges() > 0)
                    {
                        return customerDto;
                    }

                    message = "No se pudo actualizar el cliente.";
                    return null;

                }

            }
            catch (Exception e)
            {
                message = $"No se pudo actualizar el cliente. {e.Message}";
                return null;

            }
        }

        public bool DeleteCustomer(CustomerDto customerDto, out string message)
        {
            try
            {
                using (PosRiContext dbContext = new PosRiContext())
                {
                    var customer = dbContext.Customers.Find(customerDto.Id);

                    if (customer == null)
                    {
                        message = "Cliente no encontrado.";
                        return false;
                    }

                    customer.IsActive = false;

                    dbContext.Entry(customer).State = EntityState.Modified;

                    if (dbContext.SaveChanges() > 0)
                    {
                        message = "";
                        return true;
                    }

                    message = "No se pudo eliminar el cliente.";
                    return false;
                }
            }
            catch (Exception e)
            {
                message = $"No se pudo eliminar el cliente. {e.Message}";
                return false;
            }
        }

    }
}
