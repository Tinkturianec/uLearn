using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using LtiLibrary.Core.Lti1;
using LtiLibrary.Core.Outcomes.v1;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using uLearn.Web.DataContexts;
using uLearn.Web.Models;

namespace uLearn.Web.Controllers
{
	public class LtiToolController : Controller
	{
		private readonly CourseManager courseManager;
		private readonly VisitersRepo visitersRepo = new VisitersRepo();
		private readonly ConsumersRepo consumersRepo = new ConsumersRepo();
		private readonly LtiRequestsRepo ltiRequestsRepo = new LtiRequestsRepo();

		public LtiToolController()
			: this(WebCourseManager.Instance)
		{
		}

		private LtiToolController(CourseManager courseManager)
		{
			this.courseManager = courseManager;
		}


		[Authorize]
		public async Task<ActionResult> Slide(string courseId, int slideIndex)
		{
			var course = courseManager.GetCourse(courseId);
			var slide = course.Slides[slideIndex];
			var userId = User.Identity.GetUserId();

			var ltiRequestJson = FindLtiRequestJson();
			if (ltiRequestJson != null)
				await ltiRequestsRepo.Update(courseId, slide.Id, userId, ltiRequestJson);

//			var blockRenderContext = new BlockRenderContext(
//				course, 
//				slide, 
//				slide.Info.DirectoryRelativePath, 
//				slide.Blocks.Select(block => (object)null).ToArray());
			var model = new LtiPageModel
			{
				UserId = userId,
				CourseId = course.Id,
				Slide = slide,
//				BlockRenderContext = blockRenderContext
			};
			return View(model);
		}


		[Authorize]
		public void SubmitScore(string courseId, int slideIndex)
		{
			var userId = User.Identity.GetUserId();
			var course = courseManager.GetCourse(courseId);
			var slide = course.Slides[slideIndex];
			var score = visitersRepo.GetScore(slide.Id, userId);
			var maxScore = slide.MaxScore;
			var resultScore = maxScore == 0 ? 0 : (score + 0.0) / maxScore;

			var ltiRequest = ltiRequestsRepo.Find(courseId, slide.Id, userId);
			if (ltiRequest == null)
				throw new Exception("Can't find request");

			var consumerSecret = consumersRepo.FindConsumer(ltiRequest.ConsumerKey).Secret;

			OutcomesClient.PostScore(ltiRequest.LisOutcomeServiceUrl, ltiRequest.ConsumerKey, consumerSecret, ltiRequest.LisResultSourcedId, resultScore);
		}

		private string FindLtiRequestJson()
		{
			var user = User.Identity as ClaimsIdentity;
			if (user == null)
				return null;

			 var claim = user.Claims.FirstOrDefault(c => c.Type.Equals("LtiRequest"));
			return claim == null ? null : claim.Value;
		}

		private LtiRequest FindLtiRequest()
		{
			var ltiRequestJson = FindLtiRequestJson();
			if (ltiRequestJson == null)
				return null;

			return JsonSerializer.Create().Deserialize<LtiRequest>(new JsonTextReader(new StringReader(ltiRequestJson)));
		}
	}
}