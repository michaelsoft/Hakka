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

        public CrudAppServiceBase(IRepository<TEntity> repository)
        {
            this.EntityToEntityDtoMapper = this.ConfigEntityToDtoMapper();
            this.CreateDtoToEntityMapper = this.ConfigCreateDtoToEntityMapper();
            this.UpdateDtoToEntityMapper = this.ConfigUpdateDtoToEntityMapper();
            this.repository = repository;
        }

        #region CRUD methods
        public async virtual Task<TDto> CreateAsync(TCreateDto input)
        {
            var entity = this.CreateDtoToEntityMapper.Map<TEntity>(input);
            var entityInserted = await this.repository.InsertAsync(entity);

            return this.EntityToEntityDtoMapper.Map<TDto>(entityInserted);
        }

        public async virtual Task<TDto> UpdateAsync(int id, TUpdateDto input)
        {
            var entity = this.UpdateDtoToEntityMapper.Map<TEntity>(input);
            entity.Id = id;
            var entityUpdated = await this.repository.UpdateAsync(entity);

            return this.EntityToEntityDtoMapper.Map<TDto>(entityUpdated);
        }

        public async virtual Task DeleteByIdAsync(int id)
        {
            var entity = await this.repository.GetByIdAsync(id);
            await this.repository.DeleteAsync(entity);
        }

        public async virtual Task<TDto> GetByIdAsync(int id)
        {
            var entity = await this.repository.GetByIdAsync(id);
            var entityDto = this.EntityToEntityDtoMapper.Map<TDto>(entity);
            return entityDto;
        }

        public async virtual Task<List<TDto>> GetListAsync()
        {
            var entities = await this.repository.GetListAsync();
            return MapEntitiesToEntityDtoes(entities);
        }

        private List<TDto> MapEntitiesToEntityDtoes(List<TEntity> entities)
        {
            List<TDto> retVal = new List<TDto>();

            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    var entityDto = this.EntityToEntityDtoMapper.Map<TDto>(entity);
                    retVal.Add(entityDto);
                }
            }

            return retVal;
        }
        #endregion

        #region Config Mappers
        protected virtual IMapper ConfigCreateDtoToEntityMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = prop => prop.Name != "Id"; //ToDo:
                cfg.CreateMap<TCreateDto, TEntity>();
            });
            configuration.AssertConfigurationIsValid();
            return configuration.CreateMapper();
        }

        protected virtual IMapper ConfigUpdateDtoToEntityMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = prop => prop.Name != "Id"; //ToDo:
                cfg.CreateMap<TUpdateDto, TEntity>();
            });
            configuration.AssertConfigurationIsValid();
            return configuration.CreateMapper();
        }

        protected virtual IMapper ConfigEntityToDtoMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TDto>();
            });
            configuration.AssertConfigurationIsValid();
            return configuration.CreateMapper();
        }
        #endregion
    }
}
