//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MED
{
    using System;
    using System.Collections.Generic;
    
    public partial class schedules
    {
        public int schedule_id { get; set; }
        public string schedule_number { get; set; }
        public System.DateTime obsled_date { get; set; }
        public Nullable<int> department_id { get; set; }
    
        public virtual departments departments { get; set; }
    }
}
