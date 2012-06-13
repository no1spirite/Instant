/// <reference path="~/Scripts/amplify-vsdoc.js"/>

var Resources = function() {
    amplify.request.decoders.appEnvelope =
        function (data, status, xhr, success, error) {
            switch (status) {
                case "success":
                    success(data, xhr);
                    break;
                default:
                    error(xhr.status);
                    break;
            }
    };

    // GETS

    amplify.request.define("getEvents", "ajax", {
        url: "/events",
        dataType: "json",
        type: "GET",
        decoder: "appEnvelope"
    });
    
    // POSTS
    
    amplify.request.define("createEvent", "ajax", {
        url: "/events",
        dataType: "json",
        type: "POST",
        decoder: "appEnvelope"
    });
};