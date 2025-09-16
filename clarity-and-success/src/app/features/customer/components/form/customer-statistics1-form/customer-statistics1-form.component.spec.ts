import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerStatistics1FormComponent } from './customer-statistics1-form.component';

describe('CustomerStatistics1FormComponent', () => {
  let component: CustomerStatistics1FormComponent;
  let fixture: ComponentFixture<CustomerStatistics1FormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CustomerStatistics1FormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomerStatistics1FormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
