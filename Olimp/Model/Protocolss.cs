//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Olimp.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Protocolss
    {
        public int ProtocolID { get; set; }
        public int OlympiadID { get; set; }
        public int TeacherID { get; set; }
        public System.DateTime CreatedDate { get; set; }
    
        public virtual Olympiads Olympiads { get; set; }
        public virtual Teachers Teachers { get; set; }
    }
}