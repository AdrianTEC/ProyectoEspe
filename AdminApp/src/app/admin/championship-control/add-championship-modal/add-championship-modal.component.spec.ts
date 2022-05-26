import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddChampionshipModalComponent } from './add-championship-modal.component';

describe('AddChampionshipModalComponent', () => {
  let component: AddChampionshipModalComponent;
  let fixture: ComponentFixture<AddChampionshipModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddChampionshipModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddChampionshipModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
