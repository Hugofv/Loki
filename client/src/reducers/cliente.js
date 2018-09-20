import types from '../actions/types';

const initialState = {
  fetchFinish: false,
  isFetching: false,
  hasError: false,
  errorMessage: '',
  clientes: [],
};

export default (state = initialState, action) => {
  switch (action.type) {
    case types.BUSCAR_CLIENTE: {
      const { clientes } = action;
      return {
        ...state,
        fetchFinish: true,
        loggedIn: true,
        clientes,
      };
    }
    case types.ATUALIZAR_CLIENTE: {
      return {
        ...state,
        isFetching: true,
      };
    }
    case types.CADASTRAR_CLIENTE: {
      return {
        ...initialState,
      };
    }
    case types.LOGOUT_ERROR: {
      const { error } = action;
      return {
        ...state,
        isFetching: false,
        loggedIn: true,
        hasError: true,
        errorMessage: error,
      };
    }
    default: {
      return state;
    }
  }
};