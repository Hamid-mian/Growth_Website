namespace Growth_Website.Models.AuditColumn
{
    public abstract class FullAuditModel: AuditModel
    {
        public string? createdByUserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedUserId { get; set; }
        public DateTime lastModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
