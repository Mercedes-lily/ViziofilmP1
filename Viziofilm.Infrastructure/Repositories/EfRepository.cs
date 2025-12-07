using Microsoft.EntityFrameworkCore;
using Viziofilm.Infrastructure;
using Viziofilm.SharedKernel;
using Viziofilm.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viziofilm.Infrastructure.Repositories
{
	public class EfRepository<T> : IAsyncRepository<T>, IRepository<T> where T : BaseEntity, IAggregateRoot
	{
		protected readonly ViziofilmContext _ViziofilmContext;

		public EfRepository(ViziofilmContext viziofilmContext)
		{
			_ViziofilmContext = viziofilmContext;
		}
		public async Task<T> GetByIdAsync(int id)
		{
			return await _ViziofilmContext.Set<T>().FindAsync(id);
		}
		public async Task<IReadOnlyList<T>> ListAllAsync()
		{
			return await _ViziofilmContext.Set<T>().ToListAsync();
		}
		public async Task<T> AddAsync(T entity)
		{
			await _ViziofilmContext.Set<T>().AddAsync(entity);
			await _ViziofilmContext.SaveChangesAsync();
			return entity;
		}
		public async Task UpdateAsync(T entity)
		{
			_ViziofilmContext.Entry(entity).State = EntityState.Modified;
			await _ViziofilmContext.SaveChangesAsync();
		}
		public async Task DeleteAsync(T entity)
		{
			_ViziofilmContext.Set<T>().Remove(entity);
			await _ViziofilmContext.SaveChangesAsync();
		}
		private IQueryable<T> ApplySpecification(ISpecification<T> spec)
		{
			return
			SpecificationEvaluator<T>.GetQuery(_ViziofilmContext.Set<T>().AsQueryable(), spec);
		}
		public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
		{
			return await ApplySpecification(spec).ToListAsync();
		}
		public async Task<int> CountAsync(ISpecification<T> spec)
		{
			return await ApplySpecification(spec).CountAsync();
		}

		public T GetById(int id)
		{
			return _ViziofilmContext.Set<T>().Find(id);
		}

		public IReadOnlyList<T> ListAll()
		{
			return _ViziofilmContext.Set<T>().ToList();
		}

		public IReadOnlyList<T> List(ISpecification<T> spec)
		{
			throw new NotImplementedException();
		}

		public T Add(T entity)
		{
			_ViziofilmContext.Set<T>().Add(entity);
			_ViziofilmContext.SaveChanges();
			return entity;
		}

		public int Update(T entity)
		{
			throw new NotImplementedException();
		}

		public int Delete(T entity)
		{
			throw new NotImplementedException();
		}

		public int Count(ISpecification<T> spec)
		{
			throw new NotImplementedException();
		}
	}
}
