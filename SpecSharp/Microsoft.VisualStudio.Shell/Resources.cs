//------------------------------------------------------------------------------
// <copyright from='1997' to='2001' company='Microsoft Corporation'>           
//    Copyright (c) Microsoft Corporation. All Rights Reserved.                
//    Information Contained Herein is Proprietary and Confidential.            
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {
    using System;
    using System.Reflection;
    using System.Globalization;
    using System.Resources;
    using System.Text;
    using System.Threading;
    using System.ComponentModel;
    using System.Security.Permissions;

    [AttributeUsage(AttributeTargets.All)]
    internal sealed class SRDescriptionAttribute : DescriptionAttribute {

        private bool replaced = false;

        /// <summary>
        ///     Constructs a new sys description.
        /// </summary>
        /// <param name='description'>
        ///     description text.
        /// </param>
        public SRDescriptionAttribute(string description) : base(description) {
        }

        /// <summary>
        ///     Retrieves the description text.
        /// </summary>
        /// <returns>
        ///     description
        /// </returns>
        public override string Description {
            get {
                if (!replaced) {
                    replaced = true;
                    DescriptionValue = SR.GetString(base.Description);
                }
                return base.Description;
            }
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    internal sealed class SRCategoryAttribute : CategoryAttribute {

        public SRCategoryAttribute(string category) : base(category) {
        }

        protected override string GetLocalizedString(string value) {
            return SR.GetString(value);
        }
    }

    /// <summary>
    ///    AutoGenerated resource class. Usage:
    ///
    ///        string s = SR.GetString(SR.MyIdenfitier);
    /// </summary>
    
    internal sealed class SR {
        internal const string General_MissingService = "General_MissingService";
        internal const string General_InvalidType = "General_InvalidType";
        internal const string General_UnsupportedValue = "General_UnsupportedValue";
        internal const string General_ExpectedNonEmptyString = "General_ExpectedNonEmptyString";
        internal const string Attributes_ExtensionNeedsDot = "Attributes_ExtensionNeedsDot";
        internal const string Attributes_InvalidFactoryType = "Attributes_InvalidFactoryType";
        internal const string Attributes_ProductNameNotSpecified = "Attributes_ProductNameNotSpecified";
        internal const string Attributes_NoPrjForEditorFactoryNotify = "Attributes_NoPrjForEditorFactoryNotify";
        internal const string Attributes_UnknownDockingStyle = "Attributes_UnknownDockingStyle";
        internal const string Attributes_UnknownPosition = "Attributes_UnknownPosition";
        internal const string Package_InvalidServiceInstance = "Package_InvalidServiceInstance";
        internal const string Package_DuplicateService = "Package_DuplicateService";
        internal const string Package_SiteAlreadySet = "Package_SiteAlreadySet";
        internal const string Package_PageNotDialogPage = "Package_PageNotDialogPage";
        internal const string Package_PageCtorMissing = "Package_PageCtorMissing";
        internal const string Package_BadDialogPageType = "Package_BadDialogPageType";
        internal const string Package_PageMissingInterface = "Package_PageMissingInterface";
        internal const string Package_BadOptionName = "Package_BadOptionName";
        internal const string Package_OptionNameUsed = "Package_OptionNameUsed";
        internal const string Package_MissingService = "Package_MissingService";
        internal const string Package_InvalidInstanceID = "Package_InvalidInstanceID";
        internal const string Package_InvalidToolWindowClass = "Package_InvalidToolWindowClass";
        internal const string Reg_NotifyAutoLoad = "Reg_NotifyAutoLoad";
        internal const string Reg_NotifyPackage = "Reg_NotifyPackage";
        internal const string Reg_NotifyService = "Reg_NotifyService";
        internal const string Reg_NotifyMenuResource = "Reg_NotifyMenuResource";
        internal const string Reg_NotifyExtender = "Reg_NotifyExtender";
        internal const string Reg_NotifyToolResource = "Reg_NotifyToolResource";
        internal const string Reg_NotifyToolVisibility = "Reg_NotifyToolVisibility";
        internal const string Reg_NotifyOptionPage = "Reg_NotifyOptionPage";
        internal const string Reg_NotifyToolboxPage = "Reg_NotifyToolboxPage";
        internal const string Reg_NotifyCreateObject = "Reg_NotifyCreateObject";
        internal const string Reg_NotifyEditorFactory = "Reg_NotifyEditorFactory";
        internal const string Reg_NotifyProjectFactory = "Reg_NotifyProjectFactory";
        internal const string Reg_NotifyProjectItems = "Reg_NotifyProjectItems";
        internal const string Reg_NotifyEditorView = "Reg_NotifyEditorView";
        internal const string Reg_NotifyKeyBinding = "Reg_NotifyKeyBinding";
        internal const string Reg_NotifyEditorExtension = "Reg_NotifyEditorExtension";
        internal const string Reg_NotifyLanguageExtension = "Reg_NotifyLanguageExtension";
        internal const string Reg_NotifyLoadKey = "Reg_NotifyLoadKey";
        internal const string Reg_NotifyToolboxItem = "Reg_NotifyToolboxItem";
        internal const string Reg_NotifyToolboxItemConfiguration = "Reg_NotifyToolboxItemConfiguration";
        internal const string Reg_NotifyToolboxItemFilter = "Reg_NotifyToolboxItemFilter";
        internal const string Reg_NotifyInstalledProduct = "Reg_NotifyInstalledProduct";
        internal const string Reg_NotifyInstalledProductInterface = "Reg_NotifyInstalledProductInterface";
        internal const string ToolWindow_TooLateToAddToolbar = "ToolWindow_TooLateToAddToolbar";
        internal const string ToolWindow_TooLateToAddTool = "ToolWindow_TooLateToAddTool";

        static SR loader = null;
        ResourceManager resources;

        private static Object s_InternalSyncObject;
        private static Object InternalSyncObject {
            get {
                if (s_InternalSyncObject == null) {
                    Object o = new Object();
                    Interlocked.CompareExchange(ref s_InternalSyncObject, o, null);
                }
                return s_InternalSyncObject;
            }
        }
        
        internal SR() {
            resources = new System.Resources.ResourceManager("Microsoft.VisualStudio.Shell.ResourceStrings", this.GetType().Assembly);
        }
        
        private static SR GetLoader() {
            if (loader == null) {
                lock (InternalSyncObject) {
                   if (loader == null) {
                       loader = new SR();
                   }
               }
            }
            
            return loader;
        }

        private static CultureInfo Culture {
            get { return null/*use ResourceManager default, CultureInfo.CurrentUICulture*/; }
        }
        
        public static ResourceManager Resources {
            get {
                return GetLoader().resources;
            }
        }
        
        public static string GetString(string name, params object[] args) {
            SR sys = GetLoader();
            if (sys == null)
                return null;
            string res = sys.resources.GetString(name, SR.Culture);

            if (args != null && args.Length > 0) {
                for (int i = 0; i < args.Length; i ++) {
                    String value = args[i] as String;
                    if (value != null && value.Length > 1024) {
                        args[i] = value.Substring(0, 1024 - 3) + "...";
                    }
                }
                return String.Format(CultureInfo.CurrentCulture, res, args);
            }
            else {
                return res;
            }
        }

        public static string GetString(string name) {
            SR sys = GetLoader();
            if (sys == null)
                return null;
            return sys.resources.GetString(name, SR.Culture);
        }
        
        public static object GetObject(string name) {
            SR sys = GetLoader();
            if (sys == null)
                return null;
            return sys.resources.GetObject(name, SR.Culture);
        }
    }
}
