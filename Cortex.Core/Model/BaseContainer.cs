using System;
using System.Collections.Generic;
using System.Linq;
using Cortex.Core.Model.Nodes;
using Cortex.Core.Model.Serialization;

namespace Cortex.Core.Model
{
    public abstract class BaseContainer : IContainer
    {
        private readonly Dictionary<IConatinerNode, Dictionary<string, object>> _metaData =
            new Dictionary<IConatinerNode, Dictionary<string, object>>();

        private List<IConnection> _connections = new List<IConnection>();
        private List<INode> _elements = new List<INode>();

        public IEnumerable<INode> Elements => _elements;
        public IEnumerable<IConnection> Connections => _connections;

        public event Action<IContainer, INode> ElementAdded;
        public event Action<IContainer, INode> ElementRemoved;
        public event Action<IContainer, IConnection> ConnectionAdded;
        public event Action<IContainer, IConnection> ConnectionRemoved;

        public void AddElement(INode node)
        {
            if (_elements.Contains(node))
                throw new Exception("Duplicate node");
            _elements.Add(node);

            var handler = ElementAdded;
            handler?.Invoke(this, node);
        }

        public void RemoveElement(INode node)
        {
            IConnection[] relatedConnections =
                _connections.Where(c => c.StartNode.Equals(node) || c.EndNode.Equals(node)).ToArray();
            foreach (IConnection connection in relatedConnections)
                RemoveConnection(connection);
            _elements.Remove(node);

            if (_metaData.ContainsKey(node))
                _metaData.Remove(node);

            var handler = ElementRemoved;
            handler?.Invoke(this, node);
        }

        public void AddConnection(IConnection connection)
        {
            if (!_elements.Contains(connection.StartNode) || !_elements.Contains(connection.EndNode))
                throw new Exception("No such elements");

            connection.Establish();
            _connections.Add(connection);

            var handler = ConnectionAdded;
            handler?.Invoke(this, connection);
        }

        public void RemoveConnection(IConnection connection)
        {
            if (_connections.Contains(connection))
            {
                connection.Clear();
            }

            _connections.Remove(connection);

            var handler = ConnectionRemoved;
            handler?.Invoke(this, connection);
        }
        
        public T GetMetaData<T>(IConatinerNode element, string key)
        {
            return (T) _metaData[element][key];
        }

        public IDictionary<string, object> GetMetaData(IConatinerNode element)
        {
            if (!_metaData.ContainsKey(element))
                return null;

            return _metaData[element];
        }

        public void SetMetaData<T>(IConatinerNode element, string key, T value)
        {
            if (!_metaData.ContainsKey(element))
                _metaData.Add(element, new Dictionary<string, object>());
            if (!_metaData[element].ContainsKey(key))
                _metaData[element].Add(key, value);
            else
                _metaData[element][key] = value;
        }

        public void Save(IPersisterWriter persister)
        {
            persister.Set("Elements", new PersistableCollection<INode>(Elements));
            persister.Set("Connections", new PersistableCollection<IConnection>(Connections));

            var meta = new PersistableDictionary<IConatinerNode, PersistableDictionary<string, Object>>();
            foreach (INode e in Elements)
            {
                meta.Add(e, new PersistableDictionary<string, object>(GetMetaData(e)));
            }

            persister.Set("Metadata", new PersistableDictionary<IConatinerNode, PersistableDictionary<string, Object>>(meta));
        }

        public void Load(IPersisterReader persister)
        {
            _elements = persister.Get<PersistableCollection<INode>>("Elements");
            _connections = persister.Get<PersistableCollection<IConnection>>("Connections");

            foreach (IConnection connection in Connections)
            {
                connection.Establish();
            }

            var meta = persister.Get<PersistableDictionary<IConatinerNode, PersistableDictionary<string, Object>>>("Metadata");

            foreach (var kvp in meta)
            {
                _metaData.Add(kvp.Key, kvp.Value);
            }
        }
    }
}