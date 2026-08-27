using System.Reflection;

namespace IPSDesk.Models;

public static class AppPermissions
{
    public static class Dashboard
    {
        public const string View = "Permissions.Dashboard.View";
    }

    public static class Customers
    {
        public const string View = "Permissions.Customers.View";
        public const string Create = "Permissions.Customers.Create";
        public const string Edit = "Permissions.Customers.Edit";
        public const string Delete = "Permissions.Customers.Delete";
        public const string Renew = "Permissions.Customers.Renew";
        public const string BillingHub = "Permissions.Customers.BillingHub";
    }

    public static class Payments
    {
        public const string View = "Permissions.Payments.View";
        public const string ViewHistory = "Permissions.Payments.ViewHistory";
        public const string Record = "Permissions.Payments.Record";
        public const string Delete = "Permissions.Payments.Delete";
    }

    public static class Renewals
    {
        public const string ViewHistory = "Permissions.Renewals.ViewHistory";
        public const string Delete = "Permissions.Renewals.Delete";
    }

    public static class PaymentMethods
    {
        public const string View = "Permissions.PaymentMethods.View";
        public const string Create = "Permissions.PaymentMethods.Create";
        public const string Edit = "Permissions.PaymentMethods.Edit";
        public const string Delete = "Permissions.PaymentMethods.Delete";
    }

    public static class Packages
    {
        public const string View = "Permissions.Packages.View";
        public const string Create = "Permissions.Packages.Create";
        public const string Edit = "Permissions.Packages.Edit";
        public const string Delete = "Permissions.Packages.Delete";
    }

    public static class Settings
    {
        public const string View = "Permissions.Settings.View";
        public const string Edit = "Permissions.Settings.Edit";
    }

    public static class Roles
    {
        public const string View = "Permissions.Roles.View";
        public const string Manage = "Permissions.Roles.Manage";
    }

    public static class Users
    {
        public const string View = "Permissions.Users.View";
        public const string Create = "Permissions.Users.Create";
        public const string Edit = "Permissions.Users.Edit";
        public const string Delete = "Permissions.Users.Delete";
        public const string ResetPassword = "Permissions.Users.ResetPassword";
        public const string Manage = "Permissions.Users.Manage";
    }

    public static class Account
    {
        public const string ChangePassword = "Permissions.Account.ChangePassword";
    }

    public static class Reports
    {
        public const string View = "Permissions.Reports.View";
    }

    /// <summary>
    /// Gets all permission strings dynamically via reflection.
    /// Useful for seeding the Admin role with all possible permissions.
    /// </summary>
    public static List<string> GetAllPermissions()
    {
        var permissions = new List<string>();
        var modules = typeof(AppPermissions).GetNestedTypes(BindingFlags.Public | BindingFlags.Static);
        
        foreach (var module in modules)
        {
            var fields = module.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            foreach (var field in fields)
            {
                if (field.IsLiteral && !field.IsInitOnly && field.FieldType == typeof(string))
                {
                    var value = (string)field.GetValue(null)!;
                    permissions.Add(value);
                }
            }
        }
        
        return permissions;
    }
}
