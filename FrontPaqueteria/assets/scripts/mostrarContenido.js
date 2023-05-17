var txtCodRastreo = document.querySelector('#codRastreo');
var txtIdPaquete = document.querySelector('#idPaquete');
var txtNumPiezas = document.querySelector('#numPieza');
var txtAreaServicio = document.querySelector('#areaServicio');
var txtEstadoActual = document.querySelector('#estadoActual');

btnMostrar = document.querySelector('#btnMostrar');
btnEliminar = document.querySelector('#btnEliminar');
btnModificar = document.querySelector('#btnModificar');

//-----------------------------------------------------------------------------------------//
//Metodo Post
//-----------------------------------------------------------------------------------------//

btnMostrar.addEventListener('click', () =>{
    guardarPaquete();
});

async function guardarPaquete(){
    
    var codRastreo = parseInt(txtCodRastreo.value);
    var idPaquete = txtIdPaquete.value;
    var numPiezas = parseInt(txtNumPiezas.value);
    var areaServicio = txtAreaServicio.value;
    var estadoActual = txtEstadoActual.value;

    const {data, status} = await api.post('/Paquete', {
        codRastreo: codRastreo,
        idPaquete: idPaquete,
        numPieza: numPiezas,
        areaServicio: areaServicio,
        estadoActual: estadoActual,
    });

    if(status !== 200){
        console.log('Error al guardar el registro');
    }else{
        console.log('Registro guardado con éxito');
    }

    /* const res = await fetch(URL2, {
        method: 'POST',
        headers: {
            'Content-Type' : 'application/json',
        },
        body : JSON.stringify({
            codRastreo: codRastreo,
            idPaquete: idPaquete,
            numPieza: numPiezas,
            areaServicio: areaServicio,
            estadoActual: estadoActual,
        }),
    }).catch(error => {error.log(error)}); */
}

//-----------------------------------------------------------------------------------------//
//Metodo Delete
//-----------------------------------------------------------------------------------------//

btnEliminar.addEventListener('click', () =>{
    EliminarPaquete();
});

async function EliminarPaquete(){
    
    var codRastreo = parseInt(txtCodRastreo.value);

    const {data, status} = await api.delete('/Paquete/'+codRastreo);/* , {
        //codRastreo: codRastreo,
    }); */

    if(status !== 200){
        console.log('Error al eliminar el registro');
    }else{
        console.log('Registro eliminado con éxito');
    }

    /* const res = await fetch(URL2, {
        method: 'POST',
        headers: {
            'Content-Type' : 'application/json',
        },
        body : JSON.stringify({
            codRastreo: codRastreo,
            idPaquete: idPaquete,
            numPieza: numPiezas,
            areaServicio: areaServicio,
            estadoActual: estadoActual,
        }),
    }).catch(error => {error.log(error)}); */
}


//-----------------------------------------------------------------------------------------//
//Metodo PUT
//-----------------------------------------------------------------------------------------//

btnModificar.addEventListener('click', () =>{
    ModificarPaquete();
});

async function ModificarPaquete(){
    var codRastreo = parseInt(txtCodRastreo.value);
    var idPaquete = txtIdPaquete.value;
    var numPiezas = parseInt(txtNumPiezas.value);
    var areaServicio = txtAreaServicio.value;
    var estadoActual = txtEstadoActual.value;

    const {data, status} = await api.put('/Paquete/'+codRastreo, {
        idPaquete: idPaquete,
        numPieza: numPiezas,
        areaServicio: areaServicio,
        estadoActual: estadoActual,
    }); 

    if(status !== 200){
        console.log('Error al modificar el registro');
    }else{
        console.log('Registro modificado con éxito');
    }

    /* const res = await fetch(URL2, {
        method: 'POST',
        headers: {
            'Content-Type' : 'application/json',
        },
        body : JSON.stringify({
            codRastreo: codRastreo,
            idPaquete: idPaquete,
            numPieza: numPiezas,
            areaServicio: areaServicio,
            estadoActual: estadoActual,
        }),
    }).catch(error => {error.log(error)}); */ 
}