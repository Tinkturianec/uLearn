﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Ajax.Utilities;
using Microsoft.Owin.Security.Provider;
using NUnit.Framework;
using uLearn.Quizes;
using uLearn.Web.Migrations;
using uLearn.Web.Models;

namespace uLearn.Web.DataContexts
{
	public class UserQuizzesRepo
	{
		private readonly ULearnDb db;

		public UserQuizzesRepo() : this(new ULearnDb())
		{
			
		}

		public UserQuizzesRepo(ULearnDb db)
		{
			this.db = db;
		}

		public async Task<UserQuiz> AddUserQuiz(string courseId, bool isRightAnswer, string itemId, string quizId, string slideId, string text, string userId, DateTime time, bool isRightQuizBlock)
		{
			var userQuiz = new UserQuiz
			{
				CourseId = courseId,
				IsRightAnswer = isRightAnswer,
				ItemId = itemId,
				QuizId = quizId,
				SlideId = slideId,
				Text = text,
				Timestamp = time,
				UserId = userId,
				IsRightQuizBlock = isRightQuizBlock
			};
			db.UserQuizzes.Add(userQuiz);
			await db.SaveChangesAsync();
			return userQuiz;
		}

		public bool IsQuizSlidePassed(string courseId, string userId, string slideId)
		{
			return db.UserQuizzes.Any(x => x.UserId == userId && x.SlideId == slideId && !x.isDropped);
		}

		public IEnumerable<bool> GetQuizDropStates(string courseId, string userId, string slideId)
		{
			return db.UserQuizzes
				.Where(x => x.UserId == userId && x.SlideId == slideId)
				.DistinctBy(q => q.Timestamp)
				.Select(q => q.isDropped);
		}

		public HashSet<string> GetIdOfQuizPassedSlides(string courseId, string userId)
		{
			return new HashSet<string>(db.UserQuizzes.Where(x => x.CourseId == courseId && x.UserId == userId).Select(x => x.SlideId).Distinct());
		}

		public Dictionary<string, List<string>> GetAnswersForShowOnSlide(string courseId, QuizSlide slide, string userId)
		{
			if (slide == null)
				return null;
			var answer = new Dictionary<string, List<string>>();
			foreach (var block in slide.Quiz.Blocks.OfType<AbstractQuestionBlock>())
			{
				var ans = db.UserQuizzes
					.Where(x => x.UserId == userId && x.SlideId == slide.Id && x.QuizId == block.Id && !x.isDropped).ToList();
				if (block is ChoiceBlock)
					answer[block.Id] = ans.Select(x => x.ItemId).ToList();
				else if (block is IsTrueBlock)
					answer[block.Id] = ans.Select(x => x.Text).ToList();
				else if(block is FillInBlock)
					answer[block.Id] = new List<string>
					{
						ans.Select(x => x.Text).FirstOrDefault(),
						ans.Select(x => x.IsRightAnswer).FirstOrDefault().ToString()
					};
			}
			return answer;
		}

		public FillInBlockAnswerInfo GetFillInBlockAnswerInfo(string courseId, string slideId, string quizId, string userId, int questionIndex)
		{
			var answer = db.UserQuizzes.FirstOrDefault(x => x.UserId == userId && x.SlideId == slideId && x.QuizId == quizId && !x.isDropped);
			return new FillInBlockAnswerInfo
			{
				Answer = answer == null ? null : answer.Text,
				IsRight = answer != null && answer.IsRightAnswer,
				Id = questionIndex.ToString()
			};
		}

		public ChoiceBlockAnswerInfo GetChoiseBlockAnswerInfo(string courseId, string slideId, ChoiceBlock block, string userId, int questionIndex)
		{
			var ans = new SortedDictionary<string, bool>();
			foreach (var item in block.Items)
			{
				ans[item.Id] = false;
			}
			var isRight = false;
			foreach (var quizItem in db.UserQuizzes.Where(q => q.UserId == userId && q.SlideId == slideId && q.QuizId == block.Id && q.ItemId != null && !q.isDropped))
			{
				isRight = quizItem.IsRightQuizBlock;
				ans[quizItem.ItemId] = true;
			}
			return new ChoiceBlockAnswerInfo
			{
				AnswersId = ans,
				Id = questionIndex.ToString(),
				RealyRightAnswer = new HashSet<string>(block.Items.Where(x => x.IsCorrect).Select(x => x.Id)),
				IsRight = isRight
			};
		}

		public IsTrueBlockAnswerInfo GetIsTrueBlockAnswerInfo(string courseId, string slideId, string quizId, string userId, int questionIndex)
		{
			var answer =  db.UserQuizzes.FirstOrDefault(x => x.UserId == userId && x.SlideId == slideId && x.QuizId == quizId && !x.isDropped);
			return new IsTrueBlockAnswerInfo
			{
				IsAnswered = answer != null,
				Answer = answer != null && answer.Text == "True",
				Id = questionIndex.ToString(),
				IsRight = answer != null && answer.IsRightAnswer
			};
		}

		public int GetAverageStatistics(string slideId, string courseId)
		{
			var newA = db.UserQuizzes
				.Where(x => x.SlideId == slideId)
				.GroupBy(x => x.UserId)
				.Select(x => x
					.GroupBy(y => y.QuizId)
					.Select(y => y.All(z => z.IsRightQuizBlock))
					.Select(y => y ? 1 : 0)
					.DefaultIfEmpty()
					.Average())
				.DefaultIfEmpty()
				.Average() * 100;
			return (int) newA;
		}

		public int GetSubmitQuizCount(string slideId, string courseId)
		{
			return db.UserQuizzes.Where(x => x.SlideId == slideId).Select(x => x.User).Distinct().Count();
		}

		public int GetQuizSuccessful(string courseId, string slideId, string userId)
		{
			return (int)(db.UserQuizzes
				.Where(x => x.SlideId == slideId && x.UserId == userId)
				.GroupBy(y => y.QuizId)
				.Select(y => y.All(z => z.IsRightQuizBlock))
				.Select(y => y ? 1 : 0)
				.DefaultIfEmpty()
				.Average() * 100);
		}

		public async Task RemoveAnswers(string userId, string slideId)
		{
			var answersToRemove = db.UserQuizzes.Where(q => q.UserId == userId && q.SlideId == slideId).ToList();
			db.UserQuizzes.RemoveRange(answersToRemove);
			await db.SaveChangesAsync();
		}

		public async Task DropQuiz(string userId, string slideId)
		{
			var quizzes = db.UserQuizzes.Where(q => q.UserId == userId && q.SlideId == slideId).ToList();
			foreach (var q in quizzes)
			{
				q.isDropped = true;
			}
			await db.SaveChangesAsync();
		}

		public Dictionary<string, bool> GetQuizBlocksTruth(string courseId, string userId, string slideId)
		{
			return db.UserQuizzes
				.Where(q => q.UserId == userId && q.SlideId == slideId && !q.isDropped)
				.DistinctBy(q => q.QuizId)
				.ToDictionary(q => q.QuizId, q => q.IsRightQuizBlock);
		}

		public Dictionary<string, int> GetSubmitQuizzesCount(Course course)
		{
			return db.UserQuizzes
				.Where(v => v.CourseId == course.Id)
				.GroupBy(v => v.SlideId)
				.Select(g => new { g.Key, Count = g.Select(v => v.UserId).Distinct().Count() })
				.ToDictionary(a => a.Key, a => a.Count);
		}

		public Dictionary<string, int> GetAverageStatistics(Course course)
		{
			return db.UserQuizzes
				.Where(v => v.CourseId == course.Id)
				.GroupBy(v => v.SlideId)
				.Select(g => new
				{
					g.Key,
					Value = g
						.GroupBy(q => q.UserId)
						.Select(x => x
							.GroupBy(y => y.QuizId, (s, quizzes) => quizzes.All(z => z.IsRightQuizBlock) ? 100 : 0)
							.DefaultIfEmpty()
							.Average())
						.DefaultIfEmpty()
						.Average()
				})
				.ToDictionary(a => a.Key, a => (int)a.Value);
		}
	}
}