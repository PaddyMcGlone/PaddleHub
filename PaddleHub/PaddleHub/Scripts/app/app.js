function initPaddle() {
    $(".js-toggle-attend").click(function(e) {
        var button = $(e.target);
        if (button.hasClass("btn-default")) {
            $.post("/api/attendances", { "PaddleId": button.attr("data-id") })
                .done(function() {
                    button
                        .removeClass("btn-default")
                        .addClass("btn-info")
                        .text("Attending");
                })
                .fail(function() {
                    alert("Something went wrong");
                });
        } else {
            $.ajax({
                    url: "/api/attendances/" + button.attr("data-id"),
                    method: "DELETE"
                })
                .done(function() {
                    button
                        .removeClass("btn-info")
                        .addClass("btn-default")
                        .text("Add to calender");
                })
                .fail(function() {
                    alert("Something went wrong");
                });
        }
    });
}