﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NSC3_FastTableEdit.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.3.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://srv-nav:7058/NAV2016PL/WS/CRONUS%20Polska%20Sp.%20z%20o.o./Codeunit/Fields" +
            "CUExtension")]
        public string NSC3_FastTableEdit_Fields_Fields_Service {
            get {
                return ((string)(this["NSC3_FastTableEdit_Fields_Fields_Service"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://srv-nav:7058/NAV2016PL/WS/CRONUS%20Polska%20Sp.%20z%20o.o./Page/Fields")]
        public string NSC3_FastTableEdit_NAVFieldsService_Fields_Service {
            get {
                return ((string)(this["NSC3_FastTableEdit_NAVFieldsService_Fields_Service"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://srv-nav:7058/NAV2016PL/WS/CRONUS%20Polska%20Sp.%20z%20o.o./Codeunit/Fields" +
            "")]
        public string NSC3_FastTableEdit_NAVFieldsService_Fields {
            get {
                return ((string)(this["NSC3_FastTableEdit_NAVFieldsService_Fields"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://srv-nav:7058/NAV2016PL/WS/CRONUS%20Polska%20Sp.%20z%20o.o./SystemService")]
        public string NSC3_FastTableEdit_NAVFieldsService_SystemService {
            get {
                return ((string)(this["NSC3_FastTableEdit_NAVFieldsService_SystemService"]));
            }
        }
    }
}
