﻿
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using AutomationSQLdm.Commons;
using AutomationSQLdm.Configuration;
using AutomationSQLdm.Grooming_Modifications;

namespace AutomationSQLdm.AddServers
{
  
    [TestModule("A669C8F5-F555-4E6F-93B4-D292E1DA1DE9", ModuleType.UserCode, 1)]
    public class PrerequisitiesForAddingServers :Base.BaseClass, ITestModule
    {
      
        public PrerequisitiesForAddingServers()
        {
            // Do not delete - a parameterless constructor is required!
        }
	 	void ITestModule.Run()
        {
         	StartProcess();
        }
        
        bool StartProcess()
        {
        	try 
        	{
        		Steps.AddSQLServerInstance(Config.ServerOptions_DEFAULTSERVER); //CMWIN2016-S8
        		
        	} 
        	catch (Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;
        }
       
    }
}
