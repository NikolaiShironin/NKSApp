//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NKSApp.Classes
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shutdown
    {
        public int ShutdownID { get; set; }
        public Nullable<System.DateTime> TimeCreate { get; set; }
        public Nullable<int> TypeID { get; set; }
        public string TypeShutdown { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public string Homes { get; set; }
        public Nullable<int> OperatorID { get; set; }
        public Nullable<int> StatusID { get; set; }
    
        public virtual Operator Operator { get; set; }
        public virtual Status Status { get; set; }
        public virtual Type Type { get; set; }
    }
}
