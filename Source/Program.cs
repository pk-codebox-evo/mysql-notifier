﻿// Copyright (c) 2006-2008 MySQL AB, 2008-2009 Sun Microsystems, Inc.
//
// MySQL Connector/NET is licensed under the terms of the GPLv2
// <http://www.gnu.org/licenses/old-licenses/gpl-2.0.html>, like most 
// MySQL Connectors. There are special exceptions to the terms and 
// conditions of the GPLv2 as it is applied to this software, see the 
// FLOSS License Exception
// <http://www.mysql.com/about/legal/licensing/foss-exception.html>.
//
// This program is free software; you can redistribute it and/or modify 
// it under the terms of the GNU General Public License as published 
// by the Free Software Foundation; version 2 of the License.
//
// This program is distributed in the hope that it will be useful, but 
// WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
// or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License 
// for more details.
//
// You should have received a copy of the GNU General Public License along 
// with this program; if not, write to the Free Software Foundation, Inc., 
// 51 Franklin St, Fifth Floor, Boston, MA 02110-1301  USA

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySQL.Utility;
using System.Linq;
using MySql.Notifier.Properties;
using System.Threading;
using System.Diagnostics;

namespace MySql.Notifier
{
  static class Program
  {

    static void MySQLNotifierHandler(Exception e, bool critical)
    {
      using (var errorDialog = new MessageDialog(Resources.HighSeverityError, e.Message, critical))
      {        
        errorDialog.ShowDialog();
        var traceNotifier = new MySQLSourceTrace("Notifier", Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + @"\Oracle\MySQLNotifierLog.txt", "", SourceLevels.Warning);
        traceNotifier.WriteError("Unhandled Exception - "  + (e.Message + " " + e.InnerException), 1);        
      }            
    }

    static void MySQLNotifierThreadExceptionEventHandler(object sender, ThreadExceptionEventArgs args)
    {
      MySQLNotifierHandler(args.Exception, true);     
    }

    static void MySQLNotifierAppExceptionHandler(object sender, UnhandledExceptionEventArgs args)
    {
      MySQLNotifierHandler((Exception)args.ExceptionObject, true);      
    }


    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(params string[] args)
    {
      if (args.Length > 0 && (args[0] == "--c" || args[0] == "--x"))
      {
        CheckForUpdates(args[0]);
        return;
      }

      if (!SingleInstance.Start()) { return; }
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      Application.ThreadException += new ThreadExceptionEventHandler(MySQLNotifierThreadExceptionEventHandler);

      // For Windows Forms errors to go through our handler.
      Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

      // For non-UI thread exceptions
      AppDomain.CurrentDomain.UnhandledException +=
          new UnhandledExceptionEventHandler(MySQLNotifierAppExceptionHandler);

      try
      {
        var applicationContext = new NotifierApplicationContext();
        Application.Run(applicationContext);
      }
      catch (Exception ex)
      {
        using (var errorDialog = new MessageDialog(Resources.HighSeverityError, ex.Message, true))
        {
          errorDialog.ShowDialog();
          var traceNotifier = new MySQLSourceTrace("Notifier", Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + @"\Oracle\MySQLNotifierLog.txt", "", SourceLevels.Warning);
          traceNotifier.WriteError("Application Error - " + (ex.Message + " " + ex.InnerException), 1);  
        }                
      }
      SingleInstance.Stop();
    }

    private static void CheckForUpdates(string arg)
    {
      if (arg == "--c")
      {
        Settings.Default.UpdateCheck = (int)SoftwareUpdateStaus.Checking;
        Settings.Default.Save();
      }
      return;
    }
  }
}
