// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#search-events").on("click", function (e) {
    e.preventDefault();
    var url = "Events/EventsListing";
    
    var data = {
        Name: $('#Name').val(),
        CategoryId: $('#CategoryId').val()
    }

    $.post(url, data, function (events) {
        //document.getElementById("events-search-listing").appendChild(html);
        $("html").html(events);
    });
});