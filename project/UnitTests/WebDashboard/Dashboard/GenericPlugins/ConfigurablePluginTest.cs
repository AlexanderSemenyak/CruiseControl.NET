using Moq;
using NUnit.Framework;
using ThoughtWorks.CruiseControl.WebDashboard.Dashboard;
using ThoughtWorks.CruiseControl.WebDashboard.Dashboard.GenericPlugins;

namespace ThoughtWorks.CruiseControl.UnitTests.WebDashboard.Dashboard.GenericPlugins
{
	[TestFixture]
	public class ConfigurablePluginTest
	{
		[Test]
		public void ShouldUseConfigurableProperties()
		{
			var actionMock = new Mock<INamedAction>();
			INamedAction action = (INamedAction) actionMock.Object;

			ConfigurablePlugin plugin = new ConfigurablePlugin();
			plugin.LinkDescription = "My Plugin";
			plugin.NamedActions = new INamedAction[] { action };

			Assert.AreEqual("My Plugin", plugin.LinkDescription);
			Assert.AreEqual(1, plugin.NamedActions.Length);
			Assert.AreEqual(action, plugin.NamedActions[0]);
		}
	}
}
