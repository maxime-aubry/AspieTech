using Castle.DynamicProxy;

namespace AspieTech.Engine.Handlers.Vaillant
{
    public class ProxyProvider
    {
        #region Private properties
        private static ProxyProvider instance;
        #endregion

        #region Constructors

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
        public static ProxyProvider GetInstance()
        {
            if (ProxyProvider.instance == null)
                ProxyProvider.instance = new ProxyProvider();
            return ProxyProvider.instance;
        }

        public T ProvideProxy<T>(IInterceptor proxyHandler)
        {
            ProxyGenerator generator = new ProxyGenerator();
            return (T)generator.CreateInterfaceProxyWithoutTarget(typeof(T), proxyHandler);
        }
        #endregion

        #region Private methods

        #endregion
    }
}