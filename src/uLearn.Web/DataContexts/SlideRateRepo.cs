﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using uLearn.Web.Models;

namespace uLearn.Web.DataContexts
{
	public class SlideRateRepo
	{
		private readonly ULearnDb db;

		public SlideRateRepo() : this(new ULearnDb())
		{
			
		}

		public SlideRateRepo(ULearnDb db)
		{
			this.db = db;
		}

		public async Task<string> AddRate(string courseId, string slideId, string userId, SlideRates rate)
		{
			var lastRate = db.SlideRates.FirstOrDefault(x => x.SlideId == slideId && x.UserId == userId);
			if (lastRate == null)
			{
				db.SlideRates.Add(new SlideRate
				{
					Rate = rate,
					UserId = userId,
					SlideId = slideId,
					CourseId = courseId
				});
				await db.SaveChangesAsync();
				return "success";
			}
			if (lastRate.Rate == rate)
			{
				lastRate.Rate = SlideRates.NotWatched;
				await db.SaveChangesAsync();
				return "cancel";
			}
			lastRate.Rate = rate;
			await db.SaveChangesAsync();
			return "success";
		}

		public string FindRate(string courseId, string slideId, string userId)
		{
			var lastRate = db.SlideRates.FirstOrDefault(x => x.SlideId == slideId && x.UserId == userId);
			return lastRate == null ? null : lastRate.Rate.ToString();
		}

		public Rates GetRates(string slideId, string courseId)
		{
			var rates = new Rates();
			var allRates = db.SlideRates.Where(x => x.SlideId == slideId).ToList();
			foreach (var rate in allRates)
			{
				if (rate.Rate == SlideRates.Good)
					rates.AddGood();
				if (rate.Rate == SlideRates.NotUnderstand)
					rates.AddNotUnderstand();
				if (rate.Rate == SlideRates.NotWatched)
					rates.AddNotWatched();
				if (rate.Rate == SlideRates.Trivial)
					rates.AddTrivial();
			}
			return rates;
		}

		public string GetUserRate(string courseId, string slideId, string userId)
		{
			return ConvertMarkToPrettyString(db.SlideRates.FirstOrDefault(x => x.SlideId == slideId && x.UserId == userId));
		}

		private string ConvertMarkToPrettyString(SlideRate slideRate)
		{
			return slideRate == null
				? null
				: slideRate.Rate == SlideRates.Good
					? "Хорошо"
					: slideRate.Rate == SlideRates.NotUnderstand
						? "Не понял"
						: slideRate.Rate == SlideRates.Trivial
							? "Тривиально"
							: null;
		}

		public Dictionary<string, Rates> GetRates(Course course)
		{
			return db.SlideRates
				.Where(r => r.CourseId == course.Id)
				.GroupBy(r => r.SlideId)
				.Select(r => new
				{
					SlideId = r.Key,
					Good = r.Count(rate => rate.Rate == SlideRates.Good),
					NotUnderstand = r.Count(rate => rate.Rate == SlideRates.NotUnderstand),
					NotWatched = r.Count(rate => rate.Rate == SlideRates.NotWatched),
					Trivial = r.Count(rate => rate.Rate == SlideRates.Trivial)
				})
				.ToDictionary(arg => arg.SlideId, arg => new Rates(arg.Good, arg.NotUnderstand, arg.NotWatched, arg.Trivial));
		}
	}
}