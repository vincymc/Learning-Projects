var jsGigsController = function (attendanceService) {

    var button;
    var init = function initGigs() {

        $(".js-toggle-attendance").click(toggleAttendance);
    };

    var toggleAttendance = function (e) {

        button = $(e.target);

        var gigId = button.attr("data-gig-id");

        if (button.hasClass("btn-default"))
            attendanceService.createAttendance(gigId, done, fail);

        else
            attendanceService.deleteAttendance(gigId, done, fail);

    };

    var done = function () {
        var text = (button.text() == "Going") ? "Going?" : "Going";
        button.toggleClass("btn-info").toggleClass("btn-default");
    };
    var fail = function () {
        alert("something failed!");
    }

    return {
        init: init
    }
}(AttendanceService);

