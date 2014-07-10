var robotsRampageHub;

$(document).ready(function () {

    //var worldHub = $.connection.worldHub;
    //worldHub.client.setWorld = function (world) {
    //    for (var x = 0; x < world.Cubes.length; x++) {
    //        var rowDiv = $('<div></div>')
    //            //.addClass("row")
    //            .css("height", 100 / world.Cubes.length + "%");
    //        $("#world").append(rowDiv);
    //        for (var y = 0; y < world.Cubes[x].length; y++) {
    //            var div = $('<div></div>')
    //                .addClass("cube")
    //                .attr("id", "cube-" + x + "-" + y)
    //                .css("background-color", world.Cubes[x][y][0].Color);

    //            rowDiv.append(div);
    //        }
    //    }

    //    var stylesheet = document.styleSheets[0];
    //    var selector = ".cube";
    //    var rule = "{width: " + 100 / world.Cubes.length + "%;" +
    //        "height: 100%}";
    //        //"height: " + 100 / world.Cubes[0].length + "%}";

    //    if (stylesheet.insertRule) {
    //        stylesheet.insertRule(selector + rule, stylesheet.cssRules.length);
    //    } else if (stylesheet.addRule) {
    //        stylesheet.addRule(selector, rule, -1);
    //    }
    //};

    robotsRampageHub = $.connection.robotsRampageHub;
    robotsRampageHub.client.setRobots = function(robots) {
        $("#map").html("");
        for (var i = 0; i < robots.length; i++) {
            var robot = robots[i];
            var robot = $('<div></div>')
                .addClass("robot")
                .css("top", robot.Y)
                .css("left", robot.X)
                .css("background-color", robot.Client.WebColor);
            $("#map").append(robot);
        }
    };
    $.connection.hub.logging = true;

    // Start the connection
    $.connection.hub.start().done(function () {
        console.log('SignalR connected as ID: ' + $.connection.hub.id);
        robotsRampageHub.server.addClient();
    });
});