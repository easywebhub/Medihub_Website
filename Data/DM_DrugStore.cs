//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class DM_DrugStore
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string DrugType { get; set; }
        public string Acreage { get; set; }
        public string Address { get; set; }
        public long StreetId { get; set; }
        public string WardName { get; set; }
        public string DistrictName { get; set; }
        public string CityName { get; set; }
        public string Area { get; set; }
        public string Note { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public bool IsMarket { get; set; }
    }
}
