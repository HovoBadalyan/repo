using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerArchitecure.Core.Abstractions
{
    public interface IDatabaseTransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
