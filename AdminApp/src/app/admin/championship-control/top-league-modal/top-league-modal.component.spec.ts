import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopLeagueModalComponent } from './top-league-modal.component';

describe('TopLeagueModalComponent', () => {
  let component: TopLeagueModalComponent;
  let fixture: ComponentFixture<TopLeagueModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TopLeagueModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TopLeagueModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
