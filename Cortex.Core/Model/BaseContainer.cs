using System;
using System.Collections.Generic;
using System.Linq;
using Cortex.Core.Model.Serialization;

namespace Cortex.Core.Model
{
    public abstract class BaseContainer : IContainer
    {
        private readonly Dictionary<INode, Dictionary<string, object>> _metaData =
            new Dictionary<INode, Dictionary<string, object>>();

        private List<IConnection> _connections = new List<IConnection>();
        private List<IElement> _elements = new List<IElement>();

        public IEnumerable<IElement> Elements => _elements;
        public IEnumerable<IConnection> Connections => _connections;

        public event Action<IContainer, IElement> ElementAdded;
        public event Action<IContainer, IElement> ElementRemoved;
        public event Action<IContainer, IConnection> ConnectionAdded;
        public event Action<IContainer, IConnection> ConnectionRemoved;

        public void AddElement(IElement element)
        {
            if (_elements.Contains(element))
                throw new Exception("Duplicate element");
            _elements.Add(element);

            var handler = ElementAdded;
            handler?.Invoke(this, element);
        }

        public void RemoveElement(IElement element)
        {
            IConnection[] relatedConnections =
                _connections.Where(c => c.StartElement.Equals(element) || c.EndElement.Equals(element)).ToArray();
            foreach (IConnection connection in relatedConnections)
                RemoveConnection(connection);
            _elements.Remove(element);

            if (_metaData.ContainsKey(element))
                _metaData.Remove(element);

            var handler = ElementRemoved;
            handler?.Invoke(this, element);
        }

        public void AddConnection(IConnection connection)
        {
            if (!_elements.Contains(connection.StartElement) || !_elements.Contains(connection.EndElement))
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
        
        public T GetMetaData<T>(INode element, string key)
        {
            return (T) _metaData[element][key];
        }

        public IDictionary<string, object> GetMetaData(INode element)
        {
            if (!_metaData.ContainsKey(element))
                return null;

            return _metaData[element];
        }

        public void SetMetaData<T>(INode element, string key, T value)
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
            persister.Set("Elements", new PersistableCollection<IElement>(Elements));
            persister.Set("Connections", new PersistableCollection<IConnection>(Connections));

            var meta = new PersistableDictionary<INode, PersistableDictionary<string, Object>>();
            foreach (IElement e in Elements)
            {
                meta.Add(e, new PersistableDictionary<string, object>(GetMetaData(e)));
            }

            persister.Set("Metadata", new PersistableDictionary<INode, PersistableDictionary<string, Object>>(meta));
        }

        public void Load(IPersisterReader persister)
        {
            _elements = persister.Get<PersistableCollection<IElement>>("Elements");
            _connections = persister.Get<PersistableCollection<IConnection>>("Connections");

            foreach (IConnection connection in Connections)
            {
                connection.Establish();
            }

            var meta = persister.Get<PersistableDictionary<INode, PersistableDictionary<string, Object>>>("Metadata");

            foreach (var kvp in meta)
            {
                _metaData.Add(kvp.Key, kvp.Value);
            }
        }
    }
}