
namespace ThoughtWorks.CruiseControl.WebDashboard.Dashboard
{
	public interface IUrlBuilder
	{
		string BuildUrl(string relativeUrl);
		string BuildUrl(string relativeUrl, string partialQueryString);
		string BuildServerUrl(string relativeUrl, string serverName);
		string BuildProjectrUrl(string relativeUrl, string serverName, string projectName);
	}
}
