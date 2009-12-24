using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Elmah;
using System.Collections;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace Lokad.Translate
{
	/// <summary>
	/// Implements a custom ELMAH SQL Error Log that is able to read the SQL Connection String from the Azure Environment.
	/// </summary>
	public class AzureSqlErrorLog : SqlErrorLog
	{
		static IDictionary OverrideConnectionString(IDictionary config)
		{
			if(RoleEnvironment.IsAvailable)
			{
				// Completely override all other possible settings
				config["connectionStringName"] = null;
				config["connectionStringAppKey"] = null;
				config["connectionString"] = GlobalSetup.ConnectionString;
			}
			
			return config;
		}

		static string OverrideConnectionString(string connectionString)
		{
			if(RoleEnvironment.IsAvailable)
			{
				return GlobalSetup.ConnectionString;
			}
			
			return connectionString;
		}

        public AzureSqlErrorLog(IDictionary config)
			: base (OverrideConnectionString(config))
        {
        }

        public AzureSqlErrorLog(string connectionString)
			: base(OverrideConnectionString(connectionString))
        {
        }
	}
}
