﻿var robotsRampageHub;



$(document).ready(function () {
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
    robotsRampageHub.client.setRobots = function (clients) {
        $("#map").html("");
        for (var i = 0; i < clients.length; i++) {
            var client = clients[i];
            for (var j = 0; j < client.Robots.length; j++) {
                var robot = client.Robots[j];
                var robotDiv = $('<div></div>')
                    .addClass("robot")
                    .css("top", robot.Y)
                    .css("left", robot.X)
                    .css("background-color", client.WebColor);
                $("#map").append(robotDiv);
            }
        }
    };
    $.connection.hub.logging = true;

    // Start the connection
    $.connection.hub.start().done(function () {
        console.log('SignalR connected as ID: ' + $.connection.hub.id);
        robotsRampageHub.server.addClient();
    });
});