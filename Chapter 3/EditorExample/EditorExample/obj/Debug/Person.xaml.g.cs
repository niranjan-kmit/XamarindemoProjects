//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EditorExample {
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    
    public partial class EditorPage : ContentPage {
        
        private Editor edDescription;
        
        private Button btnSubmit;
        
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(EditorPage));
            edDescription = this.FindByName<Editor>("edDescription");
            btnSubmit = this.FindByName<Button>("btnSubmit");
        }
    }
}