﻿#pragma checksum "C:\Users\alperokur\Desktop\KTU-Social\Controls\ChannelMessageButton.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FCC920201D90DC02C9B7B479D29ACF8DBBC796FA56B9E387255AB12E9F9386D5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KTU_Social.Controls
{
    partial class ChannelMessageButton : 
        global::Windows.UI.Xaml.Controls.Button, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_Controls_Image_Source(global::Windows.UI.Xaml.Controls.Image obj, global::Windows.UI.Xaml.Media.ImageSource value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), targetNullValue);
                }
                obj.Source = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class ChannelMessageButton_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IChannelMessageButton_Bindings
        {
            private global::KTU_Social.Controls.ChannelMessageButton dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.TextBlock obj2;
            private global::Windows.UI.Xaml.Controls.TextBlock obj3;
            private global::Windows.UI.Xaml.Controls.TextBlock obj5;
            private global::Windows.UI.Xaml.Controls.Image obj6;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj2TextDisabled = false;
            private static bool isobj3TextDisabled = false;
            private static bool isobj5TextDisabled = false;
            private static bool isobj6SourceDisabled = false;

            private ChannelMessageButton_obj1_BindingsTracking bindingsTracking;

            public ChannelMessageButton_obj1_Bindings()
            {
                this.bindingsTracking = new ChannelMessageButton_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 23 && columnNumber == 51)
                {
                    isobj2TextDisabled = true;
                }
                else if (lineNumber == 19 && columnNumber == 24)
                {
                    isobj3TextDisabled = true;
                }
                else if (lineNumber == 21 && columnNumber == 44)
                {
                    isobj5TextDisabled = true;
                }
                else if (lineNumber == 17 && columnNumber == 47)
                {
                    isobj6SourceDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2: // Controls\ChannelMessageButton.xaml line 23
                        this.obj2 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 3: // Controls\ChannelMessageButton.xaml line 19
                        this.obj3 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 5: // Controls\ChannelMessageButton.xaml line 21
                        this.obj5 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 6: // Controls\ChannelMessageButton.xaml line 17
                        this.obj6 = (global::Windows.UI.Xaml.Controls.Image)target;
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IChannelMessageButton_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::KTU_Social.Controls.ChannelMessageButton)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::KTU_Social.Controls.ChannelMessageButton obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Message(obj.Message, phase);
                    }
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_AccountName(obj.AccountName, phase);
                    }
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Datetime(obj.Datetime, phase);
                    }
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ProfilePicture(obj.ProfilePicture, phase);
                    }
                }
            }
            private void Update_Message(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Controls\ChannelMessageButton.xaml line 23
                    if (!isobj2TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj2, obj, null);
                    }
                }
            }
            private void Update_AccountName(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Controls\ChannelMessageButton.xaml line 19
                    if (!isobj3TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj3, obj, null);
                    }
                }
            }
            private void Update_Datetime(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Controls\ChannelMessageButton.xaml line 21
                    if (!isobj5TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj5, obj, null);
                    }
                }
            }
            private void Update_ProfilePicture(global::Windows.UI.Xaml.Media.ImageSource obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Controls\ChannelMessageButton.xaml line 17
                    if (!isobj6SourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Image_Source(this.obj6, obj, null);
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class ChannelMessageButton_obj1_BindingsTracking
            {
                private global::System.WeakReference<ChannelMessageButton_obj1_Bindings> weakRefToBindingObj; 

                public ChannelMessageButton_obj1_BindingsTracking(ChannelMessageButton_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<ChannelMessageButton_obj1_Bindings>(obj);
                }

                public ChannelMessageButton_obj1_Bindings TryGetBindingObject()
                {
                    ChannelMessageButton_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_(null);
                }

                public void PropertyChanged_(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    ChannelMessageButton_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::KTU_Social.Controls.ChannelMessageButton obj = sender as global::KTU_Social.Controls.ChannelMessageButton;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                bindings.Update_AccountName(obj.AccountName, DATA_CHANGED);
                                bindings.Update_ProfilePicture(obj.ProfilePicture, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "AccountName":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_AccountName(obj.AccountName, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "ProfilePicture":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ProfilePicture(obj.ProfilePicture, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void UpdateChildListeners_(global::KTU_Social.Controls.ChannelMessageButton obj)
                {
                    ChannelMessageButton_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        if (bindings.dataRoot != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)bindings.dataRoot).PropertyChanged -= PropertyChanged_;
                        }
                        if (obj != null)
                        {
                            bindings.dataRoot = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // Controls\ChannelMessageButton.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Button element1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element1).Loaded += this.Button_Loaded;
                }
                break;
            case 4: // Controls\ChannelMessageButton.xaml line 20
                {
                    this.VerifiedIcon = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // Controls\ChannelMessageButton.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Button element1 = (global::Windows.UI.Xaml.Controls.Button)target;
                    ChannelMessageButton_obj1_Bindings bindings = new ChannelMessageButton_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

