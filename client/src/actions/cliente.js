import types from './types';
import endPoint from './../constantes/constants';

export const buscarClientes = () => (dispatch) => {
  try {
    fetch(endPoint.CLIENTE, {
      method: 'get',
      headers: {
        'Content-Type': 'application/json'
      }
    })
    .then(response => {
      if(response.status == 200) {
        return response.json()
      }
    })
    .then(clientes => {
      dispatch(dispatchCliente(clientes))
    })
    
  } catch (error) {
    console.log(error);
  }
};

export const cadastrarCliente = (data) => (dispatch) => {
  try {
    fetch(endPoint.CLIENTE, {
      method: 'post',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(data)
    })
    .then(response => {
      if(response.status == 201) {
        dispatch(buscarClientes());
      }
    })
  } catch (error) {
    console.log(error);
  }
}

export const atualizarCliente = (data, uuid) => (dispatch) => {
  try {
    fetch(endPoint.CLIENTE + '/' + uuid, {
      method: 'put',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(data)
    })
    .then(response => {
      if(response.status == 200) {
        dispatch(buscarClientes());
      }
    })
  } catch (error) {
    console.log(error);
  }
}

export const excluirCliente = uuid => dispatch => {
  try {
    fetch(endPoint.CLIENTE + '/' + uuid, {
      method: 'delete',
      headers: {
        'Content-Type': 'application/json'
      }
    })
    .then(response => {
      if(response.status == 200) {
        dispatch(buscarClientes());
      }
    })
  } catch (error) {
    console.log(error);
  }
}

const dispatchCliente = clientes => ({
  type: types.BUSCAR_CLIENTE,
  clientes
});
