using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace OdeToFood.Tests.Fakes
{
    class FakeHttpContext:HttpContextBase
    {
        HttpRequestBase _request = new FakeHttpRequest();
        public override HttpRequestBase Request
        {
            get
            {
                return _request;
            }
        }

    }
}
