using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Hapy.DB
{
    public interface IDbCommands<T>
    {
        bool Save();
        TBase FetchSingleRecord<TBase>(dynamic id) where TBase : class;
        void Insert<TBase>(TBase dataObject) where TBase : class;
        void ActionState<TBase>(TBase dataObject, EntityState entityState) where TBase : class;
        void DeleteByID<TBase>(dynamic id) where TBase : class;
        GetId InsertGetId<TBase, GetId>(TBase dataObject) where TBase : class;
    }
}
