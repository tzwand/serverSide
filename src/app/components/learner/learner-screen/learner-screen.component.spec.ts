import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LearnerScreenComponent } from './learner-screen.component';

describe('LearnerScreenComponent', () => {
  let component: LearnerScreenComponent;
  let fixture: ComponentFixture<LearnerScreenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LearnerScreenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LearnerScreenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
