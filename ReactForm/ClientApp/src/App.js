import React from 'react';
import Form from "./components/Form";
import {Layout} from "./components/Layout";
import {Routes, Route, Link} from "react-router-dom"
import AppRoutes from "./AppRoutes";

const App = () => {
    return (
        <Layout>
            <Routes>
                {AppRoutes.map((route, index) => {
                    const { element, ...rest } = route;
                    return <Route key={index} {...rest} element={element} />;
                })}
            </Routes>
        </Layout>



    );
};

export default App;