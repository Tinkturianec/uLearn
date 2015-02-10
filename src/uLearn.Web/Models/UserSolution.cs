﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace uLearn.Web.Models
{
	public class UserSolution : ISlideAction
	{
		[Required]
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(64)]
		[Index("TotalStatistic", 1)]
		public string CourseId { get; set; }

		[Required]
		[StringLength(64)]
		[Index("AcceptedList", 1)]
		[Index("TotalStatistic", 3)]
		public string SlideId { get; set; }

		public virtual ApplicationUser User { get; set; }

		[StringLength(64)]
		[Index("TotalStatistic", 4)]
		public string UserId { get; set; }

		public virtual TextBlob SolutionCode { get; set; }

		[StringLength(40)]
		[Required]
		public string SolutionCodeHash { get; set; }

		[Required]
		[Index("AcceptedList", 3)]
		public int CodeHash { get; set; }

		public virtual IList<Like> Likes { get; set; }

		[Required]
		[Index("AcceptedList", 4)]
		public DateTime Timestamp { get; set; }

		[Required]
		[Index("AcceptedList", 2)]
		[Index("TotalStatistic", 2)]
		public bool IsRightAnswer { get; set; }

		[Required]
		public bool IsCompilationError { get; set; }

		public virtual TextBlob CompilationError { get; set; }

		[StringLength(40)]
		public string CompilationErrorHash { get; set; }

		public virtual TextBlob Output { get; set; }

		[StringLength(40)]
		public string OutputHash { get; set; }

		public string GetVerdict()
		{
			if (IsCompilationError) return "CompilationError";
			if (!IsRightAnswer) return "Wrong Answer";
			
			return "Accepted";
		}
	}
}