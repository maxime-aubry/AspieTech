using AspieTech.BridgeHandler.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspieTech.DataAccessLayer.FactoryManager
{
    public class FactoryContainerBase : IFactoryContainer
    {
        #region Private properties
        protected Dictionary<Type, IFactory> factories;
        #endregion

        #region Constructors
        public FactoryContainerBase()
        {
            this.factories = new Dictionary<Type, IFactory>();
            
        }
        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters

        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Public methods
        public virtual TFactory GetFactory<TFactory>() where TFactory : IFactory
        {
            Type type = typeof(TFactory);
            TFactory factory = default(TFactory);

            if (this.factories.ContainsKey(type))
            {
                factory = (TFactory)this.factories[type];
            }
            else
            {
                Type assignableType = this.factories.Keys.FirstOrDefault(t => t.IsAssignableFrom(type) || type.IsAssignableFrom(t));

                if (assignableType != null && this.factories.ContainsKey(assignableType))
                    factory = (TFactory)this.factories[assignableType];
            }

            return factory;
        }
        #endregion

        #region Private methods

        #endregion
    }
}