//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MedicalExaminationApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notifications
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public System.DateTime NotificationDate { get; set; }
        public string ClinicAddress { get; set; }
        public string ClinicPhone { get; set; }
        public string SpecialistName { get; set; }
        public string SpecialistPosition { get; set; }
    
        public virtual Employees Employees { get; set; }
    }
}
