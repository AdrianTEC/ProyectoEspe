import { Component, HostListener, Inject, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import * as moment from 'moment';
import { Championship } from 'src/app/models/models';
import { RestApiServiceService } from 'src/app/Services/rest-api-service.service';
import { SwalService } from 'src/app/Services/swal-service.service';

@Component({
  selector: 'app-add-championship-modal',
  templateUrl: './add-championship-modal.component.html',
  styleUrls: ['./add-championship-modal.component.css'],
})
export class AddChampionshipModalComponent implements OnInit {
  showRequired: Boolean = false;

  @HostListener('document:keydown', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.code === 'KeyY') {
      this.submit({
        description: 'Campeonato Automatico2',
        startingDate: '12/8/2043',
        finishingDate: '5/12/2043',
        name: 'Campeonato Automatico2',
        startingTime: '09:57',
        finishingTime: '09:00',
        id: '',
      });
    }
  }
  constructor(
    private swal: SwalService,
    private restService: RestApiServiceService,
    public dialogRef: MatDialogRef<AddChampionshipModalComponent>,
    @Inject(MAT_DIALOG_DATA) public championships: Championship[]
  ) {}
  ngOnInit(): void {}

  validDate(date: string): boolean {
    const result = this.toDate(date).isValid();
    return result;
  }

  verifyFieldsAreFill(c: Championship): boolean {
    var isValid = (c.name !== "" && c.finishingDate !== "" && c.startingDate !== "" && c.finishingTime !== "Invalid date"
                  && c.startingTime !== "Invalid date")
    if (!isValid) {
      this.swal.showError(
        'Datos insuficientes',
        'Los datos suministrados son insuficientes. Por favor verifique de nuevo los valores ingresados e intente de nuevo'
      );
      this.showRequired = true;
      return false;
    }
    return true;
  }

  verifyChampionshipCollision(newChampionship: Championship): boolean {
    const newBegindate = this.toDate(newChampionship.startingDate);
    const newEnddate = this.toDate(newChampionship.finishingDate);

    for (let i = 0; i < this.championships.length; i++) {
      const c = this.championships[i];
      const beginDate = this.toDate(c.startingDate);
      const endDate = this.toDate(c.finishingDate);
      const inRange =
        (newBegindate.isSameOrAfter(beginDate) && newBegindate.isSameOrBefore(endDate)) ||
        (newEnddate.isSameOrAfter(beginDate) && newEnddate.isSameOrBefore(endDate)) ||
        (newBegindate.isBefore(beginDate) && newEnddate.isAfter(endDate));

      if (inRange) {
        this.swal.showError(
          'Fecha inválida',
          'Ya existe un campeonato en las fechas especificadas, porfavor corrija las fechas e intentelo de nuevo  ' +
            'El campeonato de choque corresponde a: ' +
            c.name
        );
        return false;
      }
    }
    return true;
  }

  verifyDateisAfterToday(c: Championship): boolean {
    const now = moment();
    const finish = this.toDate(c.finishingDate);
    const begin = this.toDate(c.startingDate);
    if (finish < begin || now > begin) {
      console.log('s');

      this.swal.showError(
        'Fecha inválida',
        'No se pueden crear carreras en el pasado o con fecha de finalización previa al inicio, por favor corrija las fechas introducidas e intente de nuevo'
      );
      return false;
    }
    return true;
  }

  verifyChampionshipIsValid(c: Championship): boolean {
    if (
      !this.verifyFieldsAreFill(c) ||
      !this.verifyDateisAfterToday(c) ||
      !this.verifyChampionshipCollision(c)
    ) {
      return false;
    }
    return true;
  }

  submit(championship: Championship) {
    championship.startingTime = moment(
      championship.startingTime,
      'h:mm a'
    ).format('h:mm a');
    championship.finishingTime = moment(
      championship.finishingTime,
      'h:mm a'
    ).format('h:mm a');
    if (!this.verifyChampionshipIsValid(championship)) return;
    championship.id = this.getRanHex(6);

    this.uploadChampionship(championship);
  }

  uploadChampionship(championship: Championship) {
    this.restService
      .post_request('Championships', championship)
      .subscribe((result) => {
        this.swal.showSuccess(
          'Campeonato creado con éxito',
          ' Se ha creado el campeonato de manera exitosa'
        );
        this.dialogRef.close(championship);
      });
  }

  toDate(date: string) {
    return moment(date, 'DD/MM/YYYY');
  }

  getRanHex(size: Number) {
    let result = [];
    let hexRef = [
      '0',
      '1',
      '2',
      '3',
      '4',
      '5',
      '6',
      '7',
      '8',
      '9',
      'A',
      'B',
      'C',
      'D',
      'E',
      'F',
    ];

    for (let n = 0; n < size; n++) {
      result.push(hexRef[Math.floor(Math.random() * 16)]);
    }
    return result.join('');
  }
}
