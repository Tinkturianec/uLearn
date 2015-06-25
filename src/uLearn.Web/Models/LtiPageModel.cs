namespace uLearn.Web.Models
{
	public class LtiPageModel
	{
		public string UserId { get; set; }
		public string CourseId { get; set; }
		public Slide Slide { get; set; }
		public BlockRenderContext BlockRenderContext { get; set; }
	}
}