using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleInjector;

namespace CSC.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ITreeServicesFactory _service;

        public ValuesController(ITreeServicesFactory service)
        {
            _service = service;
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            var handler = _service.Create();
            var res = JsonConvert.SerializeObject(handler.BuildTree());
            return res;
        }

        // GET api/values/5
        [HttpGet("{Id}")]
        public string Get(string id)
        {
            int level, itemId;

            Int32.TryParse(id.Substring(1), out itemId);
            Int32.TryParse(id.Substring(0, 1), out level);

            var handler = _service.Create();
            var res = handler.GetItem(level, itemId);

            return JsonConvert.SerializeObject(res);
        }

        [HttpPost]
        public void Post(int level, [FromBody]string value)
        {
            var handler = _service.Create();
            if (handler.AddItem(level, value))
            {
                Response.StatusCode = 200;
            }
            else
            {
                Response.StatusCode = 400;
            }
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody]string value)
        {
            int level, itemId;

            Int32.TryParse(id.Substring(1), out itemId);
            Int32.TryParse(id.Substring(0, 0), out level);

            var handler = _service.Create();

            if (handler.EditItem(level, itemId, value))
            {
                Response.StatusCode = 200;
            }
            else
            {
                Response.StatusCode = 400;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            int level, itemId;

            Int32.TryParse(id.Substring(1), out itemId);
            Int32.TryParse(id.Substring(0, 0), out level);

            var handler = _service.Create();

            if (handler.DeleteItem(level, itemId))
            {
                Response.StatusCode = 200;
            }
            else
            {
                Response.StatusCode = 400;
            }
        }
    }
}