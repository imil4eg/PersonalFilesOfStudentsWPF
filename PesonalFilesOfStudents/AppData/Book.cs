//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PesonalFilesOfStudents.AppData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public int ReadingBookID { get; set; }
    
        public virtual ReadingBook ReadingBook { get; set; }
    }
}