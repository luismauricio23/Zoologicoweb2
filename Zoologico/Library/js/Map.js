function iniciarMap() {
    var coord = { lat: 4.8187205, lng: -75.826498 };
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 10,
        center: coord
    });
    var marker = new google.maps.Marker({
        position: coord,
        map: map
    });
}