var FollowService = function() {

    var createFollower = function(userId, process, error) {
        $.post("/api/following", { "FolloweeId": userId })
            .done(process)
            .fail(error);
    };

    var deleteFollower = function(userId, process, error) {
        $.ajax({
                url: "/api/following" + userId,
                method: "DELETE"
            })
            .done(process)
            .fail(error);
    }


    return {
        CreateFollower: createFollower,
        DeleteFollower: deleteFollower
}

}();