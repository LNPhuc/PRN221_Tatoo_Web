namespace BusinessLogic.DTOS;

public class CreateBooking
{
    public CreateBooking(Guid accountId, DateTime dateTime, Guid studioId)
    {
        AccountId = accountId;
        DateTime = dateTime;
        StudioId = studioId;
    }

    public Guid AccountId { get; set; }
    public DateTime DateTime { get; set; }
    public Guid StudioId { get; set; }
}