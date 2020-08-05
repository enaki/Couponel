import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SavedVouchersComponent } from './saved-vouchers.component';

describe('SavedVouchersComponent', () => {
  let component: SavedVouchersComponent;
  let fixture: ComponentFixture<SavedVouchersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SavedVouchersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SavedVouchersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
