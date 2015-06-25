using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using uLearn.Web.DataContexts;
using uLearn.Web.Models;

namespace uLearn.Web.Controllers
{
	public class LtiToolController : Controller
	{
		private readonly CourseManager courseManager;
		private readonly VisitersRepo visitersRepo = new VisitersRepo();

		public LtiToolController()
			: this(WebCourseManager.Instance)
		{
		}

		private LtiToolController(CourseManager courseManager)
		{
			this.courseManager = courseManager;
		}


		[Authorize]
		public ActionResult Slide(string courseId, int slideIndex)
		{
			var course = courseManager.GetCourse(courseId);
			var slide = course.Slides[slideIndex];
//			var blockRenderContext = new BlockRenderContext(
//				course, 
//				slide, 
//				slide.Info.DirectoryRelativePath, 
//				slide.Blocks.Select(block => (object)null).ToArray());
			var model = new LtiPageModel
			{
				UserId = User.Identity.GetUserId(),
				CourseId = course.Id,
				Slide = slide,
//				BlockRenderContext = blockRenderContext
			};
			return View("Slide", model);
		}
	}
}