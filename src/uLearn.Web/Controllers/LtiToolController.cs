using System;
using System.Web.Mvc;
using LtiLibrary.Core.Lti1;
using LtiLibrary.Core.OAuth;
using uLearn.Web.DataContexts;
using uLearn.Web.LTI;

namespace uLearn.Web.Controllers
{
	public class LtiToolController : Controller
	{
		private readonly CourseManager courseManager;
		private readonly ConsumersRepo consumersRepo = new ConsumersRepo();

		public LtiToolController()
			: this(WebCourseManager.Instance)
		{
		}

		private LtiToolController(CourseManager courseManager)
		{
			this.courseManager = courseManager;
		}


		public ActionResult Slide(string courseId, int slideIndex)
		{
			var request = Request.ToLtiRequest();
			var consumer = request.ConsumerKey;
			var consumerSecret = consumersRepo.FindConsumer(consumer).Secret;

			var sign = request.GenerateSignature(consumerSecret);
			request.Parameters.Add("calculated sign", sign);

//			var sign = OAuthUtility.GenerateSignature(Request.HttpMethod, Request.Url, Request.Params, "test");
			return View(request.Parameters);
//			var authenticateResult = GetAuthenticateResult(request);
//			if (!IsAuthenticated(request))
//				return null;

//			return RedirectToAction("Slide", "Course", new { courseId, slideIndex });
//			return View(model: authenticateResult);
		}

		private bool IsAuthenticated()
		{
			var request = Request.ToLtiRequest();

			var timeout = TimeSpan.FromMinutes(5);
			var oauthTimestampAbsolute = OAuthConstants.Epoch.AddSeconds(request.Timestamp);
			if (DateTime.UtcNow - oauthTimestampAbsolute > timeout)
				return false;

			var consumer = consumersRepo.FindConsumer(request.ConsumerKey);
			if (consumer == null)
				return false;

			var signature = request.GenerateSignature(consumer.Secret);
			if (!signature.Equals(request.Signature))
				return false;

			return true;
		}

	}
}