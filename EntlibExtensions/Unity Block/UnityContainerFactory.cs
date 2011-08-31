using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ContainerModel.Unity;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace KirkChen.Library.EntlibExtension
{
    public class UnityContainerFactory
    {
        private static IUnityContainer m_unityContainer;
        private static readonly object m_locker = new object();

        public static IUnityContainer GetUnityContainer()
        {
            if (m_unityContainer == null)
            {
                lock (m_locker)
                {
                    if (m_unityContainer == null)
                    {
                        m_unityContainer = new UnityContainer();

                        UnityContainerConfigurator configurator = new UnityContainerConfigurator(m_unityContainer);
                        EnterpriseLibraryContainer.ConfigureContainer(configurator, ConfigurationSourceFactory.Create());
                        m_unityContainer.AddNewExtension<InterceptionExtension>();

                        //If load mapping setting from config
                        //m_unityContainer.LoadConfiguration();
                    }
                }
            }

            return m_unityContainer;
        }
    }
}
