using System;

public class ActivityLog
{
    public int Pk_ActivityLog { get; set; }
    public int AppId { get; set; }
    public string? AppName { get; set; }
    public string? LoginId { get; set; }
    public string? ErrorShortDesc { get; set; }
    public string? ErrorDesc { get; set; }
    public string? LogInfo { get; set; }
    public DateTime CreatedDate { get; set; }
}