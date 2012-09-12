using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TechEdDemoApi.Representations;

namespace TechEdDemoApi.Controllers
{
    public class TimeSheetsController : ApiController
    {
        public HttpResponseMessage Get(string consultant, bool? outstanding = true)
        {
            if (consultant != "me")
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);

            var engatementId = Guid.NewGuid();
            return Request.CreateResponse(HttpStatusCode.OK, new[]
            {
                new TimeSheetRepresentation
                {
                    Date = DateTime.Today.AddDays(-1),
                    Hours = 8,
                    Engagement = new EngagementRepresentation
                    {
                        Id = engatementId,
                        Client = "TechEd Prep",
                    }
                },
                new TimeSheetRepresentation
                {
                    Date = DateTime.Today,
                    Hours = 8,
                    Engagement = new EngagementRepresentation
                    {
                        Id = engatementId,
                        Client = "TechEd Prep",
                    }
                }
            });
        }
    }
}