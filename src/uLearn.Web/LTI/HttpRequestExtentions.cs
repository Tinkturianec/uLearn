using System.Collections.Specialized;
using System.Linq;
using System.Web;
using LtiLibrary.Core.Lti1;

namespace uLearn.Web.LTI
{
	public static class HttpRequestExtentions
	{
		public static LtiRequest ToLtiRequest(this HttpRequestBase httpRequest)
		{
			var ltiRequest = new LtiRequest();
			ltiRequest.Parameters.Add(GetLtiParams(httpRequest.Params));
			ltiRequest.Url = httpRequest.Url;
			ltiRequest.HttpMethod = httpRequest.HttpMethod;
			return ltiRequest;
		}

		private static NameValueCollection GetLtiParams(NameValueCollection collection)
		{
			var res = new NameValueCollection(collection);
			var keysToRemove = collection.AllKeys
				.Where(s => string.IsNullOrEmpty(s) || !char.IsLower(s, 0));
			foreach (var key in keysToRemove)
				res.Remove(key);
			return res;
		}
	}
}