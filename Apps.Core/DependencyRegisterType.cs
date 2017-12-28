using Apps.BLL;
using Apps.DAL;
using Apps.IBLL;
using Apps.IDAL;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Core
{
    public class DependencyRegisterType
    {
        //Injection
        public static void Container_Sys(ref UnityContainer container)
        {
            container.RegisterType<ISysSampleBLL, SysSampleBLL>();//test page
            container.RegisterType<ISysSampleRepository, SysSampleRepository>();
        }
    }
}
