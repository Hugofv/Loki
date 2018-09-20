import React, { Component } from 'react';
import { AppBar, Toolbar, Typography, Table, 
    TableBody, TableCell, TableHead, TableRow, 
    Paper, Dialog, Button, TextField, InputAdornment } from '@material-ui/core';
import { withStyles } from '@material-ui/core/styles';
import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPlusCircle, faPencilAlt, faTrashAlt, faSearch } from '@fortawesome/free-solid-svg-icons'
import Formulario from './form';
import { connect } from 'react-redux';
import { buscarClientes, excluirCliente } from './../../actions/cliente';
import './cliente.css';

library.add(faPlusCircle, faPencilAlt, faTrashAlt, faSearch);

const CustomTableCell = withStyles(theme => ({
    head: {
        backgroundColor: theme.palette.common.black,
        color: theme.palette.common.white,
    },
    body: {
        fontSize: 14,
    },
    }))(TableCell);

class Cliente extends Component {
    constructor(props) {
        super(props);
        this.state = {
            open: false,
            openDelete: false,
            cliente: {},
            clientesFilter: [],
            strFilter: ''
        }
        this.filterClientes = this.filterClientes.bind(this);
    }

    componentDidMount() {
        this.props.buscarClientes()
    }

    componentWillReceiveProps(props) {
        this.setState({
            clientesFilter: props.clientes
        })
    }

    handleClickOpen = cliente => {
        this.setState({
            open: true,
            cliente
        });
    };
    
    handleClose = value => {
        this.setState({ open: false });
    };

    filterClientes = nome => event => {
        let { clientes } = this.props;
        let regex = new RegExp(event.target.value, 'i');
        var resultado = clientes.filter(e => {
            return regex.test(e.nome)
        })

        this.setState({
            clientesFilter: resultado,
            [nome]: event.target.value
        });
    }

  render() {
    const { cliente, clientesFilter, strFilter } = this.state;

    return (
      <div className="App">
        <AppBar position="static" style={{ backgroundColor: '#009688' }}>
            <Toolbar>
            <Typography variant="title" color="inherit" style={{textAlign: 'center', width: '100%', fontSize: '2em', fontWeight: 'bold'}}>
                Cliente
            </Typography>
            </Toolbar>
        </AppBar>
    
        <div style={{margin: '3em 9em'}}>
            <Paper>
                <Toolbar style={{ display: 'flex', justifyContent: 'flex-end' }}>
                            <TextField fullWidth={true}
                                onChange={this.filterClientes('strFilter')}
                                value={strFilter}
                                id='search'
                                placeholder="Pesquisar"
                                margin="normal"
                                InputProps={{
                                    startAdornment: (
                                        <InputAdornment position="start">
                                            <FontAwesomeIcon icon='search' size='1x' />
                                        </InputAdornment>
                                    ),
                            }}/>
                    <div>
                        <FontAwesomeIcon onClick={() => this.handleClickOpen(null)} icon='plus-circle' size='4x' style={{ cursor: 'pointer' }} />
                    </div>
                </Toolbar>
                <Table style={{maxHeight: '20em', overflow: 'auto'}} >
                    <TableHead>
                    <TableRow>
                        <CustomTableCell>Nome</CustomTableCell>
                        <CustomTableCell>Tipo</CustomTableCell>
                        <CustomTableCell>CPF/CPNJ</CustomTableCell>
                        <CustomTableCell style={{width: '10%'}} >Ações</CustomTableCell>
                    </TableRow>
                    </TableHead>
                    <TableBody>
                        {
                            clientesFilter.map(e => {
                               return <TableRow key={e.id} className='cell'>
                                    <CustomTableCell component="th" scope="row"> {e.nome}</CustomTableCell>
                                    <CustomTableCell component="th" scope="row"> {e.pessoa_fisica ? 'Pessoa Fisíca' : 'Pessoa Juridica'}</CustomTableCell>
                                    <CustomTableCell>{e.pessoa_fisica ? e.pessoa_fisica.cpf : e.pessoa_juridica ? e.pessoa_juridica.cnpj : ''}</CustomTableCell>
                                    <CustomTableCell>
                                        <div className='action'>
                                            <FontAwesomeIcon onClick={() => this.handleClickOpen(e)} icon='pencil-alt' size='2x' style={{ cursor: 'pointer' }} />
                                            <FontAwesomeIcon onClick={() => this.setState({openDelete: true, cliente: e})} icon='trash-alt'
                                                             size='2x' style={{ cursor: 'pointer' }} />
                                        </div>
                                    </CustomTableCell>
                                </TableRow>
                            })
                        }
                    </TableBody>
                </Table>
            </Paper>
        </div>
        
        <Formulario open={this.state.open} onClose={this.handleClose} cliente={cliente}/>
        <Delete open={this.state.openDelete} cliente={cliente} onDelete={this.props.excluirCliente} onClose={() => this.setState({openDelete: false})}/>
      </div>
    );
  }
}

class Delete extends Component {
    render() {
        let { cliente } = this.props;
        return(
            <Dialog onClose={this.props.onClose} open={this.props.open} aria-labelledby="simple-dialog-title">
                <div style={{padding: '2em', paddingBottom: 0, display: 'flex', alignItems: 'center', flexDirection: 'column'}}>
                    <h4 style={{fontWeight: 'bold'}} >Deseja realmente excluir este cliente ?</h4>
                    {this.props.cliente ? this.props.cliente.nome : ''}

                    <div style={{display: 'flex', width: '100%', justifyContent: 'flex-end', margin: '1em'}}>
                        <Button onClick={() => {this.props.onDelete(cliente.uuid); this.props.onClose()}} variant="contained" color="primary">
                            Sim
                        </Button>

                        <Button style={{marginLeft: '1em'}} onClick={this.props.onClose} variant="contained">
                            Não
                        </Button>
                    </div>
                </div>
            </Dialog>
        )
    }
}

function mapStateToProps(state) {
    return {
        clientes: state.cliente.clientes
    }
}

export default connect(mapStateToProps, { buscarClientes, excluirCliente })(Cliente);