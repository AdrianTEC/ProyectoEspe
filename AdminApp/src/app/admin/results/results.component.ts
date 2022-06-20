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
    this.fileToJson(this.file);
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
      const fixedResult = {
        data: jsonData[Object.keys(jsonData)[0]],
      };

      this.dataSource = fixedResult.data;
      for (const item of this.dataSource) {
        item.carrera = this.selectedRace.id;
      }
      const formatedData: any = this.fixFormat(fixedResult);
      console.log(formatedData);

      this.restapi
        .post_request('RaceResults', formatedData)
        .subscribe((response: any) => {
          console.log(response);
        });

      return fixedResult;
    };
    reader.readAsBinaryString(file);
  }

  fixFormat(data: any): any {
    let response: any = { data: [] };
    data.data.forEach((dataRow: any) => {
      const x = {
        carrera: dataRow.carrera,
        codigoXFIA: dataRow.CodigoXFIA,
        constructor: dataRow.Constructor,
        nombre: dataRow.Nombre,
        tipo: dataRow.Tipo,
        precio: dataRow.Precio,
        posicionCalificacion:
          dataRow.PosicionCalificacion === 'N/A'
            ? -1
            : dataRow.PosicionCalificacion,
        q1: dataRow.Q1,
        q2: dataRow.Q2,
        q3: dataRow.Q3,
        sinCalificarCalificacion: dataRow.SinCalificarCalificacion,
        descalificadoCalificacion: dataRow.DescalificadoCalificacion,
        posicionCarrera:
          dataRow.PosicionCarrera === 'N/A' ? -1 : dataRow.PosicionCarrera,
        vueltaMasRapida: dataRow.VueltaMasRapida,
        ganoACompaneroEquipo: dataRow.GanoACompaneroEquipo,
        sinCalificarCarrera: dataRow.SinCalificarCarrera,
        descalificadoCarrera: dataRow.DescalificadoCarrera,
      };
      response.data.push(x);
    });

    return response;
  }

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
