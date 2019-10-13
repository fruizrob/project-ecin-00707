import React, { Component } from 'react';
import MaterialTable from 'material-table';
import './SectorDetail.css';

export default class SectorDetail extends Component {

    constructor(props) {
        super(props);
        this.state = {
            columns: [
                { title: 'Nombre', field: 'name' },
                { title: 'Edad', field: 'years', type: 'numeric' },
                { title: 'Diagnostico', field: 'diagnosis' },
                { title: 'Cuenta corriente', field: 'currentAccount' },
                { title: 'Destino', field: 'destination' },
                { title: 'Him', field: 'him' },
                {
                    title: 'Cama',
                    field: 'bed',
                    lookup: { 1: 'Si', 2: 'No' },
                },
                {
                    title: 'Tipo de cama',
                    field: 'typeBed',
                    lookup: {
                        1: 'Cama critica',
                        2: 'Cama aguda',
                        3: 'Cama básica',
                        4: 'Cama med',
                        5: 'Cama qx'
                    }
                },
                { title: 'UGCC', field: 'ugcc' },
                { 
                    title: '>12 H', 
                    field: 'twelveHours', 
                    lookup: { 1: 'Si', 2: 'No' }
                }
            ],
        }
    }

    render() {

        const { patientStore } = this.props;

        return (
            <section className="sector-page">
                <MaterialTable
                    title={`Sector ${this.props.match.params.id}`}
                    options={{
                        headerStyle: {
                            backgroundColor: `${patientStore.sectors.state.sectors[this.props.match.params.id-1].color}`,
                            color: 'white',
                            fontSize: '1em'
                        },
                    }}
                    columns={this.state.columns}
                    data={patientStore.getPatientsBySector(this.props.match.params.id)}
                    editable={{
                        onRowAdd: newData => new Promise((resolve, reject) => {
                            setTimeout(() => {
                                resolve();
                                patientStore.add(this.props.match.params.id, newData);
                            }, 1000)
                        }),

                        onRowUpdate: (newData, oldData) => new Promise((resolve, reject) => {
                            setTimeout(() => {
                                resolve();
                                patientStore.update(newData, oldData);
                            }, 1000)
                        }),
                        
                        onRowDelete: oldData => new Promise((resolve, reject) => {
                            setTimeout(() => {   
                                resolve()
                                patientStore.delete(this.props.match.params.id, oldData);
                            }, 1000)
                        }),
                    }}  
                    onRowClick={(event, rowData, togglePanel) => alert(`go to patient ${rowData.id}`)}
                />
            </section>
        )
    }
}