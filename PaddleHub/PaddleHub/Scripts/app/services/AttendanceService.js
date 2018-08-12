var AttendanceService = function (paddleId, process, error) {

    var createAttendance = function() {
        $.post("/api/attendances", { "PaddleId": paddleId })
            .done(process)
            .fail(error);
    };

    var deleteAttendance = function() {
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