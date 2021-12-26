var defaultOptions = {
    enableHighAccuracy: true,
    timeout: 1000,
    maximumAge: 0
};

let getCurrentPosition = async (options) => {
    if (!options)
        options = defaultOptions;
    var result = { position: null, error: null };
    var getCurrentPositionPromise = new Promise((resolve, reject) => {
        if (!navigator.geolocation) {
            reject({ code: 0, message: 'This device does not support geolocation.' });
        } else {
            navigator.geolocation.getCurrentPosition(resolve, reject, options);
        }
    });
    await getCurrentPositionPromise.then(
        (position) => result.position = [position.coords.longitude, position.coords.latitude]
    ).catch(
        (error) => result.error = {
            code: error.code,
            message: error.message
        }
    );
    return result;
};

window.createMap = async (id /*string*/) => {

    let position = await getCurrentPosition();

    mapboxgl.accessToken = "pk.eyJ1IjoiZGFuaWVsMWhvcnQiLCJhIjoiY2t4a3dpNml2MHlhdTJxcWtnZjVjMWQ1MyJ9.5rn3CXbkf7xE5dfI4tmmww";
    let map = new mapboxgl.Map({
        container: id,
        style: 'mapbox://styles/mapbox/streets-v11',
        center: position.position,
        zoom: 13
    });
}

