var UserController = function(followService) {
    var button;

    var process = function() {
        var text = button.text() == "Follow" ? "Following" : "Follow";
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    }

    var error = function() {
        alert("Something went wrong");
    }

    var toggleFollow = function (e) {
        button = $(e.target);
        var userId = button.attr("data-id");

        if (button.hasClass("btn-default"))
            followService.CreateFollower(userId, process, error);
        else
            followService.DeleteFollower(userId, process, error);            
    };

    var init = function(container) {
        $(container).on("click", ".js-toggle-follow", toggleFollow);
    };

    return {
        init: init
    }

}(FollowService);