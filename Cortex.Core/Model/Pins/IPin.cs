using System;

namespace Cortex.Core.Model.Pins
{
    public interface IPin
    {
        string Name { get; }
        Type Type { get; }
    }
}