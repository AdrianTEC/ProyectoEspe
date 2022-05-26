import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CareersControlComponent } from './careers-control.component';

describe('CareersControlComponent', () => {
  let component: CareersControlComponent;
  let fixture: ComponentFixture<CareersControlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CareersControlComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CareersControlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
