var PaddleController = function() {
    var button;

    var init = function () {        
        $(".js-toggle-attend").click(toggleAttendance);
    };

    var toggleAttendance = function(e) {
            button = $(e.target);
        if (button.hasClass("btn-default")) 
            createAttendance();
        else 
            deleteAttendance();
        
    };    
   
    var process = function () {
        var text = button.text() == "Attending" ? "Add to calender" : "Attending";
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    }

    var error = function() {
        alert("Something went wrong");
    }

    return{
        init: init
    }

}();

var attendanceService = function (paddleId, process, error) {

    var createAttendance = function () {
        $.post("/api/attendances", { "PaddleId": paddleId })
            .done(process)
            .fail(error);
    }

    var deleteAttendance = function () {
        $.ajax({
                url: "/api/attendances/" + paddleId,
                method: "DELETE"
            })
            .done(process)
            .fail(error);
    }

    new {
        CreateAttendance: createAttendance,
        DeleteAttendance: deleteAttendance
};
}();