using Machine.Specifications;
using PaddleHub.Controllers;
using System.Web.Mvc;

namespace ClassLibrary1.Unit_tests.Controllers
{
    public class Context
    {
        public static HomeController controller;

        //Unable to properly test this Controller without interfaces

        public Context()
        {
            controller = new HomeController();
        }
    }

    #region .Index() tests

    class when_I_call_Index : Context
    {
        static ViewResult result;

        Establish context = () => 
            result = (ViewResult)controller.Index();

        It should_return_a_populated_model = () => 
            result.Model.ShouldNotBeNull();
    }

    #endregion
}
