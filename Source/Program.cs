﻿// Copyright (c) 2012-2014, Oracle and/or its affiliates. All rights reserved.
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License as
// published by the Free Software Foundation; version 2 of the
// License.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA
// 02110-1301  USA

using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MySql.Notifier.Properties;
using MySQL.Utility.Forms;
using MySQL.Utility.Classes;

namespace MySql.Notifier
{
  internal static class Program
  {
    /// <summary>
    /// Sends an error message to the application log and optionally shows it to the users.
    /// </summary>
    /// <param name="errorMessage">A custom error message.</param>
    /// <param name="showErrorDialog">Flag indicating whether the error is shown to users.</param>
    /// <param name="exception">An <see cref="Exception"/> object.</param>
    /// <param name="errorLevel">The <see cref="SourceLevels"/> to describe the severity of the error.</param>
    public static void MySQLNotifierErrorHandler(string errorMessage, bool showErrorDialog, Exception exception, SourceLevels errorLevel)
    {
      if (string.IsNullOrEmpty(errorMessage))
      {
        errorMessage = Resources.UnhandledExceptionText;
      }

      var errorBuilder = new StringBuilder(errorMessage);
      if (exception.Message.Length > 0)
      {
        errorBuilder.Append(Environment.NewLine);
        errorBuilder.Append(exception.Message);
      }

      if (exception.InnerException != null)
      {
        errorBuilder.Append(Environment.NewLine);
        errorBuilder.Append(exception.InnerException.Message);
      }

      string completeErrorMessage = errorBuilder.ToString();
      if (showErrorDialog)
      {
        InfoDialog.ShowErrorDialog(string.IsNullOrEmpty(errorMessage) ? Resources.HighSeverityError : errorMessage, exception.Message, null, exception.InnerException != null ? exception.InnerException.Message : null);
      }

      MySqlSourceTrace.WriteToLog(completeErrorMessage, errorLevel);
    }

    /// <summary>
    /// Shows an error message to the user and sends it to the application log.
    /// </summary>
    /// <param name="exception">An <see cref="Exception"/> object.</param>
    /// <param name="critical">Flag indicating whether the error is treated as <see cref="SourceLevels.Critical"/> or <see cref="SourceLevels.Error"/>.</param>
    public static void MySQLNotifierErrorHandler(Exception exception, bool critical)
    {
      MySQLNotifierErrorHandler(null, true, exception, critical ? SourceLevels.Critical : SourceLevels.Error);
    }

    /// <summary>
    /// Shows an error message to the user and sends it to the application log.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="args"><see cref="ThreadExceptionEventArgs"/> arguments.</param>
    private static void MySQLNotifierThreadExceptionEventHandler(object sender, ThreadExceptionEventArgs args)
    {
      MySQLNotifierErrorHandler(args.Exception, true);
    }

    /// <summary>
    /// Shows an error message to the user and sends it to the application log.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="args"><see cref="UnhandledExceptionEventArgs"/> arguments.</param>
    private static void MySQLNotifierAppExceptionHandler(object sender, UnhandledExceptionEventArgs args)
    {
      MySQLNotifierErrorHandler((Exception)args.ExceptionObject, true);
    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main(params string[] args)
    {
      if (args.Length > 0 && (args[0] == "--c" || args[0] == "--x"))
      {
        CheckForUpdates(args[0]);
      }

      if (!SingleInstance.Start())
      {
        return;
      }

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.ThreadException += MySQLNotifierThreadExceptionEventHandler;

      // For Windows Forms errors to go through our handler.
      Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

      // For non-UI thread exceptions
      AppDomain.CurrentDomain.UnhandledException += MySQLNotifierAppExceptionHandler;

      try
      {
        UpdateSettingsFile();
        var applicationContext = new NotifierApplicationContext();
        Application.Run(applicationContext);
      }
      catch (Exception ex)
      {
        InfoDialog.ShowErrorDialog(Resources.HighSeverityError, ex.Message, null, ex.StackTrace, false, InfoDialog.DefaultButtonType.Button1, 60);
        MySqlSourceTrace.WriteAppErrorToLog(ex);
      }

      SingleInstance.Stop();
    }

    private static void UpdateSettingsFile()
    {
      if (Settings.Default.AutoAddPattern == ".*mysqld.*")
      {
        Settings.Default.AutoAddPattern = "mysql";
      }

      Settings.Default.Save();
    }

    private static void CheckForUpdates(string arg)
    {
      if (arg != "--c")
      {
        return;
      }

      Settings.Default.UpdateCheck = (int)SoftwareUpdateStaus.Checking;
      Settings.Default.Save();
    }
  }
}