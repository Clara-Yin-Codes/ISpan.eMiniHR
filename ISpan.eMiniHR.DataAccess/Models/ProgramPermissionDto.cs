namespace ISpan.eMiniHR.DataAccess.Models
{
    public class ProgramPermissionDto
    {
        public string ProgSysId { get; set; }
        public bool Queryable { get; set; }
        public bool Addable { get; set; }
        public bool Editable { get; set; }
        public bool Deletable { get; set; }
        public bool Voidable { get; set; }
        public bool Printable { get; set; }
        public bool Downloadable { get; set; }
        public bool Testable { get; set; }
        
    }
}
