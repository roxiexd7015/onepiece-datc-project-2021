var options = {
    enableHighAccuracy: true,
    timeout: 1000,
    maximumAge: 0
};

/*function success(pos) {
    var crd = pos.coords;

    console.log(pos);
    console.log('Your current position is:');
    console.log(`Latitude : ${crd.latitude}`);
    console.log(`Longitude: ${crd.longitude}`);
    console.log(`More or less ${crd.accuracy} meters.`);

    map.flyTo({
        center: [crd.latitude, crd.longitude],
        zoom: 16,
        duration: 1
    });
}

function error(err) {
    console.warn(`ERROR(${err.code}): ${err.message}`);
}*/

var result;

let mapPositionToResult = (position, result) => {
    result.position = [position.coords.longitude, position.coords.latitude];
};

let mapErrorToResult = (error, result) => {
    result.error = {
        code: error.code,
        message: error.message
    }
};

let getCurrentPosition = async (options) => {
    result = { position: null, error: null };
    var getCurrentPositionPromise = new Promise((resolve, reject) => {
        if (!navigator.geolocation) {
            reject({ code: 0, message: 'This device does not support geolocation.' });
        } else {
            navigator.geolocation.getCurrentPosition(resolve, reject, options);
        }
    });
    await getCurrentPositionPromise.then(
        (position) => { mapPositionToResult(position, result) }
    ).catch(
        (error) => { mapErrorToResult(error, result) }
    );
    return result;
};

window.createMap = async (id /*string*/) => {

    let position = await getCurrentPosition(options);

    mapboxgl.accessToken = "pk.eyJ1IjoiZGFuaWVsMWhvcnQiLCJhIjoiY2t4a3dpNml2MHlhdTJxcWtnZjVjMWQ1MyJ9.5rn3CXbkf7xE5dfI4tmmww";
    let map = new mapboxgl.Map({
        container: id,
        style: 'mapbox://styles/mapbox/streets-v11',
        center: position.position,
        zoom: 13
    });
}

