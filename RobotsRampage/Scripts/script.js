var robotsRampageHub;



$(document).ready(function () {
    // Trigger action when the contexmenu is about to be shown
    //$(document).bind("contextmenu", function (event) {
    //    // Avoid the real one
    //    event.preventDefault();
    //    // Show contextmenu
    //    $(".menuWrapper").toggle(100).
    //    // In the right position (the mouse)
    //    css({
    //        top: event.pageY + "px",
    //        left: event.pageX + "px"
    //    });
    //});

    //// If the document is clicked somewhere
    //$(document).bind("mousedown", function (e) {
    //    $(".menuWrapper").hide(100);
    //});

    //$(".menu li").click(function (event) {
    //    // This is the triggered action name
    //    switch ($(this).attr("data-action")) {
    //        case "rampage":
    //            robotsRampageHub.server.rampage(event.pageX, event.pageY);
    //            break;
    //    }
    //});

    $.contextMenu({
        // define which elements trigger this menu
        selector: "#map",
        // define the elements of the menu
        items: {
            rampage: {
                name: "RAMPAGEEE",
                callback: function(key, opt) {
                    robotsRampageHub.server.rampage(event.pageX, event.pageY);
                }
            },
            robot: {
                name: "MORE ROBOTTTSSS",
                callback: function(key, opt) {
                    robotsRampageHub.server.robot(event.pageX, event.pageY);
                }
            }
        }
    });

    robotsRampageHub = $.connection.robotsRampageHub;
    robotsRampageHub.client.setRobots = function (robots) {
        $("#map").html("");
        for (var i = 0; i < robots.length; i++) {
            var robot = robots[i];
            var robotDiv = $('<div></div>')
                .addClass("robot")
                .css("top", robot.Y)
                .css("left", robot.X)
                .css("background-color", robot.Client.WebColor);
            $("#map").append(robotDiv);
        }
    };
    $.connection.hub.logging = true;

    // Start the connection
    $.connection.hub.start().done(function () {
        console.log('SignalR connected as ID: ' + $.connection.hub.id);
        robotsRampageHub.server.addClient();
    });
});