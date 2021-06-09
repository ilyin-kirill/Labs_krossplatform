import React from 'react';
import Navibar from './Components/Navibar';
import {Home} from './Components/Home';
import Footer from './Components/Footer';
import Login from "./Components/Login";
import {Users} from "./Components/Users";
import {AddUser} from "./Components/AddUser";
import {Rides} from "./Components/Rides";
import 'bootstrap/dist/css/bootstrap.min.css';

import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from 'react-router-dom';


function App() {
  return (
    <>
    <Router>
    <Navibar />
    <Switch>
      <Route exact path ="/" component={Home}/>
      <Route path ="/login" component={Login}/>
      <Route path ="/users" component={Users}/>
      <Route path ="/adduser" component={AddUser}/>
      <Route path ="/rides" component={Rides}/>
    </Switch>
    </Router>
    <Footer />
    </>
  );
}

export default App;
 