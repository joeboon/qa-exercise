using OpenQA.Selenium;
using ValtechQaExercise.Pages.Base;

namespace ValtechQaExercise.Pages.Common
{
    public class Footer : BasePage
    {
        public IWebElement FooterPanel => _driver.FindElement(By.TagName("footer"));


        public Footer(IWebDriver driver)
            : base(driver)
        {
        }

        // TODO Use element titles instead of text once the footer HTML is fixed.
        // Invalid HTML in the footer creates an incomplete title that has an 
        // extra double-quote:
        //     "United
        // The title is also ambiguous because United States and United Kingdom
        // both present to Selenium as "\"United".
        // Thi means the footer hyperlink element contains two incorrect attributes:
        //     title="&quot;United" kingdom&quot;=""
        // There are other problems - the target attribute is called "targer" 
        // (with an r at the end), and contains unnecessary quotes.

        public IWebElement UnitedKingdomLink => FooterPanel.FindElement(By.LinkText("United Kingdom"));

    }
}
