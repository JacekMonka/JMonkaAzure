using System.Text.Json.Nodes;
using Cdv.People.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Cdv.People
{
    public class PeopleFn
    {
        private readonly ILogger<PeopleFn> _logger;

        public PeopleFn(ILogger<PeopleFn> logger)
        {
            _logger = logger;
        }

        [Function("PeopleFn")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")]
        HttpRequest req, [FromBody] Person newPerson)
        {
            var people = new List<Person>{
                new Person{FirstName = "Artur", LastName = "Ziemianski", Id = 1}
            };

            switch (req.Method)
            {
                case "POST":
                    people.Add(newPerson);
                    return new JsonResult(people);
                case "GET":
                    return new JsonResult(people);
                default:
                    throw new ArgumentException("Incorrect method.");
            }

        }
    }
}
