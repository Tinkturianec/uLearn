using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LtiLibrary.Core.Lti1;
using Newtonsoft.Json;
using uLearn.Web.Models;

namespace uLearn.Web.DataContexts
{
	public class LtiRequestsRepo
	{
		private readonly ULearnDb db;
		private readonly JsonSerializer serializer;

		public LtiRequestsRepo() : this(new ULearnDb())
		{
			
		}

		public LtiRequestsRepo(ULearnDb db)
		{
			this.db = db;
			serializer = new JsonSerializer();
		}

		public async Task Update(string courseId, string slideId, string userId, string ltiRequestJson)
		{
			var ltiRequestModel = FindElement(courseId, slideId, userId) ?? new LtiRequestModel
			{
				CourseId = courseId,
				SlideId = slideId,
				UserId = userId,
				Request = ltiRequestJson
			};

			db.LtiRequests.AddOrUpdate(ltiRequestModel);
			await db.SaveChangesAsync();
		}

		public LtiRequest Find(string courseId, string slideId, string userId)
		{
			var ltiRequestModel = FindElement(courseId, slideId, userId);
			if (ltiRequestModel == null)
				return null;

			return serializer.Deserialize<LtiRequest>(new JsonTextReader(new StringReader(ltiRequestModel.Request)));
		}

		private LtiRequestModel FindElement(string courseId, string slideId, string userId)
		{
			return db.LtiRequests.FirstOrDefault(request => request.SlideId == slideId && request.UserId == userId);
		}
	}
}