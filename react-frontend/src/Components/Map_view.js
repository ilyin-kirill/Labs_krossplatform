import React from 'react'
import { Container } from 'react-bootstrap';
import { YMaps, Map, SearchControl, GeolocationControl } from 'react-yandex-maps'

function Map_view(){
    return(
    <div style={{paddingTop:"2rem"}}>
    <YMaps>
        <Map width='100%' height='500px'
          defaultState={{
            center: [55.751574, 37.573856],
            zoom: 9,
            controls: [],
          }}
        >
          <GeolocationControl options={{ float: 'left' }} />
          <SearchControl options={{ float: 'right' }} />
        </Map>
    </YMaps>
    </div>
    );
}
export default Map_view