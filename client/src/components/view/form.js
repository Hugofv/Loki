import React, {Component} from 'react'
import { Dialog, TextField, RadioGroup, Button, Input,
     Radio, FormControl, FormLabel, FormControlLabel, InputLabel } from '@material-ui/core';
import NumberFormat from 'react-number-format';
import {cadastrarCliente} from './../../actions/cliente';
import { connect } from 'react-redux';

function NumberFormatCustom(props) {
    const { inputRef, onChange, rows, ...other } = props;
    return (
      <NumberFormat
        {...other}
        getInputRef={inputRef}
        onValueChange={values => {
          onChange({
            target: {
              value: values.value,
            },
          });
        }}
        format={rows}
      />
    );
  }

class Form extends Component {
    constructor(props) {
        super(props);
        this.state = {
            tipo: 'F',
            nome: '',
            cpf: '',
            cnpj: '',
            dtNascimento: '',
            razaoSocial: ''
        }
        this.salvar = this.salvar.bind(this);
    }

    handleChange = name => event => {
        this.setState({
            [name]: event.target.value,
        });
    };

    handleClose = () => {
        this.props.onClose(this.props.selectedValue);
    };

    salvar() {
        let { nome, cpf, cnpj, dtNascimento, razaoSocial, tipo} = this.state;

        if(tipo == 'F' && !nome && !cpf && !dtNascimento) {
            return;
        } else if(tipo == 'J' && !nome && !cnpj && !razaoSocial) {
            return;
        } else {
            var data = {
                nome: nome,
                pessoa_fisica: tipo == 'F' ? {
                    cpf: cpf,
                    data_nascimento: dtNascimento,
                } : null,
                pessoa_juridica: tipo == 'J' ? {
                    cnpj: cnpj,
                    razao_social: razaoSocial
                } : null
            }

            this.props.cadastrarCliente(data);
            this.handleClose();
        }
    }

    render() {
        const { nome, cpf, cnpj, dtNascimento, razaoSocial, tipo } = this.state;
        console.log(cpf);
        return (
            <Dialog onClose={this.handleClose} open={this.props.open} aria-labelledby="simple-dialog-title">
                <div style={{padding: '2em', minWidth: '28em'}}>
                    <h3>Cadastro de Cliente</h3>
                    <div style={{display: 'flex', flexDirection: 'column'}} >
                        <TextField
                            id="standard-multiline-static"
                            label="Nome"
                            margin="normal"
                            helperText={nome == '' ? "Campo Obrigatório!" : ''}
                            error={nome == ''}
                            value={nome}
                            onChange={this.handleChange('nome')}
                            fullWidth={true}
                            />

                        <FormControl style={{marginTop: '2em'}} component="fieldset">
                            <FormLabel component="legend">Tipo</FormLabel>
                                <RadioGroup
                                    aria-label="Tipo"
                                    name="gender1"
                                    value={this.state.tipo}
                                    onChange={(event) => this.setState({tipo: event.target.value})}
                                >
                                <FormControlLabel value="F" control={<Radio />} label="Pessoa Fisíca" />
                                <FormControlLabel value="J" control={<Radio />} label="Pessoa Jurídica" />
                            </RadioGroup>
                        </FormControl>

                        {
                            this.state.tipo == 'F' ?
                            <div>
                                <TextField
                                    label="CPF"
                                    value={cpf}
                                    onChange={(event) => this.setState({cpf: event.target.value.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/g,"\$1.\$2.\$3\-\$4")})}
                                    id="cpf"
                                    helperText={cpf == '' ? "Campo Obrigatório!" : ''}
                                    error={cpf == ''}
                                    rows='###.###.###-##'
                                    InputProps={{
                                        inputComponent: NumberFormatCustom,
                                    }}
                                    />

                                <TextField
                                    id="standard-multiline-static"
                                    label="Data de Nascimento"
                                    margin="normal"
                                    type="date"
                                    value={dtNascimento}
                                    helperText={dtNascimento == '' ? "Campo Obrigatório!" : ''}
                                    onChange={this.handleChange('dtNascimento')}
                                    error={dtNascimento == ''}
                                    InputLabelProps={{
                                        shrink: true,
                                      }}
                                    fullWidth={true}
                                    />
                            </div>
                            :
                            <div>
                                <TextField
                                    label="CNPJ"
                                    value={cnpj}
                                    onChange={(event) => this.setState({cnpj: event.target.value.replace(/(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/g,"\$1.\$2.\$3\/\$4\-\$5")})}
                                    id="cnpj"
                                    rows='##.###.###/####-##'
                                    helperText={cnpj == '' ? "Campo Obrigatório!" : ''}
                                    error={cnpj == ''}
                                    InputProps={{
                                        inputComponent: NumberFormatCustom,
                                    }}
                                    />

                                <TextField
                                    label="Razão Social"
                                    margin="normal"
                                    helperText={razaoSocial == '' ? "Campo Obrigatório!" : ''}
                                    error={razaoSocial == ''}
                                    onChange={this.handleChange('razaoSocial')}
                                    value={razaoSocial}
                                    fullWidth={true}
                                    />
                            </div>
                        }
                    </div>

                    <div style={{display: 'flex', width: '100%', justifyContent: 'flex-end', marginTop: '1em'}}>
                        <Button onClick={this.salvar} variant="contained" color="primary">
                            Salvar
                        </Button>

                        <Button style={{marginLeft: '1em'}} onClick={this.handleClose} variant="contained">
                            Cancelar
                        </Button>
                    </div>
                </div>
            </Dialog>
        );
    }
  }

export default connect(null, { cadastrarCliente })(Form);