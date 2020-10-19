using OpenQA.Selenium;
using ValtechQaExercise.Pages.Base;

namespace ValtechQaExercise.Pages.Common
{
    public class Menu : BasePage
    {
        // TODO Handle other display languages when looking for menu items. Menu items do no have an Id or Name.

        private By MenuIconLocator => By.CssSelector("button.icon-menu");
        private By MenuPanelLocator => By.CssSelector(".site-nav__menu");
        private By PartnersMenuItemLocator => By.XPath(".//button[contains(text(),'Partners')]");
        private By OurPartnersLinksLocator => By.CssSelector("a[data-om-navcta='Partners']");

        public IWebElement MenuIcon => _driver.FindElement(MenuIconLocator);
        public IWebElement MenuPanel => _driver.FindElement(MenuPanelLocator);
        public IWebElement PartnersMenuItem => MenuPanel.FindElement(PartnersMenuItemLocator);
        public IWebElement OurPartnersFirstLink => _driver.FindElements(OurPartnersLinksLocator)[0];
        
        public Menu(IWebDriver driver)
            : base(driver)
        {
        }

        public void OpenMenuPanel()
        {
            if (ElementIsVisible(MenuPanel)) return;

            MenuIcon.Click();
            WaitForElementToBeVisible(MenuPanelLocator);
        }

        public void NavigateToOurPartnersPage()
        {
            OpenMenuPanel();
            PartnersMenuItem.Click();
            OurPartnersFirstLink.Click();
        }
    }
}
