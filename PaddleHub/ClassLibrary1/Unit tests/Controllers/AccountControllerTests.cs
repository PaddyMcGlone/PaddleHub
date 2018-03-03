using PaddleHub.Controllers;

namespace PaddleHubTests.Unit_tests.Controllers
{
    class AccountControllerTests
    {
        class Context
        {            
            public static AccountController controller;            

            public Context()
            {
                controller = new AccountController();
            }            
        }

        #region .Register(RegisterViewModel model) tests

        class when_I_post_Register : Context
        {
            // Add NSubstitue to verify that UserManafer.CreateASync is called

        }

        class when_I_post_Register_with_model_state_errors : Context
        {
            // Model state is invald

            // It returns the register view
        }

        #endregion

    }
}
