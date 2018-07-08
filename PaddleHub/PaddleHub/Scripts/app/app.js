var PaddleController = function() {
    
    var init = function () {        
        $(".js-toggle-attend").click(toggleAttendance);
    };

    var toggleAttendance = function(e) {
            var button = $(e.target);
            if (button.hasClass("btn-default")) {
                $.post("/api/attendances", { "PaddleId": button.attr("data-id") })
                    .done(process)
                    .fail(error);
            } else {
                $.ajax({
                        url: "/api/attendances/" + button.attr("data-id"),
                        method: "DELETE"
                    })
                    .done(process)
                    .fail(error);
            }
    };
   
    var process = function () {
        var text = button.text == "Attending" ? "Add to calender" : "Attending";
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    }

    var error = function() {
        alert("Something went wrong");
    }

    return{
        init: init
    }

}();