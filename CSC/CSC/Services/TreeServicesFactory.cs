using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC
{
    public class TreeServicesFactory : ITreeServicesFactory
    {
        private readonly Container _container; 

        public TreeServicesFactory(Container container)
        {
            _container = container;
        }

        public ITreeHandler Create()
        {
            return _container.GetInstance<TreeHandler>();
        }
    }
}
