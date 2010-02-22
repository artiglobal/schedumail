using System.Web.Mvc;

using NUnit.Framework;
using ScheduMail.WebMvc2.HtmlHelpers;

namespace ScheduMail.WebMvc2Test
{
    /// <summary>
    /// Paging Helper tests.
    /// </summary>
    [TestFixture]
    public class PagingHelperTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagingHelperTests"/> class.
        /// </summary>
        public PagingHelperTests()
        {
        }
      
        #region Additional test attributes        
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }        
        #endregion

        /// <summary>
        /// Pages the links_ method_ extends_ HTML helper.
        /// </summary>
        [Test]
        public void PageLinks_Method_Extends_HtmlHelper()
        {
            HtmlHelper html = null;
            html.PageLinks(0, 0, null);
        }

        /// <summary>
        /// Pages the links_ produces_ anchor_ tags.
        /// </summary>
        [Test]
        public void PageLinks_Produces_Anchor_Tags()
        {
            // First parameter will be current page index
            // Second will be total number of pages
            // Third will be lambda method to map a page number to its URL
            string links = ((HtmlHelper)null).PageLinks(2, 3, i => "Page" + i);

            // This is how the tags should be formatted
            Assert.AreEqual(
                @"<a href=""Page1"">1</a>
<a class=""selected"" href=""Page2"">2</a>
<a href=""Page3"">3</a>
", links);
        }
    }
}

