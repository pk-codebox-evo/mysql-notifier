﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MySql.Notifier.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySql.Notifier.NotifierSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("4")]
        public int CheckForUpdatesFrequency {
            get {
                return ((int)(this["CheckForUpdatesFrequency"]));
            }
            set {
                this["CheckForUpdatesFrequency"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySql.Notifier.NotifierSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool AutoAddServicesToMonitor {
            get {
                return ((bool)(this["AutoAddServicesToMonitor"]));
            }
            set {
                this["AutoAddServicesToMonitor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySql.Notifier.NotifierSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool NotifyOfAutoServiceAddition {
            get {
                return ((bool)(this["NotifyOfAutoServiceAddition"]));
            }
            set {
                this["NotifyOfAutoServiceAddition"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySql.Notifier.NotifierSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("mysql")]
        public string AutoAddPattern {
            get {
                return ((string)(this["AutoAddPattern"]));
            }
            set {
                this["AutoAddPattern"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySql.Notifier.NotifierSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool NotifyOfStatusChange {
            get {
                return ((bool)(this["NotifyOfStatusChange"]));
            }
            set {
                this["NotifyOfStatusChange"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySql.Notifier.NotifierSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool FirstRun {
            get {
                return ((bool)(this["FirstRun"]));
            }
            set {
                this["FirstRun"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySql.Notifier.NotifierSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool AutoCheckForUpdates {
            get {
                return ((bool)(this["AutoCheckForUpdates"]));
            }
            set {
                this["AutoCheckForUpdates"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySql.Notifier.NotifierSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Generic.List<Machine> MachineList {
            get {
                return ((global::System.Collections.Generic.List<Machine>)(this["MachineList"]));
            }
            set {
                this["MachineList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySql.Notifier.NotifierSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Generic.List<MySQLService> ServiceList {
            get {
                return ((global::System.Collections.Generic.List<MySQLService>)(this["ServiceList"]));
            }
            set {
                this["ServiceList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySql.Notifier.NotifierSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ServiceSettingsList {
            get {
                return ((string)(this["ServiceSettingsList"]));
            }
            set {
                this["ServiceSettingsList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySql.Notifier.NotifierSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int UpdateCheck {
            get {
                return ((int)(this["UpdateCheck"]));
            }
            set {
                this["UpdateCheck"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySql.Notifier.NotifierSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool UseColorfulStatusIcons {
            get {
                return ((bool)(this["UseColorfulStatusIcons"]));
            }
            set {
                this["UseColorfulStatusIcons"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySql.Notifier.NotifierSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Generic.List<MySQLInstance> MySQLInstancesList {
            get {
                return ((global::System.Collections.Generic.List<MySQLInstance>)(this["MySQLInstancesList"]));
            }
            set {
                this["MySQLInstancesList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySql.Notifier.NotifierSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10")]
        public int WorkbenchMigrationRetryDelay {
            get {
                return ((int)(this["WorkbenchMigrationRetryDelay"]));
            }
            set {
                this["WorkbenchMigrationRetryDelay"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySql.Notifier.NotifierSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool WorkbenchMigrationSucceeded {
            get {
                return ((bool)(this["WorkbenchMigrationSucceeded"]));
            }
            set {
                this["WorkbenchMigrationSucceeded"] = value;
            }
        }
    }
}
