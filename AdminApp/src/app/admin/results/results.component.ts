import { Component, OnInit } from '@angular/core';
import { RestApiServiceService } from 'src/app/Services/rest-api-service.service';
import { SwalService } from 'src/app/Services/swal-service.service';
import * as XLSX from 'xlsx';

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.css'],
})
export class ResultsComponent implements OnInit {
  races: any[] = [];
  selectedRace: any = null;
  file: any = { name: null };

  dataSource: any[] = [];

  displayedColumns: string[] = [
    'CodigoXFIA',
    'Constructor',
    'Descalificado Calificación',
    ' Descalificado de Carrera',
    'Ganó a compañero de equipo',
    'Nombre',
    'Posicion Calificación',
    'Posición Carrera',
    'Precio',
    'Q1',
    'Q2',
    'Q3',
    'Sin Calificar Calificación',
    'Sin Calificar Carrera',
    'Tipo',
    'Vuelta más rápida',
  ];

  constructor(
    private restapi: RestApiServiceService,
    private swal: SwalService
  ) {}

  ngOnInit(): void {
    this.getRaces();
  }

  getRaces(): void {
    this.restapi.get_request('Races', null).subscribe((response) => {
      this.races = response;
    });
  }

  uploadFile(): void {
    const x = {};
    this.restapi.post_request('', x).subscribe > ((value: any) => {});
  }

  selectRace(race: any): void {
    this.selectedRace = race;
    console.log(race);
  }
  onFileSelected(event: any) {
    const file: File = event.target.files[0];

    if (file) {
      const extension = file.name.split('.').pop();
      if (extension != 'xlsx') {
        this.swal.showError(
          'Formato Incorrecto',
          'Por favor suba un archivo de extension xlsx'
        );
        return;
      }
      this.file = file;
      const jsonData = this.fileToJson(file);
    }
  }
  /**
   * Funcion asincrona tener cuidado porque onload se ejecuta despues
   * @param file
   */
  fileToJson(file: any): any {
    let workBook: any = null;
    let jsonData = null;
    const reader = new FileReader();
    reader.onload = () => {
      const data = reader.result;
      workBook = XLSX.read(data, { type: 'binary' });
      jsonData = workBook.SheetNames.reduce((initial: any, name: any) => {
        const sheet = workBook.Sheets[name];
        initial[name] = XLSX.utils.sheet_to_json(sheet);
        return initial;
      }, {});

      /**
      const dataKeys: any[] = Object.keys(fixedResult.data[0]);
      if (!this.compareArrays(dataKeys, this.displayedColumns))
        this.swal.showError(
          'Formato de titulos incorrecto',
          'Cambie el nombre de las cabeceras del excel a :  CodigoXFIA	Constructor	Nombre	Tipo	Precio	PosicionCalificacion	Q1	Q2	Q3	SinCalificarCalificacion	DescalificadoCalificacion	PosicionCarrera	VueltaMasRapida	GanoACompañeroEquipo	SinCalificarCarrera	DescalificadoCarrera'
        );
         */
      const fixedResult = { data: jsonData[Object.keys(jsonData)[0]] };
      console.log(fixedResult);
      this.dataSource = fixedResult.data;

      return fixedResult;
    };
    reader.readAsBinaryString(file);
  }

  x = {
    CodigoXFIA: 'XFIA-P-1099',
    Constructor: 'XFIA-C-0022',
    Nombre: ' Max Verstappen',
    Tipo: 'Piloto',
    Precio: 30,
    PosicionCalificacion: 3,
    Q1: 'Y',
    Q2: 'Y',
    Q3: 'Y',
    SinCalificarCalificacion: 'N',
    DescalificadoCalificacion: 'N',
    PosicionCarrera: 2,
    VueltaMasRapida: 'N',
    GanoACompaneroEquipo: 'Y',
    SinCalificarCarrera: 'N',
    DescalificadoCarrera: 'N',
  };

  renameFile(originalFile: any, newName: string) {
    return new File([originalFile], newName, {
      type: originalFile.type,
      lastModified: originalFile.lastModified,
    });
  }

  compareArrays(array1: any[], array2: any[]): boolean {
    return JSON.stringify(array1) === JSON.stringify(array2);
  }
}
