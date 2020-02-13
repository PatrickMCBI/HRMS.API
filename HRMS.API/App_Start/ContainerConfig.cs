using System.Reflection;
using System.Web.Mvc;
using Autofac;
using System.Web.Http;
using Autofac.Integration.WebApi;
using System.Collections;
using System.Collections.Generic;

namespace HRMS.API.App_Start
{
    public class ContainerConfig
    {

        public static void Configure()
        {

            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            //builder.RegisterType<ValuesController>().InstancePerRequest();
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //Item Data Registering.....
            //builder.RegisterType<SQLBL>().As<ISQLBL>().WithParameter("connectionString", Properties.Settings.Default.connectionString);

            builder.RegisterType<HRMS.ApiBL._001a_hrmRefPrefixListBL>().As<HRMS.ApiBL.I_001a_hrmRefPrefixListBL<HRMSDL._001a_hrmRefPrefixListDomain>>();
            builder.RegisterType< HRMS.ApiBL._001b_hrmRefGenderListBL >().As<HRMS.ApiBL.I_001b_hrmRefGenderListBL<HRMSDL._001b_hrmRefGenderListDomain>>();
            builder.RegisterType<HRMS.ApiBL._001c_hrmRefEmpNumberListBL>().As<HRMS.ApiBL.I_001c_hrmRefEmpNumberListBL<HRMSDL._001c_hrmRefEmpNumberListDomain>>();
            builder.RegisterType<HRMS.ApiBL._001d_hrmRefPositionListBL>().As<HRMS.ApiBL.I_001d_hrmRefPositionListBL<HRMSDL._001d_hrmRefPositionListDomain>>();
            builder.RegisterType<HRMS.ApiBL._001e_hrmRefPositionRankListBL>().As<HRMS.ApiBL.I_001e_hrmRefPositionRankListBL<HRMSDL._001e_hrmRefPositionRankListDomain>>();
            builder.RegisterType<HRMS.ApiBL._001f_hrmRefEmpStatusListBLv>().As<HRMS.ApiBL.I_001f_hrmRefEmpStatusListBLv<HRMSDL._001f_hrmRefEmpStatusListDomain>>();
            builder.RegisterType<HRMS.ApiBL._001g_hrmRefEmpTypeListBL>().As<HRMS.ApiBL.I_001g_hrmRefEmpTypeListBL<HRMSDL._001g_hrmRefEmpTypeListDomain>>();
            builder.RegisterType<HRMS.ApiBL._002a_hrmEmpMasterListBL>().As<HRMS.ApiBL.I_002a_hrmEmpMasterListBL<HRMSDL._002a_hrmEmpMasterListDomain>>();
            builder.RegisterType<HRMS.ApiBL._002b_hrmPersonalInfoBL>().As<HRMS.ApiBL.I_002b_hrmPersonalInfoBL<HRMSDL._002b_hrmPersonalInfoDomain>>();
            builder.RegisterType<HRMS.ApiBL._002c_hrmEmploymentInfoBL>().As<HRMS.ApiBL.I_002c_hrmEmploymentInfoBL<HRMSDL._002c_hrmEmploymentInfoDomain>>();
            builder.RegisterType<HRMS.ApiBL._002d_hrmSpouseNameBL>().As<HRMS.ApiBL.I_002d_hrmSpouseNameBL<HRMSDL._002d_hrmSpouseNameDomain>>();
            builder.RegisterType<HRMS.ApiBL._002e_hrmEmpAllowanceBL>().As<HRMS.ApiBL.I_002e_hrmEmpAllowanceBL<HRMSDL._002e_hrmEmpAllowanceDomain>>();
            builder.RegisterType<HRMS.ApiBL._002f_hrmEmpPositionBL>().As<HRMS.ApiBL.I_002f_hrmEmpPositionBL<HRMSDL._002f_hrmEmpPositionDomain>>();
            builder.RegisterType<HRMS.ApiBL._002g_hrmEmpSalaryBL>().As<HRMS.ApiBL.I_002g_hrmEmpSalaryBL<HRMSDL._002g_hrmEmpSalaryDomain>>();
            builder.RegisterType<HRMS.ApiBL._002h_hrmEmpSalaryAddOnBL>().As<HRMS.ApiBL.I_002h_hrmEmpSalaryAddOnBL<HRMSDL._002h_hrmEmpSalaryAddOnDomain>>();
            builder.RegisterType<HRMS.ApiBL.PersonInformationBL>().As<HRMS.ApiBL.I_PersonInformationBL<HRMS.DL.PersonInformationDL>>();

            List<Autofac.Core.Parameter> pars = new List<Autofac.Core.Parameter>();
            //pars.Add( new Autofac.Core.Parameter(""))


            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            //builder.RegisterWebApiModelBinderProvider();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            //return container;


            /*var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<InventoryBL._001_invRefCategory1BL>().As<InventoryBL.I_001_invRefCategory1BL<Inventory_Domain_Layer._001_invRefCategory1Domain>>();

            var container = builder.Build();

            var config = GlobalConfiguration.Configuration;

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            */

        }

    }
}