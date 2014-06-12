using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

/// <summary>
/// Summary description for HelloController
/// </summary>
public class HelloController : ApiController
{
    public string Get()
    {
        return "Hello World";
    }
}