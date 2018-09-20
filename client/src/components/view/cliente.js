import React, { Component } from 'react';
import { AppBar, Toolbar, Typography, Table, 
    TableBody, TableCell, TableHead, TableRow, 
    Paper } from '@material-ui/core';
import { withStyles } from '@material-ui/core/styles';
import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPlusCircle } from '@fortawesome/free-solid-svg-icons'
import Formulario from './form';
import { connect } from 'react-redux';
import { buscarClientes } from './../../actions/cliente';

library.add(faPlusCircle);

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
            open: false
        }
    }

    componentDidMount() {
        this.props.buscarClientes()
    }

    handleClickOpen = () => {
        this.setState({
            open: true,
        });
    };
    
    handleClose = value => {
        this.setState({ selectedValue: value, open: false });
    };

  render() {
    const { clientes } = this.props;
    let EnhancedTableToolbar = () => {
        return (<Toolbar style={{ display: 'flex', justifyContent: 'flex-end' }}>
            <div>
                <FontAwesomeIcon onClick={this.handleClickOpen} icon='plus-circle' size='4x' style={{ cursor: 'pointer' }} />
            </div>
        </Toolbar>);
    };

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
                <EnhancedTableToolbar />
                <Table >
                    <TableHead>
                    <TableRow>
                        <CustomTableCell>Nome</CustomTableCell>
                        <CustomTableCell>CPF/CPNJ</CustomTableCell>
                        <CustomTableCell style={{width: '10%'}} >Ações</CustomTableCell>
                    </TableRow>
                    </TableHead>
                    <TableBody>
                        {
                            clientes.map(e => {
                               return <TableRow key={e.id}>
                                    <CustomTableCell component="th" scope="row"> {e.nome}</CustomTableCell>
                                    <CustomTableCell>{e.pessoa_fisica ? e.pessoa_fisica.cpf : e.pessoa_juridica ? e.pessoa_juridica.cnpj : ''}</CustomTableCell>
                                </TableRow>
                            })
                        }
                    </TableBody>
                </Table>
            </Paper>
        </div>
        
        <Formulario open={this.state.open} onClose={this.handleClose}/>
      </div>
    );
  }
}

function mapStateToProps(state) {
    return {
        clientes: state.cliente.clientes
    }
}

export default connect(mapStateToProps, { buscarClientes })(Cliente);