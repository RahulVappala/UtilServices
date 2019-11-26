using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogic;

namespace WebRole1.Controllers
{
    public class CustomController : ApiController
    {
        // GET: api/Custom
        public string Get()
        {
            return "Hello";
        }

        /// <summary>
        /// Returns the nth Fibonacci number (starting from 0). Accepts input upto 92. A negative n would return the same number and an n greater than 92 would result in overflow and return -1.
        /// </summary>
        /// <param name="n">The index of the fibonacci sequence.</param>
        /// <returns>Returns the fibonacci number in the nth position.</returns>
        [HttpGet]
        public HttpResponseMessage Fibonacci(long n)
        {
            if(n < 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, n);
            }
            Fibonacci f1 = new BusinessLogic.Fibonacci();
            long fibValue = f1.GetFibValue(n);
            return Request.CreateResponse(HttpStatusCode.OK,fibValue);
        }

        /// <summary>
        /// Reverses the letters of each word in a sentence.
        /// </summary>
        /// <param name="sentence">A sentence</param>
        /// <returns>Sentence with words reversed.</returns>
        [HttpGet]
        public HttpResponseMessage ReverseWords(string sentence)
        {
            ReverseString s = new ReverseString();
            string result = s.Reverse(sentence);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            return response;
        }

        /// <summary>
        /// Finds the type of triangle based on the length of the sides.
        /// </summary>
        /// <param name="a">Length of side a</param>
        /// <param name="b">Length of side b</param>
        /// <param name="c">Length of side c</param>
        /// <returns>The type of triangle</returns>
        [HttpGet]
        public HttpResponseMessage TriangleType(int a, int b, int c)
        {
            Triangle t = new Triangle();
            return Request.CreateResponse(HttpStatusCode.OK, t.TriangleType(a,b,c));
        }
    }
}
