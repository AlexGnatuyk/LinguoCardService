using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LinguoCardService.Domain.Abstractions;

namespace LinguoCardService.Controllers
{
    /// <summary>
    /// Dictionary Controller
    /// </summary>
    [RoutePrefix(WebApiConfig.RoutePrefix)]
    public class DictionaryController : ApiController
    {
        private readonly IDictionaryService _dictionaryService;

        public DictionaryController(IDictionaryService dictionaryServices)
        {
            this._dictionaryService = dictionaryServices 
                ?? throw new ArgumentNullException(nameof(dictionaryServices));
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var result = _dictionaryService.GetById(id);
            return Content(HttpStatusCode.OK, result);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}