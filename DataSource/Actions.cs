//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataSource
{
    using System;
    using System.Collections.Generic;
    
    public partial class Actions
    {
        public Actions()
        {
            this.Permissions = new HashSet<Permission>();
        }
    
        public int Id { get; set; }
        public string ActionName { get; set; }
        public string Remark { get; set; }
        public string DelFlag { get; set; }
    
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}