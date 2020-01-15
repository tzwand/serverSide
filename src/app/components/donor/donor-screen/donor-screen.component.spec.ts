import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DonorScreenComponent } from './donor-screen.component';

describe('DonorScreenComponent', () => {
  let component: DonorScreenComponent;
  let fixture: ComponentFixture<DonorScreenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DonorScreenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DonorScreenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
