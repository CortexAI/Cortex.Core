using System;
using System.Collections.Generic;
using Cortex.Core.Model.Serialization;

namespace Cortex.Core.Model
{
    public interface IContainer : IPersistable
    {
        IEnumerable<INode> Elements { get; }
        IEnumerable<IConnection> Connections { get; }

        event Action<IContainer, INode> ElementAdded;
        event Action<IContainer, INode> ElementRemoved;
        event Action<IContainer, IConnection> ConnectionAdded;
        event Action<IContainer, IConnection> ConnectionRemoved;

        void AddElement(INode node);
        void RemoveElement(INode node);
        void AddConnection(IConnection connection);
        void RemoveConnection(IConnection connection);

        T GetMetaData<T>(IConatinerNode element, string key);
        IDictionary<string, object> GetMetaData(IConatinerNode element);
        void SetMetaData<T>(IConatinerNode element, string key, T value);
    }
}