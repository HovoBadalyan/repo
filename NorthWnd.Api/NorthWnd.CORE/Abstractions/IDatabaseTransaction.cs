using System;

namespace NorthWnd.CORE.Abstractions
{
    public interface IDatabaseTransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
