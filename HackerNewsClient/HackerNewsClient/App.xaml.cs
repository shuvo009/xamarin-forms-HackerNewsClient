using System;
using System.Collections.Generic;
using CommonServiceLocator;
using HackerNewsClient.Core.Interface;
using HackerNewsClient.Repository;
using HackerNewsClient.Service;
using HackerNewsClient.Service.AppServices;
using HackerNewsClient.Service.CommonServices;
using HackerNewsClient.ViewModels;
using Unity;
using Unity.Lifetime;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HackerNewsClient
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            RegisterDependency();
            new AutoMapperStarter().Initialize();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        #region Supported Methods

        private void RegisterDependency()
        {
            var unityContainer = new UnityContainer();

            #region Platform Specific 

            unityContainer.RegisterInstance(typeof(ITextToSpeech),  DependencyService.Get<ITextToSpeech>());

            #endregion

            #region App Service
            unityContainer.RegisterType<IStoryService, StoryService>();

            #endregion
            
            #region Common Service

            unityContainer.RegisterType<IRestService, RestService>();
            unityContainer.RegisterType<IHackerNewsService, HackerNewsService>();
            unityContainer.RegisterType<ICrashReportService, CrashReportService>();

            #endregion

            #region Repository

            unityContainer.RegisterType<IStoryRepository, StoryRepository>();
            
            #endregion

            #region ViewModel

            unityContainer.RegisterInstance(typeof(StoryViewModel));

            #endregion


            var unityServiceLocator = new UnityServiceLocator(unityContainer);
            ServiceLocator.SetLocatorProvider(() => unityServiceLocator);

        }

        #endregion
    }

    public sealed class UnityServiceLocator : ServiceLocatorImplBase, IDisposable
    {
        private IUnityContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityServiceLocator"/> class for a container.
        /// </summary>
        /// <param name="container">The <see cref="IUnityContainer"/> to wrap with the <see cref="IServiceLocator"/>
        /// interface implementation.</param>
        public UnityServiceLocator(IUnityContainer container)
        {
            _container = container;
            container.RegisterInstance<IServiceLocator>(this, new ExternallyControlledLifetimeManager());
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            if (_container != null)
            {
                _container.Dispose();
                _container = null;
            }
        }

        /// <summary>
        /// When implemented by inheriting classes, this method will do the actual work of resolving
        ///             the requested service instance.
        /// </summary>
        /// <param name="serviceType">Type of instance requested.</param><param name="key">Name of registered service you want. May be null.</param>
        /// <returns>
        /// The requested service instance.
        /// </returns>
        protected override object DoGetInstance(Type serviceType, string key)
        {
            if (_container == null)
            {
                throw new ObjectDisposedException("container");
            }

            var name = string.IsNullOrEmpty(key) ? null : key;
            return _container.Resolve(serviceType, name);
        }

        /// <summary>
        /// When implemented by inheriting classes, this method will do the actual work of
        ///             resolving all the requested service instances.
        /// </summary>
        /// <param name="serviceType">Type of service requested.</param>
        /// <returns>
        /// Sequence of service instance objects.
        /// </returns>
        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            if (_container == null)
            {
                throw new ObjectDisposedException("container");
            }

            return _container.ResolveAll(serviceType);
        }
    }
}
