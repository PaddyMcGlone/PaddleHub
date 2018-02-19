using Machine.Specifications;
using PaddleHub.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ClassLibrary1.Unit_tests.Models
{    
    #region ValidDate()      

    [Subject("Validate time")]
    public class When_I_call_Validate_with_a_date_in_the_past
    {
        static PaddleFormViewModel viewModel;
        static List<ValidationResult> result;

        Establish context = () =>
        {
            viewModel = new PaddleFormViewModel
            {
                Date = DateTime.Today.AddYears(-2).ToString("d"),
                Time = "11:00"
            };
        };

        Because of = () =>
            result = viewModel.Validate(new ValidationContext(viewModel)).ToList();

        It should_return_an_error_message = () =>
            result[0].ErrorMessage.ShouldEqual("Date must not be in the past");
    }

    [Subject("Validate time")]
    public class When_I_call_Validate_with_an_invalid_date
    {
        static PaddleFormViewModel viewModel;
        static List<ValidationResult> result;

        Establish context = () =>
        {
            viewModel = new PaddleFormViewModel
            {
                Date = "fff",
                Time = "11:00"
            };
        };

        Because of = () =>
            result = viewModel.Validate(new ValidationContext(viewModel)).ToList();

        It should_return_an_error_message = () =>
            result[0].ErrorMessage.ShouldEqual("Invalid date format, please retry");
    }

    [Subject("Validate date")]
    public class When_I_call_Validate_with_a_valid_date
    {
        static PaddleFormViewModel viewModel;
        static List<ValidationResult> result;

        Establish context = () =>
        {
            viewModel = new PaddleFormViewModel
            {
                Date = DateTime.Today.AddDays(5).ToString("d"),
                Time = "11:00"
            };
        };

        Because of = () =>
           result = viewModel.Validate(new ValidationContext(viewModel)).ToList();

        It should_not_return_any_validation_errors = () =>
            result.ShouldBeEmpty();
    }

    #endregion

    #region ValidTime()

    [Subject("Validate time")]
    public class When_I_call_Validate_with_an_invalid_time
    {
        static PaddleFormViewModel viewModel;
        static List<ValidationResult> result;

        Establish context = () =>
        {
            viewModel = new PaddleFormViewModel
            {
                Date = DateTime.Today.ToString("d"),
                Time = "fff"
            };
        };

        Because of = () =>
            result = viewModel.Validate(new ValidationContext(viewModel)).ToList();

        It Should_return_a_validation_error = () =>
            result[0].ErrorMessage.ShouldEqual("Invalid time format, please retry");
    }

    //[Subject("Validate time")]
    //public class When_I_call_Validate_with_time_between_hours_of_darkness
    //{
    //    static PaddleFormViewModel viewModel;
    //    static List<ValidationResult> results;

    //    Establish context = () =>
    //    {
    //        viewModel = new PaddleFormViewModel
    //        {
    //            Date = DateTime.Today.ToString("d"),
    //            Time = "22:00"
    //        };
    //    };

    //    Because of = () =>
    //        viewModel.Validate(new ValidationContext(viewModel)).ToList();

    //    It Should_return_invalid_start_time_error_message = () =>
    //        results[0].ErrorMessage.ShouldEqual("You cant paddle in the dark!");
    //}

    [Subject("Validate time")]
    public class When_I_call_Validate_with_a_valid_time
    {
        static PaddleFormViewModel viewModel;
        static List<ValidationResult> results;

        Establish context = () =>
        {
            viewModel = new PaddleFormViewModel
            {
                Date = DateTime.Today.ToString("d"),
                Time = "10:00"
            };
        };

        Because of = () =>
            results = viewModel.Validate(new ValidationContext(viewModel)).ToList();

        It Should_not_return_any_validation_errors = () =>
            results.ShouldBeEmpty();
    }
    
    [Subject("Validate time")]
    public class when_I_call_Validate_with_an_invalid_time
    {
        static PaddleFormViewModel viewModel;
        static List<ValidationResult> results;

        Establish context = () =>
        {
            viewModel = new PaddleFormViewModel
            {
                Date = DateTime.Today.ToString("d"),
                Time = "foo"
            };
        };

        Because of = () =>
            results = viewModel.Validate(new ValidationContext(viewModel)).ToList();

        It should_return_a_validation_error_for_time = () =>
            results[0].ErrorMessage.ShouldEqual("Invalid time format, please retry");
    }

    #endregion
}