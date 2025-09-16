import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerAppointmentsFormComponent } from './customer-appointments-form.component';

describe('CustomerAppointmentsFormComponent', () => {
  let component: CustomerAppointmentsFormComponent;
  let fixture: ComponentFixture<CustomerAppointmentsFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CustomerAppointmentsFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomerAppointmentsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
