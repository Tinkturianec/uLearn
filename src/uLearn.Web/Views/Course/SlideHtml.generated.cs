﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace uLearn.Web.Views.Course
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using uLearn;
    using uLearn.Model.Blocks;
    using uLearn.Quizes;
    using uLearn.Web.Controllers;
    using uLearn.Web.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    public static class SlideHtml
    {

public static System.Web.WebPages.HelperResult Slide(BlockRenderContext context, int currentScore = 0)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


 

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<div class=\"slide\">\r\n\t\t<h1>\r\n\t\t\t");


WebViewPage.WriteTo(@__razor_helper_writer, context.Slide.Title);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\r\n\t\t\t<span class=\"score\">");


WebViewPage.WriteTo(@__razor_helper_writer, Score(currentScore, context.Slide.MaxScore));

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</span>\r\n\t\t</h1>\r\n\t\t");


WebViewPage.WriteTo(@__razor_helper_writer, Blocks(context.Slide.Blocks, context));

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\r\n\t</div>\r\n");



});

}


public static System.Web.WebPages.HelperResult Blocks(IEnumerable<SlideBlock> blocks, BlockRenderContext context)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


 
foreach (var block in context.Slide.Blocks)
{
	if (!block.Hide)
	{
		
WebViewPage.WriteTo(@__razor_helper_writer, Block((dynamic)block, context));

                                 
	}
	else if (context.RevealHidden)
	{



WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t<div class=\'revealed\' data-toggle=\"tooltip\" data-placement=\"left\" title=\"Этот б" +
"лок студенты не видят\">\r\n\t\t\t<h4>Инструктору</h4>\r\n\t\t\t");


WebViewPage.WriteTo(@__razor_helper_writer, Block((dynamic)block, context));

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\r\n\t\t</div>\r\n");


	}
}

});

}


public static System.Web.WebPages.HelperResult Block(AbstractQuestionBlock block, BlockRenderContext context)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


 
	var mark = "";
	var style = "";
	QuizBlockData model = context.GetBlockData(block);
	if (model.QuizState != QuizState.NotPassed)
	{
		if (model.QuizModel != null && model.QuizModel.ResultsForQuizes != null)
		{
			bool res;
			res = model.QuizModel.ResultsForQuizes.TryGetValue(block.Id, out res) && res;
			mark = "glyphicon " + (res ? "glyphicon-ok" : "glyphicon-remove");
			style = "color: " + (res ? "green" : "red");
		}
	}

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<h4><i class=\"");


WebViewPage.WriteTo(@__razor_helper_writer, mark);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" style=\"");


WebViewPage.WriteTo(@__razor_helper_writer, style);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\"></i> ");


WebViewPage.WriteTo(@__razor_helper_writer, block.QuestionIndex);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, ". ");


                     WebViewPage.WriteTo(@__razor_helper_writer, block.Text.RenderTex());

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</h4>\r\n");


	
WebViewPage.WriteTo(@__razor_helper_writer, QuizBlock((dynamic)block, context));

                                    

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<hr class=\"quiz-block-delimiter\" />\r\n");



});

}


public static System.Web.WebPages.HelperResult Score(int currentScore, int maxScore)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


 
	
WebViewPage.WriteTo(@__razor_helper_writer, maxScore == 0 ? "" : string.Format("{0}/{1}", currentScore, maxScore));

                                                                         

});

}


public static System.Web.WebPages.HelperResult Block(MdBlock block, BlockRenderContext context)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


 
	
WebViewPage.WriteTo(@__razor_helper_writer, MvcHtmlString.Create(block.Markdown.RenderMd(context.BaseUrl)));

                                                                

});

}


public static System.Web.WebPages.HelperResult Block(CodeBlock block, BlockRenderContext context)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


 

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<textarea class=\"code code-sample\" data-lang=\"");


    WebViewPage.WriteTo(@__razor_helper_writer, block.LangId);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" data-ver=\"");


                             WebViewPage.WriteTo(@__razor_helper_writer, block.LangVer);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">");


                                             WebViewPage.WriteTo(@__razor_helper_writer, block.Code);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</textarea>\r\n");



});

}


public static System.Web.WebPages.HelperResult Block(TexBlock block, BlockRenderContext context)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


 
	foreach (var texLine in block.TexLines)
	{

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t<div class=\"tex\">\\displaystyle ");


WebViewPage.WriteTo(@__razor_helper_writer, texLine.Trim());

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</div>\r\n");


	}

});

}


public static System.Web.WebPages.HelperResult Block(YoutubeBlock block, BlockRenderContext context)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


 

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<div class=\"video-container\">\r\n\t\t<iframe class=\"embedded-video\" width=\"864\" heig" +
"ht=\"480\" src=\"https://www.youtube.com/embed/");


                                                  WebViewPage.WriteTo(@__razor_helper_writer, block.VideoId);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" allowfullscreen></iframe>\r\n\t</div>\r\n");



WebViewPage.WriteLiteralTo(@__razor_helper_writer, @"	<div>
		<a href=""javascript://"" class=""popover-trigger""
		   title=""Как ускорить видео?""
		   data-content=""Если по иконке с шестеренкой нет возможности ускорить видео, то вам нужно &lt;a target='blank' href='http://youtube.com/html5'>вручную включить&lt;/a> использование HTML5-плеера."">
			Как ускорить видео?
		</a>
	</div>
");



});

}


public static System.Web.WebPages.HelperResult Block(ImageGaleryBlock block, BlockRenderContext context)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


 

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<div class=\"flexslider\">\r\n\t\t<ul class=\"slides\">\r\n");


 			foreach (var imageUrl in block.ImageUrls)
			{

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t\t\t<li>\r\n\t\t\t\t\t<img src=\"");


WebViewPage.WriteTo(@__razor_helper_writer, string.Format("{0}/{1}", context.BaseUrl, imageUrl));

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" alt=\"");


                               WebViewPage.WriteTo(@__razor_helper_writer, imageUrl);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" />\r\n\t\t\t\t</li>\r\n");


			}

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t</ul>\r\n\t</div>\r\n");



});

}


public static System.Web.WebPages.HelperResult CodeTextArea(string initialCode, string langId, string runSolutionUrl)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


 

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<textarea class=\"code code-exercise\" data-lang=\"");


      WebViewPage.WriteTo(@__razor_helper_writer, langId);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">");


               WebViewPage.WriteTo(@__razor_helper_writer, initialCode);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</textarea>\r\n");



WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<div class=\"solution-control btn-group ctrl-group\">\r\n\t\t<button type=\"button\" cla" +
"ss=\"run-solution-button btn btn-primary no-rounds\" data-url=\"");


                                             WebViewPage.WriteTo(@__razor_helper_writer, runSolutionUrl);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">\r\n\t\t\tRun\r\n\t\t</button>\r\n\t</div>\r\n");



	
WebViewPage.WriteTo(@__razor_helper_writer, RunErrors());

             

});

}


public static System.Web.WebPages.HelperResult Block(ExerciseBlock block, BlockRenderContext context)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


 
	ExerciseBlockData data = context.GetBlockData(block) ?? new ExerciseBlockData();
	var action = data.CanSkip ? "$('#ShowSolutionsAlert').modal('show')" : string.Format("window.location='{0}'", data.AcceptedSolutionUrl);
	var classString = context.IsGuest ? "code-guest" : "code-exercise";

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<textarea id=\"secretCodeExercise\" class=\"hide\">");


     WebViewPage.WriteTo(@__razor_helper_writer, block.ExerciseInitialCode.EnsureEnoughLines(4));

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</textarea>\r\n");



WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<textarea class=\"code ");


WebViewPage.WriteTo(@__razor_helper_writer, classString);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" data-lang=\"");


     WebViewPage.WriteTo(@__razor_helper_writer, block.LangId);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">");


                     WebViewPage.WriteTo(@__razor_helper_writer, data.LatestAcceptedSolution ?? block.ExerciseInitialCode.EnsureEnoughLines(4));

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</textarea>\r\n");



WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<script>\r\n\t\tfunction cleanUserCode() {\r\n\t\t\tvar $secretCodeExercise = $(\'#secretC" +
"odeExercise\');\r\n\t\t\t$(\'.code-exercise\')[0].codeMirrorEditor.setValue($secretCodeE" +
"xercise.text());\r\n\t\t}\r\n\t</script>\r\n");


	if (data.ShowControls)
	{

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t<div class=\"solution-control btn-group ctrl-group\">\r\n\t\t\t<button type=\"button\" c" +
"lass=\"run-solution-button btn btn-primary no-rounds ");


                                    WebViewPage.WriteTo(@__razor_helper_writer, data.IsLti ? "run-solution-button-lti" : "");

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" data-url=\"");


                                                                                             WebViewPage.WriteTo(@__razor_helper_writer, data.RunSolutionUrl);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">\r\n\t\t\t\tRun\r\n\t\t\t</button>\r\n\r\n");


 			if (!data.DebugView)
			{
				var e = ((ExerciseSlide)context.Slide).Exercise.HintsMd;

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t\t\t<button id=\"GetHintButton\" type=\"button\" class=\"btn btn-default hints-btn\"\r\n\t" +
"\t\t\t\t\tdata-course-id=\"");


WebViewPage.WriteTo(@__razor_helper_writer, context.Course.Id);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" data-slide-index=\"");


                 WebViewPage.WriteTo(@__razor_helper_writer, context.Slide.Index);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" data-hints-count=\"");


                                                         WebViewPage.WriteTo(@__razor_helper_writer, e.Count);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\"\r\n\t\t\t\t\t\tdata-url=\"");


WebViewPage.WriteTo(@__razor_helper_writer, data.GetHintUrl);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">\r\n\t\t\t\t\tGet hint\r\n\t\t\t\t</button>\r\n");


				if (!data.IsLti)
				{

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t\t\t\t<button type=\"button\" class=\"btn btn-default giveup-btn\" onclick=\"");


                            WebViewPage.WriteTo(@__razor_helper_writer, action);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">\r\n\t\t\t\t\t\tShow solutions\r\n\t\t\t\t\t</button>\r\n");


				}

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t\t\t<button type=\"button\" class=\"btn btn-default reset-btn no-rounds\" onclick=\"cl" +
"eanUserCode()\">\r\n\t\t\t\t\tReset\r\n\t\t\t\t</button>\r\n");


			}

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t</div>\r\n");



		
WebViewPage.WriteTo(@__razor_helper_writer, RunErrors());

              


WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t<div class=\"panel-group ctrl-group\" id=\"hints-accordion\">\r\n\t\t\t<div id=\"hints-pl" +
"ace\"></div>\r\n\t\t</div>\r\n");


		if (!data.IsLti)
		{
			
WebViewPage.WriteTo(@__razor_helper_writer, YouWillLoseScoresDialog(data));

                                 
		}
	}
	if (data.DebugView)
	{

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t<div>\r\n\t\t\t<h3>Подсказки</h3>\r\n\t\t\t<ol>\r\n");


 				foreach (var hint in block.HintsMd)
				{

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t\t\t\t<li>\r\n\t\t\t\t\t\t");


WebViewPage.WriteTo(@__razor_helper_writer, MvcHtmlString.Create(hint.RenderMd(context.BaseUrl)));

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\r\n\t\t\t\t\t</li>\r\n");


				}

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t\t</ol>\r\n\t\t\t<h3>Комментарий после решения</h3>\r\n\t\t\t<p>");


WebViewPage.WriteTo(@__razor_helper_writer, block.CommentAfterExerciseIsSolved);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</p>\r\n\t\t</div>\r\n");


	}

});

}


public static System.Web.WebPages.HelperResult QuizBlock(ChoiceBlock block, BlockRenderContext context)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


 
	var items = block.ShuffledItems();
	var isMultiply = block.Multiple;
	var typeInp = isMultiply ? "checkbox" : "radio";
	QuizBlockData model = context.GetBlockData(block) ?? new QuizBlockData(new QuizModel(), 1, QuizState.NotPassed);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<div class=\"quiz-block-mark ");


WebViewPage.WriteTo(@__razor_helper_writer, typeInp);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" id=\'");


 WebViewPage.WriteTo(@__razor_helper_writer, block.Id + "_quizBlock");

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\'>\r\n");


 		for (var itemIndex = 0; itemIndex < items.Length; itemIndex++)
		{
			var item = items[itemIndex];
			var id = isMultiply ? itemIndex + "noMult" : model.BlockIndex.ToString();
			var itemChecked = model.QuizState != QuizState.NotPassed && model.QuizModel.AnswersToQuizes[block.Id].Contains(item.Id);
			var ans = itemChecked ? "checked" : "";
			var itemClass = "";
			var title = "";
			if (model.QuizState == QuizState.Total)
			{
				itemClass = item.IsCorrect ? "right-quiz" : itemChecked ? "wrong-quiz" : "";
				title = (item.IsCorrect ? "Правильный" : "Неправильный") + " вариант";
			}

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t\t<div class=\"quiz\">\r\n\t\t\t\t<label class=\"");


WebViewPage.WriteTo(@__razor_helper_writer, itemClass);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" title=\"");


WebViewPage.WriteTo(@__razor_helper_writer, title);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" ");


  WebViewPage.WriteTo(@__razor_helper_writer, GetGuestOnclick(context.IsGuest));

WebViewPage.WriteLiteralTo(@__razor_helper_writer, ">\r\n\t\t\t\t\t<input ");


WebViewPage.WriteTo(@__razor_helper_writer, ans);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, " autocomplete=\"off\" id=\'");


WebViewPage.WriteTo(@__razor_helper_writer, block.Id + "quizBlock" + item.Id);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\' name=");


                                        WebViewPage.WriteTo(@__razor_helper_writer, "group" + id);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, " type=\"");


                                                             WebViewPage.WriteTo(@__razor_helper_writer, typeInp);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" ");


                                                                       WebViewPage.WriteTo(@__razor_helper_writer, GetGuestDisable(context.IsGuest));

WebViewPage.WriteLiteralTo(@__razor_helper_writer, ">\r\n\t\t\t\t\t");


WebViewPage.WriteTo(@__razor_helper_writer, item.Description.RenderTex());

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\r\n\t\t\t\t</label>\r\n");


 				if (model.QuizState == QuizState.Total && item.IsCorrect)
				{

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t\t\t\t<i class=\"glyphicon glyphicon-ok\" style=\"color: green\" title=\"");


                        WebViewPage.WriteTo(@__razor_helper_writer, title);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\"></i>\r\n");


				}


 				if (model.QuizState == QuizState.Total && !string.IsNullOrEmpty(item.Explanation))
				{

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t\t\t\t<p class=\"text-muted\">");


WebViewPage.WriteTo(@__razor_helper_writer, item.Explanation);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</p>\r\n");


				}

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t\t</div>\r\n");


		}

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t</div>\r\n");



});

}


public static System.Web.WebPages.HelperResult QuizBlock(FillInBlock block, BlockRenderContext context)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


 
	var value = "";
	var quizRes = "";
	QuizBlockData model = context.GetBlockData(block) ?? new QuizBlockData(new QuizModel(), 1, QuizState.NotPassed);
	if (model.QuizState != QuizState.NotPassed && model.QuizModel.AnswersToQuizes[block.Id].FirstOrDefault() != null)
	{
		value = model.QuizModel.AnswersToQuizes[block.Id].FirstOrDefault();
		quizRes = (model.QuizState == QuizState.Total)
			? (model.QuizModel.AnswersToQuizes[block.Id][1] == "False" ? "wrong-quiz" : "right-quiz") : "";
	}
	var sample = block.Sample;

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<div class=\"quiz quiz-block-input\">\r\n\t\t<label ");


WebViewPage.WriteTo(@__razor_helper_writer, GetGuestOnclick(context.IsGuest));

WebViewPage.WriteLiteralTo(@__razor_helper_writer, ">\r\n\t\t\t<input autocomplete=\"off\" class=\"form-control ");


      WebViewPage.WriteTo(@__razor_helper_writer, quizRes);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" value=\"");


                       WebViewPage.WriteTo(@__razor_helper_writer, value);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" id=\'");


                                    WebViewPage.WriteTo(@__razor_helper_writer, block.Id + "quizBlock");

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\' maxlength=\"");


                                                                         WebViewPage.WriteTo(@__razor_helper_writer, QuizController.MAX_FILLINBLOCK_SIZE);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" ");


                                                                                                               WebViewPage.WriteTo(@__razor_helper_writer, GetGuestDisable(context.IsGuest));

WebViewPage.WriteLiteralTo(@__razor_helper_writer, ">\r\n\t\t</label>\r\n\t</div>\r\n");


	if (model.QuizState == QuizState.Total)
	{

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t<div>Правильный ответ: ");


WebViewPage.WriteTo(@__razor_helper_writer, sample);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</div>\r\n");


		if (!string.IsNullOrEmpty(block.Explanation))
		{

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t\t<div class=\"text-muted\">");


WebViewPage.WriteTo(@__razor_helper_writer, block.Explanation);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</div>\r\n");


		}
	}

});

}


public static System.Web.WebPages.HelperResult QuizBlock(IsTrueBlock block, BlockRenderContext context)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


 
	var tchecked = "";
	var fchecked = "";
	var trueItemClass = "";
	var falseItemClass = "";
	var ttitle = "";
	var ftitle = "";
	QuizBlockData model = context.GetBlockData(block) ?? new QuizBlockData(new QuizModel(), 1, QuizState.NotPassed);
	if (model.QuizState != QuizState.NotPassed && model.QuizModel.AnswersToQuizes[block.Id].FirstOrDefault() != null)
	{
		var userAnswer = model.QuizModel.AnswersToQuizes[block.Id].FirstOrDefault() == "True";
		tchecked = userAnswer ? "checked" : "";
		fchecked = userAnswer ? "" : "checked";
		if (model.QuizState == QuizState.Total)
		{
			trueItemClass = block.Answer ? "right-quiz" : userAnswer ? "wrong-quiz" : "";
			falseItemClass = !block.Answer ? "right-quiz" : !userAnswer ? "wrong-quiz" : "";
		}
	}
	if (model.QuizState == QuizState.Total)
	{
		ttitle = (block.Answer ? "Правильный" : "Неправильный") + " вариант";
		ftitle = (!block.Answer ? "Правильный" : "Неправильный") + " вариант";
	}

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<div class=\"radio quiz-block-mark\" id=\"");


WebViewPage.WriteTo(@__razor_helper_writer, block.Id + "_quizBlock");

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">\r\n\t\t<div class=\"quiz\">\r\n\t\t\t<label class=\"");


WebViewPage.WriteTo(@__razor_helper_writer, trueItemClass);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" title=\"");


WebViewPage.WriteTo(@__razor_helper_writer, ttitle);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" ");


      WebViewPage.WriteTo(@__razor_helper_writer, GetGuestOnclick(context.IsGuest));

WebViewPage.WriteLiteralTo(@__razor_helper_writer, ">\r\n\t\t\t\t<input autocomplete=\"off\" ");


WebViewPage.WriteTo(@__razor_helper_writer, tchecked);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, " id=\'");


  WebViewPage.WriteTo(@__razor_helper_writer, block.Id + "quizBlock" + "True");

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\' name=\'");


                                            WebViewPage.WriteTo(@__razor_helper_writer, block.Id + "group");

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\' type=\"radio\" ");


                                                                               WebViewPage.WriteTo(@__razor_helper_writer, GetGuestDisable(context.IsGuest));

WebViewPage.WriteLiteralTo(@__razor_helper_writer, ">\r\n\t\t\t\tВерно\r\n\t\t\t</label>\r\n");


 			if (model.QuizState == QuizState.Total && block.Answer)
			{

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t\t\t<i class=\"glyphicon glyphicon-ok\" style=\"color: green\" title=\"");


                       WebViewPage.WriteTo(@__razor_helper_writer, ttitle);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\"></i>\r\n");


			}

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t</div>\r\n\t\t<div class=\"quiz\">\r\n\t\t\t<label class=\"");


WebViewPage.WriteTo(@__razor_helper_writer, falseItemClass);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" title=\"");


WebViewPage.WriteTo(@__razor_helper_writer, ftitle);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" ");


       WebViewPage.WriteTo(@__razor_helper_writer, GetGuestOnclick(context.IsGuest));

WebViewPage.WriteLiteralTo(@__razor_helper_writer, ">\r\n\t\t\t\t<input autocomplete=\"off\" ");


WebViewPage.WriteTo(@__razor_helper_writer, fchecked);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, " id=\'");


  WebViewPage.WriteTo(@__razor_helper_writer, block.Id + "quizBlock" + "False");

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\' name=\'");


                                             WebViewPage.WriteTo(@__razor_helper_writer, block.Id + "group");

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\' type=\"radio\" ");


                                                                                WebViewPage.WriteTo(@__razor_helper_writer, GetGuestDisable(context.IsGuest));

WebViewPage.WriteLiteralTo(@__razor_helper_writer, ">\r\n\t\t\t\tНеверно\r\n\t\t\t</label>\r\n");


 			if (model.QuizState == QuizState.Total && !block.Answer)
			{

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t\t\t<i class=\"glyphicon glyphicon-ok\" style=\"color: green\" title=\"");


                       WebViewPage.WriteTo(@__razor_helper_writer, ftitle);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\"></i>\r\n");


			}

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t</div>\r\n\t</div>\r\n");


	if (model.QuizState == QuizState.Total && !string.IsNullOrEmpty(block.Explanation))
	{

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t<div class=\"text-muted\">");


WebViewPage.WriteTo(@__razor_helper_writer, block.Explanation);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</div>\r\n");


	}

});

}


public static System.Web.WebPages.HelperResult RunErrors()
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


 

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<div class=\"run-result run-service-error\">\r\n\t\t<div class=\"run-verdict label-warn" +
"ing\">Ошибка сервера :(</div>\r\n\t\t<pre class=\"no-rounds\"><code class=\"run-details\"" +
"></code></pre>\r\n\t</div>\r\n");




WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<div class=\"run-result run-compile-error\">\r\n\t\t<div class=\"run-verdict label-dang" +
"er\">Ошибка компиляции</div>\r\n\t\t<pre class=\"no-rounds\"><code class=\"run-details\">" +
"</code></pre>\r\n\t</div>\r\n");




WebViewPage.WriteLiteralTo(@__razor_helper_writer, @"	<div class=""run-result run-style-error"">
		<div class=""run-verdict label-danger"">Нарушение стилевых требований</div>
		<pre class=""no-rounds""><code class=""run-details""></code></pre>
		<div>
			<small>В некоторых ситуациях стилевые проверки тут могут быть жестче, чем необходимо в реальной жизни.</small>
		</div>
	</div>
");




WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<div class=\"run-result run-wa\">\r\n\t\t<div class=\"run-verdict label-danger\">Неверны" +
"й результат</div>\r\n\t\t<div class=\"diff-table tablesorter\"></div>\r\n\t</div>\r\n");




WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<div class=\"run-result run-wa-no-diff\">\r\n\t\t<div class=\"run-verdict label-danger\"" +
">Неверный результат</div>\r\n\t\t<pre class=\"no-rounds\"><code class=\"run-details\"></" +
"code></pre>\r\n\t</div>\r\n");




WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<div class=\"run-result run-success\">\r\n\t\t<div class=\"run-verdict label-success cl" +
"earfix\">Успех!</div>\r\n\t\t<pre class=\"no-rounds\"><code class=\"run-details\"></code>" +
"</pre>\r\n\t</div>\r\n");



});

}


public static System.Web.WebPages.HelperResult YouWillLoseScoresDialog(ExerciseBlockData data)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


 

WebViewPage.WriteLiteralTo(@__razor_helper_writer, @"	<div class=""modal fade"" id=""ShowSolutionsAlert"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel"" aria-hidden=""true"">
		<div class=""modal-dialog"">
			<div class=""modal-content"">
				<div class=""modal-header"">
					<button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
						<span aria-hidden=""true"">&times;</span>
					</button>
					<h4 class=""modal-title"">Внимание</h4>
				</div>
				<div class=""modal-body"">
					<p>Вы потеряете возможность получить баллы за эту задачу, если продолжите.</p>
				</div>
				<div class=""modal-footer"">
					<a class=""btn btn-default"" href=""");


WebViewPage.WriteTo(@__razor_helper_writer, data.AcceptedSolutionUrl);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">Продолжить</a>\r\n\t\t\t\t\t<button type=\"button\" class=\"btn btn-primary\" data-dismiss" +
"=\"modal\">Отмена</button>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t</div>\r\n");



});

}


	private static string GetGuestOnclick(bool isGuest)
	{
		return isGuest ? "onclick=loginForContinue()" : "";
	}

	private static string GetGuestDisable(bool isGuest)
	{
		return isGuest ? "disabled" : null;
	}

    }
}
#pragma warning restore 1591
