using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.ObjectBuilder;

namespace KirkChen.Library.EntlibExtension
{
    public class InterceptionExtension: UnityContainerExtension
    {
        protected override void Initialize()
        {
            Context.Strategies.AddNew<InterceptionStrategy>(UnityBuildStage.PreCreation);
        }
    }
}
