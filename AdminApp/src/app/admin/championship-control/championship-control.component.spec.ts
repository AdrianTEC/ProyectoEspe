import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChampionshipControlComponent } from './championship-control.component';

describe('ChampionshipControlComponent', () => {
  let component: ChampionshipControlComponent;
  let fixture: ComponentFixture<ChampionshipControlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChampionshipControlComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChampionshipControlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
