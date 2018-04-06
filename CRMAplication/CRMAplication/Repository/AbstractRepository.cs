﻿using CRMAplication.Interfaces;
using CRMAplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CRMAplication.Repository
{
    public class AbstractRepository<T> : IAbstractRepository<T> where T : class , IBasicEntity
    {
        public virtual void Create(T entity)
        {
            using (var context = new ApplicationDbContext())
            {
                entity.DateCreate = DateTime.Now;
                entity.Modificationdate = entity.DateCreate;
                entity.Aktywnosc = true;
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public virtual void Update(T entity)
        {
            using (var context = new ApplicationDbContext())
            {
                entity.Modificationdate = DateTime.Now;
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    entity.RecordModificationAuthor = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    entity.RecordModificationAuthor = "Unauthorized person";
                }
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public virtual void Delete(T entity)
        {
            using (var context = new ApplicationDbContext())
            {
                entity.RecordModificationAuthor = HttpContext.Current.User.Identity.Name;
                entity.Aktywnosc = false;
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public virtual List<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            using (var context = new ApplicationDbContext())
            {
                var query = context.Set<T>().Where(expression);
                return query.ToList();
            }
        }
    }
}
