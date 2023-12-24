using HeadHunterAggregator.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;

namespace HeadHunterAggregator.Infrastructure.Databases.EntityFramework.Extensions
{
    public static class EntityTypeBuilderExtensions
    {
        public static void OneToOne<TEntity, TRelatedEntity>(this EntityTypeBuilder<TEntity> builder, 
            Expression<Func<TEntity, TRelatedEntity?>> field, Expression<Func<TRelatedEntity, TEntity?>> foreignField, 
                Expression<Func<TRelatedEntity, object?>> foreignKey, bool isRequired = true) 
                    where TEntity : EntityBase where TRelatedEntity : EntityBase
        {
            builder.HasOne(field).WithOne(foreignField).HasForeignKey(foreignKey).IsRequired(isRequired);
        }

        public static void OneToMany<TEntity, TRelatedEntity>(this EntityTypeBuilder<TEntity> builder, 
            Expression<Func<TEntity, IEnumerable<TRelatedEntity>?>> arrayField, 
                Expression<Func<TRelatedEntity, TEntity?>> foreignField, Expression<Func<TRelatedEntity, object?>> foreignKey, 
                    bool isRequired = true) where TEntity : EntityBase where TRelatedEntity : EntityBase
        {
            builder.HasMany(arrayField).WithOne(foreignField).HasForeignKey(foreignKey).IsRequired(isRequired);
        }
    }
}
