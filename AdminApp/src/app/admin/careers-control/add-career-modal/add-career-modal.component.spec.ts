import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCareerModalComponent } from './add-career-modal.component';

describe('AddCareerModalComponent', () => {
  let component: AddCareerModalComponent;
  let fixture: ComponentFixture<AddCareerModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddCareerModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCareerModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
