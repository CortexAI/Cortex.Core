using System;

namespace Cortex.Core.Model
{
    public interface IPin
    {
        string Name { get; }
        Type Type { get; }
    }
}