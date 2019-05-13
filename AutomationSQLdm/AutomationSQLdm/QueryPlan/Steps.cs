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
using AutomationSQLdm.Extensions;
using AutomationSQLdm.Configuration;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using AutomationSQLdm.DataBaseOperations;

namespace AutomationSQLdm.QueryPlan
{
   
    [TestModule("3DB530C4-EC44-47A4-A9B3-3A46D548F489", ModuleType.UserCode, 1)]
    public static class Steps 
    {
       
        public static QueryPlanRepo repo = QueryPlanRepo.Instance;
	//	public const string GROOMING_MENU = @"/contextmenu[@processname='SQLdmDesktopClient']/menuitem[@automationid='menuToolsGrooming']";
		public const string FILECONNECT_MENU = @"/contextmenu[@processname='SQLdmDesktopClient']/menuitem[@automationid='menuFileConnect']";
		
        public static void ClickOnFile()
		{
			try 
			{
				repo.SQLdmDesktop.FileInfo.WaitForExists(new Duration(1000000));
				repo.SQLdmDesktop.File.ClickThis();
				Reports.ReportLog("ClickOnFile", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnFile :" + ex.Message);
			}
		}
        
        public static void SelectConnectRepoOption()
		{ 
			try
				{
					Ranorex.MenuItem fileMenuItem = FILECONNECT_MENU;
					if(fileMenuItem != null) fileMenuItem.ClickThis();
					Reports.ReportLog("SelectConnectRepoOption", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectConnectRepoOption :" + ex.Message);
			}
		}
        
        public static void ClickOnConnect()
		{
			try 
				{
					repo.RepoConsoleDialog.SelfInfo.WaitForExists(new Duration(1000000));
					repo.RepoConsoleDialog.btnRCDConnectInfo.WaitForItemExists(1000000);
					repo.RepoConsoleDialog.btnRCDConnect.ClickThis();
					
					Reports.ReportLog("Click On Connect", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				} 
			catch (Exception ex)
				{
				throw new Exception("Failed : ClickOnConnect :" + ex.Message);
				}
		}
        
        public static void SelectServer(string serverName)
			{
				try 
				{
					 repo.SQLdmDesktop.AllServersInfo.WaitForItemExists(120000);
					 TreeItem serveritem = repo.SQLdmDesktop.AllServers.GetChildItem(serverName);
					 
					if(serveritem != null)
					{
						serveritem.ClickThis();
						Reports.ReportLog("Successfully Selected Required Server : " + serverName, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Required Server is Not Available to Select", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
						
					}
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : SelectServer :" + ex.Message);
				}
			}
        
         public static void ClickOnQueriesTab()
			{
				try 
				{
					
				    repo.SQLdmDesktop.tabQueriesInfo.WaitForItemExists(1000000);
				    repo.SQLdmDesktop.tabQueries.ClickThis();
				    Reports.ReportLog("Successfully Clicked On Queries Tab", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnQueriesTab :" + ex.Message);
				}
			}
         public static void ClickOnSignatureMode()
			{
				try 
				{
					
				    repo.SQLdmDesktop.QueriesTab.rgQUESignatureModeInfo.WaitForExists(new Duration(1000000));
				    repo.SQLdmDesktop.QueriesTab.rgQUESignatureMode.ClickThis();
				    Reports.ReportLog("Successfully Clicked On Signature Mode", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnSignatureMode :" + ex.Message);
				}
			}
         
         public static void ClickOnConfigureQueryMonitor()
			{
				try 
				{
					
				    repo.SQLdmDesktop.btnQUEConfigureQueryMonitorInfo.WaitForItemExists(1000000);
				    repo.SQLdmDesktop.btnQUEConfigureQueryMonitor.ClickThis();
				    Reports.ReportLog("Successfully Clicked On ConfigureQueryMonitor", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnConfigureQueryMonitor :" + ex.Message);
				}
			}
         
         public static void CheckEnableQueryMonitor()
			{
				try 
				{
					repo.MonitoredSQLServerProperties.SelfInfo.WaitForExists(new Duration(1000000));
					repo.MonitoredSQLServerProperties.pnlQueryMonitor.cbMSSPEnableQueryMonitorInfo.WaitForExists(1000000);
					
					if(!repo.MonitoredSQLServerProperties.pnlQueryMonitor.cbMSSPEnableQueryMonitor.Checked)
					{
						repo.MonitoredSQLServerProperties.pnlQueryMonitor.cbMSSPEnableQueryMonitor.Checked = true;
						Reports.ReportLog("Successfully Checked Enable Query Monitor", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Enable Query Monitor is in Checked Status", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					}
						
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : CheckEnableQueryMonitor :" + ex.Message);
				}
			}
         
         public static void UnCheckEnableQueryMonitor()
			{
				try 
				{
					repo.MonitoredSQLServerProperties.SelfInfo.WaitForExists(new Duration(1000000));
					repo.MonitoredSQLServerProperties.pnlQueryMonitor.cbMSSPEnableQueryMonitorInfo.WaitForExists(1000000);
					
					if(repo.MonitoredSQLServerProperties.pnlQueryMonitor.cbMSSPEnableQueryMonitor.Checked)
					{
						repo.MonitoredSQLServerProperties.pnlQueryMonitor.cbMSSPEnableQueryMonitor.Checked = false;
						Reports.ReportLog("Successfully UnChecked Enable Query Monitor", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Enable Query Monitor is in UnChecked Status", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					}
						
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : UnCheckEnableQueryMonitor :" + ex.Message);
				}
			}
         
         public static void CheckCollectActualQueryPlans()
			{
				try 
				{
					
					repo.MonitoredSQLServerProperties.pnlQueryMonitor.cbCollectActualQueryPlansInfo.WaitForExists(1000000);
					
					if(!repo.MonitoredSQLServerProperties.pnlQueryMonitor.cbCollectActualQueryPlans.Checked)
					{
						repo.MonitoredSQLServerProperties.pnlQueryMonitor.cbCollectActualQueryPlans.Checked = true;
						Reports.ReportLog("Successfully Checked Collect Actual Query Plans", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Collect Actual Query Plans is in Checked Status", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					}
						
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : CheckCollectActualQueryPlans :" + ex.Message);
				}
			}
         
         	public static void UnCheckCollectActualQueryPlans()
			{
				try 
				{
					repo.MonitoredSQLServerProperties.pnlQueryMonitor.cbCollectActualQueryPlansInfo.WaitForExists(1000000);
					
					if(repo.MonitoredSQLServerProperties.pnlQueryMonitor.cbCollectActualQueryPlans.Checked)
					{
						repo.MonitoredSQLServerProperties.pnlQueryMonitor.cbCollectActualQueryPlans.Checked = false;
						Reports.ReportLog("Successfully UnChecked Collect Actual Query Plans", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Collect Actual Query Plans is in UnChecked Status", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					}
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : UnCheckCollectActualQueryPlans :" + ex.Message);
				}
			}
         	
         	public static void VerifyQueryStoreRB()
			{
				try 
				{
					repo.MonitoredSQLServerProperties.pnlQueryMonitor.rgCQDUsingQueryStoreInfo.WaitForExists(1000000);
					
					if (repo.MonitoredSQLServerProperties.pnlQueryMonitor.rgCQDUsingQueryStore.Visible == true)
					{
						Reports.ReportLog("Collect Query Data Using Query Store Radio Button Is Present", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
						
					}
					else
					{
						Reports.ReportLog("Collect Query Data Using Query Store Radio Button Is Not Present", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					}
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyQueryStoreRB :" + ex.Message);
				}
			}
         
          public static void ClickOnOkInMSSP()
			{
				try 
				{
					repo.MonitoredSQLServerProperties.btnMSSPOkInfo.WaitForItemExists(1000000);
					repo.MonitoredSQLServerProperties.btnMSSPOk.ClickThis();
				    
				    Reports.ReportLog("Successfully Clicked On Ok button", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnOkInMSSP :" + ex.Message);
				}
			}
         
          public static void ClickOnCancelInMSSP()
			{
				try 
				{
					repo.MonitoredSQLServerProperties.btnMSSPCancelInfo.WaitForItemExists(1000000);
					repo.MonitoredSQLServerProperties.btnMSSPCancel.ClickThis();
				    
				    Reports.ReportLog("Successfully Clicked On Cancel button", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnCancelInMSSP :" + ex.Message);
				}
			}
          
           public static void ClickOnWarningYes()
			{
				try 
				{	
					if (repo.ExceptionMessageDialog.btnMSSPYes.Visible == true)
					{
						repo.ExceptionMessageDialog.btnMSSPYes.ClickThis();
					    Reports.ReportLog("Successfully Clicked On Yes button", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Yes button is not Available", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					}
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnWarningYes :" + ex.Message);
				}
			}
          
          public static void VerifyQueryPlanOptionsEnable()
			{
				try 
				{
					repo.MonitoredSQLServerProperties.pnlPoorlyPerforming.txtPPQueryPlanInfo.WaitForItemExists(1000000);
						
					//if ((repo.MonitoredSQLServerProperties.pnlPoorlyPerforming.txtPPQueryPlan.Enabled = true) && (repo.MonitoredSQLServerProperties.pnlPoorlyPerforming.ddlPPPlansBy.Enabled = true))
					if (repo.MonitoredSQLServerProperties.pnlPoorlyPerforming.txtPPQueryPlan.Enabled == true) 
						Reports.ReportLog("Query Plan Options Are In Enable Mode ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					else
						Reports.ReportLog("Query Plan Options Are In Disable Mode ", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyQueryPlanOptionsEnable :" + ex.Message);
				}
			}
          
          public static void EnterTextInQueryPlan(int SelectTop)
		{
			try 
				{	
					repo.MonitoredSQLServerProperties.pnlPoorlyPerforming.txtPPQueryPlanInfo.WaitForItemExists(1000000);
					repo.MonitoredSQLServerProperties.pnlPoorlyPerforming.txtPPQueryPlan.TextValue = SelectTop.ToString();
					Reports.ReportLog("Successfully Entered Query Plan Value: " + SelectTop, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				} 
			catch (Exception ex)
				{
					throw new Exception("Failed : EnterTextInQueryPlan :" + ex.Message);
				}
		}
          
          public static void EnterTextInDurationMS(int DurationMS)
		{
			try 
				{	
					repo.MonitoredSQLServerProperties.pnlPoorlyPerforming.txtPPDurationInfo.WaitForItemExists(1000000);
					repo.MonitoredSQLServerProperties.pnlPoorlyPerforming.txtPPDuration.TextValue = DurationMS.ToString();
					Reports.ReportLog("Successfully Entered Duration Milli Seconds Value: " + DurationMS, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				} 
			catch (Exception ex)
				{
					throw new Exception("Failed : EnterTextInDurationMS :" + ex.Message);
				}
		}
         
          public static void VerifyQueryPlanValue(int SelectTop)
		{
			try 
				{	
					repo.MonitoredSQLServerProperties.pnlPoorlyPerforming.txtPPQueryPlanInfo.WaitForItemExists(1000000);
					if (repo.MonitoredSQLServerProperties.pnlPoorlyPerforming.txtPPQueryPlan.TextValue.Contains(Convert.ToString(SelectTop)))
						Reports.ReportLog("Successfully Verifyed Query Plan Value: " + SelectTop, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					else
						Reports.ReportLog("Query Plan Value is Not having : " + SelectTop, Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
				} 
			catch (Exception ex)
				{
					throw new Exception("Failed : VerifyQueryPlanValue :" + ex.Message);
				}
		}
          
         public static void ClickOnExtendedEvents()
			{
				try 
				{
					repo.MonitoredSQLServerProperties.pnlQueryMonitor.rgCQDUsingExtendedEventsInfo.WaitForItemExists(1000000);
					repo.MonitoredSQLServerProperties.pnlQueryMonitor.rgCQDUsingExtendedEvents.Click();
				    Reports.ReportLog("Successfully Clicked On Extended Events Radio button", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnExtendedEvents :" + ex.Message);
				}
			}
         
          public static void ClickOnAdvancedTab()
			{
				try 
				{
					repo.MonitoredSQLServerProperties.pnlQueryMonitor.btnMSSPAdvancedInfo.WaitForItemExists(1000000);
					repo.MonitoredSQLServerProperties.pnlQueryMonitor.btnMSSPAdvanced.ClickThis();
				    Reports.ReportLog("Successfully Clicked On Advanced button", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnAdvancedTab :" + ex.Message);
				}
			}
          
           public static void UnCheckExcludeSQLDMQueries()
			{
				try 
				{
					repo.AdvancedQueryFilterConfigurationDialog.cbAQFCExcludeSQLDMQueryInfo.WaitForItemExists(1000000);
					if(repo.AdvancedQueryFilterConfigurationDialog.cbAQFCExcludeSQLDMQuery.Checked)
					{
						repo.AdvancedQueryFilterConfigurationDialog.cbAQFCExcludeSQLDMQuery.Checked = false;
						Reports.ReportLog("Successfully UnChecked Exclude SQLDM Queries", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Exclude SQLDM Queries is in UnChecked Status", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					}
						
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : CheckEnableQueryMonitor :" + ex.Message);
				}
			}
           
            public static void ClickOnOkInAQFC()
			{
				try 
				{
					repo.AdvancedQueryFilterConfigurationDialog.btnAQFMOkInfo.WaitForItemExists(1000000);
					repo.AdvancedQueryFilterConfigurationDialog.btnAQFMOk.ClickThis();
				    Reports.ReportLog("Successfully Clicked On Ok button", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnOkInAQFC :" + ex.Message);
				}
			}
            
             public static void VerifyQueryDataForTopQueryPlan(string strQuery,string strTableName)
			{
				try 
					{	
						DataTable dtInfo = DataAccess.GetData(strQuery);
		        		if(dtInfo != null && dtInfo.Rows.Count > 0)
		        		{
		        		    Reports.ReportLog("Total No Of Records present in " + strTableName + "  Is : " + dtInfo.Rows.Count, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
		        			Reports.ReportLog("No Of Plan ID's present in " + strTableName + "  Is : " + dtInfo.Rows.Count, Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
		        		}
		        		else
		        		{
			        	    Reports.ReportLog("Records is not present in Table: " + strTableName, Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
		        		}
			        	
					} 
				catch (Exception ex)
					{
						throw new Exception("Failed : VerifyQueryDataForTopQueryPlan :" + ex.Message);
					}
			}
           
            public static void SelectValueInPlansBy(string plansBy)
			{
				try 
				{
					repo.MonitoredSQLServerProperties.pnlPoorlyPerforming.ddlPPPlansByInfo.WaitForItemExists(1000000);
					Common.WaitForSync(5000);
					repo.MonitoredSQLServerProperties.pnlPoorlyPerforming.btnPPPlandByOpen.ClickThis();
					Common.WaitForSync(5000);
					
					string defaultSelectedItem = repo.MonitoredSQLServerProperties.pnlPoorlyPerforming.ddlPPPlansBy.SelectedItem.Text;
					ListItem itemToSelect = @"/form/?/?/list[@accessiblename='"+ defaultSelectedItem +"']/listitem[@accessiblename='"+ plansBy +"']";
					
					if(itemToSelect != null)
					{
						itemToSelect.ClickThis();
						Common.WaitForSync(5000);
						Reports.ReportLog("Successfully Selected Plans By As: " + plansBy, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Failed to Select Plans By As: " + plansBy, Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					}
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : SelectValueInPlansBy :" + ex.Message);
				}
			}
         
         //------------------------------------------------------------------------------------------------------
		
    }
}
