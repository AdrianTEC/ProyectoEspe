import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyPortalComponent } from './my-portal.component';

describe('MyPortalComponent', () => {
  let component: MyPortalComponent;
  let fixture: ComponentFixture<MyPortalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyPortalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MyPortalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
