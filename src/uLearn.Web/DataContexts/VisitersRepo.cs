﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using uLearn.Web.Models;

namespace uLearn.Web.DataContexts
{
	public class VisitersRepo
	{
		private readonly ULearnDb db;

		public VisitersRepo() : this(new ULearnDb())
		{
			
		}

		public VisitersRepo(ULearnDb db)
		{
			this.db = db;
		}

		public async Task AddVisiter(string courseId, string slideId, string userId)
		{
			if (db.Visiters.Any(x => x.UserId == userId && x.SlideId == slideId))
				return;
			db.Visiters.Add(new Visiters
			{
				UserId = userId,
				CourseId = courseId,
				SlideId = slideId,
				Timestamp = DateTime.Now
			});
			await db.SaveChangesAsync();
		}

		public int GetVisitersCount(string slideId, string courseId)
		{
			return db.Visiters.Count(x => x.SlideId == slideId);
		}

		public bool IsUserVisit(string courseId, string slideId, string userId)
		{
			return db.Visiters.Any(x => x.SlideId == slideId && x.UserId == userId);
		}

		public HashSet<string> GetIdOfVisitedSlides(string courseId, string userId)
		{
			return new HashSet<string>(db.Visiters.Where(x => x.UserId == userId && x.CourseId == courseId).Select(x => x.SlideId));
		}
		
		public bool HasVisitedSlides(string courseId, string userId)
		{
			return db.Visiters.Any(x => x.UserId == userId && x.CourseId == courseId);
		}

		public Dictionary<string, int> GetVisitersCounts(Course course)
		{
			return db.Visiters
				.Where(v => v.CourseId == course.Id)
				.GroupBy(v => v.SlideId)
				.Select(g => new { g.Key, Count = g.Count() })
				.ToDictionary(g => g.Key, g => g.Count);
		}
	}
}