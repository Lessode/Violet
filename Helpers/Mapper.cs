﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Violet.Repositories;

namespace Violet.Helpers
{
    public class Mapper<TEntity, TViewModel> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repository;

        public Mapper(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public TEntity ViewModelToEntity(TEntity entity, TViewModel viewModel)
        {
            foreach (var item in viewModel.GetType().GetProperties())
            {
                var entityProperty = entity.GetType().GetProperty(item.Name);

                entityProperty.SetValue(
                    entity,
                    Convert.ChangeType(item.GetValue(viewModel, null), entityProperty.PropertyType),
                    null
                );
            }

            return entity;
        }

        public TViewModel EntityToViewModel(TViewModel viewModel, TEntity entity)
        {
            foreach (var item in entity.GetType().GetProperties())
            {
                var viewModelProperty = viewModel.GetType().GetProperty(item.Name);

                viewModelProperty.SetValue(
                    viewModel,
                    Convert.ChangeType(item.GetValue(entity, null), viewModelProperty.PropertyType),
                    null
                );
            }

            return viewModel;
        }
    }
}