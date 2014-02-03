using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;

namespace OdeToFood.Tests.Fakes
{
    class FakeHttpRequest:HttpRequestBase
    {
        public override string this[string key]
        {
            get
            {
                return null;

            }
        }

        public override NameValueCollection Headers
        {
            get
            {
                return new NameValueCollection();
            }
        }
    }
}
