//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ButtonExample {
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    
    public partial class LoginPage : ContentPage {
        
        private Entry txtUsername;
        
        private Entry txtPassword;
        
        private Button btnLogin;
        
        private Button btnCancel;
        
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(LoginPage));
            txtUsername = this.FindByName<Entry>("txtUsername");
            txtPassword = this.FindByName<Entry>("txtPassword");
            btnLogin = this.FindByName<Button>("btnLogin");
            btnCancel = this.FindByName<Button>("btnCancel");
        }
    }
}