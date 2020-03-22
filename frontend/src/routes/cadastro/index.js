import React from 'react';
import { Route } from 'react-router-dom';
import Usuario from './routes/usuario';
import Aposta from './routes/aposta';
import Relatorio from './routes/relatorio';

const CardComponents = ({ match }) => (
    <div>
      <Route path={`${match.url}/usuario`} component={Usuario}/>
      <Route path={`${match.url}/aposta`} component={Aposta}/>
      <Route path={`${match.url}/relatorio`} component={Relatorio}/>
    </div>
    
  )
  
  export default CardComponents;
  