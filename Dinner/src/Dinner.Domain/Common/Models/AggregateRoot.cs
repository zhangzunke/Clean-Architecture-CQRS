﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.Common.Models
{
    public abstract class AggregateRoot<TKey> : Entity<TKey> where TKey : notnull
    {
        protected AggregateRoot(TKey id) : base(id)
        {
        }

#pragma warning disable CS8618
        protected AggregateRoot()
        {

        }
#pragma warning restore CS8618
    }
}
