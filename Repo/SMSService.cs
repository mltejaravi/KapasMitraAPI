using Microsoft.AspNetCore.DataProtection.KeyManagement;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using System.Threading.Channels;
using System.Net.Http;

namespace MarketsAPI.Repo
{
    public class SMSService : ISMSService
    {
        private readonly string apiUrl = string.Empty;
        private readonly string apiKey = string.Empty;
        private readonly string senderId = string.Empty;
        private readonly string channel = string.Empty;
        private readonly string dcs = string.Empty;
        private readonly string smsCampaignId = string.Empty;
        private readonly string dltTeId = string.Empty;
        private readonly string entityId = string.Empty;

        private readonly HttpClient? _httpClient = null;
        private IConfiguration? configuration;
        public SMSService(IConfiguration? _configuration)
        {
            configuration = _configuration ?? throw new ArgumentNullException(nameof(_configuration), "Configuration cannot be null.");

            apiUrl = configuration?["Sms:apiUrl"] ?? "";
            apiKey = configuration?["Sms:apiKey"] ?? "";
            senderId = configuration?["Sms:senderId"] ?? "";
            channel = configuration?["Sms:channel"] ?? "";
            dcs = configuration?["Sms:dcs"] ?? "";
            smsCampaignId = configuration?["Sms:smsCampaignId"] ?? "";
            dltTeId = configuration?["Sms:dltTeId"] ?? "";
            entityId = configuration?["Sms:entityId"] ?? "";

            _httpClient = new HttpClient();

        }
        public async Task<string>? SendSMS(string mobileNumber,string otp)
        {
            string text = "Dear User, OTP For Login into the E-Market Cotton Procurement Software is " + otp + " - One Soft";
            string requestUrl = $"{apiUrl}?api={apiKey}" +
                                    $"&senderid={senderId}" +
                                    $"&channel={channel}" +
                                    $"&DCS={dcs}" +
                                    $"&number={mobileNumber}" +
                                    $"&text={text}" +
                                    $"&SmsCampaignId={smsCampaignId}" +
                                    $"&DLT_TE_ID={dltTeId}" +
                                    $"&EntityID={entityId}";
            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, requestUrl))
                {
                    var response = await _httpClient!.SendAsync(request) ?? null;
                    response?.EnsureSuccessStatusCode();
                    return await response!.Content.ReadAsStringAsync();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"HTTP Request Error: {ex.Message}");
            }

        }
    }
}
