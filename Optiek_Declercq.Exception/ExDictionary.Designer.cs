﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Optiek_Declercq.Exceptions {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ExDictionary {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExDictionary() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Optiek_Declercq.Exceptions.ExDictionary", typeof(ExDictionary).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Gelieve de naam van de persoon in te vullen..
        /// </summary>
        internal static string CustomerFirstNameEmpty {
            get {
                return ResourceManager.GetString("CustomerFirstNameEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to De opgegeven naam is ongeldig. Een naam kan karakters bevatten van a-z en geen speciale tekens..
        /// </summary>
        internal static string CustomerFirstNameInvalid {
            get {
                return ResourceManager.GetString("CustomerFirstNameInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Een lege waarde voor de voornaam van een gebruiker is niet toegelaten..
        /// </summary>
        internal static string CustomerFirstNameNull {
            get {
                return ResourceManager.GetString("CustomerFirstNameNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Een naam mag maximaal 100 karakters lang zijn, gelieve het opnieuw te proberen..
        /// </summary>
        internal static string CustomerFirstNameToLong {
            get {
                return ResourceManager.GetString("CustomerFirstNameToLong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Een naam moet minstens 2 karakters lang zijn, gelieve het opnieuw te proberen..
        /// </summary>
        internal static string CustomerFirstNameToShort {
            get {
                return ResourceManager.GetString("CustomerFirstNameToShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Gelieve de voornaam van de persoon in te vullen..
        /// </summary>
        internal static string CustomerLastNameEmpty {
            get {
                return ResourceManager.GetString("CustomerLastNameEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to De opgegeven voornaam is ongeldig. Een naam kan karakters bevatten van a-z en geen speciale tekens..
        /// </summary>
        internal static string CustomerLastNameInvalid {
            get {
                return ResourceManager.GetString("CustomerLastNameInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Een lege waarde voor de naam van een gebruiker is niet toegelaten..
        /// </summary>
        internal static string CustomerLastNameNull {
            get {
                return ResourceManager.GetString("CustomerLastNameNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Een voornaam mag maximaal 100 karakters lang zijn, gelieve het opnieuw te proberen..
        /// </summary>
        internal static string CustomerLastNameToLong {
            get {
                return ResourceManager.GetString("CustomerLastNameToLong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Een voornaam moet minstens 2 karakters lang zijn, gelieve het opnieuw te proberen..
        /// </summary>
        internal static string CustomerLastNameToShort {
            get {
                return ResourceManager.GetString("CustomerLastNameToShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Fout met het verbinden met de database. Gelieve contact op te nemen met w beheerder..
        /// </summary>
        internal static string DatabaseConnectionError {
            get {
                return ResourceManager.GetString("DatabaseConnectionError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Er is een onverwachte fout gebeurd..
        /// </summary>
        internal static string InvalidException {
            get {
                return ResourceManager.GetString("InvalidException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to U hebt nog geen klant geselecteerd om te bewerken. .
        /// </summary>
        internal static string NoCustomerSelected {
            get {
                return ResourceManager.GetString("NoCustomerSelected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Wenst u het document te bewaren?.
        /// </summary>
        internal static string NotSaved {
            get {
                return ResourceManager.GetString("NotSaved", resourceCulture);
            }
        }
    }
}
