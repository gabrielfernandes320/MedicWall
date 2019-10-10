﻿using Microsoft.EntityFrameworkCore;
using medicwall.Models;
using medicwall.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medicwall.Repositories.Implementation
{
    public class UserRepository : IMedicwallRepository<User>
    {

            readonly medicwallContext _medicwallContext;

            public UserRepository(medicwallContext context)
            {
                _medicwallContext = context;
            }

        public IEnumerable<User> GetAll()
        {
                return _medicwallContext.User
                    .Include(x => x.FkAdressNavigation.FkCityNavigation)
                    .Include(x => x.FkConfmedicoNavigation.FkEspecNavigation)
                    .Include(x => x.FkConfpacienteNavigation)
                    .Include(x => x.FkContactNavigation)
                    .Include(x => x.FkDocumentNavigation)
                    .ToList();
        }

        public async Task<User> Get(int id)
        {
            var user = await _medicwallContext.User.FindAsync(id);
            return user;
        }

        public object Update(int id, User user)
        {
            _medicwallContext.Entry(user).State = EntityState.Modified;

            try
            {
                _medicwallContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return user;

        }

        public async Task<User> Update(int id, object obj)
        {
            _medicwallContext.Entry(obj).State = EntityState.Modified;
          
            try
            {
               await _medicwallContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return await Get(id);

        }

        public bool Exists(int id)
        {
            return _medicwallContext.User.Any(e => e.Id == id);
        }

        public async Task<User> Add(object obj)
        {
            _medicwallContext.User.Add((User)obj);

            try
            {
                await _medicwallContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return (User)obj;
        }

        public async Task<User> Delete(object obj)
        {
            _medicwallContext.User.Remove((User)obj);

            try
            {
                await _medicwallContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return (User)obj;
        }

      
    }
}
