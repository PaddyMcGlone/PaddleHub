using Machine.Specifications;
using PaddleHub.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PaddleHub.Unit_tests
{    
    #region ValidDate()
    
    public class When_I_call_Validate_with_a_null_value
    {
        static PaddleFormViewModel viewModel;        
        static Exception expectedException;

        Establish context = () =>
        {
            viewModel = new PaddleFormViewModel
            {
                Date = null,
                Time = null
            };            
        };

        Because of = () =>
            expectedException = Catch.Exception(() => viewModel.Validate(new ValidationContext(viewModel)));

        It should_return_argument_null_exception = () =>
            expectedException.ShouldBeOfExactType<ArgumentNullException>();
    }

    public class When_I_call_ValidDate_with_a_date_in_the_past
    {
        static PaddleFormViewModel viewModel;
        static List<ValidationResult> result;

        Establish context = () =>
        {
            viewModel = new PaddleFormViewModel
            {
                Date = DateTime.Today.AddYears(-2).ToString("d")
            };
        };

        Because of = () =>
            result = viewModel.Validate(new ValidationContext(viewModel)).ToList();

        It should_return_an_error_message = () =>
            result[0].ErrorMessage.ShouldEqual("Date must not be in the past");
    }

    public class When_I_call_ValidDate_with_an_invalid_datetime
    {
        static PaddleFormViewModel viewModel;
        static List<ValidationResult> result;

        Establish context = () =>
        {
            viewModel = new PaddleFormViewModel
            {
                Date = "fff"
            };
        };

        Because of = () =>
            result = viewModel.Validate(new ValidationContext(viewModel)).ToList();

        It should_return_an_error_message = () =>
            result[0].ErrorMessage.ShouldEqual("Invalid date format");
    }

    #endregion
}