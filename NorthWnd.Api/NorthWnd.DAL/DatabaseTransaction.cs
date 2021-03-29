using Microsoft.EntityFrameworkCore.Storage;
using NorthWnd.CORE.Abstractions;
using NorthWnd.CORE.Entities;
using System;
using System.Data;

namespace NorthWnd.DAL
{
    public class DatabaseTransaction : IDatabaseTransaction
    {
        private readonly IDbContextTransaction _transaction;
        private bool disposedValue;

        public DatabaseTransaction(NORTHWNDContext context, IsolationLevel isolation)
        {
            _transaction = context.Database.BeginTransaction();
        }
        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _transaction.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
