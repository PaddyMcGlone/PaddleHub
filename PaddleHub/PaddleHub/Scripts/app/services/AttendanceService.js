var AttendanceService = function () {

    var createAttendance = function (paddleId, process, error) {
        $.post("/api/attendances", { "PaddleId": paddleId })
            .done(process)
            .fail(error);
    };

    var deleteAttendance = function (paddleId, process, error) {
        $.ajax({
            url: "/api/attendances/" + paddleId,
                method: "DELETE"
            })
            .done(process)
            .fail(error);
    };

    return {
        CreateAttendance: createAttendance,
        DeleteAttendance: deleteAttendance
    };
}();