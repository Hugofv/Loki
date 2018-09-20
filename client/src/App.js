import React from 'react'
import { BrowserRouter as Router, Route } from 'react-router-dom'
import Cliente from './components/view/cliente';
import { Provider } from "react-redux";
import configureStore from './store';

const store = configureStore();
const App = () => (
  <Provider store={store}>
    <Router>
      <div>
        <Route exact path="/" component={Cliente}/>
      </div>
    </Router>
  </Provider>
)
export default App