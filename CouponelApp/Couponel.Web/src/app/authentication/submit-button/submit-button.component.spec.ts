import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SubmitButtonComponent2 } from './submit-button.component';

describe('SubmitButtonComponent', () => {
  let component: SubmitButtonComponent2;
  let fixture: ComponentFixture<SubmitButtonComponent2>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SubmitButtonComponent2 ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SubmitButtonComponent2);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
