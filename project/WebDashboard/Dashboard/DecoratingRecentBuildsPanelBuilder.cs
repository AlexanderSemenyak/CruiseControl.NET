using System.Web.UI.HtmlControls;
using ThoughtWorks.CruiseControl.WebDashboard.MVC.View;
using ThoughtWorks.CruiseControl.WebDashboard.Plugins.ViewAllBuilds;

namespace ThoughtWorks.CruiseControl.WebDashboard.Dashboard
{
	public class DecoratingRecentBuildsPanelBuilder : HtmlBuilderViewBuilder, IRecentBuildsViewBuilder
	{
		private readonly IUrlBuilder urlBuilder;
		private readonly IRecentBuildsViewBuilder builderToDecorate;

		public DecoratingRecentBuildsPanelBuilder(IHtmlBuilder htmlBuilder, IUrlBuilder urlBuilder, IRecentBuildsViewBuilder builderToDecorate) : base(htmlBuilder)
		{
			this.builderToDecorate = builderToDecorate;
			this.urlBuilder = urlBuilder;
		}

		public HtmlTable BuildRecentBuildsTable(IProjectSpecifier projectSpecifier)
		{
			HtmlTable subTable = builderToDecorate.BuildRecentBuildsTable(projectSpecifier);
			subTable.Attributes.Add("class", "RecentBuildsPanel");
			subTable.Align = "center";
			subTable.Width = "100%";
			subTable.CellSpacing = 0;

			HtmlTableCell headerCell = new HtmlTableCell("th");
			headerCell.InnerHtml = "Recent Builds";
			subTable.Rows.Insert(0, TR(headerCell));
			subTable.Rows.Add(TR(TD()));
			subTable.Rows.Add(TR(
				TD(A("Show All", 
				     urlBuilder.BuildProjectUrl(new ActionSpecifierWithName(ViewAllBuildsAction.ACTION_NAME), projectSpecifier)))));
			return subTable;
		}
	}
}
