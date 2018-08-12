var PaddleController = function (attendanceService) {
    var button;

    var init = function () {
        $(".js-toggle-attend").click(toggleAttendance);
    };

    var toggleAttendance = function (e) {
        button = $(e.target);

        var paddleId = button.attr("data-id");

        if (button.hasClass("btn-default"))
            attendanceService.CreateAttendance(paddleId, process, error);
        else
            attendanceService.DeleteAttendance(paddleId, process, error);
    };

    var process = function () {
        var text = button.text() == "Attending" ? "Add to calender" : "Attending";
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    }

    var error = function () {
        alert("Something went wrong");
    }

    return {
        init: init
    }

}(AttendanceService);