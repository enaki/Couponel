﻿using System;
using System.Linq.Expressions;
using Couponel.Business.Coupons.Coupons.Models.SearchModels;
using Couponel.Entities;
using LinqBuilder.Core;
using LinqBuilder.OrderBy;

namespace Couponel.Business.Coupons.Extensions
{
    public static class SearchModelExtensions
    {
        public static ISpecification<T> ToSpecification<T>(this SearchModel model) where T : Entity
        {
            var parameterExpression = Expression.Parameter(typeof(T));

            var memberExpression = Expression.Property(parameterExpression, model.SortColumn);

            var expression = Expression.Convert(memberExpression, typeof(object));

            var lambda = Expression.Lambda<Func<T, object>>(expression, parameterExpression);

            return OrderSpec<T, object>
                .New(lambda, model.SortType)
                .Paginate(model.PageIndex, model.PageSize);
        }
    }
}
