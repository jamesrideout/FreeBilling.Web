﻿using FreeBilling.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FreeBilling.Web.Data;

public class BillingRepository : IBillingRepository
{
    private readonly BillingContext _context;
    private readonly ILogger<BillingRepository> _logger;

    public BillingRepository(BillingContext context, ILogger<BillingRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<Employee>> GetEmployees()
    {
        try
        {
            return await _context.Employees
            .OrderBy(e => e.Name)
            .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Could not get Employees: {ex.Message}");
            throw;
        }
    }

    public async Task<IEnumerable<Customer>> GetCustomers()
    {
        try
        {
            return await _context.Customers
            .OrderBy(c => c.CompanyName)
            .ToListAsync();
        }
        catch (Exception ex)
        {
                _logger.LogError($"Could not get Customers: {ex.Message}");
                throw;
        }
    }

    public async Task<IEnumerable<Customer>> GetCustomersWithAddresses()
    {
        try
        {
            return await _context.Customers
            .Include(c => c.Address)
            .OrderBy(c => c.CompanyName)
            .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Could not get Customers: {ex.Message}");
            throw;
        }
    }

    public async Task<Customer?> GetCustomer(int id)
    {
        try
        {
            return await _context.Customers
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Could not get Customers: {ex.Message}");
            throw;
        }
    }

    public async Task<bool> SaveChanges()
    {
        try
        {
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Could not Save to Database: {ex.Message}");
            throw;
        }
    }

    public async Task<TimeBill?> GetTimeBill(int id)
    {
        var bill = await _context.TimeBills.FindAsync(id);
        return bill;
    }

    public void AddEntity<T>(T entity) where T : notnull
    {
        _context.Add(entity);
    }
}
