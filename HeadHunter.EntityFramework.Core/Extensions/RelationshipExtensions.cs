using HeadHunter.Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;

namespace HeadHunter.EntityFramework.Core.Extensions
{
    public static class RelationshipExtensions
    {
        public static void OneToOne<TEntity, TRelatedEntity>(this EntityTypeBuilder<TEntity> builder, 
            Expression<Func<TEntity, TRelatedEntity?>> field, Expression<Func<TRelatedEntity, TEntity?>> foreignField, 
            Expression<Func<TRelatedEntity, object?>> foreignKey, bool isRequired = true) 
            where TEntity : EntityBase, IAggregateRoot
            where TRelatedEntity : EntityBase, IAggregateRoot
        {
            builder.HasOne(field).WithOne(foreignField).HasForeignKey(foreignKey).IsRequired(isRequired);
        }

        public static void OneToMany<TEntity, TRelatedEntity>(this EntityTypeBuilder<TEntity> builder, 
            Expression<Func<TEntity, IEnumerable<TRelatedEntity>?>> arrayField, 
            Expression<Func<TRelatedEntity, TEntity?>> foreignField, 
            Expression<Func<TRelatedEntity, object?>> foreignKey, 
            bool isRequired = true) 
            where TEntity : EntityBase, IAggregateRoot 
            where TRelatedEntity : EntityBase, IAggregateRoot
        {
            builder.HasMany(arrayField).WithOne(foreignField).HasForeignKey(foreignKey).IsRequired(isRequired);
        }
    }
}
