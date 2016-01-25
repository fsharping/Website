var maps = {
    
    initMap : function(id, lat, lon) {
        var mapDiv = document.getElementById(id);
        var position = { lat: lat, lng: lon };
        var map = new google.maps.Map(mapDiv, {
            center: position,
            zoom: 17
        });
        var marker = new google.maps.Marker({
            position: position,
            map: map
        });
    },
    
    init: function() {
        $(".map").each(function (k, v) {
            var id = $(v).attr("id");
            var lat = $(v).data("lat");
            var lon = $(v).data("lon");
            maps.initMap(id, lat, lon);
        });
    }
};