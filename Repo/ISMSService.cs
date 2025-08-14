namespace MarketsAPI.Repo
{
    public interface ISMSService
    {
        public Task<string>? SendSMS(string mobileNumber, string otp);
    }
}
