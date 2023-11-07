import React, {useEffect, useState} from 'react';
import {homeService} from "../services/home.service";

const Home = () => {
    const [infhome, setInfhome] = useState('')
   homeService.getHome().then(value=>setInfhome(value))
    return (
        <div>
            {infhome}
        </div>
    );
};

export default Home;