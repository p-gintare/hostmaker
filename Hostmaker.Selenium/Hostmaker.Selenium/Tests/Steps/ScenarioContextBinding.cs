using System;
using TechTalk.SpecFlow;

namespace Hostmaker.Selenium.Tests.Steps
{
    public class ScenarioContextBinding : TechTalk.SpecFlow.Steps
    {
        protected readonly ScenarioContext ScenarioContext;

        public ScenarioContextBinding(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException(nameof(scenarioContext));
            }

            ScenarioContext = scenarioContext;
        }
    }
}