﻿#pragma checksum "D:\School\Repos\UWP opdracht\UwpEindopdracht\Views\ArticleDetails.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B6FFA5E8B73D827875D41583D30CCCB5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UwpEindopdracht.Views
{
    partial class ArticleDetails : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_Image_Source(global::Windows.UI.Xaml.Controls.Image obj, global::Windows.UI.Xaml.Media.ImageSource value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), targetNullValue);
                }
                obj.Source = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(global::Windows.UI.Xaml.Controls.Primitives.ButtonBase obj, global::System.Windows.Input.ICommand value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Windows.Input.ICommand) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Windows.Input.ICommand), targetNullValue);
                }
                obj.Command = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_CommandParameter(global::Windows.UI.Xaml.Controls.Primitives.ButtonBase obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.CommandParameter = value;
            }
        };

        private class ArticleDetails_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IArticleDetails_Bindings
        {
            private global::UwpEindopdracht.Views.ArticleDetails dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.Image obj5;
            private global::Windows.UI.Xaml.Controls.TextBlock obj7;
            private global::Windows.UI.Xaml.Controls.TextBlock obj8;
            private global::Windows.UI.Xaml.Controls.HyperlinkButton obj9;
            private global::Windows.UI.Xaml.Controls.TextBlock obj10;

            private ArticleDetails_obj1_BindingsTracking bindingsTracking;

            public ArticleDetails_obj1_Bindings()
            {
                this.bindingsTracking = new ArticleDetails_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 5:
                        this.obj5 = (global::Windows.UI.Xaml.Controls.Image)target;
                        break;
                    case 7:
                        this.obj7 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 8:
                        this.obj8 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 9:
                        this.obj9 = (global::Windows.UI.Xaml.Controls.HyperlinkButton)target;
                        break;
                    case 10:
                        this.obj10 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    default:
                        break;
                }
            }

            // IArticleDetails_Bindings

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

            // ArticleDetails_obj1_Bindings

            public void SetDataRoot(global::UwpEindopdracht.Views.ArticleDetails newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.dataRoot = newDataRoot;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::UwpEindopdracht.Views.ArticleDetails obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_VM(obj.VM, phase);
                    }
                }
            }
            private void Update_VM(global::UwpEindopdracht.ViewModels.ArticleDetailViewModel obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_VM_Article(obj.Article, phase);
                    }
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_VM_OpenArticle(obj.OpenArticle, phase);
                    }
                }
            }
            private void Update_VM_Article(global::UwpEindopdracht.Models.Article obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_VM_Article(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_VM_Article_Image(obj.Image, phase);
                        this.Update_VM_Article_Title(obj.Title, phase);
                        this.Update_VM_Article_Summary(obj.Summary, phase);
                    }
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_VM_Article_Url(obj.Url, phase);
                    }
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_VM_Article_IsLiked(obj.IsLiked, phase);
                    }
                }
            }
            private void Update_VM_Article_Image(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Image_Source(this.obj5, (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), obj), null);
                }
            }
            private void Update_VM_Article_Title(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj7, obj, null);
                }
            }
            private void Update_VM_Article_Summary(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj8, obj, null);
                }
            }
            private void Update_VM_OpenArticle(global::Exercise4.Helpers.RelayCommand obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj9, obj, null);
                }
            }
            private void Update_VM_Article_Url(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_CommandParameter(this.obj9, obj, null);
                }
            }
            private void Update_VM_Article_IsLiked(global::System.Boolean obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj10, obj.ToString(), null);
                }
            }

            private class ArticleDetails_obj1_BindingsTracking
            {
                global::System.WeakReference<ArticleDetails_obj1_Bindings> WeakRefToBindingObj; 

                public ArticleDetails_obj1_BindingsTracking(ArticleDetails_obj1_Bindings obj)
                {
                    WeakRefToBindingObj = new global::System.WeakReference<ArticleDetails_obj1_Bindings>(obj);
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_VM_Article(null);
                }

                public void PropertyChanged_VM_Article(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    ArticleDetails_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::UwpEindopdracht.Models.Article obj = sender as global::UwpEindopdracht.Models.Article;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                    bindings.Update_VM_Article_Image(obj.Image, DATA_CHANGED);
                                    bindings.Update_VM_Article_Title(obj.Title, DATA_CHANGED);
                                    bindings.Update_VM_Article_Summary(obj.Summary, DATA_CHANGED);
                                    bindings.Update_VM_Article_IsLiked(obj.IsLiked, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "Image":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_VM_Article_Image(obj.Image, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "Title":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_VM_Article_Title(obj.Title, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "Summary":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_VM_Article_Summary(obj.Summary, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "IsLiked":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_VM_Article_IsLiked(obj.IsLiked, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::UwpEindopdracht.Models.Article cache_VM_Article = null;
                public void UpdateChildListeners_VM_Article(global::UwpEindopdracht.Models.Article obj)
                {
                    if (obj != cache_VM_Article)
                    {
                        if (cache_VM_Article != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_VM_Article).PropertyChanged -= PropertyChanged_VM_Article;
                            cache_VM_Article = null;
                        }
                        if (obj != null)
                        {
                            cache_VM_Article = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_VM_Article;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2:
                {
                    this.LayoutStates = (global::Windows.UI.Xaml.VisualStateGroup)(target);
                }
                break;
            case 3:
                {
                    this.PortraitState = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 4:
                {
                    this.LandscapeState = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 5:
                {
                    this.ArticleImage = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 6:
                {
                    this.scrollViewer = (global::Windows.UI.Xaml.Controls.ScrollViewer)(target);
                }
                break;
            case 11:
                {
                    this.BackButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 37 "..\..\..\Views\ArticleDetails.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.BackButton).Click += this.BackButton_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    ArticleDetails_obj1_Bindings bindings = new ArticleDetails_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            }
            return returnValue;
        }
    }
}

