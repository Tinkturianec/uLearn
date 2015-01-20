﻿using CsSandboxApi;

namespace uLearn.Web.ExecutionService
{
	public class CsSandboxService : IExecutionService
	{
		private readonly CsSandboxClient client = new CsSandboxClient();

		public SubmissionResult Submit(string code, string humanName = null)
		{
			try
			{
				var details = client.Submit(code, "", humanName).Result;
				return details == null ? null : new CsSandboxSubmissionResult(details);
			}
			catch (CsSandboxClientException)
			{
				return null;
			}
		}
	}

	public class CsSandboxSubmissionResult : SubmissionResult
	{
		private readonly PublicSubmissionDetails details;

		public CsSandboxSubmissionResult(PublicSubmissionDetails details)
		{
			this.details = details;
		}

		public override bool IsSuccess()
		{
			return details.Verdict == CsSandboxApi.Verdict.Ok;
		}

		public override bool IsCompilationError()
		{
			return details.Verdict == CsSandboxApi.Verdict.CompilationError;
		}

		public override bool IsTimeLimit()
		{
			return details.Verdict == CsSandboxApi.Verdict.TimeLimit;
		}

		public override string GetCompilationError()
		{
			return details.CompilationInfo ?? "";
		}

		public override bool IsInternalError()
		{
			return details.Verdict == CsSandboxApi.Verdict.SandboxError;
		}

		public override string StdOut
		{
			get { return details.Output; }
		}

		public override string StdErr {
			get { return details.Error; }
		}

		protected override string Verdict
		{
			get { return details.Verdict.ToString(); }
		}
	}
}