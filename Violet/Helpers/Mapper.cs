using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Violet.Repositories;

namespace Violet.Helpers
{
    public class Mapper<TEntity, TViewModel> where TEntity : class
    {
        public TEntity ViewModelToEntity(TEntity entity, TViewModel viewModel)
        {
            foreach (var item in viewModel.GetType().GetProperties())
            {
                PropertyInfo entityProperty = entity.GetType().GetProperty(item.Name);

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
                PropertyInfo viewModelProperty = viewModel.GetType().GetProperty(item.Name);

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
