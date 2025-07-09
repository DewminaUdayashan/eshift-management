using System.ComponentModel.DataAnnotations;

public enum JobStatus
{
    Pending,
    Approved,
    Rejected,
    Scheduled,
    [Display(Name = "On-Going")]
    OnGoing,
    Completed,
    Canceled
}