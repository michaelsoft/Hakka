using System;
using System.Threading.Tasks;
using Hakka.Domain.Repositories;
using Hakka.Domain.Entities;
using AutoMapper;
using System.Collections.Generic;

namespace Hakka.App
{
    public abstract class CrudAppServiceBase<TCreateDto, TUpdateDto, TDto, TEntity>
        where TCreateDto : class
        where TUpdateDto : class
        where TDto : class
        where TEntity : Entity
    {
        private IRepository<TEntity> repository;
        private readonly IMapper mapper;

        #region Mappers
        protected IMapper CreateDtoToEntityMapper
        {
            get;
            private set;
        }

        protected IMapper UpdateDtoToEntityMapper
        {
            get;
            private set;
        }

        protected IMapper EntityToEntityDtoMapper
        {
            get;
            private set;
        }
        #endregion

        public CrudAppServiceBase(IRepository<TEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        #region CRUD methods
        public async virtual Task<TDto> CreateAsync(TCreateDto input)
        {
            var entity = this.mapper.Map<TEntity>(input);
            var entityInserted = await this.repository.InsertAsync(entity);

            return this.mapper.Map<TDto>(entityInserted);
        }

        public async virtual Task<TDto> UpdateAsync(int id, TUpdateDto input)
        {
            var entity = this.mapper.Map<TEntity>(input);
            entity.Id = id;
            var entityUpdated = await this.repository.UpdateAsync(entity);

            return this.mapper.Map<TDto>(entityUpdated);
        }

        public async virtual Task DeleteByIdAsync(int id)
        {
            var entity = await this.repository.GetByIdAsync(id);
            await this.repository.DeleteAsync(entity);
        }

        public async virtual Task<TDto> GetByIdAsync(int id)
        {
            var entity = await this.repository.GetByIdAsync(id);
            var entityDto = this.mapper.Map<TDto>(entity);
            return entityDto;
        }

        public async virtual Task<List<TDto>> GetListAsync()
        {
            var entities = await this.repository.GetListAsync();
            return this.mapper.Map<List<TDto>>(entities);
        }

        #endregion


    }
}
