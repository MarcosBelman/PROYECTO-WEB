//-----------------------------------------------------------------------------------------//
//CREACION DE LAS CAJAS DE TEXTO
var txtCodRastreo = document.querySelector('#codRastreo');


//-----------------------------------------------------------------------------------------//
//Metodo Get
//-----------------------------------------------------------------------------------------//
let btnEstados = document.querySelector('#btnEstados');

btnEstados.addEventListener('click', () =>{

    if(txtCodRastreo.value==null){
        alert('POR FAVOR INGRESE UN CÓDIGO DE RASTREO...');
        txtCodRastreo.focus();
    }else{
        mostrarEstados();
    }

});

async function mostrarEstados(){

    var codRastreo = parseInt(txtCodRastreo.value);
    //console.log('Entra al método mostrar');

    const {data, status} = await api.get('/estadosPaquete/historialEstados?page=1&codRastreo='+codRastreo, {
        
    });

    if(status !== 200){
        console.log('Detecta el error');
        lblError.innerHTML = "Hubo un error:" + res.status + data.message;     
        console.log(res.status + ' ' + data.message);
    }else{

        console.log(data);

        let dataSetEstados = [];

        data.resultados.forEach(element => {
            dataSetEstados.push(Object.values(element));
            console.log(element);
        });

        console.log({dataSetEstados});

        let tablaEstados = $('#estados-table').DataTable({
            data: dataSetEstados,
            columns: [
                {title: "idEstado"},
                {title: "codRastreo"},
                {title: "idPaquete"},
                {title: "numPieza"},
                {title: "fechaHora"},
                {title: "areaServicio"},
                {title: "estadoActual"},
            ],

        });

    }
}
